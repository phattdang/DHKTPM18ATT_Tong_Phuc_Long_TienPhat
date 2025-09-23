namespace DHKTPM18ATT_Tong_Phuc_Long_TienPhat.program
{
    internal class QuickSort
    {
        public static void QuickSortt(int[] list, int left, int right)
        {
            // Điều kiện dừng: nếu left >= right, không cần sắp xếp
            if (left >= right)
            {
                return;
            }

            // Tìm chỉ số phân hoạch
            int pivotIndex = Partition(list, left, right);

            // Đệ quy sắp xếp hai nửa trái và phải của pivot
            QuickSortt(list, left, pivotIndex - 1);
            QuickSortt(list, pivotIndex + 1, right);
        }

        private static int Partition(int[] list, int left, int right)
        {
            // Chọn pivot là phần tử cuối cùng
            int pivot = list[right];
            int i = left - 1; // Chỉ số của phần tử nhỏ hơn pivot

            // Duyệt từ left đến right-1
            for (int j = left; j < right; j++)
            {
                // Nếu phần tử hiện tại nhỏ hơn hoặc bằng pivot
                if (list[j] <= pivot)
                {
                    i++; // Tăng chỉ số của vùng nhỏ hơn
                    // Hoán đổi phần tử tại i và j
                    Swap(list, i, j);
                }
            }

            // Đặt pivot vào vị trí đúng (sau phần tử nhỏ hơn cuối cùng)
            Swap(list, i + 1, right);
            return i + 1; // Trả về vị trí của pivot
        }

        private static void Swap(int[] list, int i, int j)
        {
            int temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
}