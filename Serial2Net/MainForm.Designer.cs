namespace Serial2Net
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonStartStop = new System.Windows.Forms.Button();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.checkBoxReconnect = new System.Windows.Forms.CheckBox();
            this.checkBoxDisplayHex = new System.Windows.Forms.CheckBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.groupBoxSerialPort = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxBaudRate = new System.Windows.Forms.ComboBox();
            this.labelSerialPort = new System.Windows.Forms.Label();
            this.comboBoxSerialPort = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonClient = new System.Windows.Forms.RadioButton();
            this.radioButtonServer = new System.Windows.Forms.RadioButton();
            this.textBoxTargetPort = new System.Windows.Forms.TextBox();
            this.labelTargetPort = new System.Windows.Forms.Label();
            this.textBoxIPAddress = new System.Windows.Forms.TextBox();
            this.labelTargetIP = new System.Windows.Forms.Label();
            this.groupBoxSerialPort.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonStartStop
            // 
            this.buttonStartStop.Location = new System.Drawing.Point(502, 54);
            this.buttonStartStop.Name = "buttonStartStop";
            this.buttonStartStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStartStop.TabIndex = 4;
            this.buttonStartStop.Text = "Start";
            this.buttonStartStop.UseVisualStyleBackColor = true;
            this.buttonStartStop.Click += new System.EventHandler(this.ButtonStartStopClick);
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(12, 127);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(800, 311);
            this.textBoxLog.TabIndex = 9;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(704, 457);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(108, 13);
            this.linkLabel1.TabIndex = 10;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Dynamic Devices Ltd";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1LinkClicked);
            // 
            // checkBoxReconnect
            // 
            this.checkBoxReconnect.AutoSize = true;
            this.checkBoxReconnect.Checked = true;
            this.checkBoxReconnect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxReconnect.Location = new System.Drawing.Point(623, 45);
            this.checkBoxReconnect.Name = "checkBoxReconnect";
            this.checkBoxReconnect.Size = new System.Drawing.Size(104, 17);
            this.checkBoxReconnect.TabIndex = 5;
            this.checkBoxReconnect.Text = "Auto Reconnect";
            this.checkBoxReconnect.UseVisualStyleBackColor = true;
            this.checkBoxReconnect.CheckedChanged += new System.EventHandler(this.CheckBoxReconnectCheckedChanged);
            // 
            // checkBoxDisplayHex
            // 
            this.checkBoxDisplayHex.AutoSize = true;
            this.checkBoxDisplayHex.Location = new System.Drawing.Point(623, 68);
            this.checkBoxDisplayHex.Name = "checkBoxDisplayHex";
            this.checkBoxDisplayHex.Size = new System.Drawing.Size(82, 17);
            this.checkBoxDisplayHex.TabIndex = 11;
            this.checkBoxDisplayHex.Text = "Display Hex";
            this.checkBoxDisplayHex.UseVisualStyleBackColor = true;
            this.checkBoxDisplayHex.CheckedChanged += new System.EventHandler(this.CheckBoxDisplayHexCheckedChanged);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(12, 444);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 12;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.ButtonClearClick);
            // 
            // groupBoxSerialPort
            // 
            this.groupBoxSerialPort.Controls.Add(this.label1);
            this.groupBoxSerialPort.Controls.Add(this.comboBoxBaudRate);
            this.groupBoxSerialPort.Controls.Add(this.labelSerialPort);
            this.groupBoxSerialPort.Controls.Add(this.comboBoxSerialPort);
            this.groupBoxSerialPort.Location = new System.Drawing.Point(12, 12);
            this.groupBoxSerialPort.Name = "groupBoxSerialPort";
            this.groupBoxSerialPort.Size = new System.Drawing.Size(200, 109);
            this.groupBoxSerialPort.TabIndex = 13;
            this.groupBoxSerialPort.TabStop = false;
            this.groupBoxSerialPort.Text = "Serial Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Baud Rate";
            // 
            // comboBoxBaudRate
            // 
            this.comboBoxBaudRate.FormattingEnabled = true;
            this.comboBoxBaudRate.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.comboBoxBaudRate.Location = new System.Drawing.Point(84, 61);
            this.comboBoxBaudRate.Name = "comboBoxBaudRate";
            this.comboBoxBaudRate.Size = new System.Drawing.Size(100, 21);
            this.comboBoxBaudRate.TabIndex = 11;
            // 
            // labelSerialPort
            // 
            this.labelSerialPort.AutoSize = true;
            this.labelSerialPort.Location = new System.Drawing.Point(6, 37);
            this.labelSerialPort.Name = "labelSerialPort";
            this.labelSerialPort.Size = new System.Drawing.Size(26, 13);
            this.labelSerialPort.TabIndex = 10;
            this.labelSerialPort.Text = "Port";
            // 
            // comboBoxSerialPort
            // 
            this.comboBoxSerialPort.FormattingEnabled = true;
            this.comboBoxSerialPort.Location = new System.Drawing.Point(84, 34);
            this.comboBoxSerialPort.Name = "comboBoxSerialPort";
            this.comboBoxSerialPort.Size = new System.Drawing.Size(100, 21);
            this.comboBoxSerialPort.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxTargetPort);
            this.groupBox1.Controls.Add(this.labelTargetPort);
            this.groupBox1.Controls.Add(this.textBoxIPAddress);
            this.groupBox1.Controls.Add(this.labelTargetIP);
            this.groupBox1.Controls.Add(this.radioButtonServer);
            this.groupBox1.Controls.Add(this.radioButtonClient);
            this.groupBox1.Location = new System.Drawing.Point(229, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(246, 109);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TCP/IP";
            // 
            // radioButtonClient
            // 
            this.radioButtonClient.AutoSize = true;
            this.radioButtonClient.Location = new System.Drawing.Point(17, 19);
            this.radioButtonClient.Name = "radioButtonClient";
            this.radioButtonClient.Size = new System.Drawing.Size(51, 17);
            this.radioButtonClient.TabIndex = 0;
            this.radioButtonClient.TabStop = true;
            this.radioButtonClient.Text = "Client";
            this.radioButtonClient.UseVisualStyleBackColor = true;
            // 
            // radioButtonServer
            // 
            this.radioButtonServer.AutoSize = true;
            this.radioButtonServer.Location = new System.Drawing.Point(74, 19);
            this.radioButtonServer.Name = "radioButtonServer";
            this.radioButtonServer.Size = new System.Drawing.Size(56, 17);
            this.radioButtonServer.TabIndex = 1;
            this.radioButtonServer.TabStop = true;
            this.radioButtonServer.Text = "Server";
            this.radioButtonServer.UseVisualStyleBackColor = true;
            this.radioButtonServer.CheckedChanged += new System.EventHandler(this.RadioButtonServerCheckedChanged);
            // 
            // textBoxTargetPort
            // 
            this.textBoxTargetPort.Location = new System.Drawing.Point(130, 75);
            this.textBoxTargetPort.Name = "textBoxTargetPort";
            this.textBoxTargetPort.Size = new System.Drawing.Size(100, 20);
            this.textBoxTargetPort.TabIndex = 7;
            this.textBoxTargetPort.Text = "10446";
            // 
            // labelTargetPort
            // 
            this.labelTargetPort.AutoSize = true;
            this.labelTargetPort.Location = new System.Drawing.Point(14, 75);
            this.labelTargetPort.Name = "labelTargetPort";
            this.labelTargetPort.Size = new System.Drawing.Size(26, 13);
            this.labelTargetPort.TabIndex = 8;
            this.labelTargetPort.Text = "Port";
            // 
            // textBoxIPAddress
            // 
            this.textBoxIPAddress.Location = new System.Drawing.Point(130, 45);
            this.textBoxIPAddress.Name = "textBoxIPAddress";
            this.textBoxIPAddress.Size = new System.Drawing.Size(100, 20);
            this.textBoxIPAddress.TabIndex = 5;
            this.textBoxIPAddress.Text = "127.0.0.1";
            // 
            // labelTargetIP
            // 
            this.labelTargetIP.AutoSize = true;
            this.labelTargetIP.Location = new System.Drawing.Point(14, 48);
            this.labelTargetIP.Name = "labelTargetIP";
            this.labelTargetIP.Size = new System.Drawing.Size(91, 13);
            this.labelTargetIP.TabIndex = 6;
            this.labelTargetIP.Text = "Server IP address";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 479);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxSerialPort);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.checkBoxDisplayHex);
            this.Controls.Add(this.checkBoxReconnect);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.buttonStartStop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Serial2Net";
            this.groupBoxSerialPort.ResumeLayout(false);
            this.groupBoxSerialPort.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStartStop;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.CheckBox checkBoxReconnect;
        private System.Windows.Forms.CheckBox checkBoxDisplayHex;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.GroupBox groupBoxSerialPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxBaudRate;
        private System.Windows.Forms.Label labelSerialPort;
        private System.Windows.Forms.ComboBox comboBoxSerialPort;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxTargetPort;
        private System.Windows.Forms.Label labelTargetPort;
        private System.Windows.Forms.TextBox textBoxIPAddress;
        private System.Windows.Forms.Label labelTargetIP;
        private System.Windows.Forms.RadioButton radioButtonServer;
        private System.Windows.Forms.RadioButton radioButtonClient;
    }
}

