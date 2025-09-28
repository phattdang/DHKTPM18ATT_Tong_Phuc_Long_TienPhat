using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

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
            MethodLibrary.MethodLibrary m = new MethodLibrary.MethodLibrary();
            string input = TestContext.DataRow["list"]?.ToString() ?? "";
            string leftStr = TestContext.DataRow["left"]?.ToString() ?? "";
            string rightStr = TestContext.DataRow["right"]?.ToString() ?? "";
            string expectedStr = TestContext.DataRow["ExpectedResult"]?.ToString() ?? "";
            Exception ex = null;

            // Chuyển input thành mảng string
            string[] stringArray = string.IsNullOrEmpty(input) || input == "[]"
                ? new string[0]
                : input.Trim('[', ']').Split(',', (char)StringSplitOptions.RemoveEmptyEntries)
                      .Select(s => s.Trim()).ToArray();

            // Chuyển mảng string thành mảng int
            int[] intArray = new int[stringArray.Length];

            try
            {

                for (int i = 0; i < stringArray.Length; i++)
                {
                    try
                    {
                        intArray[i] = int.Parse(stringArray[i]);
                    }
                    catch (Exception ex1)
                    {
                        ex = ex1;
                        Assert.IsNotNull(ex);
                    }
                }

                int leftValue = Convert.ToInt32(TestContext.DataRow["left"]);
                int rightValue = Convert.ToInt32(TestContext.DataRow["right"]);
                string actualResult = "[" + string.Join(",", intArray) + "]";
                m.QuickSort(intArray, leftValue, rightValue);
                actualResult = "[" + string.Join(",", intArray) + "]";
                Assert.AreEqual(expectedStr, actualResult);
            }
            catch (Exception ex2)
            {
                ex = ex2;
                Assert.IsNotNull(ex);
            }
            ;
        }
    }
}