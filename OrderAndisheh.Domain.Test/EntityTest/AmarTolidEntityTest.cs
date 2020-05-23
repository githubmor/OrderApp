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
            AmarTolidEntity a = new AmarTolidEntity();
            a.Khodor = new KhodorEntity() { Name = "206" };
            a.TedadTolid = 200;

            Assert.AreEqual(200, a.TedadTolid);
            Assert.AreEqual(a.Khodor.Name, "206");
            Assert.IsNotNull(a.Khodor);
        }

        [TestMethod]
        public void AmarTolidEntity_DefaultProperty_IsOK()
        {
            AmarTolidEntity a = new AmarTolidEntity();

            Assert.AreEqual(0, a.TedadTolid);
            Assert.IsNull(a.Khodor);
        }

        [ExpectedException(typeof(NullReferenceException))]
        [TestMethod]
        public void AmarTolidEntity_SetKhodroNull_IsOK()
        {
            AmarTolidEntity a = new AmarTolidEntity();

            a.Khodor = null;
        }
    }
}