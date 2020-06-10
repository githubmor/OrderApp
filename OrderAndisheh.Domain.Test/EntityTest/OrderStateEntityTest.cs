using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndisheh.Domain.Entity;

namespace OrderAndisheh.Domain.Test.EntityTest
{
    [TestClass]
    public class OrderStateEntityTest
    {
        [TestMethod]
        public void OrderStateEntity_SetProperty_IsOk()
        {
            OrderStateEntity orderState = new OrderStateEntity(13990102, true, true, true, true);

            Assert.IsTrue(orderState.IsDestinationSet);
            Assert.IsTrue(orderState.IsDriverSet);
            Assert.IsTrue(orderState.IsTahvilSet);
            Assert.IsTrue(orderState.IsTedadSet);
        }
    }
}