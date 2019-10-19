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

        public class RconCommandEventArgs : EventArgs
        {
            public RconCommand command;
            public RconCommandEventArgs(RconCommand command) { this.command = command; }
        }
        public delegate void RconCommandHandler(object sender, RconCommandEventArgs rea);

        private MultiLogger logger; //TODO
        private Socket socket;        
        private Thread processingThread;
        private bool working;
        private List<RconCommand> cmdQueue;
        private object queueLock = new object();

        public MultiLogger Logger { get { return logger; } }
        public RconCommandHandler CommandSent;
        public RconResponseHandler ResponseReceived;
        

        public RconClient()
        {            
            cmdQueue = new List<RconCommand>();
        }

        private void StartProcThread()
        {
            working = true;
            processingThread = new Thread(new ThreadStart(Work));
            processingThread.Start();
        }

        private void Work()
        {
            while (working)
            {
                lock(queueLock)
                {                    
                    while(cmdQueue.Count > 0)
                    {
                        RconCommand cmd = cmdQueue[0];
                        cmdQueue.RemoveAt(0);
                        SendCommand(cmd);
                    }
                }
                Thread.Sleep(100);
            }
        }

        public void QueueCommand(RconCommand cmd)
        {
            lock(queueLock)
            {
                cmdQueue.Add(cmd);
            }
        }


        private int SendCommand(RconCommand command)
        {
            int ret = (int)ERROR_CODES.FAILURE;
            try
            {
                byte[] buf = command.Raw;
                int ec = socket.Send(buf);
                CommandSent?.Invoke(this, new RconCommandEventArgs(command));
                if (ec < buf.Length)
                {
                    ret = (int)ERROR_CODES.TRANSMIT_ERROR;
                    return ret;
                }
                
               Thread.Sleep(100);

                ec = Receive(out RconResponse response);
                if (ec < 0)
                {                    
                    return ec;
                }

                //Raise event
                ResponseReceived?.Invoke(this, new RconResponseEventArgs(response));
                
                if(response.ResponseType == RconResponse.Type.AUTH_RESPONSE)
                {
                    if(command.RequestId != response.RequestId)
                    {
                        ec = (int)ERROR_CODES.INCORRECT_PASSWORD;
                    }
                }

                ret = ec;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
            }
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
                using (MemoryStream stream = new MemoryStream())
                {
                    Stopwatch stw = new Stopwatch();
                    stw.Start();
                    while (socket.Available > 0)
                    {
                        rxlen = socket.Receive(buf, SocketFlags.None);
                        stream.Write(buf, 0, rxlen);
                        //if (rxlen <= 0) { break; }
                    }
                    stw.Stop();
                    Trace.WriteLine($"Receive finished in {stw.Elapsed}");                    
                    byte[] data = stream.ToArray();                    
                    ret = RconResponse.FromBytes(data, out response);
                }
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
                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    socket.ReceiveTimeout = 10 * 1000; //Allows 10s max for RX
                    socket.SendTimeout = 10 * 1000; //Allow 10s max for TX
                    socket.Connect(address, port);
                    //note this yields resp
                    ec = SendCommand(new RconCommand(password, CommandType.AUTH));
                    if (ec > 0) //Auth successful, start processing thread
                    {
                        StartProcThread();
                    }
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
            if (socket.Connected)
            {
                try
                {
                    socket.Disconnect(false);
                }
                catch { }
            }
            working = false;
        }

    }
}
