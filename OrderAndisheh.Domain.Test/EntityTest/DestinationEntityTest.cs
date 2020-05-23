using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndisheh.Domain.Entity;

namespace OrderAndisheh.Domain.Test.EntityTest
{
    [TestClass]
    public class DestinationEntityTest
    {
        [TestMethod]
        public void DestinationEntity_DefaultProperty_IsOK()
        {
            DestinationEntity d = new DestinationEntity();

            Assert.AreEqual("", d.Name);
        }

        [TestMethod]
        public void DestinationEntity_SetProperty_IsOK()
        {
            DestinationEntity d = new DestinationEntity();
            d.Name = "asdsad";

            Assert.AreEqual("asdsad", d.Name);
        }
    }
}