using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHKTPM18ATT_Tong_Phuc_Long_TienPhat.program
{
    public class TinhTienDienClass
    {
        public double TinhTienDien(int chiSoCu, int chiSoMoi)
        {
            
            if (chiSoCu > chiSoMoi || chiSoCu < 0 || chiSoMoi < 0)
                return -1;

            int soKW = chiSoMoi - chiSoCu;
            double tongTien = 0;

            int[] muc = { 50, 50, 100, 100, 100 }; // Giới hạn bậc
            int[] gia = { 1484, 1533, 1786, 2242, 2503, 2587 }; // Giá mỗi bậc

            int i = 0;
            while (soKW > 0 && i < muc.Length)
            {
                int soKWTinh = Math.Min(soKW, muc[i]);
                tongTien += soKWTinh * gia[i];
                soKW -= soKWTinh;
                i++;
            }

            
            if (soKW > 0)
            {
                tongTien += soKW * gia[5];
            }

            // Cộng VAT 10%
            tongTien *= 1.1;

            return tongTien;
        }

    }
}
