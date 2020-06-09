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
            ProductEntity p = new ProductEntity(Ultility.getkalaBastei(), 120);

            Assert.IsNotNull(p.Kala);
            Assert.AreEqual(120, p.Tedad);
            Assert.AreEqual("12", p.TedadBaste);
            Assert.AreEqual(1, p.TedadPallet);
            Assert.AreEqual(800, p.getVazn());
        }

        [TestMethod]
        public void ProductEntityTest_NoBasteii_TedadEqual_IsOk()
        {
            ProductEntity p = new ProductEntity(Ultility.getkalaNoBastei(), 120);

            Assert.IsNotNull(p.Kala);
            Assert.AreEqual(120, p.Tedad);
            Assert.AreEqual("", p.TedadBaste);
            Assert.AreEqual(1, p.TedadPallet);
            Assert.AreEqual(800, p.getVazn());
        }

        [TestMethod]
        public void ProductEntityTest_NoBasteii_TedadLowerHalf_IsOk()
        {
            ProductEntity p = new ProductEntity(Ultility.getkalaNoBastei(), 50);

            Assert.AreEqual("", p.TedadBaste);
            Assert.AreEqual(0, p.TedadPallet);
            Assert.AreEqual(250, p.getVazn());
        }

        [TestMethod]
        public void ProductEntityTest_Basteii_TedadLowerHalf_IsOk()
        {
            ProductEntity p = new ProductEntity(Ultility.getkalaBastei(), 50);

            Assert.AreEqual("5", p.TedadBaste);
            Assert.AreEqual(0, p.TedadPallet);
            Assert.AreEqual(250, p.getVazn());
        }

        [TestMethod]
        public void ProductEntityTest_Basteii_TedadBiggerHalf_SetProperty_IsOk()
        {
            ProductEntity p = new ProductEntity(Ultility.getkalaBastei(), 70);

            Assert.AreEqual("7", p.TedadBaste);
            Assert.AreEqual(1, p.TedadPallet);
            Assert.AreEqual(550, p.getVazn());
        }

        [TestMethod]
        public void ProductEntityTest_NoBasteii_TedadBiggerHalf_SetProperty_IsOk()
        {
            ProductEntity p = new ProductEntity(Ultility.getkalaNoBastei(), 70);

            Assert.AreEqual("", p.TedadBaste);
            Assert.AreEqual(1, p.TedadPallet);
            Assert.AreEqual(550, p.getVazn());
        }

        [TestMethod]
        public void ProductEntityTest_NoBasteii_TedadNotBatch_SetProperty_IsOk()
        {
            ProductEntity p = new ProductEntity(Ultility.getkalaNoBastei(), 195);

            Assert.AreEqual("", p.TedadBaste);
            Assert.AreEqual(2, p.TedadPallet);
            Assert.AreEqual(1375, p.getVazn());
        }

        [TestMethod]
        public void ProductEntityTest_Basteii_TedadNotBatch_SetProperty_IsOk()
        {
            ProductEntity p = new ProductEntity(Ultility.getkalaBastei(), 195);

            Assert.AreEqual("19[5]", p.TedadBaste);
            Assert.AreEqual(2, p.TedadPallet);
            Assert.AreEqual(1375, p.getVazn());
        }

        [TestMethod]
        public void ProductEntityTest_Basteii_NoTedad_SetProperty_IsOk()
        {
            ProductEntity p = new ProductEntity(Ultility.getkalaBastei(), 0);

            Assert.AreEqual("0", p.TedadBaste);
            Assert.AreEqual(0, p.TedadPallet);
            Assert.AreEqual(0, p.getVazn());
        }

        [TestMethod]
        public void ProductEntityTest_NoBasteii_NoTedad_SetProperty_IsOk()
        {
            ProductEntity p = new ProductEntity(Ultility.getkalaNoBastei(), 0);

            Assert.AreEqual("", p.TedadBaste);
            Assert.AreEqual(0, p.TedadPallet);
            Assert.AreEqual(0, p.getVazn());
        }

        [TestMethod]
        public void ProductEntityTest_SetTedad_IsOk()
        {
            ProductEntity p = new ProductEntity(Ultility.getkalaNoBastei(), 100);
            p.Tedad = 120;

            Assert.AreEqual("", p.TedadBaste);
            Assert.AreEqual(1, p.TedadPallet);
            Assert.AreEqual(800, p.getVazn());
        }

        [TestMethod]
        public void ProductEntityTest_SetTedadPallet_IsOk()
        {
            ProductEntity p = new ProductEntity(Ultility.getkalaNoBastei(), 120);
            p.TedadPallet = 2;

            Assert.AreEqual("", p.TedadBaste);
            Assert.AreEqual(2, p.TedadPallet);
            Assert.AreEqual(1000, p.getVazn());
        }

        [ExpectedException(typeof(NullReferenceException))]
        [TestMethod]
        public void ProductEntityTest_EmptyName_Exception()
        {
            ProductEntity p = new ProductEntity(null, 200);
        }
    }
}