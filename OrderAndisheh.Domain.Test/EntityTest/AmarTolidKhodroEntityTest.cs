using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndisheh.Domain.Entity;
using System;

namespace OrderAndisheh.Domain.Test.EntityTest
{
    [TestClass]
    public class AmarTolidKhodroEntityTest
    {
        [TestMethod]
        public void AmarTolidKhodroEntity_SetProperty_IsOK()
        {

            AmarTolidKhodroEntity amarTolidKhodro = new AmarTolidKhodroEntity("206", 200);

            Assert.AreEqual(200, amarTolidKhodro.TedadTolid);
            Assert.AreEqual("206", amarTolidKhodro.Name);
        }
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void AmarTolidKhodroEntity_ZeroTedadTolid_ExpectedException()
        {
            AmarTolidKhodroEntity amarTolidKhodro = new AmarTolidKhodroEntity("206", 0);
        }
        
    }
}