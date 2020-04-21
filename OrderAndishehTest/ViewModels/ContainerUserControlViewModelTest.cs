using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrdersAndisheh.ViewModel;
using Core.Services;
using OrdersAndisheh.DesignService;
using GalaSoft.MvvmLight.Messaging;
using System.Linq;
using System.Collections.Generic;
using Core.Models;

namespace OrderAndishehTest.ViewModels
{
    [TestClass]
    public class ContainerUserControlViewModelTest
    {
        
        [TestMethod]
        public void ContainerUserControlViewModelOpenWithData()
        {
            IErsalItemService itemService = new DesignErsalItemService();
            var items = itemService.GetItems("");
            var ranads = itemService.GetRanandehList();
            var chobi = items.Where(p => !p.ItemKala.IsPalletFelezi).Sum(p=>p.PalletCount);
            var felezi = items.Where(p => p.ItemKala.IsPalletFelezi).Sum(p => p.PalletCount);
            var ja = (Math.Ceiling((double)felezi / 2) + chobi).ToString();
            string maghsum = " ";
            items.Select(p => p.ItemMaghsad).Distinct().ToList().ForEach(p => maghsum = maghsum + " - " + (p!=null?p.Name:""));
            int sum = 0;
            items.ToList().ForEach(p => sum = sum + p.Vazn);

            ContainerUserControlViewModel vm = new ContainerUserControlViewModel(items,ranads);

            Assert.AreEqual(chobi,vm.ChobiPalletCount);
            Assert.AreEqual(felezi,vm.FeleziPalletCount);
            Assert.AreEqual(ja,vm.JaigahCount);
            Assert.AreEqual(maghsum,vm.Maghased);
            Assert.AreEqual(items.Count,vm.Mahmole.Count);
            Assert.AreEqual(ranads.Count,vm.Ranandeha.Count);
            Assert.IsNull(vm.SelectedRanande);
            Assert.AreEqual(sum,vm.VaznKol);
        }
        
        
    }
    
}
