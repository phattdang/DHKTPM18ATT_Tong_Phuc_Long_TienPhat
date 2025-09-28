using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace DHKTPM18ATT_Tong_Phuc_Long_TienPhat.test
{
    [TestClass]
    public class UTLab7
    {
        public TestContext TestContext { get; set; }

        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "|DataDirectory|\\data\\UTLab07.csv",
            "UTLab07#csv",
            DataAccessMethod.Sequential),
        DeploymentItem("data\\UTLab07.csv"),
        TestMethod]
        public void TestFindLargest()
        {
            MethodLibrary.MethodLibrary m = new MethodLibrary.MethodLibrary();

            // Lấy dữ liệu từ CSV
            string input = TestContext.DataRow["list"].ToString().Trim('"');
            int expected = Convert.ToInt32(TestContext.DataRow["ExpectedResult"]);

            // Chuyển input thành mảng string
            string[] stringArray = string.IsNullOrEmpty(input) || input == "[]"
                ? new string[0]
                : input.Trim('[', ']').Split(',', (char)StringSplitOptions.RemoveEmptyEntries)
                      .Select(s => s.Trim()).ToArray();

            // Chuyển mảng string thành mảng int
            int[] intArray = new int[stringArray.Length];

            Exception ex = null;
            for (int i = 0; i < stringArray.Length; i++)
            {
                try
                {
                    intArray[i] = int.Parse(stringArray[i]);
                }
                catch (Exception e)
                {
                    ex = e;
                    Assert.IsNotNull(ex);
                }
            }

            int actual = m.Largest(intArray);
            Assert.AreEqual(expected, actual);
        }
    }
}