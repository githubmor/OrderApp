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
        public void TahvilOrderEntity_SetAll_IsOk()
        {
            TahvilOrderEntity tahvilOrder = new TahvilOrderEntity(13990208, Ultility.getTahvilList());

            Assert.AreEqual(1, tahvilOrder.TahvilFroshs.Count);
            Assert.IsNotNull(tahvilOrder.TahvilFroshs);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void TahvilOrderEntity_SetEmptyNullTahvilFroshs_IsOk()
        {
            TahvilOrderEntity tahvilOrder = new TahvilOrderEntity(13990208, new List<TahvilFroshEntity>());
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void TahvilOrderEntity_SetNullTahvilFroshs_IsOk()
        {
            TahvilOrderEntity tahvilOrder = new TahvilOrderEntity(13990208, null);
        }
    }
}