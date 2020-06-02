using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndisheh.Domain.Entity;
using System;

namespace OrderAndisheh.Domain.Test.EntityTest
{
    [TestClass]
    public class PalletEntityTest
    {
        [TestMethod]
        public void PalletEntityTest_SetProperty_IsOk()
        {
            PalletEntity p = new PalletEntity("name", 200);

            Assert.AreEqual("name", p.Name);
            Assert.AreEqual(200, p.Vazn);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void PalletEntityTest_EmptyName_Exception()
        {
            PalletEntity p = new PalletEntity("", 100);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void PalletEntityTest_EmptyVazn_Exception()
        {
            PalletEntity p = new PalletEntity("dsfs", 0);
        }
    }
}