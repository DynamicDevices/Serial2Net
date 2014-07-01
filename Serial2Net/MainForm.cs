using System;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Net;
using System.Windows.Forms;
using System.Net.Sockets;
using PortListener.Core.Utilities;

namespace Serial2Net
{
    public partial class MainForm : Form
    {
        private delegate void LogHandler(string text);

        private TcpClient _client;
        private TcpListener _server;

        private SerialPort _port;
        private NetworkStream _stream;
        private readonly byte[] _tcpdata = new byte[1024];

        private bool _bAutoReconnect;
        private bool _bDisplayHex;
        private bool _bIsRunning;

        enum ConnectionMode
        {
            CLIENT,
            SERVER,
        }

        private ConnectionMode _eConnectionMode = ConnectionMode.CLIENT;

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

            radioButtonClient.Checked = true;

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
                    if (_eConnectionMode == ConnectionMode.CLIENT)
                    {
                        Log("Connecting to " + textBoxIPAddress.Text + ":" + textBoxTargetPort.Text);

                        _client = new TcpClient();
                        _client.BeginConnect(textBoxIPAddress.Text, int.Parse(textBoxTargetPort.Text), TcpConnectedOut,
                                                 null);
                    }
                    else
                    {
                        _server = new TcpListener(IPAddress.Any, int.Parse(textBoxTargetPort.Text));
                        _server.Start();
                        _server.BeginAcceptTcpClient(TcpConnectedIn, null);
                    }
                }
                catch (Exception ex)
                {
                    if(_eConnectionMode == ConnectionMode.CLIENT)   
                        Log("Couldn't connect: " + ex.Message);
                    else
                        Log("Couldn't listen: " + ex.Message);

                    _port.DataReceived -= PortDataReceived;
                    _port.Close();

                    return;
                }
                buttonStartStop.Text = @"Stop";
                _bIsRunning = true;
            }
            else
            {
                if (_port.IsOpen)
                    _port.Close();

                if (_client != null)
                {
                    if (_client.Connected)
                        _client.Close();
                    _client = null;
                }

                if(_server != null)
                {
                    _server.Stop();
//                    _server = null;
                }

                buttonStartStop.Text = @"Start";
                _bIsRunning = false;
            }              
        }

        void TcpConnectedIn(IAsyncResult result)
        {
            try
            {
                _client = _server.EndAcceptTcpClient(result);

                _stream = _client.GetStream();

                Log("Client Connected from: " + _client.Client.RemoteEndPoint);

                var tcpdata = new byte[1024];
                _stream.BeginRead(tcpdata, 0, tcpdata.Length, TcpReader, null);
            } catch(Exception e)
            {
                if(e is ObjectDisposedException)
                    Log("Server shutdown");
                else
                    Log("Server exception: " + e.Message);
            }
        }

        void TcpConnectedOut(IAsyncResult result)
        {
            try
            {
                _client.EndConnect(result);

                _stream = _client.GetStream();

                Log("Connected");

                var tcpdata = new byte[1024];
                _stream.BeginRead(tcpdata, 0, tcpdata.Length, TcpReader, null);

            } catch(Exception e)
            {
                Log("Couldn't connect: " + e.Message);

                if (_eConnectionMode == ConnectionMode.CLIENT)
                {
                    if (_bAutoReconnect && _bIsRunning)
                    {
                        Log("Connecting to " + textBoxIPAddress.Text + ":" + textBoxTargetPort.Text);
                        _client.BeginConnect(textBoxIPAddress.Text, int.Parse(textBoxTargetPort.Text), TcpConnectedOut,
                                                 null);
                    }
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
                            if (_eConnectionMode == ConnectionMode.CLIENT)
                            {
                                Log("Connecting to " + textBoxIPAddress.Text + ":" + textBoxTargetPort.Text);

                                _client.BeginConnect(textBoxIPAddress.Text, int.Parse(textBoxTargetPort.Text),
                                                         TcpConnectedOut, null);
                            }
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
                if (e is ObjectDisposedException)
                    Log("Connection closed");
                else if(e is IOException && e.Message.Contains("closed"))
                    Log("Connection closed");
                else
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
                        try
                        {
                            _client.Close();
                        } catch
                        {
                        }

                        if (_eConnectionMode == ConnectionMode.CLIENT)
                        {
                            Log("Connecting to " + textBoxIPAddress.Text + ":" + textBoxTargetPort.Text);
                            
                            _client = new TcpClient();

                            _client.BeginConnect(textBoxIPAddress.Text, int.Parse(textBoxTargetPort.Text),
                                                     TcpConnectedOut,
                                                     null);
                        }
                        else
                        {
                            _server.BeginAcceptTcpClient(TcpConnectedIn, null);
                        }

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

        private void RadioButtonServerCheckedChanged(object sender, EventArgs e)
        {

            if(radioButtonServer.Checked)
            {
                _eConnectionMode = ConnectionMode.SERVER;
                textBoxIPAddress.Enabled = false;
            }
            else
            {
                _eConnectionMode = ConnectionMode.CLIENT;
                textBoxIPAddress.Enabled = true;                
            }
        }
    }
}
