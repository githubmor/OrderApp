using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndisheh.Domain.Entity;

namespace OrderAndisheh.Domain.Test.EntityTest
{
    [TestClass]
    public class DriverEntityTest
    {
        [TestMethod]
        public void DriverEntity_DefaultProperty_IsOK()
        {
            DriverEntity d = new DriverEntity();

            Assert.AreEqual(d.CodeMeli, "");
            Assert.AreEqual(d.Mobile, "");
            Assert.AreEqual(d.Name, "");
            Assert.AreEqual(d.Pelak, "");
        }

        [TestMethod]
        public void DriverEntity_SetProperty_IsOK()
        {
            DriverEntity d = new DriverEntity();
            d.CodeMeli = "206";
            d.Mobile = "0911";
            d.Name = "nam";
            d.Pelak = "857";

            Assert.AreEqual(d.CodeMeli, "206");
            Assert.AreEqual(d.Mobile, "0911");
            Assert.AreEqual(d.Name, "nam");
            Assert.AreEqual(d.Pelak, "857");
        }
    }
}