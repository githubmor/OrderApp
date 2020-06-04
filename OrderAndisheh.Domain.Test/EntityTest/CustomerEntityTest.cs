﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndisheh.Domain.Entity;

namespace OrderAndisheh.Domain.Test.EntityTest
{
    [TestClass]
    public class CustomerEntityTest
    {
        [TestMethod]
        public void CustomerEntityTest_DefaultProperty_IsOk()
        {
            CustomerEntity c = new CustomerEntity("Sapco");

            Assert.AreEqual("Sapco", c.CustomerName);
        }


        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void CustomerEntityTest_NullProperty_IsOk()
        {
            CustomerEntity c = new CustomerEntity("");
        }

    }
}