using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace Lab3
{
    static class Server
    {
        static Socket ListenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        static IPEndPoint ListenPoint = new IPEndPoint(IPAddress.Parse(Settings.host), Settings.ServerPort);

        static List<int> Syn = new List<int>();
        static List<int> Connections = new List<int>();

        static int MaxSyn = 10;
        static int MaxConnection = 10;

        public static void Listener()
        {
            try
            {
                ListenSocket.Bind(ListenPoint);
                while (true)
                {
                    byte[] data = new byte[1024];
                    int len = ListenSocket.Receive(data);
                    TCP message = TCP.GetByte(TCP.BitSection(data, len));

                    if (message.DestinationPort != Settings.ServerPort) continue;

                    else if (Connections.Contains(message.SenderPort)) continue;

                    else if (Syn.Contains(message.SenderPort) && message.ACK)
                    {

                        Connections.Add(message.SenderPort);
                        Syn.Remove(message.SenderPort);

                        if (Connections.Count > MaxConnection)
                            throw new Exception("Connection is overloaded");

                        Console.WriteLine($"Get {message.SenderPort} ACK");
                    }
                    else if (!Syn.Contains(message.SenderPort) && message.SYN)
                    {
                        Console.WriteLine($"Get {message.SenderPort} SYN");

                        Socket sender = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                        sender.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999));

                        try
                        {
                            var response = new TCP(Settings.ServerPort, message.SenderPort, syn: true, ack: true);
                            sender.SendTo(response.ToByteArray(), new IPEndPoint(IPAddress.Parse(Settings.host), message.SenderPort));
                            Syn.Add(message.SenderPort);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            sender.Close();
                        }

                        if (Syn.Count > MaxSyn)
                            throw new Exception("SYN is overloaded");

                        Console.WriteLine($"Send {message.SenderPort} SYN-ACK");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n{ex.Message}");
            }
            finally
            {
                ListenSocket.Close();
            }
        }
    }
}
