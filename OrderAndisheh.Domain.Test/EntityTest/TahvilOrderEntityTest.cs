using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndisheh.Domain.Entity;
using System;
using System.Collections.Generic;

namespace OrderAndisheh.Domain.Test.EntityTest
{
    [TestClass]
    public class TahvilOrderEntityTest
    {
        [TestMethod]
        public void TahvilOrderEntity_SetProperty_IsOk()
        {
            TahvilOrderEntity b = new TahvilOrderEntity(13990208);

            Assert.AreEqual(13990208, b.Tarikh);
            Assert.AreEqual(0, b.TahvilFroshs.Count);
            Assert.IsNotNull( b.TahvilFroshs);
        }

        [TestMethod]
        public void TahvilOrderEntity_AddVersion_IsOk()
        {

            TahvilOrderEntity b = new TahvilOrderEntity(13990208,getTahvilList());

            Assert.AreEqual(1, b.TahvilFroshs.Count);
            Assert.IsNotNull(b.TahvilFroshs);
        }

        private List<TahvilFroshEntity> getTahvilList()
        {
            TahvilFroshEntity t = new TahvilFroshEntity(getProductList(), 15);
            return new List<TahvilFroshEntity>() { t };
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