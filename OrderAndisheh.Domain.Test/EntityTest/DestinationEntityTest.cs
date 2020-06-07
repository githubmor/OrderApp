using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndisheh.Domain.Entity;
using System;

namespace OrderAndisheh.Domain.Test.EntityTest
{
    [TestClass]
    public class DestinationEntityTest
    {
        [TestMethod]
        public void DestinationEntity_DefaultProperty_IsOK()
        {
            DestinationEntity destination = new DestinationEntity("name");

            Assert.AreEqual("name", destination.Name);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void DestinationEntity_EmptyName_ExpectedException()
        {
            DestinationEntity destination = new DestinationEntity("");
        }
    }
}