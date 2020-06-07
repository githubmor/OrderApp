using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndisheh.Domain.Entity;

namespace OrderAndisheh.Domain.Test.EntityTest
{
    [TestClass]
    public class BaseSherkatEntityTest
    {
        [TestMethod]
        public void BaseSherkatEntity_DefaultProperty_IsOk()
        {
            BaseSherkatEntity baseSherkat = new BaseSherkatEntity("Andisheh");

            Assert.AreEqual("Andisheh", baseSherkat.SherkatName);
        }


        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void BaseSherkatEntity_NullProperty_IsOk()
        {
            BaseSherkatEntity baseSherkat = new BaseSherkatEntity("");
        }

    }
}