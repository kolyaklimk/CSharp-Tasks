using System;

namespace Lab2
{
    public static class Settings
    {
        public static readonly byte[] K_C = Additionally.ExtendKey("vzvrfdgvsdfasedg");
        public static readonly byte[] K_C_TGS = Additionally.ExtendKey("regrdsfgzsvres");
        public static readonly byte[] K_C_SS = Additionally.ExtendKey("grsvadfgeevcvx");
        public static readonly byte[] K_AS_TGS = Additionally.ExtendKey("vssdfgagvfds");
        public static readonly byte[] K_TGS_SS = Additionally.ExtendKey("ahadsfgfdasgarer");

        public const string tgs = "nbdfsfvadh";
        public const string ID_SS = "dfshfgdbvs";

        public static readonly TimeSpan ASTicketDuration = new TimeSpan(1, 0, 0);
        public static readonly TimeSpan TGSTicketDuration = new TimeSpan(1, 0, 0);


        public const int C_port = 8111;
        public const int AS_port = 8222;
        public const int SS_port = 8333;
        public const int TGS_port = 8444;
    }
}
