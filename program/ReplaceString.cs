using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHKTPM18ATT_Tong_Phuc_Long_TienPhat.program
{
    public class ReplaceStringProgram
    {
        // Hàm ReplaceString
        public static string ReplaceString(string s1, string s2, string s3)
        {
            if (string.IsNullOrEmpty(s1) && string.IsNullOrEmpty(s2) && string.IsNullOrEmpty(s3))
                return "";

            if (string.IsNullOrEmpty(s2))
                return s1;

            if (string.IsNullOrEmpty(s3))
                return s1.Replace(s2, "");

            if (!s1.Contains(s2))
                return s1;

            return s1.Replace(s2, s3);
        }
    }
}
