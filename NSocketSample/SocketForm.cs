using NCommonUtility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleMain
{
    public partial class SocketForm : Form
    {
        NSocket _Socket;

        public SocketForm(NSocket socket)
        {
            _Socket = socket;
            _Socket.OnDisConnectEvent += OnDisConnect;
            _Socket.OnRecvEvent += OnReceive;
            _Socket.OnSendEvent += OnSend;

            InitializeComponent();

            txt_ipAddr1.Text = socket.LocalIPAddress?.ToString();
            txt_portNo1.Text = socket.LocalPortno?.ToString();
            txt_ipAddr2.Text = socket.RemoteIPAddress.ToString();
            txt_portNo2.Text = socket.RemotePortno.ToString();

            if (socket.isServer)
            {
                this.Text = "サーバーソケット";
            }
            if (socket.isClient)
            {
                this.Text = "クライアントソケット";
            }
        }

        private void DisplayLog(string message)
        {
            txt_log.Text += $"{DateTime.Now} {message}\r\n";
        }

        private void OnDisConnect(object sender, NSocketEventArgs args)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new NSocketEventHandler(OnDisConnect), new object[] { sender, args });
                return;
            }
            this.Close();
        }

        private void OnReceive(object sender, SendRecvEventArgs args)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new SendRecvEventHandler(OnReceive), new object[] { sender, args });
                return;
            }
            DisplayLog($"RECV {Encoding.Unicode.GetString(args.dat)}");
        }

        private void OnSend(object sender, SendRecvEventArgs args)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new SendRecvEventHandler(OnSend), new object[] { sender, args });
                return;
            }
            DisplayLog($"RECV {Encoding.Unicode.GetString(args.dat)}");
        }


        private void SocketForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _Socket.Close();
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            _Socket.Send(Encoding.Unicode.GetBytes(txt_sendData.Text));
        }
    }
}
