using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndisheh.Domain.Entity;

namespace OrderAndisheh.Domain.Test.EntityTest
{
    [TestClass]
    public class SherkatEntityTest
    {
        [TestMethod]
        public void SherkatEntity_DefaultProperty_IsOk()
        {
            SherkatEntity c = new SherkatEntity("Andisheh");

            Assert.AreEqual("Andisheh", c.SherkatName);
        }


        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void SherkatEntity_NullProperty_IsOk()
        {
            SherkatEntity c = new SherkatEntity("");
        }

    }
}