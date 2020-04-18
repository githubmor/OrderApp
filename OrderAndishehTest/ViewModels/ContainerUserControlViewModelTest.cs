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

            MahmoleList n = new MahmoleList();
            items.ForEach(p => n.Add(new ContainerRow(p)));

            ContainerUserControlViewModel vm = new ContainerUserControlViewModel(items,ranads);

            Assert.AreEqual(vm.ChobiPalletCount,n.ChobiPalletCount);
            Assert.AreEqual(vm.FeleziPalletCount,n.FeleziPalletCount);
            //با تغییر آیتم ها اینها ممکنه فیل بشه
            Assert.AreEqual("236",vm.JaigahCount);
            Assert.AreEqual(vm.Maghased, " - kashan - saipa -  - pars");

            Assert.AreEqual(vm.Mahmole.Count, n.Count);
            Assert.AreEqual(vm.Ranandeha.Count, ranads.Count);
            Assert.AreEqual(vm.SelectedRanande, null);
            Assert.AreEqual(vm.VaznKol, n.VaznKol);
        }
        
        
    }
}
