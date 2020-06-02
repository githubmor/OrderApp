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
            BaseOrderEntity b = new BaseOrderEntity(13990208, 5, true);

            Assert.IsTrue(b.IsAccepted);
            Assert.AreEqual(13990208, b.Tarikh);
            Assert.AreEqual(5, b.Version);
        }

        [TestMethod]
        public void BaseOrderEntity_AddVersion_IsOk()
        {
            BaseOrderEntity b = new BaseOrderEntity(13990208, 5, true);

            b.VersionIncrease();

            Assert.AreEqual(6, b.Version);
        }

        [TestMethod]
        public void BaseOrderEntity_ChangeAccepted_IsOk()
        {
            BaseOrderEntity b = new BaseOrderEntity(13990208, 5, true);

            b.ChangeAccepted(false);

            Assert.IsFalse(b.IsAccepted);
        }

        [TestMethod]
        public void BaseOrderEntity_DefaultProperty_IsOk()
        {
            BaseOrderEntity b = new BaseOrderEntity(13990208);

            Assert.IsFalse(b.IsAccepted);
            Assert.AreEqual(13990208, b.Tarikh);
            Assert.AreEqual(0, b.Version);
        }

        [ExpectedException(typeof(IndexOutOfRangeException))]
        [TestMethod]
        public void BaseOrderEntity_tarikhNotDate_ExceptionAttributeProperty1()
        {
            BaseOrderEntity b = new BaseOrderEntity(1398);
        }

        [ExpectedException(typeof(IndexOutOfRangeException))]
        [TestMethod]
        public void BaseOrderEntity_monthBiggerThan12_ExceptionAttributeProperty()
        {
            BaseOrderEntity b = new BaseOrderEntity(14001308);
        }

        [ExpectedException(typeof(IndexOutOfRangeException))]
        [TestMethod]
        public void BaseOrderEntity_tarikhIsZero_ExceptionAttributeProperty()
        {
            BaseOrderEntity b = new BaseOrderEntity(0);
        }
    }
}