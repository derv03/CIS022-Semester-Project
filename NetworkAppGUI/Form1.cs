using System;
using System.Linq.Expressions;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace NetworkAppGUI
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            txtAddr.Focus();
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async Task Nslookup()
        {

            try
            {
                IPHostEntry hostEntry = await Dns.GetHostEntryAsync(txtAddr.Text);
                if (hostEntry != null)
                {
                    lsbNslookup.Items.Add($"Host: {txtAddr.Text}");
                    foreach (IPAddress ip in hostEntry.AddressList)
                    {
                        lsbNslookup.Items.Add($" - {ip}");
                    }
                    lsbNslookup.Items.Add($"Hostname: {hostEntry.HostName}");

                }

            }
            catch
            {
                lsbNslookup.Items.Add($"NSLookup failed.");

            }
        }


        private async Task Ping()
        {
            Ping pingsender = new Ping();
            try
            {
                PingReply reply = await pingsender.SendPingAsync(txtAddr.Text);
                if (reply.Status == IPStatus.Success)
                {
                    lsbPing.Items.Add($"Ping was successful");
                    lsbPing.Items.Add($"Address: {reply.Address}");
                    lsbPing.Items.Add($"roundtrip was {reply.RoundtripTime} ms");
                    lsbPing.Items.Add($"TTL was {reply.Options.Ttl} seconds");
                }
                else
                {
                    lsbPing.Items.Add("Ping Failed.");

                }
            }

            catch (Exception ex)
            {

            }
        }

        private async Task TraceRoute()
        {
            string ip = txtAddr.Text;
            Ping pingSender = new Ping();
            PingOptions pingOptions = new PingOptions(1, true);
            byte[] buffer = new byte[32];
            int timeout = 3000; // ms
            int maxHops = 30;

            lsbTrace.Items.Add($"Tracing route to {ip} with a maximum of {maxHops} hops.");

            for (int ttl = 1; ttl <= maxHops; ttl++)
            {
                pingOptions.Ttl = ttl;

                try
                {
                    PingReply reply = await pingSender.SendPingAsync(ip, timeout, buffer, pingOptions);
                    if (reply.Status == IPStatus.Success || reply.Status == IPStatus.TtlExpired)
                    {
                        lsbTrace.Items.Add($"{ttl}\t{reply.Address}\tTime: {reply.RoundtripTime}ms");
                        if (reply.Status == IPStatus.Success)
                        {
                            lsbTrace.Items.Add($"Trace complete. Destination reached.");
                            break;
                        }

                    }
                    else
                    {
                        lsbTrace.Items.Add($"{ttl}\t*");
                    }
                }
                catch (Exception ex) 
                {
                    lsbTrace.Items.Add($"Error: {ex.Message}");
                }

            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtAddr.Clear();
            lsbPing.Items.Clear();
            lsbNslookup.Items.Clear();
            lsbTrace.Items.Clear();
            lsbPort.Items.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnStart(object sender, EventArgs e)
        {
            TraceRoute();
            await Nslookup();
            await Ping();
            PortCheck(); // comment out if you want "eco mode"
        }

        private void lsbTrace_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async Task PortCheck()      // checks for open ports
        {                                   // this function is cpu-heavy.
            int startPort = 80;              // need to implement choices of ports
            int endPort = 443;

            string ipAddress = txtAddr.Text;

            

            List<int> openPorts = await ScanPortsAsync(ipAddress, startPort, endPort);

            if (openPorts.Count > 0)
            {
                foreach (int port in openPorts)
                {
                    lsbPort.Items.Add($"Port {port} is open.");
                }
            }
            else
            {
                lsbPort.Items.Add("No open ports found in the specified range.");
            }
        }

        private async Task<List<int>> ScanPortsAsync(string ipAddress, int startPort, int endPort)
        {
            TcpClient Scan = new TcpClient();
            List<int> openPorts = new List<int>();

            List<Task> tasks = new List<Task>();
            for (int port = startPort; port <= endPort; port++)
            {
                int currentPort = port;
                tasks.Add(Task.Run(async () =>      // async to allow waiting until all ports are checked
                {
                    if (await IsPortOpen(ipAddress, currentPort)) 
                    {
                        lock (openPorts)
                        {
                            openPorts.Add(currentPort);
                        }
                    }
                }));
            }

            await Task.WhenAll(tasks); //waits until all ports have been checked to display them
            return openPorts;
        }

        private async Task<bool> IsPortOpen(string ipAddress, int port, int timeout = 200)
        {
            try
            {
                using (TcpClient tcpClient = new TcpClient())
                {
                    var task = tcpClient.ConnectAsync(ipAddress, port);
                    var result = await Task.WhenAny(task, Task.Delay(timeout));
                    return result == task && tcpClient.Connected;
                }
            }
            catch
            {
                return false;
            }
        }



}
}
