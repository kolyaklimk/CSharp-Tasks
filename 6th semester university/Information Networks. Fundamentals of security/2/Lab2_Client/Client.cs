using Lab2;
using System.Net;
using System.Net.Sockets;
using System.Text;
namespace Lab2_Client
{
    class Client
    {
        public string Login { get; set; }
        private byte[] TicketGrantingTicket { get; set; }
        private byte[] TicketGrantingService { get; set; }
        private byte[] K_C_TGS { get; set; }
        private byte[] K_C_SS { get; set; }
        DateTime T4 { get; set; }

        private readonly IPEndPoint ASEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), Settings.AS_port);
        private readonly IPEndPoint SSEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), Settings.SS_port);
        private readonly IPEndPoint TGSEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), Settings.TGS_port);

        public void LogOn(string login)
        {
            Login = login;
            Console.WriteLine($"Sending id:{login} to AS");
            TransportData trdata = new TransportData(EnumSteps._1);
            trdata.Data.Add(new List<byte>(Encoding.UTF8.GetBytes(login)));
            trdata.Send(ASEndPoint);
        }
        public void Connection()
        {
            UdpClient reciever = new UdpClient(Settings.C_port);
            IPEndPoint remoteIP = null;
            try
            {
                while (true)
                {
                    byte[] data = reciever.Receive(ref remoteIP);
                    TransportData trdata = UTF8Serialiser<TransportData>.Deserialise(data);
                    switch (trdata.Type)
                    {
                        case EnumSteps._2:
                            {
                                TicketGrantingTicket = DES
                                    .Decrypt(trdata.Data[0].ToArray(), Settings.K_C);
                                K_C_TGS = Additionally
                                    .RecoverData(new List<byte>(DES.Decrypt(trdata.Data[1].ToArray(), Settings.K_C)));
                                var a = Encoding.UTF8.GetString(K_C_TGS);

                                Console.WriteLine("1-2 done");
                                trdata = new TransportData(EnumSteps._3);
                                trdata.Data.Add(new List<byte>(TicketGrantingTicket));
                                TimeMark mark = new TimeMark() { C = Login, T = DateTime.Now };

                                var Aut1 = Additionally.ExtendData(UTF8Serialiser<TimeMark>.Serialise(mark));
                                trdata.Data.Add(new List<byte>(DES.Encrypt(Aut1, K_C_TGS)));
                                trdata.Data.Add(new List<byte>(Encoding.UTF8.GetBytes(Settings.ID_SS)));
                                trdata.Send(TGSEndPoint);
                                break;
                            }
                        case EnumSteps._4:
                            {
                                TicketGrantingService = DES
                                    .Decrypt(trdata.Data[0].ToArray(), K_C_TGS);
                                K_C_SS = Additionally
                                    .RecoverData(new List<byte>(DES.Decrypt(trdata.Data[1].ToArray(), K_C_TGS)));
                                TransportData msg = new TransportData(EnumSteps._5);
                                msg.Data.Add(new List<byte>(TicketGrantingService));
                                var mark = new TimeMark() { C = Login, T = DateTime.Now };
                                var Aut2 = Additionally.ExtendData(UTF8Serialiser<TimeMark>.Serialise(mark));

                                T4 = mark.T;
                                msg.Data.Add(new List<byte>(DES.Encrypt(Aut2, K_C_SS)));
                                msg.Send(SSEndPoint);
                                Console.WriteLine("3-4 done");
                                break;
                            }

                        case EnumSteps._6:
                            {
                                var t = DES.Decrypt(trdata.Data[0].ToArray(), K_C_SS);
                                var checkT_bytes = Additionally.RecoverData(new List<byte>(t));
                                var asd = Encoding.UTF8.GetString(checkT_bytes);
                                var checkT = UTF8Serialiser<long>.Deserialise(checkT_bytes);

                                Console.WriteLine("5-6 done\n");
                                if (T4.Ticks + 1 == checkT)
                                {
                                    Console.WriteLine($"Success");
                                }
                                break;
                            }
                        case EnumSteps.NoValid:
                            Console.WriteLine("Ticket is not valid");
                            break;
                        case EnumSteps.NoAccess:
                            Console.WriteLine("No access");
                            break;
                        default:
                            Console.WriteLine("Invalid type of message");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
