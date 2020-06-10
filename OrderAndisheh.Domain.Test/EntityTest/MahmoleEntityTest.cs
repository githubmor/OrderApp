using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndisheh.Domain.Entity;
using System;

namespace OrderAndisheh.Domain.Test.EntityTest
{
    [TestClass]
    public class MahmoleEntityTest
    {
        [TestMethod]
        public void MahmoleEntityTest_DefaultSet_IsOk()
        {
            MahmoleEntity mahmole = new MahmoleEntity();

            Assert.IsNull(mahmole.Destination);
            Assert.AreEqual("", mahmole.DestinationName);
            Assert.IsNotNull(mahmole.Products);
            Assert.AreEqual(0, mahmole.Products.Count);
            Assert.AreEqual(0, mahmole.getMahmoleVazn());
            Assert.AreEqual(0, mahmole.getMahmolePalletChobiCount());
            Assert.AreEqual(0, mahmole.getMahmolePalletCount());
            Assert.AreEqual(0, mahmole.getMahmolePalletFeleziCount());
        }

        [TestMethod]
        public void MahmoleEntityTest_SetDestination_IsOk()
        {
            MahmoleEntity mahmole = new MahmoleEntity(Ultility.getDestination());

            Assert.IsNotNull(mahmole.Destination);
            Assert.AreEqual("Saipa", mahmole.DestinationName);
        }

        [TestMethod]
        public void MahmoleEntityTest_SetDestinationAndProducts_IsOk()
        {
            MahmoleEntity mahmole = new MahmoleEntity(Ultility.getProductList_Default(), Ultility.getDestination());

            Assert.IsNotNull(mahmole.Destination);
            Assert.AreEqual("Saipa", mahmole.DestinationName);
            Assert.IsNotNull(mahmole.Products);
            Assert.AreEqual(1, mahmole.Products.Count);
        }

        [TestMethod]
        public void MahmoleEntityTest_getMahmolePalletChobiCount_IsOk()
        {
            MahmoleEntity mahmole = new MahmoleEntity(Ultility.getProductList_Default(), Ultility.getDestination());

            var re = mahmole.getMahmolePalletChobiCount();

            Assert.AreEqual(re, 1);
        }

        [TestMethod]
        public void MahmoleEntityTest_getMahmolePalletCount_IsOk()
        {
            MahmoleEntity mahmole = new MahmoleEntity(Ultility.getProductList_Default(), Ultility.getDestination());

            var re = mahmole.getMahmolePalletCount();

            Assert.AreEqual(re, 1);
        }

        [TestMethod]
        public void MahmoleEntityTest_getMahmolePalletFeleziCount_IsOk()
        {
            MahmoleEntity mahmole = new MahmoleEntity(Ultility.getProductList_Default(), Ultility.getDestination());

            var re = mahmole.getMahmolePalletFeleziCount();

            Assert.AreEqual(re, 0);
        }

        [TestMethod]
        public void MahmoleEntityTest_getMahmoleVazn_IsOk()
        {
            MahmoleEntity mahmole = new MahmoleEntity(Ultility.getProductList_Default(), Ultility.getDestination());

            var re = mahmole.getMahmoleVazn();

            Assert.AreEqual(re, 800);
        }

        [TestMethod]
        public void MahmoleEntityTest_SetProducts_IsOk()
        {
            MahmoleEntity mahmole = new MahmoleEntity(Ultility.getProductList_Default());

            Assert.IsNull(mahmole.Destination);
            Assert.AreEqual("", mahmole.DestinationName);
            Assert.IsNotNull(mahmole.Products);
            Assert.AreEqual(1, mahmole.Products.Count);
            Assert.AreEqual(800, mahmole.getMahmoleVazn());
        }

        [TestMethod]
        public void MahmoleEntityTest_AddProduct_IsOk()
        {
            MahmoleEntity mahmole = new MahmoleEntity();

            mahmole.AddProduct(Ultility.getProductList_Default());

            Assert.IsNotNull(mahmole.Products);
            Assert.AreEqual(1, mahmole.Products.Count);
            Assert.AreEqual(800, mahmole.getMahmoleVazn());
        }

        [TestMethod]
        public void MahmoleEntityTest_AddDestination_IsOk()
        {
            MahmoleEntity mahmole = new MahmoleEntity();

            mahmole.Destination = Ultility.getDestination();

            Assert.IsNotNull(mahmole.Destination);
            Assert.AreEqual("Saipa", mahmole.DestinationName);
        }

        [TestMethod]
        public void MahmoleEntityTest_AddProductNull_IsOk()
        {
            MahmoleEntity mahmole = new MahmoleEntity();

            mahmole.AddProduct(null);

            Assert.IsNotNull(mahmole.Products);
            Assert.AreEqual(0, mahmole.Products.Count);
            Assert.AreEqual(0, mahmole.getMahmoleVazn());
        }

        [TestMethod]
        public void MahmoleEntityTest_AddDestinationNull_IsOk()
        {
            MahmoleEntity mahmole = new MahmoleEntity(Ultility.getDestination());

            mahmole.Destination = null;

            Assert.IsNull(mahmole.Destination);
            Assert.AreEqual("", mahmole.DestinationName);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void MahmoleEntityTest_AddProductDuplicate_ExpectedException()
        {
            MahmoleEntity mahmole = new MahmoleEntity(Ultility.getProductList_Default());

            mahmole.AddProduct(Ultility.getProductList_Default());
        }
    }
}