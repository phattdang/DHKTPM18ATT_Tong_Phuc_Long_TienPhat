using DHKTPM18ATT_Tong_Phuc_Long_TienPhat.program;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DHKTPM18ATT_Tong_Phuc_Long_TienPhat.test
{
    [TestClass]
    public class UTLab5Test
    {
        public TestContext TestContext { get; set; }

        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "|DataDirectory|\\data\\UTLab05.csv",
            "UTLab05#csv",
            DataAccessMethod.Sequential),
        DeploymentItem("data\\UTLab05.csv"),
        TestMethod]
        public void TestHuyChuoi()
        {
            string input = TestContext.DataRow["s"].ToString();
            int n = Convert.ToInt32(TestContext.DataRow["n"]);
            int p = Convert.ToInt32(TestContext.DataRow["p"]);
            string expected = TestContext.DataRow["ExpectedResult"].ToString();

            string actual = HuyChuoiProgram.HuyChuoi(input, n, p);
            Assert.AreEqual(expected, actual);

        }
    }
}