using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndisheh.Domain.Entity;
using System;

namespace OrderAndisheh.Domain.Test.EntityTest
{
    [TestClass]
    public class ProductEntityTest
    {
        [TestMethod]
        public void ProductEntityTest_Basteii_TedadEqual_IsOk()
        {
            PalletEntity pallet = new PalletEntity("GP8", 200);

            KalaEntity kala = new KalaEntity("name", "codeAnbar", "fani", "jens",
                pallet, 120, 10, 800);

            ProductEntity p = new ProductEntity(kala, 120);

            Assert.AreEqual(kala, p.Kala);
            Assert.AreEqual(120, p.Tedad);
            Assert.AreEqual("12", p.TedadBaste);
            Assert.AreEqual(1, p.TedadPallet);
            Assert.AreEqual(800, p.vazn);
        }

        [TestMethod]
        public void ProductEntityTest_NoBasteii_TedadEqual_IsOk()
        {
            PalletEntity pallet = new PalletEntity("GP8", 200);

            KalaEntity kala = new KalaEntity("name", "codeAnbar", "fani", "jens",
                pallet, 120, 0, 800);

            ProductEntity p = new ProductEntity(kala, 120);

            Assert.AreEqual(kala, p.Kala);
            Assert.AreEqual(120, p.Tedad);
            Assert.AreEqual("", p.TedadBaste);
            Assert.AreEqual(1, p.TedadPallet);
            Assert.AreEqual(800, p.vazn);
        }

        [TestMethod]
        public void ProductEntityTest_NoBasteii_TedadLowerHalf_IsOk()
        {
            PalletEntity pallet = new PalletEntity("GP8", 200);

            KalaEntity kala = new KalaEntity("name", "codeAnbar", "fani", "jens",
                pallet, 120, 0, 800);

            ProductEntity p = new ProductEntity(kala, 50);

            Assert.AreEqual("", p.TedadBaste);
            Assert.AreEqual(0, p.TedadPallet);
            Assert.AreEqual(250, p.vazn);
        }

        [TestMethod]
        public void ProductEntityTest_Basteii_TedadLowerHalf_IsOk()
        {
            PalletEntity pallet = new PalletEntity("GP8", 200);

            KalaEntity kala = new KalaEntity("name", "codeAnbar", "fani", "jens",
                pallet, 120, 10, 800);

            ProductEntity p = new ProductEntity(kala, 50);

            Assert.AreEqual("5", p.TedadBaste);
            Assert.AreEqual(0, p.TedadPallet);
            Assert.AreEqual(250, p.vazn);
        }

        [TestMethod]
        public void ProductEntityTest_Basteii_TedadBiggerHalf_SetProperty_IsOk()
        {
            PalletEntity pallet = new PalletEntity("GP8", 200);

            KalaEntity kala = new KalaEntity("name", "codeAnbar", "fani", "jens",
                pallet, 120, 10, 800);

            ProductEntity p = new ProductEntity(kala, 70);

            Assert.AreEqual("7", p.TedadBaste);
            Assert.AreEqual(1, p.TedadPallet);
            Assert.AreEqual(550, p.vazn);
        }

        [TestMethod]
        public void ProductEntityTest_NoBasteii_TedadBiggerHalf_SetProperty_IsOk()
        {
            PalletEntity pallet = new PalletEntity("GP8", 200);

            KalaEntity kala = new KalaEntity("name", "codeAnbar", "fani", "jens",
                pallet, 120, 0, 800);

            ProductEntity p = new ProductEntity(kala, 70);

            Assert.AreEqual("", p.TedadBaste);
            Assert.AreEqual(1, p.TedadPallet);
            Assert.AreEqual(550, p.vazn);
        }

        //[TestMethod]
        //public void ProductEntityTest_NoBasteii_TedadOneAndLowerHalf_SetProperty_IsOk()
        //{
        //    PalletEntity pallet = new PalletEntity("GP8", 200);

        //    KalaEntity kala = new KalaEntity("name", "codeAnbar", "fani", "jens",
        //        pallet, 120, 0, 800);

        //    ProductEntity p = new ProductEntity(kala, 170);

        //    Assert.AreEqual("", p.TedadBaste);
        //    Assert.AreEqual(1, p.TedadPallet);
        //    Assert.AreEqual(1050, p.vazn);
        //}
        //[TestMethod]
        //public void ProductEntityTest_Basteii_TedadOneAndLowerHalf_SetProperty_IsOk()
        //{
        //    PalletEntity pallet = new PalletEntity("GP8", 200);

        //    KalaEntity kala = new KalaEntity("name", "codeAnbar", "fani", "jens",
        //        pallet, 120, 10, 800);

        //    ProductEntity p = new ProductEntity(kala, 170);

        //    Assert.AreEqual("17", p.TedadBaste);
        //    Assert.AreEqual(1, p.TedadPallet);
        //    Assert.AreEqual(1050, p.vazn);
        //}

