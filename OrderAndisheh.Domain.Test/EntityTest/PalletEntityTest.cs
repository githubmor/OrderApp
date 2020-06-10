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
            PalletEntity pallet = new PalletEntity("name", 200, true);

            Assert.AreEqual("name", pallet.Name);
            Assert.AreEqual(200, pallet.Vazn);
            Assert.IsTrue(pallet.IsFelezi);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void PalletEntityTest_EmptyName_Exception()
        {
            PalletEntity pallet = new PalletEntity("", 100, false);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void PalletEntityTest_EmptyVazn_Exception()
        {
            PalletEntity pallet = new PalletEntity("dsfs", 0, false);
        }
    }
}