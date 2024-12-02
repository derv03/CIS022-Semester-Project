namespace NetworkAppGUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtAddr = new TextBox();
            lsbPing = new ListBox();
            btnClear = new Button();
            btnPing = new Button();
            lsbNslookup = new ListBox();
            lsbTrace = new ListBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            lsbPort = new ListBox();
            SuspendLayout();
            // 
            // txtAddr
            // 
            txtAddr.Location = new Point(29, 108);
            txtAddr.Name = "txtAddr";
            txtAddr.Size = new Size(150, 23);
            txtAddr.TabIndex = 0;
            txtAddr.Text = "dsgallery.us";
            txtAddr.TextAlign = HorizontalAlignment.Center;
            txtAddr.TextChanged += textBox1_TextChanged;
            // 
            // lsbPing
            // 
            lsbPing.FormattingEnabled = true;
            lsbPing.ItemHeight = 15;
            lsbPing.Location = new Point(242, 52);
            lsbPing.Name = "lsbPing";
            lsbPing.Size = new Size(271, 64);
            lsbPing.TabIndex = 2;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(29, 188);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 34);
            btnClear.TabIndex = 3;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnPing
            // 
            btnPing.Location = new Point(104, 188);
            btnPing.Name = "btnPing";
            btnPing.Size = new Size(75, 34);
            btnPing.TabIndex = 4;
            btnPing.Text = "Start";
            btnPing.UseVisualStyleBackColor = true;
            btnPing.Click += btnStart;
            // 
            // lsbNslookup
            // 
            lsbNslookup.FormattingEnabled = true;
            lsbNslookup.ItemHeight = 15;
            lsbNslookup.Location = new Point(242, 157);
            lsbNslookup.Name = "lsbNslookup";
            lsbNslookup.Size = new Size(271, 79);
            lsbNslookup.TabIndex = 5;
            // 
            // lsbTrace
            // 
            lsbTrace.FormattingEnabled = true;
            lsbTrace.ItemHeight = 15;
            lsbTrace.Location = new Point(519, 52);
            lsbTrace.Name = "lsbTrace";
            lsbTrace.Size = new Size(372, 289);
            lsbTrace.TabIndex = 6;
            lsbTrace.SelectedIndexChanged += lsbTrace_SelectedIndexChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(29, 79);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(150, 23);
            textBox1.TabIndex = 7;
            textBox1.Text = "Enter IP Address or Host";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(306, 128);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(150, 23);
            textBox2.TabIndex = 8;
            textBox2.Text = "NSLookup";
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(306, 23);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(150, 23);
            textBox3.TabIndex = 9;
            textBox3.Text = "Ping";
            textBox3.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(620, 23);
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.Size = new Size(150, 23);
            textBox4.TabIndex = 10;
            textBox4.Text = "Trace Route";
            textBox4.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(306, 242);
            textBox5.Name = "textBox5";
            textBox5.ReadOnly = true;
            textBox5.Size = new Size(150, 23);
            textBox5.TabIndex = 11;
            textBox5.Text = "Ports";
            textBox5.TextAlign = HorizontalAlignment.Center;
            // 
            // lsbPort
            // 
            lsbPort.FormattingEnabled = true;
            lsbPort.ItemHeight = 15;
            lsbPort.Location = new Point(242, 271);
            lsbPort.Name = "lsbPort";
            lsbPort.Size = new Size(271, 79);
            lsbPort.TabIndex = 12;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(926, 407);
            Controls.Add(lsbPort);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(lsbTrace);
            Controls.Add(lsbNslookup);
            Controls.Add(btnPing);
            Controls.Add(btnClear);
            Controls.Add(lsbPing);
            Controls.Add(txtAddr);
            Name = "Form1";
            Text = "NetWork";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtAddr;
        private ListBox lsbPing;
        private Button btnClear;
        private Button btnPing;
        private ListBox lsbNslookup;
        private ListBox lsbTrace;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private ListBox lsbPort;
    }
}
