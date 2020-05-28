using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndisheh.Domain.Entity;

namespace OrderAndisheh.Domain.Test.EntityTest
{
    [TestClass]
    public class BaseKalaEntityTest
    {
        [TestMethod]
        public void BaseKalaEntityTest_DefaultProperty_IsOk()
        {
            BaseKalaEntity b = new BaseKalaEntity();

            Assert.AreEqual("", b.Code);
            Assert.AreEqual("", b.FaniCode);
            Assert.AreEqual("", b.Name);
        }

        [TestMethod]
        public void BaseKalaEntityTest_SetProperty_IsOk()
        {
            BaseKalaEntity b = new BaseKalaEntity();
            b.Code = "12";
            b.FaniCode = "12";
            b.Name = "12";

            Assert.AreEqual("12", b.Code);
            Assert.AreEqual("12", b.FaniCode);
            Assert.AreEqual("12", b.Name);
        }

        [ExpectedException(typeof(ExpectedExceptionAttribute))]
        [TestMethod]
        public void BaseKalaEntityTest_SetProperty_IsOk()
        {
            BaseKalaEntity b = new BaseKalaEntity();

            b.Name = "";
        }
    }
}