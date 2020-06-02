using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndisheh.Domain.Entity;
using System.Collections.Generic;

namespace OrderAndisheh.Domain.Test.EntityTest
{
    [TestClass]
    public class CabinEntityTest
    {
        [TestMethod]
        public void CabinEntity_DefaultProperty_IsOk()
        {
            CabinEntity c = new CabinEntity();

            Assert.IsNull(c.Driver);
            Assert.IsNotNull(c.Mahmoles);
            Assert.AreEqual(0, c.Mahmoles.Count);
            Assert.AreEqual("", c.Drivername);
            Assert.AreEqual(0, c.VaznCabin);
        }

        [TestMethod]
        public void CabinEntity_SetDriver_IsOk()
        {
            DriverEntity d = new DriverEntity("name", "mobile", "codeMeli", "pelak");
            CabinEntity c = new CabinEntity(d);

            Assert.IsNotNull(c.Driver);
            Assert.IsNotNull(c.Mahmoles);
            Assert.AreEqual(0, c.Mahmoles.Count);
            Assert.AreEqual("name", c.Drivername);
            Assert.AreEqual(0, c.VaznCabin);
        }

        [TestMethod]
        public void CabinEntity_SetNullDriver_IsOk()
        {
            DriverEntity d = new DriverEntity("name", "mobile", "codeMeli", "pelak");
            CabinEntity c = new CabinEntity(d);

            c.Driver = null;

            Assert.IsNull(c.Driver);
            Assert.IsNotNull(c.Mahmoles);
            Assert.AreEqual(0, c.Mahmoles.Count);
            Assert.AreEqual("", c.Drivername);
            Assert.AreEqual(0, c.VaznCabin);
        }

        [TestMethod]
        public void CabinEntity_SetMahmoleAndDriver_IsOk()
        {
            PalletEntity pallet = new PalletEntity("GP8", 200);

            KalaEntity kala = new KalaEntity("name", "codeAnbar", "fani", "jens",
                pallet, 120, 10, 800);

            ProductEntity p = new ProductEntity(kala, 120);
            DestinationEntity de = new DestinationEntity("Saipa");
            MahmoleEntity m = new MahmoleEntity(de, new List<ProductEntity>() { p });

            DriverEntity d = new DriverEntity("name", "mobile", "codeMeli", "pelak");

            CabinEntity c = new CabinEntity(new List<MahmoleEntity>() { m }, d);

            Assert.IsNotNull(c.Driver);
            Assert.IsNotNull(c.Mahmoles);
            Assert.AreEqual(1, c.Mahmoles.Count);
            Assert.AreEqual("name", c.Drivername);
            Assert.AreEqual(800, c.VaznCabin);
        }

        [TestMethod]
        public void CabinEntity_SetMahmole_IsOk()
        {
            PalletEntity pallet = new PalletEntity("GP8", 200);

            KalaEntity kala = new KalaEntity("name", "codeAnbar", "fani", "jens",
                pallet, 120, 10, 800);

            ProductEntity p = new ProductEntity(kala, 120);
            DestinationEntity de = new DestinationEntity("Saipa");
            MahmoleEntity m = new MahmoleEntity(de, new List<ProductEntity>() { p });

            CabinEntity c = new CabinEntity(new List<MahmoleEntity>() { m });

            Assert.IsNull(c.Driver);
            Assert.IsNotNull(c.Mahmoles);
            Assert.AreEqual(1, c.Mahmoles.Count);
            Assert.AreEqual("", c.Drivername);
            Assert.AreEqual(800, c.VaznCabin);
        }

        [TestMethod]
        public void CabinEntity_SetNewMahmole_IsOk()
        {
            PalletEntity pallet = new PalletEntity("GP8", 200);

            KalaEntity kala = new KalaEntity("name", "codeAnbar", "fani", "jens",
                pallet, 120, 10, 800);

            ProductEntity p = new ProductEntity(kala, 120);
            DestinationEntity de = new DestinationEntity("Saipa");
            MahmoleEntity m = new MahmoleEntity(de, new List<ProductEntity>() { p });

            DriverEntity d = new DriverEntity("name", "mobile", "codeMeli", "pelak");

            CabinEntity c = new CabinEntity(d);

            c.AddMahmole(new List<MahmoleEntity>() { m });

            Assert.IsNotNull(c.Driver);
            Assert.IsNotNull(c.Mahmoles);
            Assert.AreEqual(1, c.Mahmoles.Count);
            Assert.AreEqual("name", c.Drivername);
            Assert.AreEqual(800, c.VaznCabin);
        }

        [TestMethod]
        public void CabinEntity_SetNewMahmole2_IsOk()
        {
            PalletEntity pallet = new PalletEntity("GP8", 200);

            KalaEntity kala = new KalaEntity("name", "codeAnbar", "fani", "jens",
                pallet, 120, 10, 800);

            ProductEntity p = new ProductEntity(kala, 120);
            DestinationEntity de = new DestinationEntity("Saipa");
            MahmoleEntity m = new MahmoleEntity(de, new List<ProductEntity>() { p });

            DriverEntity d = new DriverEntity("name", "mobile", "codeMeli", "pelak");

            CabinEntity c = new CabinEntity(new List<MahmoleEntity>() { m }, d);

            PalletEntity pallet2 = new PalletEntity("GP8", 200);

            KalaEntity kala2 = new KalaEntity("name", "codeAnbar2", "fani", "jens",
                pallet2, 120, 10, 800);

            ProductEntity p2 = new ProductEntity(kala2, 120);
            DestinationEntity de2 = new DestinationEntity("Saipa");
            MahmoleEntity m2 = new MahmoleEntity(de2, new List<ProductEntity>() { p2 });

            c.AddMahmole(new List<MahmoleEntity>() { m2 });

            Assert.IsNotNull(c.Driver);
            Assert.IsNotNull(c.Mahmoles);
            Assert.AreEqual(1, c.Mahmoles.Count);
            Assert.AreEqual("name", c.Drivername);
            Assert.AreEqual(1600, c.VaznCabin);
        }

        [TestMethod]
        public void CabinEntity_SetNewMahmole3_IsOk()
        {
            PalletEntity pallet = new PalletEntity("GP8", 200);

            KalaEntity kala = new KalaEntity("name", "codeAnbar", "fani", "jens",
                pallet, 120, 10, 800);

            ProductEntity p = new ProductEntity(kala, 120);
            DestinationEntity de = new DestinationEntity("Saipa");
            MahmoleEntity m = new MahmoleEntity(de, new List<ProductEntity>() { p });

            DriverEntity d = new DriverEntity("name", "mobile", "codeMeli", "pelak");

            CabinEntity c = new CabinEntity(new List<MahmoleEntity>() { m }, d);

            PalletEntity pallet2 = new PalletEntity("GP8", 200);

            KalaEntity kala2 = new KalaEntity("name2", "codeAnbar", "fani", "jens",
                pallet2, 120, 10, 800);

            ProductEntity p2 = new ProductEntity(kala2, 120);
            DestinationEntity de2 = new DestinationEntity("Sapco");
            MahmoleEntity m2 = new MahmoleEntity(de2, new List<ProductEntity>() { p2 });

            c.AddMahmole(new List<MahmoleEntity>() { m2 });

            Assert.IsNotNull(c.Driver);
            Assert.IsNotNull(c.Mahmoles);
            Assert.AreEqual(2, c.Mahmoles.Count);
            Assert.AreEqual("name", c.Drivername);
            Assert.AreEqual(1600, c.VaznCabin);
        }
    }
}