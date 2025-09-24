using Microsoft.VisualStudio.TestTools.UnitTesting;
using DHKTPM18ATT_Tong_Phuc_Long_TienPhat.program;
using System;
using System.Text;

namespace DHKTPM18ATT_Tong_Phuc_Long_TienPhat.test
{
    [TestClass]
    public class UTLab2
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "|DataDirectory|\\data\\UTLab02.csv",
            "UTLab02#csv",
            DataAccessMethod.Sequential)]
        [DeploymentItem("data\\UTLab02.csv")]
        public void TestSolveQuadratic()
        {
            // Đọc dữ liệu từ CSV
            int a = Convert.ToInt32(TestContext.DataRow["a"]);
            int b = Convert.ToInt32(TestContext.DataRow["b"]);
            int c = Convert.ToInt32(TestContext.DataRow["c"]);

            // Trim để tránh lỗi dấu cách / encoding
            string expectedResult = TestContext.DataRow["ExpectedResult"].ToString().Trim();

            // Parse x1,x2 từ CSV
            float expectedX1 = ParseFloat(TestContext.DataRow["x1"].ToString());
            float expectedX2 = ParseFloat(TestContext.DataRow["x2"].ToString());

            // Gọi phương thức giải phương trình
            float x1, x2;
            string actualResult = SolveQuadraticProgram.SolveQuadratic(a, b, c, out x1, out x2).Trim();

            // So sánh trạng thái nghiệm (bỏ dấu để tránh lỗi encoding)
            Assert.AreEqual(
                RemoveDiacritics(expectedResult),
                RemoveDiacritics(actualResult),
                $"Sai thông báo nghiệm với ({a},{b},{c})"
            );

            // So sánh nghiệm nếu có
            if (!float.IsNaN(expectedX1))
                Assert.AreEqual(expectedX1, (float)Math.Round(x1, 2), 0.001, "Sai giá trị x1");

            if (!float.IsNaN(expectedX2))
                Assert.AreEqual(expectedX2, (float)Math.Round(x2, 2), 0.001, "Sai giá trị x2");
        }

        // Hàm helper parse float, NaN nếu chuỗi là "NaN" hoặc lỗi parse
        private float ParseFloat(string s)
        {
            if (string.IsNullOrWhiteSpace(s) || s.Equals("NaN", StringComparison.OrdinalIgnoreCase))
                return float.NaN;

            return float.TryParse(s, out float result) ? result : float.NaN;
        }

        // Hàm bỏ dấu tiếng Việt
        private string RemoveDiacritics(string text)
        {
            if (string.IsNullOrEmpty(text)) return text;
            var normalized = text.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            foreach (var ch in normalized)
            {
                if (System.Globalization.CharUnicodeInfo.GetUnicodeCategory(ch)
                    != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(ch);
                }
            }
            return sb.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
