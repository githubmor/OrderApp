using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Services;
using System.Linq;
using OrdersAndisheh.DesignService;
using OrdersAndisheh.ViewModel;

namespace OrderAndishehTest.Model
{
    [TestClass]
    public class MahmoleTest
    {
        [TestMethod]
        public void MahmoleIsOk()
        {
            IErsalItemService itemService = new DesignErsalItemService();
            var items = itemService.GetItems("");
            var ranads = itemService.GetRanandehList();
            var chobi = items.Where(p => !p.ItemKala.IsPalletFelezi).Sum(p => p.PalletCount);
            var felezi = items.Where(p => p.ItemKala.IsPalletFelezi).Sum(p => p.PalletCount);
            var ja = (Math.Ceiling((double)felezi / 2) + chobi).ToString();
            string maghsum = " ";
            items.Select(p => p.ItemMaghsad).Distinct().ToList().ForEach(p => maghsum = maghsum + " - " + (p != null ? p.Name : ""));
            int sum = 0;
            items.ToList().ForEach(p => sum = sum + p.Vazn);

            MahmoleList vm = new MahmoleList();
            items.ForEach(p => vm.Add(new ContainerRow(p)));

            Assert.AreEqual(236, vm.ChobiPalletCount);
            Assert.AreEqual(0, vm.FeleziPalletCount);
            Assert.AreEqual("kashan - saipa - pars", vm.Maghased);
            Assert.AreEqual(2677, vm.VaznKol);
            Assert.AreEqual(5, vm.Count);

        }
    }
}
