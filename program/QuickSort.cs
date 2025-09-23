namespace DHKTPM18ATT_Tong_Phuc_Long_TienPhat.program
{
    internal class QuickSort
    {
        public static void QuickSortt(int[] list, int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            int pivotIndex = Partition(list, left, right);

            QuickSortt(list, left, pivotIndex - 1);
            QuickSortt(list, pivotIndex + 1, right);
        }

        private static int Partition(int[] list, int left, int right)
        {

            int pivot = list[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {

                if (list[j] <= pivot)
                {
                    i++;

                    Swap(list, i, j);
                }
            }
            Swap(list, i + 1, right);
            return i + 1;
        }

        private static void Swap(int[] list, int i, int j)
        {
            int temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
}