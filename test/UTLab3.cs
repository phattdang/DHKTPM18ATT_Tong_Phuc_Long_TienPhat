using DHKTPM18ATT_Tong_Phuc_Long_TienPhat.program;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;

namespace DHKTPM18ATT_Tong_Phuc_Long_TienPhat.test
{
    [TestClass]
    public class UTLab3
    {
        public TestContext TestContext { get; set; }

        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "|DataDirectory|\\data\\UTLab03.csv",
            "UTLab03#csv",
            DataAccessMethod.Sequential),
        DeploymentItem("data\\UTLab03.csv"),
        TestMethod]
        public void TestTinhTienDien()
        {

            int chiSoCu = int.Parse(TestContext.DataRow[0].ToString().Trim(), CultureInfo.InvariantCulture);
            int chiSoMoi = int.Parse(TestContext.DataRow[1].ToString().Trim(), CultureInfo.InvariantCulture);
            double expected = double.Parse(TestContext.DataRow[2].ToString().Trim(), CultureInfo.InvariantCulture);

            var tinhTien = new TinhTienDienClass();
            double actual = tinhTien.TinhTienDien(chiSoCu, chiSoMoi);

            Assert.AreEqual(expected, actual, 0.1,
                $"Sai ở case chiSoCu={chiSoCu}, chiSoMoi={chiSoMoi}");
        }
    }
}
