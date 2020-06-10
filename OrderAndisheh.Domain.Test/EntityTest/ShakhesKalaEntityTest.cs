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
            ShakhesKalaEntity shakhesKala = new ShakhesKalaEntity(Ultility.getOneErsali(),
                Ultility.getAmarTolids());

            Assert.IsNotNull(shakhesKala.AmarTolids);
            Assert.AreEqual(1,shakhesKala.AmarTolids.Count);
            Assert.IsNotNull(shakhesKala.ErsalKala);
            Assert.AreEqual(5,shakhesKala.getKalaDarsadSahm());
        }

        [TestMethod]
        public void ShakhesKalaEntity_getKalaDarsadSahm_IsOk()
        {
            ShakhesKalaEntity shakhesKala = new ShakhesKalaEntity(Ultility.getOneErsali(),
                Ultility.getAmarTolids());

            var re = shakhesKala.getKalaDarsadSahm();

            Assert.AreEqual(5, re);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void ShakhesKalaEntity_NullErsali_ExpectedException()
        {
            ShakhesKalaEntity shakhesKala = new ShakhesKalaEntity(null, Ultility.getAmarTolids());
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void ShakhesKalaEntity_EmptyTolidi_ExpectedException()
        {
            ShakhesKalaEntity shakhesKala = new ShakhesKalaEntity(Ultility.getOneErsali(),
                new List<AmarTolidKhodroEntity>());
        }
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void ShakhesKalaEntity_NullTolidi_ExpectedException()
        {
            ShakhesKalaEntity shakhesKala = new ShakhesKalaEntity(Ultility.getOneErsali(),
                null);
        }
       
    }
}
