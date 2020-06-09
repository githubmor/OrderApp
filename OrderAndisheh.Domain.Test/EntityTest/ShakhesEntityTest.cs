using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndisheh.Domain.Entity;
using System.Collections.Generic;

namespace OrderAndisheh.Domain.Test.EntityTest
{
    [TestClass]
    public class ShakhesEntityTest
    {
        [TestMethod]
        public void ShakhesEntity_SetDafult_IsOk()
        {
            ShakhesEntity s = new ShakhesEntity(Ultility.getErsaliSherkat(), 
                Ultility.getCustomerTolidi());

            Assert.IsNotNull(s.CustomerTolidi);
            Assert.IsNotNull(s.ErsaliSherkat);
        }

        [TestMethod]
        public void ShakhesEntity_getDarsadSahm_IsOk()
        {
            ShakhesEntity s = new ShakhesEntity(Ultility.getErsaliSherkat(),
                Ultility.getCustomerTolidi());
             var re = s.getDarsadSahm(new BaseSherkatEntity("Andisheh"), new BaseCustomerEntity("Sapco"));

            Assert.AreEqual(5,re );
        }


        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void ShakhesEntity_emptyAll_ExpectedException()
        {
            ShakhesEntity s = new ShakhesEntity(new List<ErsaliSherkatEntity>(), 
                new List<CustomerTolidiEntity>());
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void ShakhesEntity_EmptyErsali_ExpectedException()
        {
            ShakhesEntity s = new ShakhesEntity(new List<ErsaliSherkatEntity>(), 
                Ultility.getCustomerTolidi());
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void ShakhesEntity_EmptyTolidi_ExpectedException()
        {
            ShakhesEntity s = new ShakhesEntity(Ultility.getErsaliSherkat(),
                new List<CustomerTolidiEntity>());
        }


    }
}
