using System;

namespace DHKTPM18ATT_Tong_Phuc_Long_TienPhat.program
{
    public class Programs
    {
        /// <summary>
        /// Hàm trả về giá trị lớn nhất của ba số A,B,C trong miền [1,50].
        /// Nếu một giá trị không hợp lệ thì ném IndexOutOfRangeException.
        /// </summary>
        public static int Max(int A, int B, int C)
        {
            if (A < 1 || A > 50 || B < 1 || B > 50 || C < 1 || C > 50)
            {
                throw new IndexOutOfRangeException("Giá trị ngoài khoảng [1,50]");
            }

            return Math.Max(A, Math.Max(B, C));
        }
    }
}
