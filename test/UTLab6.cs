using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DHKTPM18ATT_Tong_Phuc_Long_TienPhat.program;

namespace DHKTPM18ATT_Tong_Phuc_Long_TienPhat.test
{
    [TestClass]
    public class UTLab6
    {
        public TestContext TestContext { get; set; }

        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "|DataDirectory|\\data\\UTLab06.csv",
            "UTLab06#csv",
            DataAccessMethod.Sequential),
        DeploymentItem("data\\UTLab06.csv"),
        TestMethod]
        public void TestThayThe()
        {
            // Lấy dữ liệu từ file CSV
            string s1 = TestContext.DataRow["s1"].ToString();
            string s2 = TestContext.DataRow["s2"].ToString();
            string s3 = TestContext.DataRow["s3"].ToString();
            string expected = TestContext.DataRow["ExpectedResult"].ToString();

            MethodLibrary.MethodLibrary o = new MethodLibrary.MethodLibrary();

            string actual = o.ThayThe(s1, s2, s3);
            Assert.AreEqual(expected, actual);
        }
    }
}
