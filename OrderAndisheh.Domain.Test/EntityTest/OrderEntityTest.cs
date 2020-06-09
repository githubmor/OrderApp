using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndisheh.Domain.Entity;

namespace OrderAndisheh.Domain.Test.EntityTest
{
    [TestClass]
    public class OrderEntityTest
    {
        [TestMethod]
        public void OrderEntityTest_AllSet_IsOk()
        {
            OrderEntity order = new OrderEntity(13980201, Ultility.getCabinList(), 5, true);

            Assert.IsNotNull(order.Cabins);
            Assert.AreEqual(1, order.Cabins.Count);
        }

        [TestMethod]
        public void OrderEntityTest_DefaultSet_IsOk()
        {
            OrderEntity order = new OrderEntity(13980201, 5, true);

            Assert.IsNotNull(order.Cabins);
            Assert.AreEqual(0, order.Cabins.Count);
        }

        [TestMethod]
        public void OrderEntityTest_AddnewCabin_IsOk()
        {
            OrderEntity order = new OrderEntity(13980201, 5, true);

            order.AddCabin(Ultility.getCabinList());

            Assert.IsNotNull(order.Cabins);
            Assert.AreEqual(1, order.Cabins.Count);
        }

        [TestMethod]
        public void OrderEntityTest_AddNullCabin_IsOk()
        {
            OrderEntity order = new OrderEntity(13980201, 5, true);

            order.AddCabin(null);

            Assert.IsNotNull(order.Cabins);
            Assert.AreEqual(0, order.Cabins.Count);
        }

        [TestMethod]
        public void OrderEntityTest_AddNewCabinWithSameDriver_IsOk()
        {
            OrderEntity order = new OrderEntity(13980201, Ultility.getCabinList(), 5, true);

            order.AddCabin(Ultility.getCabinList3());

            Assert.IsNotNull(order.Cabins);
            Assert.AreEqual(1, order.Cabins.Count);
            Assert.AreEqual(2, order.Cabins[0].Mahmoles[0].Products.Count);
        }

        [TestMethod]
        public void OrderEntityTest_AddNewCabinWithDifDriver_IsOk()
        {
            OrderEntity order = new OrderEntity(13980201, Ultility.getCabinList(), 5, true);

            order.AddCabin(Ultility.getCabinList2());

            Assert.IsNotNull(order.Cabins);
            Assert.AreEqual(2, order.Cabins.Count);
            Assert.AreEqual(1, order.Cabins[0].Mahmoles.Count);
            Assert.AreEqual(1, order.Cabins[1].Mahmoles.Count);
        }
    }
}