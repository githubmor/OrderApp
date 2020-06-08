using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndisheh.Domain.Entity;
using System;
using System.Collections.Generic;

namespace OrderAndisheh.Domain.Test.EntityTest
{
    [TestClass]
    public class MahmoleEntityTest
    {
        [TestMethod]
        public void MahmoleEntityTest_DefaultSet_IsOk()
        {
            MahmoleEntity m = new MahmoleEntity();

            Assert.IsNull(m.Destination);
            Assert.AreEqual("", m.DestinationName);
            Assert.IsNotNull(m.Products);
            Assert.AreEqual(0, m.Products.Count);
            Assert.AreEqual(0, m.getMahmoleVazn());
        }

        [TestMethod]
        public void MahmoleEntityTest_SetDestination_IsOk()
        {
            DestinationEntity d = new DestinationEntity("Saipa");
            MahmoleEntity m = new MahmoleEntity(d);

            Assert.IsNotNull(m.Destination);
            Assert.AreEqual("Saipa", m.DestinationName);
        }

        [TestMethod]
        public void MahmoleEntityTest_SetDestinationProducts_IsOk()
        {
            PalletEntity pallet = new PalletEntity("GP8", 200);

            KalaEntity kala = new KalaEntity("name", "codeAnbar", "fani", "jens",
                pallet, 120, 10, 800);

            ProductEntity p = new ProductEntity(kala, 120);
            DestinationEntity d = new DestinationEntity("Saipa");
            MahmoleEntity m = new MahmoleEntity(new List<ProductEntity>() { p },d);

            Assert.IsNotNull(m.Destination);
            Assert.AreEqual("Saipa", m.DestinationName);
            Assert.IsNotNull(m.Products);
            Assert.AreEqual(1, m.Products.Count);
            Assert.AreEqual(800, m.getMahmoleVazn());
        }

        [TestMethod]
        public void MahmoleEntityTest_SetProducts_IsOk()
        {
            PalletEntity pallet = new PalletEntity("GP8", 200);

            KalaEntity kala = new KalaEntity("name", "codeAnbar", "fani", "jens",
                pallet, 120, 10, 800);

            ProductEntity p = new ProductEntity(kala, 120);
            DestinationEntity d = new DestinationEntity("Saipa");
            MahmoleEntity m = new MahmoleEntity(new List<ProductEntity>() { p });

            Assert.IsNull(m.Destination);
            Assert.AreEqual("", m.DestinationName);
            Assert.IsNotNull(m.Products);
            Assert.AreEqual(1, m.Products.Count);
            Assert.AreEqual(800, m.getMahmoleVazn());
        }

        [TestMethod]
        public void MahmoleEntityTest_DefaultSet_AddProduct_IsOk()
        {
            PalletEntity pallet = new PalletEntity("GP8", 200);

            KalaEntity kala = new KalaEntity("name", "codeAnbar", "fani", "jens",
                pallet, 120, 10, 800);

            ProductEntity p = new ProductEntity(kala, 120);

            MahmoleEntity m = new MahmoleEntity();

            m.AddProduct(new List<ProductEntity>() { p });

            Assert.IsNotNull(m.Products);
            Assert.AreEqual(1, m.Products.Count);
            Assert.AreEqual(800, m.getMahmoleVazn());
        }

        [TestMethod]
        public void MahmoleEntityTest_SetDestinationNull_IsOk()
        {
            DestinationEntity d = new DestinationEntity("Saipa");
            MahmoleEntity m = new MahmoleEntity(d);

            m.Destination = null;

            Assert.IsNull(m.Destination);
            Assert.AreEqual("", m.DestinationName);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void MahmoleEntityTest_Add_IsOk()
        {
            PalletEntity pallet = new PalletEntity("GP8", 200);

            KalaEntity kala = new KalaEntity("name", "codeAnbar", "fani", "jens",
                pallet, 120, 10, 800);

            ProductEntity p = new ProductEntity(kala, 120);

            MahmoleEntity m = new MahmoleEntity(new List<ProductEntity>() { p });

            m.AddProduct(new List<ProductEntity>() { p });
        }
    }
}