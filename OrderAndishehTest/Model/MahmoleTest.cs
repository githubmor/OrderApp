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

            Assert.AreEqual(chobi, vm.ChobiPalletCount);
            Assert.AreEqual(felezi, vm.FeleziPalletCount);
            Assert.AreEqual(maghsum, vm.Maghased);
            Assert.AreEqual(sum, vm.VaznKol);
            Assert.AreEqual(items.Count, vm.Count);

        }
    }
}
