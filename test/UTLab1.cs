using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
            // Tạo đối tượng thư viện
            MethodLibrary.MethodLibrary m = new MethodLibrary.MethodLibrary();

            // Lấy dữ liệu từ CSV
            int a = Convert.ToInt32(TestContext.DataRow["a"]);
            int b = Convert.ToInt32(TestContext.DataRow["b"]);
            int c = Convert.ToInt32(TestContext.DataRow["c"]);
            string expected = TestContext.DataRow["Expected result"].ToString();

            // Nếu mong đợi exception
            if (expected == "IndexOutOfRangeException")
            {
                Assert.ThrowsException<IndexOutOfRangeException>(() =>
                {
                    m.Max(a, b, c);
                });
            }
            else
            {
                // Nếu mong đợi giá trị số
                int expectedValue = Convert.ToInt32(expected);
                int actual = m.Max(a, b, c);
                Assert.AreEqual(expectedValue, actual,
                    $"Test failed with input a={a}, b={b}, c={c}");
            }
        }
    }
}
