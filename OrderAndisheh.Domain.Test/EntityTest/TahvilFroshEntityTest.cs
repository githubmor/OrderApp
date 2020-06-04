using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndisheh.Domain.Entity;
using System;
using System.Collections.Generic;

namespace OrderAndisheh.Domain.Test.EntityTest
{
    [TestClass]
    public class TahvilFroshEntityTest
    {
        [TestMethod]
        public void TahvilFroshEntityTest_DefaultSet_IsOk()
        {

            TahvilFroshEntity t = new TahvilFroshEntity(getProductList(), 15);

            Assert.IsNotNull(t.Products);
            Assert.AreEqual(15, t.TahvilNumber);
        }
        
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void TahvilFroshEntityTest_emptyList_IsOk()
        {
            TahvilFroshEntity t = new TahvilFroshEntity(new List<ProductEntity>(), 15);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void TahvilFroshEntityTest_ZeroTahvilNumber_IsOk()
        {
            TahvilFroshEntity t = new TahvilFroshEntity(getProductList(), 0);
        }

        private static List<ProductEntity> getProductList()
        {
            PalletEntity pallet = new PalletEntity("GP8", 200);

            KalaEntity kala = new KalaEntity("name", "codeAnbar", "fani", "jens",
                pallet, 120, 10, 800);

            ProductEntity p = new ProductEntity(kala, 120);
            return new List<ProductEntity>() { p };
        }
    }
}