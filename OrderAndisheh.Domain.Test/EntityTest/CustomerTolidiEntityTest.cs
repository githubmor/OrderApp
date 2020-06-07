using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndisheh.Domain.Entity;
using System.Collections.Generic;

namespace OrderAndisheh.Domain.Test.EntityTest
{
    [TestClass]
    public class CustomerTolidiEntityTest
    {
        [TestMethod]
        public void CustomerTolidiEntity_DefaultProperty_IsOk()
        {
            CustomerTolidiEntity c = new CustomerTolidiEntity("Sapco",getAmarTolids());

            Assert.AreEqual("Sapco", c.CustomerName);
            Assert.AreEqual(1, c.AmarTolids.Count);
            Assert.IsNotNull(c.AmarTolids);
        }

        [TestMethod]
        public void CustomerTolidiEntity_getAmarTolidi_IsOk()
        {
            CustomerTolidiEntity c = new CustomerTolidiEntity("Sapco", getAmarTolids());

            var re = c.getAmarTolidi(new ErsalKalaEntity("name", "codeAnbar", "fani", "jens", 20, 2, 
                getKhodroList(), getCustomer()));

            Assert.AreEqual(1, re.Count);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void CustomerTolidiEntityTest_NullProperty_IsOk()
        {
            CustomerTolidiEntity c = new CustomerTolidiEntity("Sapco",new List<AmarTolidKhodroEntity>());
        }
        private List<AmarTolidKhodroEntity> getAmarTolids()
        {
            return new List<AmarTolidKhodroEntity>() { new AmarTolidKhodroEntity("206", 2000) };
        }
        private List<KhodorEntity> getKhodroList()
        {
            return new List<KhodorEntity>() { new KhodorEntity("206") };
        }
        private BaseCustomerEntity getCustomer()
        {
            return new BaseCustomerEntity("Sapco");
        }
    }
}