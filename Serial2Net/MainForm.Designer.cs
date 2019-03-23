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
            this.textBoxReadOnlyPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxTargetPort = new System.Windows.Forms.TextBox();
            this.labelTargetPort = new System.Windows.Forms.Label();
            this.textBoxIPAddress = new System.Windows.Forms.TextBox();
            this.labelTargetIP = new System.Windows.Forms.Label();
            this.radioButtonServer = new System.Windows.Forms.RadioButton();
            this.radioButtonClient = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.groupBoxSerialPort.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonStartStop
            // 
            this.buttonStartStop.Location = new System.Drawing.Point(497, 24);
            this.buttonStartStop.Name = "buttonStartStop";
            this.buttonStartStop.Size = new System.Drawing.Size(75, 21);
            this.buttonStartStop.TabIndex = 4;
            this.buttonStartStop.Text = "Start";
            this.buttonStartStop.UseVisualStyleBackColor = true;
            this.buttonStartStop.Click += new System.EventHandler(this.ButtonStartStopClick);
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(12, 167);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(593, 237);
            this.textBoxLog.TabIndex = 9;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.Silver;
            this.linkLabel1.Location = new System.Drawing.Point(402, 421);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(119, 12);
            this.linkLabel1.TabIndex = 10;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Dynamic Devices Ltd";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1LinkClicked);
            // 
            // checkBoxReconnect
            // 
            this.checkBoxReconnect.AutoSize = true;
            this.checkBoxReconnect.Location = new System.Drawing.Point(497, 58);
            this.checkBoxReconnect.Name = "checkBoxReconnect";
            this.checkBoxReconnect.Size = new System.Drawing.Size(108, 16);
            this.checkBoxReconnect.TabIndex = 5;
            this.checkBoxReconnect.Text = "Auto Reconnect";
            this.checkBoxReconnect.UseVisualStyleBackColor = true;
            this.checkBoxReconnect.CheckedChanged += new System.EventHandler(this.CheckBoxReconnectCheckedChanged);
            // 
            // checkBoxDisplayHex
            // 
            this.checkBoxDisplayHex.AutoSize = true;
            this.checkBoxDisplayHex.Location = new System.Drawing.Point(497, 82);
            this.checkBoxDisplayHex.Name = "checkBoxDisplayHex";
            this.checkBoxDisplayHex.Size = new System.Drawing.Size(90, 16);
            this.checkBoxDisplayHex.TabIndex = 11;
            this.checkBoxDisplayHex.Text = "Display Hex";
            this.checkBoxDisplayHex.UseVisualStyleBackColor = true;
            this.checkBoxDisplayHex.CheckedChanged += new System.EventHandler(this.CheckBoxDisplayHexCheckedChanged);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(12, 410);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 21);
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
            this.groupBoxSerialPort.Location = new System.Drawing.Point(12, 11);
            this.groupBoxSerialPort.Name = "groupBoxSerialPort";
            this.groupBoxSerialPort.Size = new System.Drawing.Size(200, 135);
            this.groupBoxSerialPort.TabIndex = 13;
            this.groupBoxSerialPort.TabStop = false;
            this.groupBoxSerialPort.Text = "Serial Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
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
            this.comboBoxBaudRate.Location = new System.Drawing.Point(84, 56);
            this.comboBoxBaudRate.Name = "comboBoxBaudRate";
            this.comboBoxBaudRate.Size = new System.Drawing.Size(100, 20);
            this.comboBoxBaudRate.TabIndex = 11;
            // 
            // labelSerialPort
            // 
            this.labelSerialPort.AutoSize = true;
            this.labelSerialPort.Location = new System.Drawing.Point(6, 34);
            this.labelSerialPort.Name = "labelSerialPort";
            this.labelSerialPort.Size = new System.Drawing.Size(29, 12);
            this.labelSerialPort.TabIndex = 10;
            this.labelSerialPort.Text = "Port";
            // 
            // comboBoxSerialPort
            // 
            this.comboBoxSerialPort.FormattingEnabled = true;
            this.comboBoxSerialPort.Location = new System.Drawing.Point(84, 31);
            this.comboBoxSerialPort.Name = "comboBoxSerialPort";
            this.comboBoxSerialPort.Size = new System.Drawing.Size(100, 20);
            this.comboBoxSerialPort.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxReadOnlyPort);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxTargetPort);
            this.groupBox1.Controls.Add(this.labelTargetPort);
            this.groupBox1.Controls.Add(this.textBoxIPAddress);
            this.groupBox1.Controls.Add(this.labelTargetIP);
            this.groupBox1.Controls.Add(this.radioButtonServer);
            this.groupBox1.Controls.Add(this.radioButtonClient);
            this.groupBox1.Location = new System.Drawing.Point(229, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(246, 135);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TCP/IP";
            // 
            // textBoxReadOnlyPort
            // 
            this.textBoxReadOnlyPort.Location = new System.Drawing.Point(130, 96);
            this.textBoxReadOnlyPort.Name = "textBoxReadOnlyPort";
            this.textBoxReadOnlyPort.Size = new System.Drawing.Size(100, 21);
            this.textBoxReadOnlyPort.TabIndex = 7;
            this.textBoxReadOnlyPort.Text = "6666";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "Read-olny Port";
            // 
            // textBoxTargetPort
            // 
            this.textBoxTargetPort.Location = new System.Drawing.Point(130, 69);
            this.textBoxTargetPort.Name = "textBoxTargetPort";
            this.textBoxTargetPort.Size = new System.Drawing.Size(100, 21);
            this.textBoxTargetPort.TabIndex = 7;
            this.textBoxTargetPort.Text = "6667";
            // 
            // labelTargetPort
            // 
            this.labelTargetPort.AutoSize = true;
            this.labelTargetPort.Location = new System.Drawing.Point(15, 72);
            this.labelTargetPort.Name = "labelTargetPort";
            this.labelTargetPort.Size = new System.Drawing.Size(29, 12);
            this.labelTargetPort.TabIndex = 8;
            this.labelTargetPort.Text = "Port";
            // 
            // textBoxIPAddress
            // 
            this.textBoxIPAddress.Location = new System.Drawing.Point(130, 42);
            this.textBoxIPAddress.Name = "textBoxIPAddress";
            this.textBoxIPAddress.Size = new System.Drawing.Size(100, 21);
            this.textBoxIPAddress.TabIndex = 5;
            this.textBoxIPAddress.Text = "127.0.0.1";
            // 
            // labelTargetIP
            // 
            this.labelTargetIP.AutoSize = true;
            this.labelTargetIP.Location = new System.Drawing.Point(14, 44);
            this.labelTargetIP.Name = "labelTargetIP";
            this.labelTargetIP.Size = new System.Drawing.Size(107, 12);
            this.labelTargetIP.TabIndex = 6;
            this.labelTargetIP.Text = "Server IP address";
            // 
            // radioButtonServer
            // 
            this.radioButtonServer.AutoSize = true;
            this.radioButtonServer.Checked = true;
            this.radioButtonServer.Location = new System.Drawing.Point(74, 18);
            this.radioButtonServer.Name = "radioButtonServer";
            this.radioButtonServer.Size = new System.Drawing.Size(59, 16);
            this.radioButtonServer.TabIndex = 1;
            this.radioButtonServer.TabStop = true;
            this.radioButtonServer.Text = "Server";
            this.radioButtonServer.UseVisualStyleBackColor = true;
            this.radioButtonServer.CheckedChanged += new System.EventHandler(this.radioButtonServer_CheckedChanged);
            // 
            // radioButtonClient
            // 
            this.radioButtonClient.AutoSize = true;
            this.radioButtonClient.Location = new System.Drawing.Point(17, 18);
            this.radioButtonClient.Name = "radioButtonClient";
            this.radioButtonClient.Size = new System.Drawing.Size(59, 16);
            this.radioButtonClient.TabIndex = 0;
            this.radioButtonClient.Text = "Client";
            this.radioButtonClient.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(349, 421);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "Author:";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.LinkColor = System.Drawing.Color.Silver;
            this.linkLabel2.Location = new System.Drawing.Point(528, 421);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(59, 12);
            this.linkLabel2.TabIndex = 16;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "YeLincoln";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 442);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.label3);
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
        private System.Windows.Forms.TextBox textBoxReadOnlyPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkLabel2;
    }
}

