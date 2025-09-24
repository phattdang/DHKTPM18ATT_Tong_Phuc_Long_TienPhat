using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DHKTPM18ATT_Tong_Phuc_Long_TienPhat.program;

namespace DHKTPM18ATT_Tong_Phuc_Long_TienPhat.test
{
    [TestClass]
    public class UTLab5
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