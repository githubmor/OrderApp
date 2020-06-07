using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndisheh.Domain.Entity;

namespace OrderAndisheh.Domain.Test.EntityTest
{
    [TestClass]
    public class BaseCustomerEntityTest
    {
        [TestMethod]
        public void BaseCustomerEntityTest_DefaultProperty_IsOk()
        {
            BaseCustomerEntity customer = new BaseCustomerEntity("Sapco");

            Assert.AreEqual("Sapco", customer.CustomerName);
        }


        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void BaseCustomerEntityTest_NullProperty_IsOk()
        {
            BaseCustomerEntity customer = new BaseCustomerEntity("");
        }

    }
}