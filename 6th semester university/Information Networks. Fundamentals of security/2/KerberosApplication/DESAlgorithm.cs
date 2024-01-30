using System.Collections;
using System.Text;

namespace _2.KerberosApplication
{
    static public class DESAlgorithm
    {
        private readonly static int[] IP = new int[]
        {
            58,  50,  42,  34,  26,  18,  10,  02, 60,  52,  44,  36,  28,  20,  12,  04,
            62,  54,  46,  38,  30,  22,  14,  06, 64,  56,  48,  40,  32,  24,  16,  08,
            57,  49,  41,  33,  25,  17,  09,  01, 59,  51,  43,  35,  27,  19,  11,  03,
            61,  53,  45,  37,  29,  21,  13,  05, 63,  55,  47,  39,  31,  23,  15,  07,
        };

        private readonly static int[] IP_1 = new int[]
        {
            40,  08,  48,  16,  56,  24,  64,  32, 39,  07,  47,  15,  55,  23,  63,  31,
            38,  06,  46,  14,  54,  22,  62,  30, 37,  05,  45,  13,  53,  21,  61,  29,
            36,  04,  44,  12,  52,  20,  60,  28, 35,  03,  43,  11,  51,  19,  59,  27,
            34,  02,  42,  10,  50,  18,  58,  26, 33,  01,  41,  09,  49,  17,  57,  25,
        };

        static public string Encrypt(string text, string key)
        {
            if (text.Length % 8 != 0)
            {
                for (var i = 0; i < text.Length % 8; i++)
                {
                    text = ' ' + text;
                }
            }

            var bitkey = new BitArray(Encoding.ASCII.GetBytes(key[0..6]));

            for (var i = 0; i < text.Length; i += 8)
            {
                var bittext = new BitArray(Encoding.ASCII.GetBytes(text[i..(i + 7)]));

                var newbittext = new BitArray(64);
                for (var n = 0; n < IP.Length; n++)
                {
                    newbittext[n] = bittext[IP[n]];
                }

                BitArray Lbit = new BitArray(32);
                BitArray Rbit = new BitArray(32);
                for (var n = 0; n < 32; n++)
                {
                    Lbit[n] = newbittext[n];
                    Rbit[n + 32] = newbittext[n + 32];
                }

                for (var n = 0; n < 16; n++)
                {

                }
            }
            return "";
        }
    }
}
