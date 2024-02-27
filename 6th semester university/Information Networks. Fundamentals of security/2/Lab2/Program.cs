using System;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            AS AS = new AS();
            TGS TGS = new TGS();
            Server SS = new Server();
            try
            {
                Task.Run(() => AS.Listen());
                Task.Run(() => TGS.Listen());
                Task.Run(() => SS.Listen());

                Console.WriteLine($"K_C: {Convert.ToBase64String(Settings.K_C)}");
                Console.WriteLine($"K(C_TGS): {Convert.ToBase64String(Settings.K_C_TGS)}");
                Console.WriteLine($"K(C_SS: {Convert.ToBase64String(Settings.K_C_SS)}");
                Console.WriteLine($"K(AS_TGS): {Convert.ToBase64String(Settings.K_AS_TGS)}");
                Console.WriteLine($"K(TGS_SS): {Convert.ToBase64String(Settings.K_TGS_SS)}");
                Console.WriteLine($"AS ticket duration: {Settings.ASTicketDuration}");
                Console.WriteLine($"TG sTicket duration: {Settings.TGSTicketDuration}");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

            Console.ReadLine();
        }
    }
}
