using System;
using System.Diagnostics;
using System.IO.Ports;
using System.Windows.Forms;
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
        private readonly byte[] _tcpdata = new byte[1024];

        private bool _bAutoReconnect;
        private bool _bDisplayHex;
        private bool _bIsRunning;

        public MainForm()
        {
            InitializeComponent();

            Text += " v" + System.Reflection.Assembly.GetEntryAssembly().GetName().Version;

            var arrPorts = SerialPort.GetPortNames();
            comboBoxSerialPort.Items.Clear();
            foreach (var port in arrPorts)
                comboBoxSerialPort.Items.Add(port);
            if (arrPorts.Length > 0)
                comboBoxSerialPort.SelectedIndex = 0;

            comboBoxBaudRate.SelectedIndex = 7;

            _bAutoReconnect = checkBoxReconnect.Checked;
            _bDisplayHex = checkBoxDisplayHex.Checked;
        }

        private void ButtonStartStopClick(object sender, EventArgs e)
        {
            if (!_bIsRunning)
            {                
                try
                {
                    _port = new SerialPort((string)comboBoxSerialPort.SelectedItem, int.Parse((string)comboBoxBaudRate.SelectedItem), Parity.None, 8, StopBits.One);
                    _port.DataReceived += PortDataReceived;
                    _port.ReceivedBytesThreshold = 1;                    
                    _port.Open();
                } catch(Exception)
                {
                    MessageBox.Show(@"Couldn't open port " + (string) comboBoxSerialPort.SelectedItem);
                    return;
                }

                try
                {
                    Log("Connecting to " + textBoxIPAddress.Text + ":" + textBoxTargetPort.Text);

                    _connection = new TcpClient();
                    _connection.BeginConnect(textBoxIPAddress.Text, int.Parse(textBoxTargetPort.Text), TcpConnected, null);
                }
                catch (Exception)
                {
                    Log("Couldn't connect");

                    _port.DataReceived -= PortDataReceived;
                    _port.Close();

                    return;
                }
                buttonStartStop.Text = @"Stop";
                _bIsRunning = true;
            }
            else
            {
                if(_port.IsOpen)
                    _port.Close();

                if(_connection.Connected)
                    _connection.Close();

                buttonStartStop.Text = @"Start";
                _bIsRunning = false;
            }              
        }

        void TcpConnected(IAsyncResult result)
        {
            try
            {
                _connection.EndConnect(result);

                _stream = _connection.GetStream();

                Log("Connected");

                var tcpdata = new byte[1024];
                _stream.BeginRead(tcpdata, 0, tcpdata.Length, TcpReader, null);

            } catch(Exception e)
            {
                Log("Couldn't connect: " + e.Message);

                if (_bAutoReconnect && _bIsRunning)
                {
                    Log("Connecting to " + textBoxIPAddress.Text + ":" + textBoxTargetPort.Text);
                    _connection.BeginConnect(textBoxIPAddress.Text, int.Parse(textBoxTargetPort.Text), TcpConnected, null);
                }
            }
        }

        void PortDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var rxlen = _port.BytesToRead;
            var data = new byte[rxlen];
            _port.Read(data, 0, rxlen);

            var line = _bDisplayHex ? StringHelper.ToHexString(data, 0, rxlen) : System.Text.Encoding.ASCII.GetString(data, 0, rxlen);
            if (line.EndsWith("\r\n"))
                line = line.Substring(0, line.Length - 2);

            Log("S->N: " + line);

            if(_stream != null)
                if(_stream.CanWrite)
                {
                    try
                    {
                        _stream.Write(data, 0, rxlen);
                    }
                    catch(Exception ex)
                    {
                        Log("Can't write to TCP stream:" + ex.Message);

                        try
                        {
                            _stream.Close();
                        } catch{}
                        _stream = null;
                        if (_bAutoReconnect && _bIsRunning)
                        {
                            Log("Connecting to " + textBoxIPAddress.Text + ":" + textBoxTargetPort.Text);

                            _connection.BeginConnect(textBoxIPAddress.Text, int.Parse(textBoxTargetPort.Text), TcpConnected, null);

                        }
                    }
                }
                }

        void TcpReader(IAsyncResult ar)
        {
            try
            {
                var rxbytes = _stream.EndRead(ar);

                if (rxbytes > 0)
                {
                    _port.Write(_tcpdata, 0, rxbytes);

                    var line = _bDisplayHex ? StringHelper.ToHexString(_tcpdata, 0, rxbytes) : System.Text.Encoding.ASCII.GetString(_tcpdata, 0, rxbytes);
                    if (line.EndsWith("\r\n"))
                        line = line.Substring(0, line.Length - 2);

                    Log("N->S: " + line);
                }

                if (rxbytes >= 0)
                {
                    _stream.BeginRead(_tcpdata, 0, _tcpdata.Length, TcpReader, null);
                }
            } catch(Exception e)
            {
                Log("Exception: " + e.Message);

                try
                {
                    _stream.Close();
                }
                catch { }
                _stream = null;

                if (_bAutoReconnect && _bIsRunning)
                {
                    try
                    {
                        Log("Connecting to " + textBoxIPAddress.Text + ":" + textBoxTargetPort.Text);

                        try
                        {
                            _connection.Close();
                        } catch
                        {
                        }

                        _connection = new TcpClient();

                        _connection.BeginConnect(textBoxIPAddress.Text, int.Parse(textBoxTargetPort.Text), TcpConnected,
                                                 null);
                    } catch(Exception ex)
                    {
                        Log("Problem reconnecting:" + ex.Message);
                    }
                }
            }
        }

        void Log(string text)
        {
            if(InvokeRequired)
            {
                Invoke(new LogHandler(Log), new object[] {text});
                return;
            }

            // Truncate
            if (textBoxLog.Text.Length > 4096)
                textBoxLog.Text = textBoxLog.Text.Substring(textBoxLog.Text.Length - 4096);

            textBoxLog.Text += text + "\r\n";
            textBoxLog.SelectionStart = textBoxLog.Text.Length - 1;
            textBoxLog.ScrollToCaret();
        }

        private void LinkLabel1LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.dynamicdevices.co.uk");
        }

        private void CheckBoxReconnectCheckedChanged(object sender, EventArgs e)
        {
            _bAutoReconnect = checkBoxReconnect.Checked;
        }

        private void CheckBoxDisplayHexCheckedChanged(object sender, EventArgs e)
        {
            _bDisplayHex = checkBoxDisplayHex.Checked;
        }

        private void ButtonClearClick(object sender, EventArgs e)
        {
            textBoxLog.Text = "";
        }
    }
}
