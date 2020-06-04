using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndisheh.Domain.Entity;
using System;

namespace OrderAndisheh.Domain.Test.EntityTest
{
    [TestClass]
    public class AmarTolidEntityTest
    {
        [TestMethod]
        public void AmarTolidEntity_SetProperty_IsOK()
        {

            AmarTolidEntity a = new AmarTolidEntity("206", getCustomer(), 200);

            Assert.AreEqual(200, a.TedadTolid);

        }

        private static CustomerEntity getCustomer()
        {
            CustomerEntity c = new CustomerEntity("Sapco");
            return c;
        }
        
    }
}