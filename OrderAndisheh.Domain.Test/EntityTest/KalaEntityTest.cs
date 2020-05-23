using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndisheh.Domain.Entity;

namespace OrderAndisheh.Domain.Test.EntityTest
{
    [TestClass]
    public class KalaEntityTest
    {
        [TestMethod]
        public void KalaEntity_DefaultProperty_IsOK()
        {
            KalaEntity k = new KalaEntity();

            Assert.AreEqual(k.Code, "");
            Assert.AreEqual(k.CodeJense, "");
            Assert.AreEqual(k.Name, "");
            Assert.AreEqual(k.TedadDarBaste, 0);
            Assert.AreEqual(k.TedadDarPallet, 0);
            Assert.AreEqual(k.WeighWithPallet, 0);
            Assert.AreEqual(k.getBasteCount(20), 0);
            Assert.AreEqual(k.getPalletCount(20), 0);
            Assert.AreEqual(k.getVazn(20), 0);
        }

        [TestMethod]
        public void KalaEntity_SetProperty_IsOK()
        {
            KalaEntity k = new KalaEntity();
            k.Code = "asdasd";
            k.CodeJense = "asdsa";
            k.Name = "asdd";
            k.TedadDarBaste = 16;
            k.TedadDarPallet = 120;
            k.WeighWithPallet = 700;

            Assert.AreEqual(k.Code, "asdasd");
            Assert.AreEqual(k.CodeJense, "asdsa");
            Assert.AreEqual(k.Name, "asdd");
            Assert.AreEqual(k.TedadDarBaste, 16);
            Assert.AreEqual(k.TedadDarPallet, 120);
            Assert.AreEqual(k.WeighWithPallet, 700);
            Assert.AreEqual(k.getBasteCount(240), 0);
            Assert.AreEqual(k.getPalletCount(240), 2);
            Assert.AreEqual(k.getVazn(240), 1400);
        }

        [TestMethod]
        public void KalaEntity_SetBasteProperty_IsOK()
        {
            KalaEntity k = new KalaEntity();
            k.Code = "asdasd";
            k.CodeJense = "asdsa";
            k.Name = "asdd";
            k.TedadDarBaste = 16;
            k.TedadDarPallet = 120;
            k.WeighWithPallet = 700;

#error مقادير حساب كن
            Assert.AreEqual(k.getBasteCount(270), 5);
            Assert.AreEqual(k.getPalletCount(270), 3);
            Assert.AreEqual(k.getVazn(270), 1700);
        }
    }
}