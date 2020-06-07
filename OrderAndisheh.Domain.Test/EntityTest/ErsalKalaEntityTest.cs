using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndisheh.Domain.Entity;
using System;
using System.Collections.Generic;

namespace OrderAndisheh.Domain.Test.EntityTest
{
    [TestClass]
    public class ErsalKalaEntityTest
    {
        [TestMethod]
        public void ErsalKalaEntity_DefaultProperty_IsOK()
        {
            ErsalKalaEntity e = new ErsalKalaEntity("name", "codeAnbar", "fani",
                "jens", 20, 2, Ultility.getKhodroList(), Ultility.getCustomer());

            Assert.AreEqual(20, e.TedadErsali);
            Assert.AreEqual(2, e.ZaribMasrafDarKhodro);
            Assert.AreEqual(1, e.Khodors.Count);
            Assert.IsNotNull(e.Khodors);
            Assert.IsNotNull(e.Customer);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void ErsalKalaEntity_AllNull_IsOK()
        {
            ErsalKalaEntity e = new ErsalKalaEntity("name", "codeAnbar", "fani", "jens",
                20, 0, null, null);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void ErsalKalaEntity_EmptyKhodros_IsOK()
        {
            ErsalKalaEntity e = new ErsalKalaEntity("name", "codeAnbar", "fani", "jens",
                20, 10, new List<KhodorEntity>(),Ultility.getCustomer());
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void ErsalKalaEntity_NullKhodros_IsOK()
        {
            ErsalKalaEntity e = new ErsalKalaEntity("name", "codeAnbar", "fani", "jens",
                20, 10, null, Ultility.getCustomer());
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void ErsalKalaEntity_ZerZarib_IsOK()
        {
            ErsalKalaEntity e = new ErsalKalaEntity("name", "codeAnbar", "fani", "jens", 20, 0, Ultility.getKhodroList(), Ultility.getCustomer());
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void ErsalKalaEntity_NullCustomer_IsOK()
        {
            ErsalKalaEntity e = new ErsalKalaEntity("name", "codeAnbar", "fani", "jens", 20, 10, Ultility.getKhodroList(), null);
        }

        
    }
}