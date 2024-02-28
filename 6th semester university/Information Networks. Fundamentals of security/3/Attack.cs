using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab3
{
    class Attack
    {
        private static EndPoint server = new IPEndPoint(IPAddress.Parse(Settings.host), Settings.ServerPort);
        public static void Run()
        {
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            try
            {
                serverSocket.Bind(new IPEndPoint(IPAddress.Parse(Settings.host), 10000));

                Parallel.For(1, 100, i =>
                {
                    TCP tcp = new TCP(10000 + i, Settings.ServerPort, syn: true);

                    serverSocket.SendTo(tcp.ToByteArray(), server);
                    Socket ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                    try
                    {
                        ClientSocket.Bind(new IPEndPoint(IPAddress.Parse(Settings.host), 10000 + i));

                        byte[] data = new byte[100];
                        var countByte = ClientSocket.Receive(data);
                        var message = TCP.GetByte(TCP.BitSection(data, countByte));

                        var response = new TCP(message.DestinationPort, message.SenderPort, ack: true);
                        ClientSocket.SendTo(response.ToByteArray(), server);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        ClientSocket.Close();
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                serverSocket.Close();
            }
        }
    }
}
