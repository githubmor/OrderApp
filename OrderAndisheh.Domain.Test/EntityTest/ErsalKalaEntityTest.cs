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
            ErsalKalaEntity ersalKala = new ErsalKalaEntity("name", "codeAnbar", "fani",
                "jens", 20, 2, Ultility.getKhodroList(), Ultility.getCustomer());

            Assert.AreEqual(20, ersalKala.TedadErsali);
            Assert.AreEqual(2, ersalKala.ZaribMasrafDarKhodro);
            Assert.AreEqual(1, ersalKala.Khodors.Count);
            Assert.IsNotNull(ersalKala.Khodors);
            Assert.IsNotNull(ersalKala.Customer);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void ErsalKalaEntity_AllNull_IsOK()
        {
            ErsalKalaEntity ersalKala = new ErsalKalaEntity("name", "codeAnbar", "fani", "jens",
                20, 0, null, null);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void ErsalKalaEntity_EmptyKhodros_IsOK()
        {
            ErsalKalaEntity ersalKala = new ErsalKalaEntity("name", "codeAnbar", "fani", "jens",
                20, 10, new List<BaseKhodorEntity>(),Ultility.getCustomer());
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void ErsalKalaEntity_NullKhodros_IsOK()
        {
            ErsalKalaEntity ersalKala = new ErsalKalaEntity("name", "codeAnbar", "fani", "jens",
                20, 10, null, Ultility.getCustomer());
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void ErsalKalaEntity_ZerZarib_IsOK()
        {
            ErsalKalaEntity ersalKala = new ErsalKalaEntity("name", "codeAnbar", "fani", "jens", 20, 0, Ultility.getKhodroList(), Ultility.getCustomer());
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void ErsalKalaEntity_NullCustomer_IsOK()
        {
            ErsalKalaEntity ersalKala = new ErsalKalaEntity("name", "codeAnbar", "fani", "jens", 20, 10, Ultility.getKhodroList(), null);
        }

        
    }
}