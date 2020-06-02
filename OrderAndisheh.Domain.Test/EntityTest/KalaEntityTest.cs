using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndisheh.Domain.Entity;
using System;

namespace OrderAndisheh.Domain.Test.EntityTest
{
    [TestClass]
    public class KalaEntityTest
    {
        [TestMethod]
        public void KalaEntity_SetProperty_IsOK()
        {
            PalletEntity pallet = new PalletEntity("GP8", 200);

            KalaEntity k = new KalaEntity("name", "codeAnbar", "fani", "jens",
                pallet, 120, 10, 800);

            Assert.AreEqual(k.CodeAnbar, "codeAnbar");
            Assert.AreEqual(k.CodeJense, "jens");
            Assert.AreEqual(k.Name, "name");
            Assert.AreEqual(k.FaniCode, "fani");
            Assert.AreEqual(k.TedadDarBaste, 10);
            Assert.AreEqual(k.TedadDarPallet, 120);
            Assert.AreEqual(k.WeighWithPallet, 800);
            Assert.AreEqual(k.Pallet, pallet);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void KalaEntity_EmptyName_Exception()
        {
            PalletEntity pallet = new PalletEntity("GP8", 200);

            KalaEntity k = new KalaEntity("", "codeAnbar", "fani", "jens", pallet, 120, 0, 800);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void KalaEntity_EmptyCodeAnbar_Exception()
        {
            PalletEntity pallet = new PalletEntity("GP8", 200);

            KalaEntity k = new KalaEntity("sadasd", "", "fani", "jens", pallet, 120, 0, 800);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void KalaEntity_EmptyNameAndCodeAnbar_Exception()
        {
            PalletEntity pallet = new PalletEntity("GP8", 200);

            KalaEntity k = new KalaEntity("", "", "fani", "jens", pallet, 120, 0, 800);
        }

        [ExpectedException(typeof(NullReferenceException))]
        [TestMethod]
        public void KalaEntity_Emptypallet_Exception()
        {
            KalaEntity k = new KalaEntity("dsf", "sdf", "fani", "jens", null, 120, 0, 800);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void KalaEntity_EmptyTadadDarPallet_Exception()
        {
            PalletEntity pallet = new PalletEntity("GP8", 200);

            KalaEntity k = new KalaEntity("sasd", "asd", "fani", "jens", pallet, 0, 0, 800);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void KalaEntity_EmptyWeight_Exception()
        {
            PalletEntity pallet = new PalletEntity("GP8", 200);

            KalaEntity k = new KalaEntity("sasd", "asd", "fani", "jens", pallet, 200, 0, 0);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void KalaEntity_EmptyAll_Exception()
        {
            PalletEntity pallet = new PalletEntity("GP8", 200);

            KalaEntity k = new KalaEntity("", "", "fani", "jens", null, 0, 0, 0);
        }
    }
}