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
    public class NewViewModelTest
    {
        
        [TestMethod]
        public void ViewModelIntializeBeforeOpenTarikhTest()
        {
            IErsalItemService itemService = new DesignErsalItemService();
            NewItemViewModel vm = new NewItemViewModel(itemService);

            Assert.IsTrue(vm.SelectedViewModel is SelectKalaUserControlViewModel);
            Assert.IsTrue(vm.Next.CanExecute(null));
            Assert.IsFalse(vm.Back.CanExecute(null));
            //Assert.IsFalse(vm.AddToSefaresh.CanExecute(null));
        }
        [TestMethod]
        public void ViewModelOpenSefareshTest()
        {
            IErsalItemService itemService = new DesignErsalItemService();
            NewItemViewModel vm = new NewItemViewModel(itemService);

            List<ItemDto> items = itemService.GetItems("");
            Messenger.Default.Send<List<ItemDto>>(items, "SendItemsFromMain");

            Assert.IsTrue(vm.SelectedViewModel is MaghsadItemUserControlViewModel);
            Assert.IsFalse(vm.Next.CanExecute(null));
            Assert.IsTrue(vm.Back.CanExecute(null));
            //Assert.IsTrue(vm.AddToSefaresh.CanExecute(null));

        }

        
        
    }
}
