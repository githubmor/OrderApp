using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndisheh.Domain.Entity;
using System;

namespace OrderAndisheh.Domain.Test.EntityTest
{
    [TestClass]
    public class ErsalKalaEntityTest
    {
        [TestMethod]
        public void ErsalKalaEntity_DefaultProperty_IsOK()
        {
            SherkatEntity c = new SherkatEntity("Andisheh");
            ErsalKalaEntity e = new ErsalKalaEntity("name", "codeAnbar", "fani", "jens",c,20);

            Assert.IsNotNull(e.Sherkat);
            Assert.AreEqual(20,e.TedadErsali);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void ErsalEntity_NullKalaProperty_IsOK()
        {
            ErsalKalaEntity e = new ErsalKalaEntity("name", "codeAnbar", "fani", "jens", null, 0);

        }
    }
}