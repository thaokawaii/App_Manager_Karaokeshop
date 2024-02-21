using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuanLy_Karaoke;

namespace Test_KhoHang
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_them()
        {
            BLL_KhoHang bll = new BLL_KhoHang();
            bool Result_Actual = bll.Check_NameProduct("anh");
            bool Result_Expect = true;
            Assert.AreEqual(Result_Expect, Result_Actual);

        }
        [TestMethod]
        public void Test_them01()
        {
            BLL_KhoHang bll = new BLL_KhoHang();
            bool Result_Actual = bll.ThemSP("HHH","10","100");
            bool Result_Expect = true;
            Assert.AreEqual(Result_Expect, Result_Actual);

        }
        [TestMethod]
        public void Test_Gia()
        {
            BLL_KhoHang bll = new BLL_KhoHang();
            bool Result_Actual = bll.Check_txtPrice("100");
            bool Result_Expect = true;
            Assert.AreEqual(Result_Expect, Result_Actual);

        }
        [TestMethod]
        public void Test_SoLuong()
        {
            BLL_KhoHang bll = new BLL_KhoHang();
            bool Result_Actual = bll.Check_txtQuantity("100");
            bool Result_Expect = true;
            Assert.AreEqual(Result_Expect, Result_Actual);

        }
        [TestMethod]
        public void Test_SoLuong2()
        {
            BLL_KhoHang bll = new BLL_KhoHang();
            bool Result_Actual = bll.Check_txtQuantity("dd");
            bool Result_Expect = true;
            Assert.AreEqual(Result_Expect, Result_Actual);

        }
    }
}
