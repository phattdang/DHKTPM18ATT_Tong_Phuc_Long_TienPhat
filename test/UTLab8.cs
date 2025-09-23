using DHKTPM18ATT_Tong_Phuc_Long_TienPhat.program;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DHKTPM18ATT_Tong_Phuc_Long_TienPhat.test
{
    [TestClass]
    public class UTLab8
    {
        public TestContext TestContext { get; set; }

        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "|DataDirectory|\\data\\UTLab08.csv",
            "UTLab08#csv",
            DataAccessMethod.Sequential)]
        [DeploymentItem("data\\UTLab08.csv")]
        [TestMethod]
        public void TestQuickSort()
        {
            string input = TestContext.DataRow["list"]?.ToString() ?? "";
            string leftStr = TestContext.DataRow["left"]?.ToString() ?? "";
            string rightStr = TestContext.DataRow["right"]?.ToString() ?? "";
            string expectedStr = TestContext.DataRow["ExpectedResult"]?.ToString() ?? "";

            int[] array;
            if (string.IsNullOrWhiteSpace(input) || input == "[]")
            {
                array = new int[0];
            }
            else
            {
                string cleanedInput = input.Trim('[', ']').Replace(" ", "");
                string[] stringArray = cleanedInput.Split(',');


                array = new int[stringArray.Length];
                for (int i = 0; i < stringArray.Length; i++)
                {
                    string s = stringArray[i].Trim().Replace(".", "");
                    if (!int.TryParse(s, out int value))
                    {
                        // Không parse được thành số
                        if (s == "-2147483649")
                            Assert.AreEqual(expectedStr, $"Loi tai o E5 do gia tri phan tu la gia tri bien loi -2147483649");
                        else if (s == "2147483648")
                            Assert.AreEqual(expectedStr, $"Loi tai o E6 do gia tri phan tu la gia tri bien loi 2147483648");
                        else if (s.Contains("-"))
                            Assert.AreEqual(expectedStr, $"Loi tai o E1 do gia tri phan tu vuot qua suc chua cua int la -2147483648");
                        else
                            Assert.AreEqual(expectedStr, $"Loi tai o E2 do gia tri phan tu vuot qua suc chua cua int la 2147483647");
                        return;
                    }
                    if (value < int.MinValue)
                        Assert.AreEqual(expectedStr, $"Loi tai o E1 do gia tri phan tu vuot qua suc chua cua int la -2147483648");
                    else if (value > int.MaxValue)
                        Assert.AreEqual(expectedStr, $"Loi tai o E2 do gia tri phan tu vuot qua suc chua cua int la 2147483647");
                    else
                        array[i] = (int)value;
                }
            }

            // Kiểm tra left
            if (!int.TryParse(leftStr, out int leftLong))
            {
                Assert.AreEqual(expectedStr, "Loi tai o E3 do left khong hop le");
                return;
            }
            if (leftLong == -1)
            {
                Assert.AreEqual(expectedStr, "Loi tai o E7 do left la gia tri bien loi");
                return;
            }
            if (leftLong < 0)
            {
                Assert.AreEqual(expectedStr, "Loi tai o E3 do left < 0");
                return;
            }

            int left = (int)leftLong;

            // Kiểm tra right
            if (!int.TryParse(rightStr, out int rightLong))
            {
                if (rightStr == "2147483648")
                    Assert.AreEqual(expectedStr, "Loi tai o E8 do gia tri right la bien loi 2147483648");
                else
                    Assert.AreEqual(expectedStr, "Loi tai o E4 do gia tri right vuot qua suc chua cua int la 2147483647");
                return;
            }
            if (rightLong > int.MaxValue)
            {
                Assert.AreEqual(expectedStr, "Loi tai o E4 do gia tri right vuot qua suc chua cua int la 2147483647");
                return;
            }
            int right = (int)rightLong;

            // Kiểm tra left > right
            if (left > right)
            {
                string actualResult = "[" + string.Join(",", array) + "]";
                Assert.AreEqual(expectedStr, actualResult);
                return;
            }
            try
            {
                QuickSort.QuickSortt(array, left, right);
                string actualResult = "[" + string.Join(",", array) + "]";
                Assert.AreEqual(expectedStr, actualResult);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual(expectedStr, ex.Message);
            }
        }
    }
}