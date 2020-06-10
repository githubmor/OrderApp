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
            TolidMahaneEntity tolidMahane = new TolidMahaneEntity(1, Ultility.getAmarTolids());

            Assert.IsNotNull(tolidMahane.AmarTolids);
            Assert.AreEqual(1, tolidMahane.AmarTolids.Count);
            Assert.AreEqual(1, tolidMahane.Mah);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void TolidMahaneEntity_MahZero_IsOk()
        {
            TolidMahaneEntity tolidMahane = new TolidMahaneEntity(0, Ultility.getAmarTolids());
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void TolidMahaneEntity_MahOutOfRange_IsOk()
        {
            TolidMahaneEntity tolidMahane = new TolidMahaneEntity(14, Ultility.getAmarTolids());
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void TolidMahaneEntity_EmptyAmarTolid_IsOk()
        {
            TolidMahaneEntity tolidMahane = new TolidMahaneEntity(1, new List<AmarTolidKhodroEntity>());
        }
    }
}