using System;

namespace DHKTPM18ATT_Tong_Phuc_Long_TienPhat.program
{
    public class SolveQuadraticProgram
    {
        public static string SolveQuadratic(int a, int b, int c, out float x1, out float x2)
        {
            // Mặc định gán NaN
            x1 = float.NaN;
            x2 = float.NaN;

            // Trường hợp vô số nghiệm
            if (a == 0 && b == 0 && c == 0)
            {
                return "Vo so nghiem";
            }

            // Trường hợp vô nghiệm
            if (a == 0 && b == 0 && c != 0)
            {
                return "Vo nghiem";
            }

            // Trường hợp bậc nhất (a=0, b≠0)
            if (a == 0)
            {
                x1 = x2 = -((float)c / b);
                return "Co 1 nghiem";
            }

            // Tính delta
            double delta = b * b - 4 * a * c;

            if (delta < 0)
            {
                return "Vo nghiem";
            }
            else if (delta == 0)
            {
                x1 = x2 = -b / (2f * a);
                return "Co nghiem kep";
            }
            else
            {
                x1 = (float)((-b + Math.Sqrt(delta)) / (2 * a));
                x2 = (float)((-b - Math.Sqrt(delta)) / (2 * a));
                return "Co 2 nghiem phan biet";
            }
        }
    }
}
