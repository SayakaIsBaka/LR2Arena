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
                if (recvBuffer.Length > 0)
                {
                    queue.Add(recvBuffer);
                }
            }
        }

        public static void UpdatePacemaker(uint exScore)
        {
            byte[] data = BitConverter.GetBytes(exScore);
            byte[] dataWithId = AddIdToData(1, data);
            pacemakerClient.SendAsync(dataWithId, dataWithId.Length, "127.0.0.1", 2223);
        }

        public static void SendP2ReadyToLR2()
        {
            byte[] data = { 2 };
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

        private static byte[] AddIdToData(byte id, byte[] data)
        {
            byte[] dataWithId = new byte[data.Length + 1];
            dataWithId[0] = id;
            Array.Copy(data, 0, dataWithId, 1, data.Length);
            return dataWithId;
        }

        public static void RemoteSendExScore(uint exScore)
        {
            byte[] data = BitConverter.GetBytes(exScore);
            RemoteSendWithId(1, data);
        }

        public static void RemoteSendWithId(byte id, byte[] data)
        {
            byte[] dataWithId = AddIdToData(id, data);
            RemoteSend(dataWithId);
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
