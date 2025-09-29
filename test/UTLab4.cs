using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DHKTPM18ATT_Tong_Phuc_Long_TienPhat.test
{
    [TestClass]
    public class UTLab4
    {
        [TestMethod]
        public void TestSum_Input_am1()
        {
            MethodLibrary.MethodLibrary o = new MethodLibrary.MethodLibrary();

            long expectedK = 1;
            long expectedS = 1;
            long actualK = o.Sum(-1, out long s);
          
            Assert.AreEqual(expectedK, actualK, $"Sai giá trị k: mong đợi {expectedK} nhưng nhận {actualK}");
            Assert.AreEqual(expectedS, s, $"Sai giá trị s: mong đợi {expectedS} nhưng nhận {s}");
        }
        [TestMethod]
        public void TestSum_Input_am3()
        {
            MethodLibrary.MethodLibrary o = new MethodLibrary.MethodLibrary();

            long expectedK = 1;
            long expectedS = 1;
            long actualK = o.Sum(-3, out long s);

            Assert.AreEqual(expectedK, actualK, $"Sai giá trị k: mong đợi {expectedK} nhưng nhận {actualK}");
            Assert.AreEqual(expectedS, s, $"Sai giá trị s: mong đợi {expectedS} nhưng nhận {s}");
        }

        [TestMethod]
        public void TestSum_Input_3()
        {
            MethodLibrary.MethodLibrary o = new MethodLibrary.MethodLibrary();

            long expectedK = 3;   
            long expectedS = 6;  

            long actualK = o.Sum(3, out long s);

            Assert.AreEqual(expectedK, actualK, $"Sai giá trị k: mong đợi {expectedK} nhưng nhận {actualK}");
            Assert.AreEqual(expectedS, s, $"Sai giá trị s: mong đợi {expectedS} nhưng nhận {s}");
        }
      
        [TestMethod]
        public void TestSum_Input_0()
        {
            MethodLibrary.MethodLibrary o = new MethodLibrary.MethodLibrary();

            long expectedK = 1;
            long expectedS = 1;

            long actualK = o.Sum(0, out long s);

            Assert.AreEqual(expectedK, actualK, $"Sai giá trị k: mong đợi {expectedK} nhưng nhận {actualK}");
            Assert.AreEqual(expectedS, s, $"Sai giá trị s: mong đợi {expectedS} nhưng nhận {s}");
        }
        [TestMethod]
        public void TestSum_Input_1()
        {
            MethodLibrary.MethodLibrary o = new MethodLibrary.MethodLibrary();

            long expectedK = 2;
            long expectedS = 3;

            long actualK = o.Sum(1, out long s);

            Assert.AreEqual(expectedK, actualK, $"Sai giá trị k: mong đợi {expectedK} nhưng nhận {actualK}");
            Assert.AreEqual(expectedS, s, $"Sai giá trị s: mong đợi {expectedS} nhưng nhận {s}");
        }

    }
}
