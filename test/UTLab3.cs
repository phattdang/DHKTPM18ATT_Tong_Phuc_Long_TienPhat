using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


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
            MethodLibrary.MethodLibrary o = new MethodLibrary.MethodLibrary();
            int chiSoCu, chiSoMoi;
            chiSoCu = Convert.ToInt32(TestContext.DataRow[0]);
            chiSoMoi = Convert.ToInt32(TestContext.DataRow[1]);
            double kq_mongdoi = Convert.ToDouble(TestContext.DataRow[2]);
            double kq_thucte = o.TinhTienDien(chiSoCu, chiSoMoi);

            Assert.AreEqual(kq_mongdoi, kq_thucte, 0.001);
        }
    }
}
