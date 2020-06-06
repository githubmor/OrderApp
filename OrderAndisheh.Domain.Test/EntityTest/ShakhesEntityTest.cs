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
            ShakhesEntity s = new ShakhesEntity(getErsaliSherkat(),getCustomerTolidi());

            Assert.IsNotNull(s.CustomerTolidi);
            Assert.IsNotNull(s.ErsaliSherkat);
            Assert.AreEqual(5,s.getDarsadSahm(new BaseSherkatEntity("Andisheh"),new BaseCustomerEntity("Sapco")));
        }


        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void ShakhesEntity_NullErsali_ExpectedException()
        {
            ShakhesEntity s = new ShakhesEntity(new List<ErsaliSherkatEntity>(), new List<CustomerTolidiEntity>());
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void ShakhesEntity_ZeroZarib_ExpectedException()
        {
            ShakhesEntity s = new ShakhesEntity(new List<ErsaliSherkatEntity>(), getCustomerTolidi());
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void ShakhesEntity_EmptyTolidi_ExpectedException()
        {
            ShakhesEntity s = new ShakhesEntity(getErsaliSherkat(), new List<CustomerTolidiEntity>());
        }

        private List<CustomerTolidiEntity> getCustomerTolidi()
        {
            return new List<CustomerTolidiEntity>() { new CustomerTolidiEntity("Sapco", getAmarTolids()) };
        }

        private List<ErsaliSherkatEntity> getErsaliSherkat()
        {
            return new List<ErsaliSherkatEntity>() { new ErsaliSherkatEntity("Andisheh", getErsali()) };
        }
        private List<AmarTolidEntity> getAmarTolids()
        {
            return new List<AmarTolidEntity>() { new AmarTolidEntity("206", 200) };
        }

        private List<KhodorEntity> getKhodroList()
        {
            return new List<KhodorEntity>() { new KhodorEntity("206") };
        }
        private BaseCustomerEntity getCustomer()
        {
            return new BaseCustomerEntity("Sapco");
        }

        private List<ErsalKalaEntity> getErsali()
        {
            return new List<ErsalKalaEntity>() { new ErsalKalaEntity("name", "codeAnbar", "fani", "jens", 20, 2, 
                getKhodroList(), getCustomer()) };
        }
    }
}
