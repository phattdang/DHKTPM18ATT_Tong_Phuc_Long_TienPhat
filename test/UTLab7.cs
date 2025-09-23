using DHKTPM18ATT_Tong_Phuc_Long_TienPhat.program;
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
            // Lấy dữ liệu từ CSV
            string input = TestContext.DataRow["list"].ToString().Trim('"');
            string expectedStr = TestContext.DataRow["ExpectedResult"].ToString();

            // Chuyển đổi expected thành int
            int expected = string.IsNullOrEmpty(expectedStr) ? int.MaxValue : Convert.ToInt32(expectedStr);

            // Chuyển input thành mảng string
            string[] stringArray = string.IsNullOrEmpty(input) || input == "[]"
                ? new string[0]
                : input.Trim('[', ']').Split(',', (char)StringSplitOptions.RemoveEmptyEntries)
                      .Select(s => s.Trim()).ToArray();

            // Chuyển mảng string thành mảng int
            int[] intArray = new int[stringArray.Length];
            for (int i = 0; i < stringArray.Length; i++)
            {
                string s = stringArray[i].Replace(".", "");
                try
                {
                    intArray[i] = int.Parse(s);
                }
                catch (OverflowException)
                {
                    intArray[i] = int.MaxValue; // Gán MaxValue cho giá trị vượt quá
                }
                catch (FormatException)
                {
                    intArray[i] = 0; // Giá trị không hợp lệ
                }
            }

            // Gọi hàm FindLargest và so sánh
            int actual = Largest.FindLargest(intArray);
            Assert.AreEqual(expected, actual, $"Failed for input {input}. Expected {expected}, but got {actual}.");
        }
    }
}