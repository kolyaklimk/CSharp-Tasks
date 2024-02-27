using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
namespace Lab2
{
    class AS
    {
        private List<string> Users = new List<string>();
        public AS()
        {
            Users.Add("kolyaklimk");
        }
        public void Listen()
        {
            UdpClient receiver = new UdpClient(Settings.AS_port);
            IPEndPoint remoteIP = null;
            try
            {
                while (true)
                {
                    byte[] data = receiver.Receive(ref remoteIP);
                    remoteIP.Port = Settings.C_port;
                    TransportData responseMessage = new TransportData();

                    Console.WriteLine("\n\nSTEP 1: ");
                    Console.WriteLine("C->AS: {c}");

                    var trdata = UTF8Serialiser<TransportData>.Deserialise(data);
                    if (trdata.Type == EnumSteps._1)
                    {
                        Console.WriteLine("\n\nSTEP 2: ");
                        Console.WriteLine("AS->C: {{TGT}K(AS_TGS), K(C_TGS)}K(C)");
                        var id = Encoding.UTF8.GetString(trdata.Data[0].ToArray());
                        if (Users.Contains(id))
                        {
                            responseMessage.Type = EnumSteps._2;
                            TgsClass ticket = new TgsClass()
                            {
                                ClientIdentity = id,
                                Duration = Settings.ASTicketDuration.Ticks,
                                IssuingTime = DateTime.Now,
                                ServiceIdentity = Settings.tgs,
                                Key = Encoding.UTF8.GetString(Settings.K_C_TGS)
                            };
                            var ticket_bytes = Additionally.ExtendData(UTF8Serialiser<TgsClass>.Serialise(ticket));
                            var k_c_tgs_bytes = Additionally.ExtendData(Settings.K_C_TGS);
                            var tb_enc = DES.Encrypt(ticket_bytes, Settings.K_AS_TGS);
                            tb_enc = DES.Encrypt(tb_enc, Settings.K_C);
                            var k_c_tgs_enc = DES.Encrypt(k_c_tgs_bytes, Settings.K_C);
                            responseMessage.Data.Add(new List<byte>(tb_enc));
                            responseMessage.Data.Add(new List<byte>(k_c_tgs_enc));

                            Console.WriteLine($"DES TGT: {BitConverter.ToString(tb_enc)}");
                            Console.WriteLine($"DES K(C_TGS): {BitConverter.ToString(k_c_tgs_enc)}");
                        }
                        else
                        {
                            responseMessage.Type = EnumSteps.NoAccess;
                            Console.WriteLine("Access denied on the authentication server");
                        }
                        responseMessage.Send(remoteIP);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
