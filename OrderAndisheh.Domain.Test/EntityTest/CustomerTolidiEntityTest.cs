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

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void CustomerTolidiEntityTest_NullProperty_IsOk()
        {
            CustomerTolidiEntity c = new CustomerTolidiEntity("Sapco",new List<AmarTolidEntity>());
        }
        private List<AmarTolidEntity> getAmarTolids()
        {
            return new List<AmarTolidEntity>() { new AmarTolidEntity("206", 2000) };
        }
    }
}