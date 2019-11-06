using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MoneyLover.Test
{
    [TestFixture]
    class CalculatorTest
    {
       // public DangKy dk;

        [SetUp]
        public void Setup()
        {
          //  dk = new DangKy();
        }

        [Test]
        public void OnePlusOneEqualTwo()
        {
            //DangKy dk = new DangKy();
            Assert.AreEqual(false, DangKy.CheckPassword("thusang@123"));
            Assert.AreEqual(false, DangKy.CheckPassword("thusang123"));
            Assert.AreEqual(false, DangKy.CheckPassword(""));
            Assert.AreEqual(true, DangKy.CheckPassword("Thusang@123"));
        }


        [Test]
        public void TestEMail()
        {
            //DangKy dk = new DangKy();
            Assert.AreEqual(false, DangKy.IsValidEmail("thusang"));
            Assert.AreEqual(true, DangKy.IsValidEmail("abc@gmail.com"));
        }


    }




}
