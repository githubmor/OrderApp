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
            Assert.AreEqual(0, cabin.getCabinVazn());
        }

        [TestMethod]
        public void CabinEntity_SetDriver_IsOk()
        {
            CabinEntity cabin = new CabinEntity(Ultility.getDriver());

            Assert.IsNotNull(cabin.Driver);
            Assert.IsNotNull(cabin.Mahmoles);
            Assert.AreEqual(0, cabin.Mahmoles.Count);
            Assert.AreEqual("name", cabin.Drivername);
            Assert.AreEqual(0, cabin.getCabinVazn());
        }

        [TestMethod]
        public void CabinEntity_SetNullDriver_IsOk()
        {
            CabinEntity cabin = new CabinEntity(null);

            Assert.IsNull(cabin.Driver);
            Assert.IsNotNull(cabin.Mahmoles);
            Assert.AreEqual(0, cabin.Mahmoles.Count);
            Assert.AreEqual("", cabin.Drivername);
            Assert.AreEqual(0, cabin.getCabinVazn());
        }

        [TestMethod]
        public void CabinEntity_AddNullDriver_IsOk()
        {
            CabinEntity cabin = new CabinEntity(Ultility.getDriver());

            cabin.Driver = null;

            Assert.IsNull(cabin.Driver);
            Assert.IsNotNull(cabin.Mahmoles);
            Assert.AreEqual(0, cabin.Mahmoles.Count);
            Assert.AreEqual("", cabin.Drivername);
            Assert.AreEqual(0, cabin.getCabinVazn());
        }

        [TestMethod]
        public void CabinEntity_SetMahmoleAndDriver_IsOk()
        {
            CabinEntity cabin = new CabinEntity(Ultility.getMahmoleList_Default(), Ultility.getDriver());

            Assert.IsNotNull(cabin.Driver);
            Assert.IsNotNull(cabin.Mahmoles);
            Assert.AreEqual(1, cabin.Mahmoles.Count);
            Assert.AreEqual("name", cabin.Drivername);
            Assert.AreEqual(800, cabin.getCabinVazn());
        }

        [TestMethod]
        public void CabinEntity_getCabinJaighah_IsOk()
        {
            CabinEntity cabin = new CabinEntity(Ultility.getMahmoleList_Default(), Ultility.getDriver());

            var re = cabin.getCabinJaighah();

            Assert.AreEqual(1, re);
        }

        [TestMethod]
        public void CabinEntity_getCabinPalletCount_IsOk()
        {
            CabinEntity cabin = new CabinEntity(Ultility.getMahmoleList_Default(), Ultility.getDriver());

            var re = cabin.getCabinPalletCount();

            Assert.AreEqual(1, re);
        }

        [TestMethod]
        public void CabinEntity_getCabinVazn_IsOk()
        {
            CabinEntity cabin = new CabinEntity(Ultility.getMahmoleList_Default(), Ultility.getDriver());

            var re = cabin.getCabinVazn();

            Assert.AreEqual(800, re);
        }

        [TestMethod]
        public void CabinEntity_SetMahmole_IsOk()
        {
            CabinEntity cabin = new CabinEntity(Ultility.getMahmoleList_Default());

            Assert.IsNull(cabin.Driver);
            Assert.IsNotNull(cabin.Mahmoles);
            Assert.AreEqual(1, cabin.Mahmoles.Count);
            Assert.AreEqual("", cabin.Drivername);
            Assert.AreEqual(800, cabin.getCabinVazn());
        }

        [TestMethod]
        public void CabinEntity_SetNullMahmole_IsOk()
        {
            CabinEntity cabin = new CabinEntity(null);

            Assert.IsNull(cabin.Driver);
            Assert.IsNotNull(cabin.Mahmoles);
            Assert.AreEqual(0, cabin.Mahmoles.Count);
            Assert.AreEqual("", cabin.Drivername);
            Assert.AreEqual(0, cabin.getCabinVazn());
        }

        [TestMethod]
        public void CabinEntity_SetEmptyMahmole_IsOk()
        {
            CabinEntity cabin = new CabinEntity(new List<MahmoleEntity>());

            Assert.IsNull(cabin.Driver);
            Assert.IsNotNull(cabin.Mahmoles);
            Assert.AreEqual(0, cabin.Mahmoles.Count);
            Assert.AreEqual("", cabin.Drivername);
            Assert.AreEqual(0, cabin.getCabinVazn());
        }

        [TestMethod]
        public void CabinEntity_AddMahmole_IsOk()
        {
            CabinEntity cabin = new CabinEntity(Ultility.getDriver());

            cabin.AddMahmole(Ultility.getMahmoleList_Default());

            Assert.IsNotNull(cabin.Driver);
            Assert.IsNotNull(cabin.Mahmoles);
            Assert.AreEqual(1, cabin.Mahmoles.Count);
            Assert.AreEqual("name", cabin.Drivername);
            Assert.AreEqual(800, cabin.getCabinVazn());
        }

        [TestMethod]
        public void CabinEntity_AddEmptyMahmole_IsOk()
        {
            CabinEntity cabin = new CabinEntity(Ultility.getDriver());

            cabin.AddMahmole(new List<MahmoleEntity>());

            Assert.IsNotNull(cabin.Driver);
            Assert.IsNotNull(cabin.Mahmoles);
            Assert.AreEqual(0, cabin.Mahmoles.Count);
            Assert.AreEqual("name", cabin.Drivername);
            Assert.AreEqual(0, cabin.getCabinVazn());
        }

        [TestMethod]
        public void CabinEntity_AddNullMahmole_IsOk()
        {
            CabinEntity cabin = new CabinEntity(Ultility.getDriver());

            cabin.AddMahmole(null);

            Assert.IsNotNull(cabin.Driver);
            Assert.IsNotNull(cabin.Mahmoles);
            Assert.AreEqual(0, cabin.Mahmoles.Count);
            Assert.AreEqual("name", cabin.Drivername);
            Assert.AreEqual(0, cabin.getCabinVazn());
        }

        [TestMethod]
        public void CabinEntity_AddMahmoleWithSameDestination_IsOk()
        {
            CabinEntity cabin = new CabinEntity(Ultility.getMahmoleList_Default(), Ultility.getDriver());

            cabin.AddMahmole(Ultility.getMahmoleList_DifProduct_SameDestination());

            Assert.IsNotNull(cabin.Driver);
            Assert.IsNotNull(cabin.Mahmoles);
            Assert.AreEqual(1, cabin.Mahmoles.Count);
            Assert.AreEqual("name", cabin.Drivername);
            Assert.AreEqual(1600, cabin.getCabinVazn());
        }

        [TestMethod]
        public void CabinEntity_AddMahmoleWithDiffrentDestination_IsOk()
        {
            CabinEntity cabin = new CabinEntity(Ultility.getMahmoleList_Default(), Ultility.getDriver());

            cabin.AddMahmole(Ultility.getMahmoleList_SameProduct_DifDestination());

            Assert.IsNotNull(cabin.Driver);
            Assert.IsNotNull(cabin.Mahmoles);
            Assert.AreEqual(2, cabin.Mahmoles.Count);
            Assert.AreEqual("name", cabin.Drivername);
            Assert.AreEqual(1600, cabin.getCabinVazn());
        }
    }
}