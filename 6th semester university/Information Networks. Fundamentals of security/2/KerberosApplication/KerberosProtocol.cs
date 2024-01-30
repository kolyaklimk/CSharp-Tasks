namespace _2.KerberosApplication
{
    static class KerberosProtocol
    {
        static private Dictionary<string, KDC> id = new Dictionary<string, KDC>() { { "KlimkovichNikolay153504", new KDC() { KC = "Victoro" } } };

        static public object AuthenticationServer(string _id)
        {
            if (id.ContainsKey(_id))
            {
                id[_id].K_AS_TGS = Methods.GenerateRandomString(7);

                var k_c_tgs = Methods.GenerateRandomString(7);

                TGT tgt = new TGT()
                {
                    c = _id,
                    tgs = "tgs_server",
                    t1 = DateTime.UtcNow.ToString(),
                    p1 = TimeSpan.FromHours(1).ToString(),
                    K_C_TGS = k_c_tgs,
                };

                string tgt_str = $"{tgt.c}\n{tgt.tgs}\n{tgt.t1}\n{tgt.p1}\n{tgt.K_C_TGS}";

                // зашифровать tgt где ключ K_AS_TGS

                // зашифровать прошлую зашифровку вместе с K_C_TGS где ключ КС

                return null;
            }
            else
            {
                return null;
            }
        }
    }
}
