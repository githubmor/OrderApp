using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndisheh.Domain.Entity;
using System;

namespace OrderAndisheh.Domain.Test.EntityTest
{
    [TestClass]
    public class BaseKhodorEntityTest
    {
        [TestMethod]
        public void BaseKhodorEntity_DefaultProperty_IsOK()
        {
            BaseKhodorEntity baseKhodor = new BaseKhodorEntity("206");

            Assert.AreEqual(baseKhodor.Name, "206");
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void BaseKhodorEntity_Emptyname_ExpectedException()
        {
            BaseKhodorEntity baseKhodor = new BaseKhodorEntity("");
        }

    }
}