        //[TestMethod]
        //public void ProductEntityTest_Basteii_TedadOneAndBiggerHalf_SetProperty_IsOk()
        //{
        //    PalletEntity pallet = new PalletEntity("GP8", 200);

        //    KalaEntity kala = new KalaEntity("name", "codeAnbar", "fani", "jens",
        //        pallet, 120, 10, 800);

        //    ProductEntity p = new ProductEntity(kala, 190);

        //    Assert.AreEqual("19", p.TedadBaste);
        //    Assert.AreEqual(2, p.TedadPallet);
        //    Assert.AreEqual(1350, p.vazn);
        //}

        //[TestMethod]
        //public void ProductEntityTest_NoBasteii_TedadOneAndBiggerHalf_SetProperty_IsOk()
        //{
        //    PalletEntity pallet = new PalletEntity("GP8", 200);

        //    KalaEntity kala = new KalaEntity("name", "codeAnbar", "fani", "jens",
        //        pallet, 120, 0, 800);

        //    ProductEntity p = new ProductEntity(kala, 190);

        //    Assert.AreEqual("", p.TedadBaste);
        //    Assert.AreEqual(2, p.TedadPallet);
        //    Assert.AreEqual(1350, p.vazn);
        //}

        [TestMethod]
        public void ProductEntityTest_NoBasteii_TedadNotBatch_SetProperty_IsOk()
        {
            PalletEntity pallet = new PalletEntity("GP8", 200);

            KalaEntity kala = new KalaEntity("name", "codeAnbar", "fani", "jens",
                pallet, 120, 0, 800);

            ProductEntity p = new ProductEntity(kala, 195);

            Assert.AreEqual("", p.TedadBaste);
            Assert.AreEqual(2, p.TedadPallet);
            Assert.AreEqual(1375, p.vazn);
        }

        [TestMethod]
        public void ProductEntityTest_Basteii_TedadNotBatch_SetProperty_IsOk()
        {
            PalletEntity pallet = new PalletEntity("GP8", 200);

            KalaEntity kala = new KalaEntity("name", "codeAnbar", "fani", "jens",
                pallet, 120, 10, 800);

            ProductEntity p = new ProductEntity(kala, 195);

            Assert.AreEqual("19[5]", p.TedadBaste);
            Assert.AreEqual(2, p.TedadPallet);
            Assert.AreEqual(1375, p.vazn);
        }

        [TestMethod]
        public void ProductEntityTest_Basteii_NoTedad_SetProperty_IsOk()
        {
            PalletEntity pallet = new PalletEntity("GP8", 200);

            KalaEntity kala = new KalaEntity("name", "codeAnbar", "fani", "jens",
                pallet, 120, 10, 800);

            ProductEntity p = new ProductEntity(kala, 0);

            Assert.AreEqual("0", p.TedadBaste);
            Assert.AreEqual(0, p.TedadPallet);
            Assert.AreEqual(0, p.vazn);
        }

        [TestMethod]
        public void ProductEntityTest_NoBasteii_NoTedad_SetProperty_IsOk()
        {
            PalletEntity pallet = new PalletEntity("GP8", 200);

            KalaEntity kala = new KalaEntity("name", "codeAnbar", "fani", "jens",
                pallet, 120, 0, 800);

            ProductEntity p = new ProductEntity(kala, 0);

            Assert.AreEqual("", p.TedadBaste);
            Assert.AreEqual(0, p.TedadPallet);
            Assert.AreEqual(0, p.vazn);
        }

        [TestMethod]
        public void ProductEntityTest_SetTedad_IsOk()
        {
            PalletEntity pallet = new PalletEntity("GP8", 200);

            KalaEntity kala = new KalaEntity("name", "codeAnbar", "fani", "jens",
                pallet, 120, 0, 800);

            ProductEntity p = new ProductEntity(kala, 100);
            p.Tedad = 120;

            Assert.AreEqual("", p.TedadBaste);
            Assert.AreEqual(1, p.TedadPallet);
            Assert.AreEqual(800, p.vazn);
        }

        [TestMethod]
        public void ProductEntityTest_SetTedadPallet_IsOk()
        {
            PalletEntity pallet = new PalletEntity("GP8", 200);

            KalaEntity kala = new KalaEntity("name", "codeAnbar", "fani", "jens",
                pallet, 120, 0, 800);

            ProductEntity p = new ProductEntity(kala, 120);
            p.TedadPallet = 2;

            Assert.AreEqual("", p.TedadBaste);
            Assert.AreEqual(2, p.TedadPallet);
            Assert.AreEqual(1000, p.vazn);
        }

        [ExpectedException(typeof(NullReferenceException))]
        [TestMethod]
        public void ProductEntityTest_EmptyName_Exception()
        {
            ProductEntity p = new ProductEntity(null, 200);
        }
    }
}