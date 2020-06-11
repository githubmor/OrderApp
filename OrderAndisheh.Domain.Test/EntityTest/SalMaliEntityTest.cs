using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndisheh.Domain.Entity;
using System;

namespace OrderAndisheh.Domain.Test.EntityTest
{
    [TestClass]
    public class SalMaliEntityTest
    {
        [TestMethod]
        public void SalMaliEntity_SetProperty_IsOK()
        {
            SalMaliEntity salmali = new SalMaliEntity(1399);

            Assert.AreEqual(1399, salmali.Sal);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void SalMaliEntity_NotYear_ExpectedException()
        {
            SalMaliEntity salmali = new SalMaliEntity(154);
        }
    }
}