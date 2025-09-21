using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHKTPM18ATT_Tong_Phuc_Long_TienPhat.program
{
    public class Program
    {
        public static string HuyChuoi(string s, int n, int p)
        {
            if (string.IsNullOrEmpty(s)) return s;
            if (p < 0 || n < 0) return s;
            if (p >= s.Length) return s;

            if (n > s.Length - p)
            {
                return s.Substring(0, p);
            }

            string left = s.Substring(0, p);
            string right = s.Substring(p + n);
            return left + right;
        }
    }
}
