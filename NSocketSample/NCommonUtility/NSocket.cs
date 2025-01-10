using NCommonUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NCommonUtility
{

    public delegate void NSocketEventHandler(Object sender, NSocketEventArgs args);
    public class NSocketEventArgs : EventArgs
    {
        public NSocket Socket { get; private set; }
        public NSocketEventArgs(NSocket socket)
        {
            Socket = socket;
        }
    }

    public delegate void SendRecvEventHandler(Object sender, SendRecvEventArgs args);
    public class SendRecvEventArgs : EventArgs
    {
        public NSocket socket { get; private set; }
        public byte[] dat { get; private set; }

        public SendRecvEventArgs(NSocket socket, byte[] dat)
        {
            this.socket = socket;
            this.dat = dat;
        }
    }

    /// <summary>
    /// NSocketクラス
    /// </summary>
    public class NSocket
    {
        protected Socket _soc = null;
        protected IPEndPoint _self_EndPoint = null;     // バインドするためのEndPoint
        protected byte[] _recv_buf = new byte[1024];
        public int RecvBuffSize { 
            get { return _recv_buf.Length; } 
            set { _recv_buf = new byte[value];  } 
        }

        public bool isOpen {  get { return _soc != null; } }

        private int _type = 0;
        public bool isServer { get { return _type == 1; } }
        public bool isClient { get { return _type == 2; } }


        public IPAddress LocalIPAddress { get { return ((IPEndPoint)_soc?.LocalEndPoint)?.Address; } }
        public int? LocalPortno { get { return ((IPEndPoint)_soc?.LocalEndPoint)?.Port; } }


        public IPAddress RemoteIPAddress { get { return ((IPEndPoint)_soc?.RemoteEndPoint)?.Address; } }
        public int? RemotePortno { get { return ((IPEndPoint)_soc?.RemoteEndPoint)?.Port; } }


        public event ThreadExceptionEventHandler OnExceptionEvent;
        public event NSocketEventHandler OnDisConnectEvent;
        public event NSocketEventHandler OnAcceptEvent;
        public event NSocketEventHandler OnConnectEvent;
        public event SendRecvEventHandler OnRecvEvent;
        public event SendRecvEventHandler OnSendEvent;

        private IAsyncResult _asyncListenResult;

        public NSocket()
        {
            _type = 0;
        }
        protected NSocket(Socket soc)
        {
            // Acceptした時に生成されるサーバーソケット
            _soc = soc;
            _type = 1;
        }

        protected void OnException(Exception e)
        {
            if (OnExceptionEvent == null)
            {
                throw e;
            }
            OnExceptionEvent.Invoke(this, new ThreadExceptionEventArgs(e));
        }

        protected void OnDisConnect()
        {
            lock (this)
            {
                _soc?.Close();
                _soc = null;
            }
            OnDisConnectEvent?.Invoke(this, new NSocketEventArgs(this));
        }

        protected void OnAccept(NSocket socket)
        {
            OnAcceptEvent?.Invoke(this, new NSocketEventArgs(socket));
            // 受信スレッド起動
            socket.StartRecvThread();

            lock (this)
            {
                // Acceptの処理が終わったら引き続きAcceptを待つ
                _soc?.BeginAccept(new AsyncCallback(AcceptCallback), this);
            }

        }

        protected void OnConnect()
        {
            OnConnectEvent?.Invoke(this, new NSocketEventArgs(this));
            // 受信スレッド起動
            StartRecvThread();
        }

        protected virtual void OnRecv()
        {
            int len =_soc.Receive(_recv_buf);
            byte[] buf = new byte[len];
            Buffer.BlockCopy(_recv_buf, 0, buf, 0, len);
            OnRecvEvent?.Invoke(this, new SendRecvEventArgs(this, buf));
        }

        protected virtual void OnSend(byte[] buf)
        {
            OnSendEvent?.Invoke(this, new SendRecvEventArgs(this, buf));
        }

        public void SetSelfEndPoint(string iaddr, string portno)
        {
            SetSelfEndPoint(IPAddress.Parse(iaddr), int.Parse(portno));
        }
        public void SetSelfEndPoint(string iaddr, int portno = 0)
        {
            SetSelfEndPoint(IPAddress.Parse(iaddr), portno);
        }
        public void SetSelfEndPoint(IPAddress iaddr, int portno = 0)
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            if (!ipHostInfo.AddressList.Contains<IPAddress>(iaddr))
            {
                throw new Exception("指定されたIPアドレスがホストに存在しません");
            }
            _self_EndPoint = new IPEndPoint(iaddr, portno);
        }

        public void Close()
        {
            lock (this)
            {
                _soc?.Close();
                _soc = null;
            }
        }

        public void Listen(string str_iaddr, string str_portno)
        {
            IPAddress iaddr;
            try
            {
                iaddr = IPAddress.Parse(str_iaddr);
            }
            catch (Exception e)
            {
                OnException(new Exception("IPAddress指定が不正です", e));
                return;
            }
            int portno;
            try
            {
                portno = int.Parse(str_portno);
            }
            catch (Exception e)
            {
                OnException(new Exception("PortNo指定が不正です", e));
                return;
            }
            Listen(iaddr, portno);
        }
        public void Listen(string str_iaddr, int portno)
        {
            IPAddress iaddr;
            try
            {
                iaddr = IPAddress.Parse(str_iaddr);
            }
            catch (Exception e)
            {
                OnException(new Exception("IPAddress指定が不正です", e));
                return;
            }

            Listen(iaddr, portno);
        }
        public void Listen(IPAddress iaddr, int portno)
        {
            lock (this)
            {
                bool needDisconnect = true;
                try
                {
                    if (_soc != null)
                    {
                        needDisconnect = false;
                        throw new Exception("既にListen中です");
                    }
                    SetSelfEndPoint(iaddr, portno);
                    _soc = new Socket(_self_EndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                    _soc.Bind(_self_EndPoint);
                    _soc.Listen(1);     // 一度に一個だけ受け付ける
                    _asyncListenResult = _soc.BeginAccept(new AsyncCallback(AcceptCallback), this);
                }
                catch (Exception ex)
                {
                    if (needDisconnect)
                    {
                        OnDisConnect();
                    }
                    OnException(ex);
                }
            }
        }

        public void Connect(string str_iaddr, string str_portno)
        {
            IPAddress iaddr;
            try
            {
                iaddr = IPAddress.Parse(str_iaddr);
            }
            catch (Exception e)
            {
                OnException(new Exception("IPAddress指定が不正です", e));
                return;
            }
            int portno;
            try
            {
                portno = int.Parse(str_portno);
            }
            catch (Exception e)
            {
                OnException(new Exception("PortNo指定が不正です", e));
                return;
            }

            Connect(iaddr, portno);
        }
        public void Connect(string str_iaddr, int portno)
        {
            IPAddress iaddr;
            try
            {
                iaddr = IPAddress.Parse(str_iaddr);
            }
            catch (Exception e)
            {
                OnException(new Exception("IPAddress指定が不正です", e));
                return;
            }
            Connect(iaddr, portno);
        }
        public void Connect(IPAddress iaddr, int portno)
        {
            try
            {
                lock (this)
                {
                    if (_soc != null)
                    {
                        throw new Exception("Connect中にConnectしました");
                    }
                    IPEndPoint endPoint = new IPEndPoint(iaddr, portno);
                    _soc = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                    if (_self_EndPoint != null)
                    {
                        _soc.Bind(_self_EndPoint);
                    }
                    _type = 2;
                    _soc.BeginConnect(endPoint, new AsyncCallback(ConnectCallback), this);
                }
            }
            catch (Exception ex)
            {
                OnDisConnect();
                OnException(new Exception("Connect処理でエラー発生", ex));
            }
        }


        protected virtual void AcceptCallback(IAsyncResult ar)
        {
            NSocket socket = (NSocket)ar.AsyncState;
            if (socket._soc == null)
            {
                return;
            }
            try
            {
                Socket soc = socket._soc.EndAccept(ar);
                OnAccept(new NSocket(soc));
            }
            catch (Exception ex)
            {
                OnDisConnect();
                OnException(ex);
            }
        }

        protected virtual void ConnectCallback(IAsyncResult ar)
        {
            NSocket socket = (NSocket)ar.AsyncState;
            if (socket._soc == null)
            {
                return;
            }
            try
            {
                socket._soc.EndConnect(ar);
                OnConnect();
            }
            catch (Exception ex)
            {
                OnDisConnect();
                OnException(new Exception("Connect中にエラー発生", ex));
            }
        }

        protected void StartRecvThread()
        {
            Task.Run(() => recvThread(this));
        }

        /// <summary>
        /// 受信スレッド
        /// </summary>
        /// <param name="_this"></param>
        static private void recvThread(NSocket _this)
        {
            try
            {
                while (true)
                {
                    if (_this._soc ==null ||_this._soc.Connected == false)
                    {
                        break;
                    }
                    _this.OnRecv();
                }
            }
            catch (Exception ex)
            {
                _this.OnException(ex);
            }
            finally
            {
                _this.OnDisConnect();
            }
        }

        public void Send(byte[] dat)
        {
            try
            {
                byte[] buf = new byte[dat.Length];
                Buffer.BlockCopy(dat, 0, buf, 0, dat.Length);

                _soc?.BeginSend(buf, 0, buf.Length, SocketFlags.None, new AsyncCallback(SendCallback), (this, buf));
            }
            catch (Exception e)
            {
                OnDisConnect();
                OnException(new Exception("送信中に例外発生", e));
            }
        }

        protected virtual void SendCallback(IAsyncResult ar)
        {
            var (socket, buf) = ((NSocket, byte[]))ar.AsyncState;
            if (socket._soc == null)
            {
                return;
            }
            try
            {
                socket._soc.EndSend(ar);
                OnSend(buf);
            }
            catch (System.ObjectDisposedException ex)
            {
                OnDisConnect();
                OnException(new Exception("ソケット送信エラー", ex));
            }
        }
    }
}
