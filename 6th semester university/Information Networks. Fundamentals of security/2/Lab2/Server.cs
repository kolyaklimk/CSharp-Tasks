using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace Lab2
{
    class Server
    {
        public void Listen()
        {
            UdpClient receiver = new UdpClient(Settings.SS_port);
            IPEndPoint remoteIP = null;
            try
            {
                while (true)
                {
                    byte[] data = receiver.Receive(ref remoteIP);
                    remoteIP.Port = Settings.C_port;
                    var message = UTF8Serialiser<TransportData>.Deserialise(data);
                    if (message.Type == EnumSteps._5)
                    {
                        Console.WriteLine("\n\nSTEP 5");
                        Console.WriteLine("C->SS: {TGS}K(TGS_SS), {Aut2} K(C_SS)");
                        var tgs_bytes = Additionally.RecoverData(
                            new List<byte>(DES.Decrypt(message.Data[0].ToArray(), Settings.K_TGS_SS)));
                        var tgs = UTF8Serialiser<TgsClass>.Deserialise(tgs_bytes);

                        Console.WriteLine("TGS Ticket:");
                        Console.WriteLine($"Client Identity: {tgs.ClientIdentity}");
                        Console.WriteLine($"Service Identity: {tgs.ServiceIdentity}");
                        Console.WriteLine($"Duration: {tgs.Duration}");
                        Console.WriteLine($"Issuing Time: {tgs.IssuingTime}");

                        var aut2_bytes = Additionally.RecoverData(
                            new List<byte>(DES.Decrypt(message.Data[1].ToArray(), Settings.K_C_SS)));
                        var aut2 = UTF8Serialiser<TimeMark>.Deserialise(aut2_bytes);
                        Console.WriteLine("Aut2:");
                        Console.WriteLine($"Client Identity: {aut2.C}");
                        Console.WriteLine($"Time Mark: {aut2.T}");
                        TransportData ReMessage = new TransportData();
                        if (Additionally.TimeComparison(tgs.IssuingTime, aut2.T, tgs.Duration))
                        {
                            Console.WriteLine("\n\nSTEP 6:");
                            Console.WriteLine("SS->C: {t(4+1)}K(C_SS)");

                            ReMessage.Type = EnumSteps._6;
                            DateTime reTime = aut2.T;
                            var time_bytes = UTF8Serialiser<long>.Serialise(aut2.T.Ticks + 1);
                            var bytes = DES.Encrypt(Additionally.ExtendData(time_bytes), Settings.K_C_SS);
                            Console.WriteLine($"Data: {BitConverter.ToString(bytes)}");
                            ReMessage.Data.Add(new List<byte>(bytes));
                        }
                        else
                        {
                            ReMessage.Type = EnumSteps.NoValid;
                            Console.WriteLine("TicketNotValid in SS;");
                        }

                        ReMessage.Send(remoteIP);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}

