using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndisheh.Domain.Entity;
using System;
using System.Collections.Generic;

namespace OrderAndisheh.Domain.Test.EntityTest
{
    [TestClass]
    public class CustomerTolidiEntityTest
    {
        [TestMethod]
        public void CustomerTolidiEntity_DefaultProperty_IsOk()
        {
            CustomerTolidiEntity customerTolidi = new CustomerTolidiEntity("Sapco", Ultility.getAmarTolids());

            Assert.AreEqual("Sapco", customerTolidi.CustomerName);
            Assert.AreEqual(1, customerTolidi.AmarTolids.Count);
            Assert.IsNotNull(customerTolidi.AmarTolids);
        }

        [TestMethod]
        public void CustomerTolidiEntity_getAmarTolidi_IsOk()
        {
            CustomerTolidiEntity customerTolidi = new CustomerTolidiEntity("Sapco", Ultility.getAmarTolids());

            var re = customerTolidi.getAmarTolidi(Ultility.getKhodroList());

            Assert.AreEqual(1, re.Count);
        }

        [TestMethod]
        public void CustomerTolidiEntity_getAmarTolidiNullKhodro_IsOk()
        {
            CustomerTolidiEntity customerTolidi = new CustomerTolidiEntity("Sapco", Ultility.getAmarTolids());

            var re = customerTolidi.getAmarTolidi(null);

            Assert.AreEqual(0, re.Count);
        }

        [TestMethod]
        public void CustomerTolidiEntity_getEmptyAmarTolidi_IsOk()
        {
            CustomerTolidiEntity customerTolidi = new CustomerTolidiEntity("Sapco", Ultility.getAmarTolids());

            var re = customerTolidi.getAmarTolidi(new List<KhodorEntity>());

            Assert.AreEqual(0, re.Count);
        }

        [TestMethod]
        public void CustomerTolidiEntity_getAmarTolidiNotMatch_IsOk()
        {
            CustomerTolidiEntity customerTolidi = new CustomerTolidiEntity("Sapco", Ultility.getAmarTolids());

            var re = customerTolidi.getAmarTolidi(Ultility.getKhodroList2());

            Assert.AreEqual(0, re.Count);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void CustomerTolidiEntityTest_NullProperty_IsOk()
        {
            CustomerTolidiEntity customerTolidi = new CustomerTolidiEntity("Sapco", new List<AmarTolidKhodroEntity>());
        }
    }
}