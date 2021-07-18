using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;

namespace LR2Arena
{
    class UdpManager
    {
        private int port;
        private UdpClient udpClient;
        private BlockingCollection<byte[]> queue;
        static readonly UdpClient pacemakerClient = new UdpClient();
        static readonly UdpClient remoteClient = new UdpClient();
        static IPEndPoint remoteEndpoint;

        public UdpManager(int port, BlockingCollection<byte[]> queue)
        {
            this.port = port;
            this.queue = queue;
            udpClient = new UdpClient();
            udpClient.Client.Bind(new IPEndPoint(IPAddress.Any, port));
        }

        public void Listen()
        {
            IPEndPoint from = new IPEndPoint(0, 0);
            while (true)
            {
                byte[] recvBuffer = udpClient.Receive(ref from);
                queue.Add(recvBuffer);
            }
        }

        public static void UpdatePacemaker(uint exScore)
        {
            byte[] data = BitConverter.GetBytes(exScore);
            pacemakerClient.SendAsync(data, data.Length, "127.0.0.1", 2223);
        }

        public static bool SetRemoteAddress(string ipAddress, int port)
        {
            try
            {
                UdpManager.remoteEndpoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);
            } catch (Exception e)
            {
                Console.Error.WriteLine(e.ToString());
                return false;
            }
            return true;
        }

        public static void RemoteSendExScore(uint exScore)
        {
            byte[] data = BitConverter.GetBytes(exScore);
            RemoteSend(data);
        }

        public static void RemoteSend(byte[] data)
        {
            if (remoteEndpoint != null)
            {
                remoteClient.SendAsync(data, data.Length, remoteEndpoint);
            }
            else
            {
                Console.Error.WriteLine("No remote endpoint set!");
            }
        }
    }
}
