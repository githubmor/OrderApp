using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndisheh.Domain.Entity;
using System;
using System.Collections.Generic;

namespace OrderAndisheh.Domain.Test.EntityTest
{
    [TestClass]
    public class ShakhesEntityTest
    {
        [TestMethod]
        public void ShakhesEntity_SetDafult_IsOk()
        {
            ShakhesEntity shakhes = new ShakhesEntity(Ultility.getErsaliSherkat(),
                Ultility.getCustomerTolidi());

            Assert.IsNotNull(shakhes.CustomerTolidi);
            Assert.IsNotNull(shakhes.ErsaliSherkat);
        }

        [TestMethod]
        public void ShakhesEntity_getDarsadSahm_IsOk()
        {
            ShakhesEntity shakhes = new ShakhesEntity(Ultility.getErsaliSherkat(),
                Ultility.getCustomerTolidi());
            var re = shakhes.getDarsadSahm(new BaseSherkatEntity("Andisheh"), new BaseCustomerEntity("Sapco"));

            Assert.AreEqual(5, re);
        }

        [TestMethod]
        public void ShakhesEntity_getDarsadSahmDic_IsOk()
        {
            ShakhesEntity shakhes = new ShakhesEntity(Ultility.getErsaliSherkat(),
                Ultility.getCustomerTolidi());
            var re = shakhes.getDarsadSahmDic();

            Assert.AreEqual(1, re.Count);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void ShakhesEntity_emptyAll_ExpectedException()
        {
            ShakhesEntity shakhes = new ShakhesEntity(new List<ErsaliSherkatEntity>(),
                new List<CustomerTolidiEntity>());
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void ShakhesEntity_EmptyErsali_ExpectedException()
        {
            ShakhesEntity shakhes = new ShakhesEntity(new List<ErsaliSherkatEntity>(),
                Ultility.getCustomerTolidi());
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void ShakhesEntity_EmptyTolidi_ExpectedException()
        {
            ShakhesEntity shakhes = new ShakhesEntity(Ultility.getErsaliSherkat(),
                new List<CustomerTolidiEntity>());
        }
    }
}