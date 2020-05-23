using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndisheh.Domain.Entity;
using System;

namespace OrderAndisheh.Domain.Test.EntityTest
{
    [TestClass]
    public class ErsalEntityTest
    {
        [TestMethod]
        public void ErsalEntity_DefaultProperty_IsOK()
        {
            ErsalEntity e = new ErsalEntity();

            Assert.IsNull(e.Kala);
            Assert.IsNull(e.Khodor);
            Assert.AreEqual(0, e.TedadErsali);
        }

        [TestMethod]
        public void ErsalEntity_SetProperty_IsOK()
        {
            ErsalEntity e = new ErsalEntity();
            e.Kala = new KalaEntity() { Code = "sad", CodeJense = "sa", Name = "ad", TedadDarBaste = 0, TedadDarPallet = 560 };
            e.Khodor = new KhodorEntity() { Name = "dsa" };
            e.TedadErsali = 2540;

            Assert.IsNotNull(e.Kala);
            Assert.IsNotNull(e.Khodor);
            Assert.AreEqual(2540, e.TedadErsali);
        }

        [ExpectedException(typeof(NullReferenceException))]
        [TestMethod]
        public void ErsalEntity_NullKalaProperty_IsOK()
        {
            ErsalEntity e = new ErsalEntity();
            e.Kala = null;
        }

        [ExpectedException(typeof(NullReferenceException))]
        [TestMethod]
        public void ErsalEntity_NullKalaProperty_IsOK()
        {
            ErsalEntity e = new ErsalEntity();
            e.Khodor = null;
        }
    }
}