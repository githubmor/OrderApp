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
    public class MaghsadViewModelTest
    {
        
        [TestMethod]
        public void MaghsadItemUserControlViewModelOpenWithDefault()
        {
            IErsalItemService itemService = new DesignErsalItemService();
            MaghsadItemUserControlViewModel vm = new MaghsadItemUserControlViewModel(itemService);

            Assert.IsTrue(vm.KalaList.Count==0);
            Assert.IsTrue(vm.Maghased.Count==0);
            Assert.IsNull(vm.SelectionMaghsad);
        }
        [TestMethod]
        public void MaghsadViewModelSendItems()
        {
            IErsalItemService itemService = new DesignErsalItemService();
            MaghsadItemUserControlViewModel vm = new MaghsadItemUserControlViewModel(itemService);

            List<ItemDto> items = itemService.GetItems("");
            Messenger.Default.Send<List<ItemDto>>(items, "GetKala");

            Assert.IsTrue(vm.KalaList.Count > 0);
            Assert.IsTrue(vm.Maghased.Count > 0);
            Assert.IsNull(vm.SelectionMaghsad);

            vm.KalaList.First().IsSelected = true;

            vm.SelectionMaghsad = vm.Maghased[0];

            vm.SetMaghsad.Execute(null);

            Assert.IsTrue(vm.KalaList.First().MaghsadName == vm.SelectionMaghsad.Name);

        }

        
        
    }
}
