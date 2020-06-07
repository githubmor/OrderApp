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
            CabinEntity cabin = new CabinEntity();

            Assert.IsNull(cabin.Driver);
            Assert.IsNotNull(cabin.Mahmoles);
            Assert.AreEqual(0, cabin.Mahmoles.Count);
            Assert.AreEqual("", cabin.Drivername);
            Assert.AreEqual(0, cabin.VaznCabin);
        }

        [TestMethod]
        public void CabinEntity_SetDriver_IsOk()
        {
            CabinEntity cabin = new CabinEntity(Ultility.getDriver());

            Assert.IsNotNull(cabin.Driver);
            Assert.IsNotNull(cabin.Mahmoles);
            Assert.AreEqual(0, cabin.Mahmoles.Count);
            Assert.AreEqual("name", cabin.Drivername);
            Assert.AreEqual(0, cabin.VaznCabin);
        }

        [TestMethod]
        public void CabinEntity_SetNullDriver_IsOk()
        {
            CabinEntity cabin = new CabinEntity(Ultility.getDriver());

            cabin.Driver = null;

            Assert.IsNull(cabin.Driver);
            Assert.IsNotNull(cabin.Mahmoles);
            Assert.AreEqual(0, cabin.Mahmoles.Count);
            Assert.AreEqual("", cabin.Drivername);
            Assert.AreEqual(0, cabin.VaznCabin);
        }

        [TestMethod]
        public void CabinEntity_SetMahmoleAndDriver_IsOk()
        {
            CabinEntity c = new CabinEntity(Ultility.getMahmoleList(), Ultility.getDriver());

            Assert.IsNotNull(c.Driver);
            Assert.IsNotNull(c.Mahmoles);
            Assert.AreEqual(1, c.Mahmoles.Count);
            Assert.AreEqual("name", c.Drivername);
            Assert.AreEqual(800, c.VaznCabin);
        }

        [TestMethod]
        public void CabinEntity_SetMahmole_IsOk()
        {
            CabinEntity c = new CabinEntity(Ultility.getMahmoleList());

            Assert.IsNull(c.Driver);
            Assert.IsNotNull(c.Mahmoles);
            Assert.AreEqual(1, c.Mahmoles.Count);
            Assert.AreEqual("", c.Drivername);
            Assert.AreEqual(800, c.VaznCabin);
        }

        [TestMethod]
        public void CabinEntity_AddMahmole_IsOk()
        {
            CabinEntity c = new CabinEntity(Ultility.getDriver());

            c.AddMahmole(Ultility.getMahmoleList());

            Assert.IsNotNull(c.Driver);
            Assert.IsNotNull(c.Mahmoles);
            Assert.AreEqual(1, c.Mahmoles.Count);
            Assert.AreEqual("name", c.Drivername);
            Assert.AreEqual(800, c.VaznCabin);
        }

        [TestMethod]
        public void CabinEntity_AddEmptyMahmole_IsOk()
        {
            CabinEntity c = new CabinEntity(Ultility.getDriver());

            c.AddMahmole(new List<MahmoleEntity>());

            Assert.IsNotNull(c.Driver);
            Assert.IsNotNull(c.Mahmoles);
            Assert.AreEqual(0, c.Mahmoles.Count);
            Assert.AreEqual("name", c.Drivername);
            Assert.AreEqual(0, c.VaznCabin);
        }

        [TestMethod]
        public void CabinEntity_AddMahmoleWithSameDestination_IsOk()
        {
            CabinEntity c = new CabinEntity(Ultility.getMahmoleList(), Ultility.getDriver());

            c.AddMahmole(Ultility.getMahmoleList2());

            Assert.IsNotNull(c.Driver);
            Assert.IsNotNull(c.Mahmoles);
            Assert.AreEqual(1, c.Mahmoles.Count);
            Assert.AreEqual("name", c.Drivername);
            Assert.AreEqual(1600, c.VaznCabin);
        }

        [TestMethod]
        public void CabinEntity_AddMahmoleWithDiffrentDestination_IsOk()
        {
            CabinEntity c = new CabinEntity(Ultility.getMahmoleList(), Ultility.getDriver());

            c.AddMahmole(Ultility.getMahmoleList3());

            Assert.IsNotNull(c.Driver);
            Assert.IsNotNull(c.Mahmoles);
            Assert.AreEqual(2, c.Mahmoles.Count);
            Assert.AreEqual("name", c.Drivername);
            Assert.AreEqual(1600, c.VaznCabin);
        }
    }
}