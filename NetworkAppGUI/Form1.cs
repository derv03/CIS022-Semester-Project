using System;
using System.Linq.Expressions;
using System.Net;
using System.Net.NetworkInformation;

namespace NetworkAppGUI
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            txtAddr.Focus();
        }

        private string IP()
        {
            //return "dsgallery.us";
            return txtAddr.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public async Task Nslookup()
        {

            try
            {
                IPHostEntry hostEntry = await Dns.GetHostEntryAsync(IP());
                if (hostEntry != null)
                {
                    lsbNslookup.Items.Add($"Host: {IP()}");
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


        public async Task Ping()
        {
            Ping pingsender = new Ping();
            try
            {
                PingReply reply = await pingsender.SendPingAsync(IP());
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
                lsbPing.Items.Add($"Error: {ex.Message}");

            }
        }

        public async Task TraceRoute()
        {
            string ip = IP();
            Ping pingSender = new Ping();
            PingOptions pingOptions = new PingOptions(1, true);
            byte[] buffer = new byte[32];
            int timeout = 3000; // ms
            int maxHops = 30;

            lsbTrace.Items.Add($"Tracing route to {ip} with a maximum of 30 hops.");

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
                        lsbTrace.Items.Add($"{ttl}\tRequest timed out.");
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
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnPing_Click(object sender, EventArgs e)
        {
            TraceRoute();
            await Nslookup();
            await Ping();
        }

        private void lsbTrace_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
