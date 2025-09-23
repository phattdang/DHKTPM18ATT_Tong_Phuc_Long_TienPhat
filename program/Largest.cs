namespace DHKTPM18ATT_Tong_Phuc_Long_TienPhat.program
{
    internal class Largest
    {
        public static int FindLargest(int[] a)
        {
            if (a == null || a.Length == 0)
            {
                return int.MaxValue; // 2147483647
            }

            int max = a[0];
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] > max)
                {
                    max = a[i];
                }
            }

            return max;
        }
    }
}