using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndisheh.Domain.Entity;
using System;
using System.Collections.Generic;

namespace OrderAndisheh.Domain.Test.EntityTest
{
    [TestClass]
    public class ErsaliSherkatEntityTest
    {
        [TestMethod]
        public void ErsaliSherkatEntityTest_DefaultProperty_IsOk()
        {
            ErsaliSherkatEntity ersaliSherkat =
                new ErsaliSherkatEntity("Andisheh", Ultility.getErsali());

            Assert.AreEqual("Andisheh", ersaliSherkat.SherkatName);
            Assert.AreEqual(1, ersaliSherkat.ErsaliKala.Count);
            Assert.IsNotNull(ersaliSherkat.ErsaliKala.Count);
        }

        [TestMethod]
        public void ErsaliSherkatEntityTest_getErsaliByNullCustomer_IsOk()
        {
            ErsaliSherkatEntity ersaliSherkat =
                new ErsaliSherkatEntity("Andisheh", Ultility.getErsali());

            var re = ersaliSherkat.getKalaErsaliByCustomer(null);

            Assert.AreEqual(0, re.Count);
        }

        [TestMethod]
        public void ErsaliSherkatEntityTest_getErsaliByNotMatchCustomer_IsOk()
        {
            ErsaliSherkatEntity ersaliSherkat =
                new ErsaliSherkatEntity("Andisheh", Ultility.getErsali());

            var re = ersaliSherkat.getKalaErsaliByCustomer(Ultility.getCustomer2());

            Assert.AreEqual(0, re.Count);
        }

        [TestMethod]
        public void ErsaliSherkatEntityTest_getErsaliByCustomer_IsOk()
        {
            ErsaliSherkatEntity ersaliSherkat =
                new ErsaliSherkatEntity("Andisheh", Ultility.getErsali());

            var re = ersaliSherkat.getKalaErsaliByCustomer(Ultility.getCustomer());

            Assert.AreEqual(1, re.Count);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void ErsaliSherkatEntityTest_EmptyErsaliKala_IsOk()
        {
            ErsaliSherkatEntity ersaliSherkat = new ErsaliSherkatEntity("Andisheh",
                new List<ErsalKalaEntity>());
        }
    }
}