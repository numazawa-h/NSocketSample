using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NCommonUtility;

namespace SampleMain
{
    public partial class MainForm : Form
    {
        NSocket listensocket = new NSocket();
        Point ShowFormPoint = new Point(-1, -1);


        public MainForm()
        {
            InitializeComponent();
            listensocket.OnExceptionEvent += OnException;
            listensocket.OnAcceptEvent += OnAccept;
            listensocket.OnDisConnectEvent += OnDisConnect;
        }

        private void DisplayLog(string message)
        {
            txt_log.Text += $"{DateTime.Now}  {message}\r\n";
        }

        private void btn_listen_Click(object sender, EventArgs e)
        {
            string iaddr1 = txt_ipAddr1.Text.Trim();
            string portno1 = txt_portNo1.Text.Trim();
            DisplayLog($"listen [{iaddr1} Port#{portno1}]");
            listensocket.Listen(iaddr1, portno1);
        }
        private void btn_stopListen_Click(object sender, EventArgs e)
        {
            if (listensocket.isOpen == false)
            {
                DisplayLog($"listen is NOT started");
                return;
            }
            string iaddr1 = listensocket.LocalIPAddress.ToString();
            string portno1 = listensocket.LocalPortno.ToString();
            DisplayLog($"listen STOP [{iaddr1} Port#{portno1}]");
            listensocket.Close();
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            NSocket socket = new NSocket();
            socket.OnExceptionEvent += OnException;
            socket.OnConnectEvent += OnConnect;
            socket.OnDisConnectEvent += OnDisConnect;

            string iaddr1 = txt_ipAddr1.Text.Trim();
            string portno1 = txt_portNo1.Text.Trim();
            if (iaddr1.Length > 0)
            {
                try
                {
                    socket.SetSelfEndPoint(iaddr1, portno1);
                }
                catch (Exception ex)
                {
                    OnException(this, new ThreadExceptionEventArgs(new Exception("Local ipアドレスの指定が不正です。", ex)));
                    socket.Close();
                    return;
                }
            }
            string iaddr2 = txt_ipAddr2.Text.Trim();
            string portno2 = txt_portNo2.Text.Trim();
            socket.Connect(iaddr2, portno2);
        }


        private void OnException(object sender, ThreadExceptionEventArgs args)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new ThreadExceptionEventHandler(OnException), new object[] { sender, args });
                return;
            }

            DisplayLog(args.Exception.Message);
            if(args.Exception.InnerException != null)
            {
                DisplayLog(args.Exception.InnerException.Message);
            }
        }

        private void OnDisConnect(object sender, NSocketEventArgs args)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new NSocketEventHandler(OnDisConnect), new object[] { sender, args });
                return;
            }
            DisplayLog($"OnDisConnect {args.Socket.RemoteIPAddress}:{args.Socket.RemotePortno}");
        }

        private void OnAccept(object sender, NSocketEventArgs args)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new NSocketEventHandler(OnAccept), new object[] { sender, args });
                return;
            }

            NSocket socket = (NSocket)args.Socket;
            socket.OnExceptionEvent += OnException;
            socket.OnDisConnectEvent += OnDisConnect;

            DisplayLog($"OnAccept {socket.RemoteIPAddress}:{socket.RemotePortno}");

            var frm = new SocketForm(socket);
            if (ShowFormPoint.X <0)
            {
                ShowFormPoint = new Point(this.Location.X, this.Location.Y);
            }
            ShowFormPoint.Offset(50, 30);
            frm.StartPosition = FormStartPosition.Manual;
            frm.Location = ShowFormPoint;
            frm.Show();
        }

        private void OnFailListen(object sender, NSocketEventArgs args)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new NSocketEventHandler(OnFailListen), new object[] { sender, args });
                return;
            }
            DisplayLog($"OnFailListen {args.Socket.LocalIPAddress}:{args.Socket.LocalPortno}");
        }

        private void OnConnect(object sender, NSocketEventArgs args)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new NSocketEventHandler(OnConnect), new object[] { sender, args });
                return;
            }
            DisplayLog($"OnConnect {args.Socket.RemoteIPAddress}:{args.Socket.RemotePortno}");

            var frm = new SocketForm(args.Socket);
            if (ShowFormPoint.X < 0)
            {
                ShowFormPoint = new Point(this.Location.X, this.Location.Y);
            }
            ShowFormPoint.Offset(50, 30);
            frm.StartPosition = FormStartPosition.Manual;
            frm.Location = ShowFormPoint;
            frm.Show();
        }

    }
}
