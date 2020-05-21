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
        IErsalItemService itemService;
        public ContainerUserControlViewModelTest()
        {
            itemService = new DesignErsalItemService();
        }
        [TestMethod]
        public void ContainerUserControlViewModelOpenWithData()
        {
            var ranads = itemService.GetRanandehList();

            ContainerUserControlViewModel vm = new ContainerUserControlViewModel(getItems(),ranads);

            Assert.AreEqual(1,vm.ChobiPalletCount);
            Assert.AreEqual(1,vm.FeleziPalletCount);
            Assert.AreEqual("2",vm.JaigahCount);
            Assert.AreEqual("aaa - bbb", vm.Maghased);
            Assert.AreEqual(2,vm.Mahmole.Count);
            Assert.AreEqual(4,vm.Ranandeha.Count);
            Assert.IsNotNull(vm.SelectedRanande);
            Assert.AreEqual(300,vm.VaznKol);
        }

        private List<ItemDto> getItems()
        {
            return new List<ItemDto>() 
                { 
                    new ItemDto() 
                    { 
                        Id = 1,
                        ItemKala = new KalaDto(){Name = "111",IsPalletFelezi=true}, 
                        ItemMaghsad = new MaghsadDto(){Name="aaa"},
                        ItemRanande = itemService.GetRanandehList()[0],
                        Karton = 5,
                        PalletCount = 1,
                        Vazn = 100
                    },
                    new ItemDto() 
                    { 
                        Id = 2,
                        ItemKala = new KalaDto(){Name = "121"}, 
                        ItemMaghsad = new MaghsadDto(){Name="bbb"},
                        Karton = 50,
                        PalletCount = 1,
                        Tedad = 48,
                        Vazn = 200
                    },
                    
                };
        }

        [TestMethod]
        public void ContainerUserControlViewModelOpenWithData2()
        {
            var ranads = itemService.GetRanandehList();

            ContainerUserControlViewModel vm = new ContainerUserControlViewModel(getItems2(), ranads);

            Assert.AreEqual(1, vm.ChobiPalletCount);
            Assert.AreEqual(1, vm.FeleziPalletCount);
            Assert.AreEqual("2", vm.JaigahCount);
            Assert.AreEqual("", vm.Maghased);
            Assert.AreEqual(2, vm.Mahmole.Count);
            Assert.AreEqual(4, vm.Ranandeha.Count);
            Assert.IsNotNull(vm.SelectedRanande);
            Assert.AreEqual(300, vm.VaznKol);
        }

        private List<ItemDto> getItems2()
        {
            return new List<ItemDto>() 
                { 
                    new ItemDto() 
                    { 
                        Id = 1,
                        ItemKala = new KalaDto(){Name = "111",IsPalletFelezi=true}, 
                        ItemRanande = itemService.GetRanandehList()[0],
                        Karton = 5,
                        PalletCount = 1,
                        Vazn = 100
                    },
                    new ItemDto() 
                    { 
                        Id = 2,
                        ItemKala = new KalaDto(){Name = "121"}, 
                        Karton = 50,
                        PalletCount = 1,
                        Tedad = 48,
                        Vazn = 200
                    },
                    
                };
        }

        
    }
    
}
