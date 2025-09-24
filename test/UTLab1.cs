using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DHKTPM18ATT_Tong_Phuc_Long_TienPhat.program;

namespace DHKTPM18ATT_Tong_Phuc_Long_TienPhat.test
{
    [TestClass]
    public class UTLab1
    {
        public TestContext TestContext { get; set; }

        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "|DataDirectory|\\data\\UTLab01.csv",
            "UTLab01#csv",
            DataAccessMethod.Sequential),
        DeploymentItem("data\\UTLab01.csv"),
        TestMethod]
        public void TestMax()
        {
            int a = Convert.ToInt32(TestContext.DataRow["a"]);
            int b = Convert.ToInt32(TestContext.DataRow["b"]);
            int c = Convert.ToInt32(TestContext.DataRow["c"]);
            string expected = TestContext.DataRow["Expected result"].ToString();

            if (expected == "IndexOutOfRangeException")
            {
                Assert.ThrowsException<IndexOutOfRangeException>(() =>
                {
                    Programs.Max(a, b, c);
                });
            }
            else
            {
                int expectedValue = Convert.ToInt32(expected);
                int actual = Programs.Max(a, b, c);
                Assert.AreEqual(expectedValue, actual);
            }
        }
    }
}
