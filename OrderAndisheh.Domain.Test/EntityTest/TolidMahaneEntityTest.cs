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
            TolidMahaneEntity t = new TolidMahaneEntity(1, new List<AmarTolidKhodroEntity>());

        }
        private List<AmarTolidKhodroEntity> getAmarTolidList()
        {
            return new List<AmarTolidKhodroEntity>() { new AmarTolidKhodroEntity("206", 200) };
        }

        private static BaseCustomerEntity getCustomer()
        {
            BaseCustomerEntity c = new BaseCustomerEntity("Sapco");
            return c;
        }
    }
}