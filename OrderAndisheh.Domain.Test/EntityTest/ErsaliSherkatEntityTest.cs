using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndisheh.Domain.Entity;
using System.Collections.Generic;

namespace OrderAndisheh.Domain.Test.EntityTest
{
    [TestClass]
    public class ErsaliSherkatEntityTest
    {
        [TestMethod]
        public void ErsaliSherkatEntityTest_DefaultProperty_IsOk()
        {
            ErsaliSherkatEntity c = new ErsaliSherkatEntity("Andisheh",getErsali());

            Assert.AreEqual("Andisheh", c.SherkatName);
            Assert.AreEqual(1, c.ErsaliKala.Count);
            Assert.IsNotNull(c.ErsaliKala.Count);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void ErsaliSherkatEntityTest_EmptyErsaliKala_IsOk()
        {
            ErsaliSherkatEntity c = new ErsaliSherkatEntity("Andisheh", new List<ErsalKalaEntity>());
        }


        private List<KhodorEntity> getKhodroList()
        {
            return new List<KhodorEntity>() { new KhodorEntity("206") };
        }
        private BaseCustomerEntity getCustomer()
        {
            return new BaseCustomerEntity("Sapco");
        }
        private List<ErsalKalaEntity> getErsali()
        {
            return new List<ErsalKalaEntity>() { new ErsalKalaEntity("name", "codeAnbar", "fani", "jens", 20, 2, 
                getKhodroList(), getCustomer()) };
        }
    }
}