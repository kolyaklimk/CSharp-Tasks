using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    public class Additionally
    {
        public static byte[] ExtendKey(string data)
        {
            StringBuilder stringBuilder = new StringBuilder(data);
            if (data.Length > 7)
            {
                return Encoding.UTF8.GetBytes(stringBuilder.Remove(7, data.Length - 7).ToString());
            }

            for (int i = 0; i < 7 - data.Length; i++)
            {
                stringBuilder.Append(data[i % data.Length]);
            }
            return Encoding.UTF8.GetBytes(stringBuilder.ToString());

        }

        public static bool TimeComparison(DateTime t1, DateTime t2, long duration)
        {
            if (t2 < t1 + new TimeSpan(duration)) return true;
            return false;
        }

        public static byte[] ExtendData(byte[] data)
        {
            int diff = 8 - (data.Length % 8);
            byte[] res = new byte[data.Length + diff];
            data.CopyTo(res, 0);
            return res;
        }

        public static byte[] RecoverData(List<byte> data)
        {
            int i = data.Count - 1;
            while (data[i] == 0)
            {
                data.RemoveRange(i, data.Count - i);
                i--;
            }
            return data.ToArray();
        }
    }
}
