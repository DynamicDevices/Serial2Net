using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using PortListener.Core.Utilities;

namespace Serial2Net
{
    public partial class MainForm : Form
    {
        private delegate void LogHandler(string text);

        private TcpClient _connection;
        private SerialPort _port;
        private NetworkStream _stream;
        private byte[] _tcpdata = new byte[1024];

        public MainForm()
        {
            InitializeComponent();

            string[] arrPorts = SerialPort.GetPortNames();
            comboBoxSerialPort.Items.Clear();
            foreach (var port in arrPorts)
                comboBoxSerialPort.Items.Add(port);
            if (arrPorts.Length > 0)
                comboBoxSerialPort.SelectedIndex = 0;

            comboBoxBaudRate.SelectedIndex = 4;
        }

        private void buttonStartStop_Click(object sender, EventArgs e)
        {
            if(buttonStartStop.Text == "Start")
            {
                try
                {
                    _port = new SerialPort((string)comboBoxSerialPort.SelectedItem, int.Parse((string)comboBoxBaudRate.SelectedItem), Parity.None, 8, StopBits.One);
                    _port.DataReceived += new SerialDataReceivedEventHandler(_port_DataReceived);
                    _port.ReceivedBytesThreshold = 8;                    
                    _port.Open();
                } catch(Exception ex)
                {
                    MessageBox.Show("Couldn't open port " + (string) comboBoxSerialPort.SelectedItem);
                    return;
                }

                try
                {
                    _connection = new TcpClient(textBoxIPAddress.Text, int.Parse(textBoxTargetPort.Text));
                    _stream = _connection.GetStream();
                    byte[] tcpdata = new byte[1024];
                    _stream.BeginRead(tcpdata, 0, tcpdata.Length, new AsyncCallback(TcpReader), null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Couldn't connect to " + textBoxTargetPort.Text + ":" + textBoxIPAddress.Text);
                    return;
                }
                buttonStartStop.Text = "Stop";
            }
            else
            {
                if(_port.IsOpen)
                    _port.Close();

                if(_connection.Connected)
                    _connection.Close();

                buttonStartStop.Text = "Start";               
            }              
        }

        void _port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int rxlen = _port.BytesToRead;
            byte[] data = new byte[rxlen];
            _port.Read(data, 0, rxlen);

            Log("S->N: " + StringHelper.ToHexString(data, 0, rxlen));

            _stream.Write(data, 0, rxlen);
        }

        void TcpReader(IAsyncResult ar)
        {
            int rxbytes = _stream.EndRead(ar);

            if (rxbytes > 0)
            {
                _port.Write(_tcpdata, 0, rxbytes);
                Log("N->S: " + StringHelper.ToHexString(_tcpdata, 0, rxbytes));
            }

            if (rxbytes >= 0)
            {
                _stream.BeginRead(_tcpdata, 0, _tcpdata.Length, new AsyncCallback(TcpReader), null);
            }
        }

        void Log(string text)
        {
            if(InvokeRequired)
            {
                this.Invoke(new LogHandler(Log), new object[] {text});
                return;
            }
            textBoxLog.Text += text + "\r\n";
            textBoxLog.SelectionStart = textBoxLog.Text.Length - 1;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.dynamicdevices.co.uk");
        }
    }
}
