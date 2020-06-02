using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndisheh.Domain.Entity;
using System;

namespace OrderAndisheh.Domain.Test.EntityTest
{
    [TestClass]
    public class BaseKalaEntityTest
    {
        [TestMethod]
        public void BaseKalaEntityTest_SetProperty_IsOk()
        {
            BaseKalaEntity b = new BaseKalaEntity("name", "codeAnbar", "fani", "jens");

            Assert.AreEqual("codeAnbar", b.CodeAnbar);
            Assert.AreEqual("fani", b.FaniCode);
            Assert.AreEqual("name", b.Name);
            Assert.AreEqual("jens", b.CodeJense);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void BaseKalaEntityTest_EmptyName_Exception()
        {
            BaseKalaEntity b = new BaseKalaEntity("", "dsa", "sdf", "sdfs");
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void BaseKalaEntityTest_EmptyCodeAnbar_Exception()
        {
            BaseKalaEntity b = new BaseKalaEntity("asd", "", "asd", "asd");
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void BaseKalaEntityTest_EmptyNameAndCodeAnbar_Exception()
        {
            BaseKalaEntity b = new BaseKalaEntity("", "", "asd", "asd");
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void BaseKalaEntityTest_EmptyAll_Exception()
        {
            BaseKalaEntity b = new BaseKalaEntity("", "", "", "");
        }
    }
}