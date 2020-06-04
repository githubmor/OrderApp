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
            ShakhesKalaEntity s = new ShakhesKalaEntity(getErsali(), 5, getTolidList());

            Assert.IsNotNull(s.Ersali);
            Assert.IsNotNull(s.Tolidi);
            Assert.AreEqual(1,s.Tolidi.Count);
            Assert.AreEqual(5,s.ZaribMasrafDarKhodro);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void ShakhesKalaEntity_NullErsali_ExpectedException()
        {
            ShakhesKalaEntity s = new ShakhesKalaEntity(null, 5, getTolidList());
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void ShakhesKalaEntity_ZeroZarib_ExpectedException()
        {
            ShakhesKalaEntity s = new ShakhesKalaEntity(getErsali(), 0, getTolidList());
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void ShakhesKalaEntity_EmptyTolidi_ExpectedException()
        {
            ShakhesKalaEntity s = new ShakhesKalaEntity(getErsali(), 5,  new List<AmarTolidEntity>());
        }

        private List<AmarTolidEntity> getTolidList()
        {
            return new List<AmarTolidEntity>() { new AmarTolidEntity("206",getCustomer(), 200) };
        }

        private static CustomerEntity getCustomer()
        {
            CustomerEntity c = new CustomerEntity("Sapco");
            return c;
        }

        private ErsalKalaEntity getErsali()
        {
            SherkatEntity c = new SherkatEntity("Andisheh");
            return new ErsalKalaEntity("name", "codeAnbar", "fani", "jens", c, 20);
        }
    }
}
