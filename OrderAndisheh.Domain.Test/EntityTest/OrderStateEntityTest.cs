using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndisheh.Domain.Entity;
using System;
using System.Collections.Generic;

namespace OrderAndisheh.Domain.Test.EntityTest
{
    [TestClass]
    public class OrderStateEntityTest
    {
        [TestMethod]
        public void OrderStateEntity_SetProperty_IsOk()
        {
            OrderStateEntity b = new OrderStateEntity(13990102,true, true, true, true);

            Assert.IsTrue(b.IsDestinationSet);
            Assert.IsTrue(b.IsDriverSet);
            Assert.IsTrue(b.IsTahvilSet);
            Assert.IsTrue(b.IsTedadSet);
        }
        
    }
}