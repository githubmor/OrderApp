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
            ProductEntity product = new ProductEntity(Ultility.getkalaBastei(), 120);

            Assert.IsNotNull(product.Kala);
            Assert.AreEqual(120, product.Tedad);
            Assert.AreEqual("12", product.TedadBaste);
            Assert.AreEqual(1, product.TedadPallet);
            Assert.AreEqual(800, product.getVazn());
        }

        [TestMethod]
        public void ProductEntityTest_NoBasteii_TedadEqual_IsOk()
        {
            ProductEntity product = new ProductEntity(Ultility.getkalaNoBastei(), 120);

            Assert.IsNotNull(product.Kala);
            Assert.AreEqual(120, product.Tedad);
            Assert.AreEqual("", product.TedadBaste);
            Assert.AreEqual(1, product.TedadPallet);
            Assert.AreEqual(800, product.getVazn());
        }

        [TestMethod]
        public void ProductEntityTest_NoBasteii_TedadLowerHalf_IsOk()
        {
            ProductEntity product = new ProductEntity(Ultility.getkalaNoBastei(), 50);

            Assert.AreEqual("", product.TedadBaste);
            Assert.AreEqual(0, product.TedadPallet);
            Assert.AreEqual(250, product.getVazn());
        }

        [TestMethod]
        public void ProductEntityTest_Basteii_TedadLowerHalf_IsOk()
        {
            ProductEntity product = new ProductEntity(Ultility.getkalaBastei(), 50);

            Assert.AreEqual("5", product.TedadBaste);
            Assert.AreEqual(0, product.TedadPallet);
            Assert.AreEqual(250, product.getVazn());
        }

        [TestMethod]
        public void ProductEntityTest_Basteii_TedadBiggerHalf_SetProperty_IsOk()
        {
            ProductEntity product = new ProductEntity(Ultility.getkalaBastei(), 70);

            Assert.AreEqual("7", product.TedadBaste);
            Assert.AreEqual(1, product.TedadPallet);
            Assert.AreEqual(550, product.getVazn());
        }

        [TestMethod]
        public void ProductEntityTest_NoBasteii_TedadBiggerHalf_SetProperty_IsOk()
        {
            ProductEntity product = new ProductEntity(Ultility.getkalaNoBastei(), 70);

            Assert.AreEqual("", product.TedadBaste);
            Assert.AreEqual(1, product.TedadPallet);
            Assert.AreEqual(550, product.getVazn());
        }

        [TestMethod]
        public void ProductEntityTest_NoBasteii_TedadNotBatch_SetProperty_IsOk()
        {
            ProductEntity product = new ProductEntity(Ultility.getkalaNoBastei(), 195);

            Assert.AreEqual("", product.TedadBaste);
            Assert.AreEqual(2, product.TedadPallet);
            Assert.AreEqual(1375, product.getVazn());
        }

        [TestMethod]
        public void ProductEntityTest_Basteii_TedadNotBatch_SetProperty_IsOk()
        {
            ProductEntity product = new ProductEntity(Ultility.getkalaBastei(), 195);

            Assert.AreEqual("19[5]", product.TedadBaste);
            Assert.AreEqual(2, product.TedadPallet);
            Assert.AreEqual(1375, product.getVazn());
        }

        [TestMethod]
        public void ProductEntityTest_Basteii_NoTedad_SetProperty_IsOk()
        {
            ProductEntity product = new ProductEntity(Ultility.getkalaBastei(), 0);

            Assert.AreEqual("0", product.TedadBaste);
            Assert.AreEqual(0, product.TedadPallet);
            Assert.AreEqual(0, product.getVazn());
        }

        [TestMethod]
        public void ProductEntityTest_NoBasteii_NoTedad_SetProperty_IsOk()
        {
            ProductEntity product = new ProductEntity(Ultility.getkalaNoBastei(), 0);

            Assert.AreEqual("", product.TedadBaste);
            Assert.AreEqual(0, product.TedadPallet);
            Assert.AreEqual(0, product.getVazn());
        }

        [TestMethod]
        public void ProductEntityTest_SetTedad_IsOk()
        {
            ProductEntity product = new ProductEntity(Ultility.getkalaNoBastei(), 100);
            product.Tedad = 120;

            Assert.AreEqual("", product.TedadBaste);
            Assert.AreEqual(1, product.TedadPallet);
            Assert.AreEqual(800, product.getVazn());
        }

        [TestMethod]
        public void ProductEntityTest_SetTedadPallet_IsOk()
        {
            ProductEntity product = new ProductEntity(Ultility.getkalaNoBastei(), 120);
            product.TedadPallet = 2;

            Assert.AreEqual("", product.TedadBaste);
            Assert.AreEqual(2, product.TedadPallet);
            Assert.AreEqual(1000, product.getVazn());
        }

        [ExpectedException(typeof(NullReferenceException))]
        [TestMethod]
        public void ProductEntityTest_EmptyName_Exception()
        {
            ProductEntity product = new ProductEntity(null, 200);
        }
    }
}