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
            BaseOrderEntity baseOrder = new BaseOrderEntity(13990208, 5, true);

            Assert.IsTrue(baseOrder.IsAccepted);
            Assert.AreEqual(13990208, baseOrder.Tarikh);
            Assert.AreEqual(5, baseOrder.Version);
        }

        [TestMethod]
        public void BaseOrderEntity_AddVersion_IsOk()
        {
            BaseOrderEntity baseOrder = new BaseOrderEntity(13990208, 5, true);

            baseOrder.VersionIncrease();

            Assert.AreEqual(6, baseOrder.Version);
        }

        [TestMethod]
        public void BaseOrderEntity_ChangeAccepted_IsOk()
        {
            BaseOrderEntity baseOrder = new BaseOrderEntity(13990208, 5, true);

            baseOrder.ChangeAccepted(false);

            Assert.IsFalse(baseOrder.IsAccepted);
        }

        [TestMethod]
        public void BaseOrderEntity_DefaultProperty_IsOk()
        {
            BaseOrderEntity baseOrder = new BaseOrderEntity(13990208);

            Assert.IsFalse(baseOrder.IsAccepted);
            Assert.AreEqual(13990208, baseOrder.Tarikh);
            Assert.AreEqual(0, baseOrder.Version);
        }

        [ExpectedException(typeof(IndexOutOfRangeException))]
        [TestMethod]
        public void BaseOrderEntity_tarikhNotDate_ExceptionAttributeProperty1()
        {
            BaseOrderEntity baseOrder = new BaseOrderEntity(1398);
        }

        [ExpectedException(typeof(IndexOutOfRangeException))]
        [TestMethod]
        public void BaseOrderEntity_monthBiggerThan12_ExceptionAttributeProperty()
        {
            BaseOrderEntity b = new BaseOrderEntity(14001308);
        }

        [ExpectedException(typeof(IndexOutOfRangeException))]
        [TestMethod]
        public void BaseOrderEntity_dayBiggerThan31InBahman_ExceptionAttributeProperty()
        {
            BaseOrderEntity b = new BaseOrderEntity(14001131);
        }

        [ExpectedException(typeof(IndexOutOfRangeException))]
        [TestMethod]
        public void BaseOrderEntity_tarikhIsZero_ExceptionAttributeProperty()
        {
            BaseOrderEntity b = new BaseOrderEntity(0);
        }
    }
}