using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DHKTPM18ATT_Tong_Phuc_Long_TienPhat.program;
using System.Globalization;

namespace DHKTPM18ATT_Tong_Phuc_Long_TienPhat.test
{
    [TestClass]
    public class UTLab4
    {
        public TestContext TestContext { get; set; }

        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "|DataDirectory|\\data\\UTLab04.csv",
            "UTLab04#csv",
            DataAccessMethod.Sequential)]
        [DeploymentItem("data\\UTLab04.csv")]
        [TestMethod]
        public void TestSum()
        {
           
            string s0Raw = TestContext.DataRow[0].ToString().Trim();
            long s0 = long.Parse(s0Raw, CultureInfo.InvariantCulture);

            string expectedRaw = TestContext.DataRow[1].ToString().Trim();
         
            string expected = expectedRaw;
            if (expected.StartsWith("\"") && expected.EndsWith("\"") && expected.Length >= 2)
            {
                expected = expected.Substring(1, expected.Length - 2);
            }
            expected = expected.Trim();

            var sumClass = new SumClass();
            string actual;

            try
            {
                long actualK = sumClass.Sum(s0, out long actualS);

                
                if (actualK == -1 || actualS == -1)
                {
                    actual = "Thong bao loi: Gia tri nhap vao phai lon hon hoac bang 0";
                }
                else
                {
                    actual = $"k={actualK}, s={actualS}";
                }
            }
            catch (ArgumentException ex)
            {
               
                actual = "Thong bao loi: " + ex.Message;
            }

            Assert.AreEqual(expected, actual,
                $"Sai o case s0={s0}. Expected='{expected}', Actual='{actual}'");
        }
    }
}
