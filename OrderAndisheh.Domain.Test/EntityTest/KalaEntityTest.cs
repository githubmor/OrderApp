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
            KalaEntity kala = new KalaEntity("name", "codeAnbar", "fani", "jens",
                Ultility.getpallet(), 120, 10, 800);

            Assert.AreEqual(kala.CodeAnbar, "codeAnbar");
            Assert.AreEqual(kala.CodeJense, "jens");
            Assert.AreEqual(kala.Name, "name");
            Assert.AreEqual(kala.FaniCode, "fani");
            Assert.AreEqual(kala.TedadDarBaste, 10);
            Assert.AreEqual(kala.TedadDarPallet, 120);
            Assert.AreEqual(kala.WeighWithPallet, 800);
            Assert.IsNotNull(kala.Pallet);
        }

        [TestMethod]
        public void KalaEntity_getOneProductVazn_IsOK()
        {
            KalaEntity kala = new KalaEntity("name", "codeAnbar", "fani", "jens",
                Ultility.getpallet(), 120, 10, 800);

            var re = kala.getOneProductVazn();

            Assert.AreEqual(5, re);
        }

        [TestMethod]
        public void KalaEntity_getPalletVazn_IsOK()
        {
            KalaEntity kala = new KalaEntity("name", "codeAnbar", "fani", "jens",
                Ultility.getpallet(), 120, 10, 800);

            var re = kala.getPalletVazn();

            Assert.AreEqual(200, re);
        }

        [TestMethod]
        public void KalaEntity_IsDoublePallet_IsOK()
        {
            KalaEntity kala = new KalaEntity("name", "codeAnbar", "fani", "jens",
                Ultility.getpallet(), 120, 10, 800);

            var re = kala.IsDoublePallet();

            Assert.IsFalse(re);
        }

        [TestMethod]
        public void KalaEntity_getVaznKhales_IsOK()
        {
            KalaEntity kala = new KalaEntity("name", "codeAnbar", "fani", "jens",
                Ultility.getpallet(), 120, 10, 800);

            var re = kala.getVaznKhales();

            Assert.AreEqual(600, re);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void KalaEntity_EmptyName_Exception()
        {
            KalaEntity kala = new KalaEntity("", "codeAnbar", "fani", "jens", Ultility.getpallet(), 120, 0, 800);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void KalaEntity_EmptyCodeAnbar_Exception()
        {
            KalaEntity kala = new KalaEntity("sadasd", "", "fani", "jens", Ultility.getpallet(), 120, 0, 800);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void KalaEntity_EmptyNameAndCodeAnbar_Exception()
        {
            KalaEntity kala = new KalaEntity("", "", "fani", "jens", Ultility.getpallet(), 120, 0, 800);
        }

        [ExpectedException(typeof(NullReferenceException))]
        [TestMethod]
        public void KalaEntity_Emptypallet_Exception()
        {
            KalaEntity kala = new KalaEntity("dsf", "sdf", "fani", "jens", null, 120, 0, 800);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void KalaEntity_EmptyTadadDarPallet_Exception()
        {
            KalaEntity kala = new KalaEntity("sasd", "asd", "fani", "jens", Ultility.getpallet(), 0, 0, 800);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void KalaEntity_EmptyWeight_Exception()
        {
            KalaEntity kala = new KalaEntity("sasd", "asd", "fani", "jens", Ultility.getpallet(), 200, 10, 0);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void KalaEntity_EmptyAll_Exception()
        {
            KalaEntity kala = new KalaEntity("", "", "fani", "jens", null, 0, 0, 0);
        }
    }
}