using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndisheh.Domain.Entity;
using System.Collections.Generic;

namespace OrderAndisheh.Domain.Test.EntityTest
{
    [TestClass]
    public class OrderEntityTest
    {
        [TestMethod]
        public void OrderEntityTest_AllSet_IsOk()
        {
            PalletEntity pallet = new PalletEntity("GP8", 200);

            KalaEntity kala = new KalaEntity("name", "codeAnbar", "fani", "jens",
                pallet, 120, 10, 800);

            ProductEntity p = new ProductEntity(kala, 120);
            DestinationEntity de = new DestinationEntity("Saipa");
            MahmoleEntity m = new MahmoleEntity(de, new List<ProductEntity>() { p });

            DriverEntity d = new DriverEntity("name", "mobile", "codeMeli", "pelak");

            CabinEntity c = new CabinEntity(new List<MahmoleEntity>() { m }, d);

            OrderEntity o = new OrderEntity(13980201, new List<CabinEntity>() { c }, 5, true);

            Assert.IsNotNull(o.Cabins);
            Assert.AreEqual(1, o.Cabins.Count);
        }

        [TestMethod]
        public void OrderEntityTest_DefaultSet_IsOk()
        {
            OrderEntity o = new OrderEntity(13980201, 5, true);

            Assert.IsNotNull(o.Cabins);
            Assert.AreEqual(0, o.Cabins.Count);
        }

        [TestMethod]
        public void OrderEntityTest_AddnewCabin_IsOk()
        {
            OrderEntity o = new OrderEntity(13980201, 5, true);

            PalletEntity pallet = new PalletEntity("GP8", 200);

            KalaEntity kala = new KalaEntity("name", "codeAnbar", "fani", "jens",
                pallet, 120, 10, 800);

            ProductEntity p = new ProductEntity(kala, 120);
            DestinationEntity de = new DestinationEntity("Saipa");
            MahmoleEntity m = new MahmoleEntity(de, new List<ProductEntity>() { p });

            DriverEntity d = new DriverEntity("name", "mobile", "codeMeli", "pelak");

            CabinEntity c = new CabinEntity(new List<MahmoleEntity>() { m }, d);

            o.AddCabin(new List<CabinEntity>() { c });

            Assert.IsNotNull(o.Cabins);
            Assert.AreEqual(1, o.Cabins.Count);
        }

        [TestMethod]
        public void OrderEntityTest_AddNewCabinWithSameDriver_IsOk()
        {
            PalletEntity pallet = new PalletEntity("GP8", 200);

            KalaEntity kala = new KalaEntity("name", "codeAnbar", "fani", "jens",
                pallet, 120, 10, 800);

            ProductEntity p = new ProductEntity(kala, 120);
            DestinationEntity de = new DestinationEntity("Saipa");
            MahmoleEntity m = new MahmoleEntity(de, new List<ProductEntity>() { p });

            DriverEntity d = new DriverEntity("name", "mobile", "codeMeli", "pelak");

            CabinEntity c = new CabinEntity(new List<MahmoleEntity>() { m }, d);

            OrderEntity o = new OrderEntity(13980201, new List<CabinEntity>() { c }, 5, true);

            PalletEntity pallet2 = new PalletEntity("GP8", 200);

            KalaEntity kala2 = new KalaEntity("name", "codeAnbar2", "fani", "jens",
                pallet2, 120, 10, 800);

            ProductEntity p2 = new ProductEntity(kala2, 120);
            DestinationEntity de2 = new DestinationEntity("Saipa");
            MahmoleEntity m2 = new MahmoleEntity(de2, new List<ProductEntity>() { p2 });

            DriverEntity d2 = new DriverEntity("name", "mobile", "codeMeli", "pelak");

            CabinEntity c2 = new CabinEntity(new List<MahmoleEntity>() { m2 }, d2);

            o.AddCabin(new List<CabinEntity>() { c2 });

            Assert.IsNotNull(o.Cabins);
            Assert.AreEqual(1, o.Cabins.Count);
        }

        [TestMethod]
        public void OrderEntityTest_AddNewCabinWithDifDriver_IsOk()
        {
            PalletEntity pallet = new PalletEntity("GP8", 200);

            KalaEntity kala = new KalaEntity("name", "codeAnbar", "fani", "jens",
                pallet, 120, 10, 800);

            ProductEntity p = new ProductEntity(kala, 120);
            DestinationEntity de = new DestinationEntity("Saipa");
            MahmoleEntity m = new MahmoleEntity(de, new List<ProductEntity>() { p });

            DriverEntity d = new DriverEntity("name", "mobile", "codeMeli", "pelak");

            CabinEntity c = new CabinEntity(new List<MahmoleEntity>() { m }, d);

            OrderEntity o = new OrderEntity(13980201, new List<CabinEntity>() { c }, 5, true);

            PalletEntity pallet2 = new PalletEntity("GP8", 200);

            KalaEntity kala2 = new KalaEntity("name", "codeAnbar2", "fani", "jens",
                pallet2, 120, 10, 800);

            ProductEntity p2 = new ProductEntity(kala2, 120);
            DestinationEntity de2 = new DestinationEntity("Saipa");
            MahmoleEntity m2 = new MahmoleEntity(de2, new List<ProductEntity>() { p });

            DriverEntity d2 = new DriverEntity("name2", "mobile", "codeMeli", "pelak");

            CabinEntity c2 = new CabinEntity(new List<MahmoleEntity>() { m2 }, d2);

            o.AddCabin(new List<CabinEntity>() { c2 });

            Assert.IsNotNull(o.Cabins);
            Assert.AreEqual(2, o.Cabins.Count);
        }
    }
}