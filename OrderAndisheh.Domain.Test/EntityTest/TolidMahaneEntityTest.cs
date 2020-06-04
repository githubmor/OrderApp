using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndisheh.Domain.Entity;
using System;
using System.Collections.Generic;

namespace OrderAndisheh.Domain.Test.EntityTest
{
    [TestClass]
    public class TolidMahaneEntityTest
    {
        [TestMethod]
        public void TolidMahaneEntity_DefaultSet_IsOk()
        {
            TolidMahaneEntity t = new TolidMahaneEntity(1, getAmarTolidList());

            Assert.IsNotNull(t.AmarTolids);
            Assert.AreEqual(1, t.AmarTolids.Count);
            Assert.AreEqual(1, t.Mah);
        }
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void TolidMahaneEntity_MahOutOfRange_IsOk()
        {
            TolidMahaneEntity t = new TolidMahaneEntity(0, getAmarTolidList());
        }
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void TolidMahaneEntity_EmptyAmarTolid_IsOk()
        {
            TolidMahaneEntity t = new TolidMahaneEntity(1, new List<AmarTolidEntity>());

        }
        private List<AmarTolidEntity> getAmarTolidList()
        {
            return new List<AmarTolidEntity>() { new AmarTolidEntity("206",getCustomer(), 200) };
        }

        private static CustomerEntity getCustomer()
        {
            CustomerEntity c = new CustomerEntity("Sapco");
            return c;
        }
    }
}