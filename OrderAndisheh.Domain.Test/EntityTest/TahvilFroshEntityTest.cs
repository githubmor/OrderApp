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
            TahvilFroshEntity tahvilFrosh = new TahvilFroshEntity(Ultility.getProductList(), 15);

            Assert.IsNotNull(tahvilFrosh.Products);
            Assert.AreEqual(15, tahvilFrosh.TahvilNumber);
        }
        
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void TahvilFroshEntityTest_emptyList_IsOk()
        {
            TahvilFroshEntity tahvilFrosh = new TahvilFroshEntity(new List<ProductEntity>(), 15);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void TahvilFroshEntityTest_NullList_IsOk()
        {
            TahvilFroshEntity tahvilFrosh = new TahvilFroshEntity(null, 15);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void TahvilFroshEntityTest_ZeroTahvilNumber_IsOk()
        {
            TahvilFroshEntity tahvilFrosh = new TahvilFroshEntity(Ultility.getProductList(), 0);
        }
    }
}