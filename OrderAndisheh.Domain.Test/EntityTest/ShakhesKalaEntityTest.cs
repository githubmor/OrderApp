using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndisheh.Domain.Entity;
using System.Collections.Generic;

namespace OrderAndisheh.Domain.Test.EntityTest
{
    [TestClass]
    public class ShakhesKalaEntityTest
    {
        [TestMethod]
        public void ShakhesKalaEntity_SetDafult_IsOk()
        {
            ShakhesKalaEntity s = new ShakhesKalaEntity(getErsali(), getAmarTolids());

            Assert.IsNotNull(s.AmarTolids);
            Assert.AreEqual(1,s.AmarTolids.Count);
            Assert.IsNotNull(s.ErsalKala);
            Assert.AreEqual(5,s.getDarsadSahm());
        }


        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void ShakhesKalaEntity_NullErsali_ExpectedException()
        {
            ShakhesKalaEntity s = new ShakhesKalaEntity(null, getAmarTolids());
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void ShakhesKalaEntity_EmptyTolidi_ExpectedException()
        {
            ShakhesKalaEntity s = new ShakhesKalaEntity(getErsali(), new List<AmarTolidKhodroEntity>());
        }

        private List<AmarTolidKhodroEntity> getAmarTolids()
        {
            return new List<AmarTolidKhodroEntity>() { new AmarTolidKhodroEntity("206", 200) };
        }

        private List<KhodorEntity> getKhodroList()
        {
            return new List<KhodorEntity>() { new KhodorEntity("206") };
        }
        private BaseCustomerEntity getCustomer()
        {
            return new BaseCustomerEntity("Sapco");
        }

        private ErsalKalaEntity getErsali()
        {
            return new ErsalKalaEntity("name", "codeAnbar", "fani", "jens", 20, 2, 
                getKhodroList(), getCustomer()) ;
        }
    }
}
