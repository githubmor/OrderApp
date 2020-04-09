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
    public class SelectKalaViewModelTest
    {
        
        [TestMethod]
        public void ViewModelIntializeBeforeOpenTarikhTest()
        {
            IErsalItemService itemService = new DesignErsalItemService();
            SelectKalaUserControlViewModel vm = new SelectKalaUserControlViewModel(itemService);

            Assert.IsTrue(vm.AllKalaList.Count>0);
            Assert.IsTrue(vm.Selection_KalaList.Count==0);
            Assert.IsNull(vm.SelectedKala);
            Assert.IsNull(vm.Selection_SelectedItem);
        }
        [TestMethod]
        public void ViewModelOpenSefareshTest()
        {
            IErsalItemService itemService = new DesignErsalItemService();
            SelectKalaUserControlViewModel vm = new SelectKalaUserControlViewModel(itemService);


            vm.SelectedKala = vm.AllKalaList[0];

            vm.AddThisItem.Execute(null);

            Assert.IsTrue(vm.Selection_KalaList.First().Code == vm.SelectedKala.CodeKala);

        }

        
        
    }
}
