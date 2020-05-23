using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndisheh.Domain.Entity;

namespace OrderAndisheh.Domain.Test.EntityTest
{
    [TestClass]
    public class BaseOrderEntityTest
    {
        [TestMethod]
        public void BaseOrderEntity_DefaultProperty_IsOk()
        {
            BaseOrderEntity b = new BaseOrderEntity();

            Assert.IsFalse(b.IsAccepted);
            Assert.AreEqual("", b.Tarikh);
        }

        [TestMethod]
        public void BaseOrderEntity_SetProperty_IsOk()
        {
            BaseOrderEntity b = new BaseOrderEntity();
            b.IsAccepted = true;
            b.Tarikh = 13920201;

            Assert.IsTrue(b.IsAccepted);
            Assert.AreEqual(13920201, b.Tarikh);
        }
    }
}