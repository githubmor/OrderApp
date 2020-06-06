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

            KhodorEntity k = new KhodorEntity("206");

            Assert.AreEqual(k.Name, "206");
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void KalaEntity_Emptyname_ExpectedException()
        {
            KhodorEntity k = new KhodorEntity("");
        }

    }
}