using System;
using MoneyLover;
using NUnit.Framework;

namespace Sample.Test
{
    [TestFixture]
    class Class1
    {
        private DangKy dk;

        [SetUp]
        public void Setup()
        {
            dk = new DangKy();
        }

        [Test]
        public void OnePlusOneEqualTwo()
        {

          //  Assert.AreEqual(false, DangKy.IsValidEmail("thusang@123"));
        }
    }

}
