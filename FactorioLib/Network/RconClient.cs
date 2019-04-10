using FactorioLib.Data;
using FactorioLib.Logging;
using FactorioLib.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FactorioLib.Network
{
    public class RconClient
    {
        public class RconResponseEventArgs : EventArgs
        {
            public RconResponse response;
            public RconResponseEventArgs(RconResponse response) { this.response = response; }
        }
        public delegate void RconResponseHandler(object sender, RconResponseEventArgs rea);

        private MultiLogger _logger; //TODO
        private Socket _socket;
        private int _requestId;

        private Thread _processingThread;
        private bool _working;

        private List<string> _cmdQueue;
        private object _cq_lock = new object();
        public MultiLogger Logger { get { return _logger; } }
        public RconResponseHandler ResponseReceived;

        public RconClient()
        {
            _requestId = 0;            
            _cmdQueue = new List<string>();            
        }

        private void _StartProcThread()
        {
            _working = true;
            _processingThread = new Thread(new ThreadStart(_Work));
            _processingThread.Start();
        }

        private void _Work()
        {
            while (_working)
            {
                lock(_cq_lock)
                {
                    //
                    while(_cmdQueue.Count > 0)
                    {
                        string cmd = _cmdQueue[0];
                        _cmdQueue.RemoveAt(0);
                        SendCommand(cmd);
                    }
                }
                Thread.Sleep(100);
            }
        }

        public void QueueCommand(string cmd)
        {
            lock(_cq_lock)
            {
                _cmdQueue.Add(cmd);
            }
        }
        

        private int SendCommand(string cmd)
        {
            return SendCommand(cmd, COMMAND_TYPE.EXEC_CMD);
        }
        private int SendCommand(string cmd, COMMAND_TYPE cmd_type)
        {
            int ret = (int)ERROR_CODES.FAILURE;

            unsafe { ++_requestId; } //If > int.MaxValue rolls over  
            RconCommand rcmd = new RconCommand(_requestId, cmd, cmd_type);
            try
            {
                byte[] tx_buf = rcmd.ToBytes();
                int ec = _socket.Send(tx_buf);
                
                if (ec < tx_buf.Length)
                {
                    ret = (int)ERROR_CODES.TRANSMIT_ERROR;
                    goto EXIT_RET;
                }
                
               Thread.Sleep(100);

                ec = Receive(out RconResponse response);
                if (ec < 0)
                {
                    ret = ec;
                    goto EXIT_RET;
                }
                //Raise event
                ResponseReceived?.Invoke(this, new RconResponseEventArgs(response));
                
                ret = ec;
            }
            catch
            {
            }

            //wait for resp
        EXIT_RET:
            return ret;
        }

        private int Receive(out RconResponse response)
        {
            int ret = (int)ERROR_CODES.FAILURE;
            byte[] buf = new byte[1024];
            int rxlen = 0;
            response = null;
            try
            {
                MemoryStream ms = new MemoryStream();
                Stopwatch stw = new Stopwatch();
                stw.Start();

                do
                {
                    if (_socket.Available > 0)
                    {
                        rxlen = _socket.Receive(buf, SocketFlags.None);
                        ms.Write(buf, 0, rxlen);
                    }
                    else
                    {
                        break; // nothing available for read
                    }
                } while (rxlen > 0);

                stw.Stop();
                Console.WriteLine("Receive finished in {0} seconds", 
                    stw.Elapsed.TotalSeconds);
                ms.Close();
                byte[] data = ms.ToArray();
                if (data.Length > 0)
                    ret = RconResponse.FromBytes(data, out response);                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return ret;
        }

        public int Connect(string host, int port, string password)
        {
            int ret = (int)ERROR_CODES.FAILURE;
            int ec;
            //Perform DNS lookup
            IPAddress[] addresses = Dns.GetHostAddresses(host);
            foreach (IPAddress address in addresses)
            {
                try
                {
                    _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    _socket.ReceiveTimeout = 10 * 1000; //Allows 10s max for RX
                    _socket.SendTimeout = 10 * 1000; //Allow 10s max for TX
                    _socket.Connect(address, port);
                    //note this yields resp
                    ec = SendCommand(password, COMMAND_TYPE.AUTH);
                    if (ec > 0) //Auth successful, start processing thread
                        _StartProcThread();

                    ret = ec;
                    break;
                }
                catch(SocketException ex)
                {
                    //TODO Log
                    Console.WriteLine(ex);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
         EXIT_RET:
            return ret;
        }

        public void Disconnect()
        {
            if (_socket.Connected)
            {
                try
                {
                    _socket.Disconnect(false);
                }
                catch { }
            }
            _working = false;
        }

    }
}
