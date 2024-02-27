using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
namespace Lab2
{
    class TGS
    {
        public void Listen()
        {
            UdpClient reciever = new UdpClient(Settings.TGS_port);
            IPEndPoint remoteIP = null;
            try
            {
                while (true)
                {
                    byte[] data = reciever.Receive(ref remoteIP);
                    remoteIP.Port = Settings.C_port;
                    Console.WriteLine("\n\nSTEP 3:");
                    Console.WriteLine("C->TGS: {TGT}K(AS_TGS), {Aut1}K(C_TGS), {ID}");
                    var message = UTF8Serialiser<TransportData>.Deserialise(data);
                    if (message.Type == EnumSteps._3)
                    {
                        var tgt_json = Additionally.RecoverData(new List<byte>(DES.Decrypt(message.Data[0].ToArray(), Settings.K_AS_TGS)));
                        var tgt = UTF8Serialiser<TgsClass>.Deserialise(tgt_json);
                        var aut1_json = Additionally.RecoverData(new List<byte>(DES.Decrypt(message.Data[1].ToArray(), Settings.K_C_TGS)));
                        var a = Encoding.UTF8.GetString(aut1_json);
                        var aut1 = UTF8Serialiser<TimeMark>.Deserialise(aut1_json);
                        var ID = Encoding.UTF8.GetString(message.Data[2].ToArray());
                        Console.WriteLine($"ID: {ID}");
                        Console.WriteLine($"tgt.ClientIdentity: {tgt.ClientIdentity}");
                        Console.WriteLine($"Aut1: {a}");
                        if (tgt.ClientIdentity == aut1.C)
                        {
                            Console.WriteLine("Client identity == in TGT");
                        }
                        else
                        {
                            Console.WriteLine("Client identity != in TGT");
                        }
                        TransportData ReMessage = new TransportData();
                        if (Additionally.TimeComparison(tgt.IssuingTime, aut1.T, tgt.Duration))
                        {
                            Console.WriteLine("\n\nSTEP 4:");
                            Console.WriteLine("TGS->C: {{TGS}K(TGS_SS),K(C_SS)}K(C_TGS)");
                            ReMessage.Type = EnumSteps._4;
                            var TGS = new TgsClass()
                            {
                                ClientIdentity = aut1.C,
                                ServiceIdentity = ID,
                                Duration = Settings.TGSTicketDuration.Ticks,
                                IssuingTime = DateTime.Now,
                                Key = Encoding.UTF8.GetString(Settings.K_C_SS)
                            };
                            var ticket_bytes = Additionally.ExtendData(UTF8Serialiser<TgsClass>.Serialise(TGS));
                            var k_c_ss_bytes = Additionally.ExtendData(Settings.K_C_SS);
                            var tgs_enc = DES.Encrypt(ticket_bytes, Settings.K_TGS_SS);
                            tgs_enc = DES.Encrypt(tgs_enc, Settings.K_C_TGS);
                            var k_c_ss_enc = DES.Encrypt(k_c_ss_bytes, Settings.K_C_TGS);

                            Console.WriteLine($"Data: {BitConverter.ToString(tgs_enc)} {BitConverter.ToString(k_c_ss_enc)}");
                            ReMessage.Data.Add(new List<byte>(tgs_enc));
                            ReMessage.Data.Add(new List<byte>(k_c_ss_enc));
                        }
                        else
                        {
                            ReMessage.Type = EnumSteps.NoValid;
                            Console.WriteLine("TicketNotValid in TGS");
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
