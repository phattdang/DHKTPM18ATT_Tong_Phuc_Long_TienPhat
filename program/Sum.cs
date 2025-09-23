using System;

namespace DHKTPM18ATT_Tong_Phuc_Long_TienPhat.program
{
    public class SumClass
    {
        public long Sum(long s0, out long s)
        {
            if (s0 < 0)
            {
                s = -1;
                return -1; 
            }

            long k = 0;
            s = 0;

            while (s <= s0)
            {
                k++;
                s += k;
            }

            return k;
        }
    }
}
