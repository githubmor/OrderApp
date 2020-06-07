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
            DriverEntity driver = new DriverEntity("name", "mobile", "codeMeli", "pelak");

            Assert.AreEqual(driver.CodeMeli, "codeMeli");
            Assert.AreEqual(driver.Mobile, "mobile");
            Assert.AreEqual(driver.Name, "name");
            Assert.AreEqual(driver.Pelak, "pelak");
        }

        [TestMethod]
        public void DriverEntity_SetNameMeli_IsOK()
        {
            DriverEntity driver = new DriverEntity("name", "", "", "");

            Assert.AreEqual(driver.CodeMeli, "");
            Assert.AreEqual(driver.Mobile, "");
            Assert.AreEqual(driver.Name, "name");
            Assert.AreEqual(driver.Pelak, "");
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void DriverEntity_EmptyName_ExpectedException()
        {
            DriverEntity driver = new DriverEntity("", "mobile", "codeMeli", "pelak");
        }
    }
}