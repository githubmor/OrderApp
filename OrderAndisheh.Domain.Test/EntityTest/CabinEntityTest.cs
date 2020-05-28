using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndisheh.Domain.Entity;
using System;

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
        }

        [TestMethod]
        public void CabinEntity_SetProperty_IsOk()
        {
            CabinEntity c = new CabinEntity();

            var d = new DriverEntity() { CodeMeli = "2064800", Mobile = "0911", Name = "masoud", Pelak = "ad" };
            c.Driver = d;
            var cf = new System.Collections.Generic.List<MahmoleEntity>(){
                new MahmoleEntity(){Destination=new DestinationEntity(){Name="irankhodro"},
                    Product=new System.Collections.Generic.List<ProductEntity>(){
                        new ProductEntity(new KalaEntity(),200)
                }}
            };
            c.Mahmoles = cf;

            Assert.IsNotNull(c.Driver);
            Assert.IsNotNull(c.Mahmoles);
            Assert.AreEqual(1, c.Mahmoles.Count);
        }

        [ExpectedException(typeof(NullReferenceException))]
        [TestMethod]
        public void CabinEntity_NullDriver_IsOk()
        {
            CabinEntity c = new CabinEntity();
            c.Driver = null;
        }

        [ExpectedException(typeof(NullReferenceException))]
        [TestMethod]
        public void CabinEntity_NullMahmoles_IsOk()
        {
            CabinEntity c = new CabinEntity();
            c.Mahmoles = null;
        }
    }
}