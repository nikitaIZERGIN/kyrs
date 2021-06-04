using ClassPenkin;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace UnitTestPenkin
{
    [TestClass]
    public class UnitTest1
    {
        static Class1 disk__price;
        [ClassInitialize]
        static public void Init(TestContext tc)
        {
            disk__price = new Class1();
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(disk__price.DiscountPrice(100), 1500);
        }
        [TestMethod]
        public void SalaryNotNull()
        {
            Assert.AreEqual(disk__price.SalaryNotNull(-12), "цена не может быть меньше или равана нулю  или больше 100000");
        }
    }
}
