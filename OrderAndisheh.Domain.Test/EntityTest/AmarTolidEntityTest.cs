using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndisheh.Domain.Entity;
using System;

namespace OrderAndisheh.Domain.Test.EntityTest
{
    [TestClass]
    public class AmarTolidEntityTest
    {
        [TestMethod]
        public void AmarTolidEntity_SetProperty_IsOK()
        {

            AmarTolidEntity a = new AmarTolidEntity("206", 200);

            Assert.AreEqual(200, a.TedadTolid);
            Assert.AreEqual("206", a.Name);
        }
        
    }
}