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

            AmarTolidKhodroEntity a = new AmarTolidKhodroEntity("206", 200);

            Assert.AreEqual(200, a.TedadTolid);
            Assert.AreEqual("206", a.Name);
        }
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void AmarTolidKhodroEntity_ZeroTedadTolid_ExpectedException()
        {
            AmarTolidKhodroEntity a = new AmarTolidKhodroEntity("206", 0);
        }
        
    }
}