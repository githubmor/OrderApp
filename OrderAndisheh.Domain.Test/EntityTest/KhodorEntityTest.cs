using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndisheh.Domain.Entity;
using System;

namespace OrderAndisheh.Domain.Test.EntityTest
{
    [TestClass]
    public class KhodorEntityTest
    {
        [TestMethod]
        public void KalaEntity_DefaultProperty_IsOK()
        {

            KhodorEntity k = new KhodorEntity("206", getCustomer());

            Assert.AreEqual(k.Name, "206");
            Assert.IsNotNull(k.Customer);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void KalaEntity_Emptyname_ExpectedException()
        {
            KhodorEntity k = new KhodorEntity("", getCustomer());
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void KalaEntity_NullCustomer_ExpectedException()
        {
            KhodorEntity k = new KhodorEntity("206", null);
        }

        private static CustomerEntity getCustomer()
        {
            CustomerEntity c = new CustomerEntity("Sapco");
            return c;
        }
    }
}