//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using OrderAndisheh.Domain.Entity;

//namespace OrderAndisheh.Domain.Test.EntityTest
//{
//    [TestClass]
//    public class CustomerEntityTest
//    {
//        [TestMethod]
//        public void CustomerEntityTest_DefaultProperty_IsOk()
//        {
//            CustomerEntity c = new CustomerEntity();

//            Assert.AreEqual("", c.CustomerName);
//            Assert.IsNull(c.TolidMahane);
//        }

//        [TestMethod]
//        public void CustomerEntityTest_SetProperty_IsOk()
//        {
//            CustomerEntity c = new CustomerEntity();

//            c.CustomerName = "ASd";
//            c.TolidMahane = new TolidMahaneEntity() { Mah = 10 };

//            Assert.AreEqual("ASd", c.CustomerName);
//            Assert.IsNotNull(c.TolidMahane);
//        }

//        [ExpectedException(typeof(NullReferenceException))]
//        [TestMethod]
//        public void CustomerEntityTest_NullProperty_IsOk()
//        {
//            CustomerEntity c = new CustomerEntity();

//            c.TolidMahane = null;
//        }

//        //[ExpectedException(typeof(ExpectedExceptionAttribute))]
//        //[TestMethod]
//        //public void CustomerEntityTest_NullProperty_IsOk()
//        //{
//        //    CustomerEntity c = new CustomerEntity();

//        //    c.CustomerName = "";
//        //}
//    }
//}