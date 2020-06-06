using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndisheh.Domain.Entity;
using System;
using System.Collections.Generic;

namespace OrderAndisheh.Domain.Test.EntityTest
{
    [TestClass]
    public class ErsalKalaEntityTest
    {
        [TestMethod]
        public void ErsalKalaEntity_DefaultProperty_IsOK()
        {

            ErsalKalaEntity e = new ErsalKalaEntity("name", "codeAnbar", "fani", "jens",20,2,getKhodroList(),getCustomer());

            Assert.AreEqual(20,e.TedadErsali);
            Assert.AreEqual(2, e.ZaribMasrafDarKhodro);
            Assert.AreEqual(1, e.Khodors.Count);
            Assert.IsNotNull(e.Khodors);
            Assert.IsNotNull(e.Customer);

        }

        

        //[TestMethod]
        //public void ErsalKalaEntity_IsUsedInKhodro_IsOK()
        //{

        //    ErsalKalaEntity e = new ErsalKalaEntity("name", "codeAnbar", "fani", "jens", 20, 2, getKhodroList());

        //    Assert.IsTrue(e.IsUsedInKhodro(new KhodorEntity("206")););
        //}
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void ErsalKalaEntity_AllNull_IsOK()
        {

            ErsalKalaEntity e = new ErsalKalaEntity("name", "codeAnbar", "fani", "jens", 20, 0, new List<KhodorEntity>(),null);
        }
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void ErsalKalaEntity_EmptyKhodros_IsOK()
        {

            ErsalKalaEntity e = new ErsalKalaEntity("name", "codeAnbar", "fani", "jens", 20, 10, new List<KhodorEntity>(),getCustomer());
        }
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void ErsalKalaEntity_ZerZarib_IsOK()
        {

            ErsalKalaEntity e = new ErsalKalaEntity("name", "codeAnbar", "fani", "jens", 20, 0, getKhodroList(),getCustomer());
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void ErsalKalaEntity_NullCustomer_IsOK()
        {

            ErsalKalaEntity e = new ErsalKalaEntity("name", "codeAnbar", "fani", "jens", 20, 10, getKhodroList(), null);
        }
        [ExpectedException(typeof(ArgumentNullException))]
        private List<KhodorEntity> getKhodroList()
        {
            return new List<KhodorEntity>() { new KhodorEntity("206") };
        }
        private BaseCustomerEntity getCustomer()
        {
            return new BaseCustomerEntity("Sapco");
        }

    }
}