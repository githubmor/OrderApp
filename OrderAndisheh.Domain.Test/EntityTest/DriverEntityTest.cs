using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndisheh.Domain.Entity;
using System;

namespace OrderAndisheh.Domain.Test.EntityTest
{
    [TestClass]
    public class DriverEntityTest
    {
        [TestMethod]
        public void DriverEntity_AllSet_IsOK()
        {
            DriverEntity d = new DriverEntity("name", "mobile", "codeMeli", "pelak");

            Assert.AreEqual(d.CodeMeli, "codeMeli");
            Assert.AreEqual(d.Mobile, "mobile");
            Assert.AreEqual(d.Name, "name");
            Assert.AreEqual(d.Pelak, "pelak");
        }

        [TestMethod]
        public void DriverEntity_SetNameMeli_IsOK()
        {
            DriverEntity d = new DriverEntity("name", "", "", "");

            Assert.AreEqual(d.CodeMeli, "");
            Assert.AreEqual(d.Mobile, "");
            Assert.AreEqual(d.Name, "name");
            Assert.AreEqual(d.Pelak, "");
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void DriverEntity_EmptyName_IsOK()
        {
            DriverEntity d = new DriverEntity("", "mobile", "codeMeli", "pelak");
        }
    }
}