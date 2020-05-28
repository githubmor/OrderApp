using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndisheh.Domain.Entity;
using System;

namespace OrderAndisheh.Domain.Test.EntityTest
{
    [TestClass]
    public class BaseOrderEntityTest
    {


        [TestMethod]
        public void BaseOrderEntity_SetProperty_IsOk()
        {
            BaseOrderEntity b = new BaseOrderEntity(139902085,true);

            Assert.IsTrue(b.IsAccepted);
            Assert.AreEqual(13990208, b.Tarikh);
            Assert.AreEqual(5, b.Version);
        }

        [ExpectedException(typeof(IndexOutOfRangeException))]
        [TestMethod]
        public void BaseOrderEntity_ExceptionAttributeProperty_IsOk()
        {
            BaseOrderEntity b = new BaseOrderEntity(13548585);

        }
    }
}