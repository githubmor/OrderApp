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
            BaseKalaEntity baseKala = new BaseKalaEntity("name", "codeAnbar", "fani", "jens");

            Assert.AreEqual("codeAnbar", baseKala.CodeAnbar);
            Assert.AreEqual("fani", baseKala.FaniCode);
            Assert.AreEqual("name", baseKala.Name);
            Assert.AreEqual("jens", baseKala.CodeJense);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void BaseKalaEntityTest_EmptyName_Exception()
        {
            BaseKalaEntity baseKala = new BaseKalaEntity("", "dsa", "fani", "jens");
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void BaseKalaEntityTest_EmptyCodeAnbar_Exception()
        {
            BaseKalaEntity baseKala = new BaseKalaEntity("asd", "", "fani", "jens");
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void BaseKalaEntityTest_EmptyNameAndCodeAnbar_Exception()
        {
            BaseKalaEntity baseKala = new BaseKalaEntity("", "", "fani", "jens");
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void BaseKalaEntityTest_EmptyAll_Exception()
        {
            BaseKalaEntity baseKala = new BaseKalaEntity("", "", "", "");
        }
    }
}