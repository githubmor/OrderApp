using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrdersAndisheh.ViewModel;
using Core.Services;
using OrdersAndisheh.DesignService;
using GalaSoft.MvvmLight.Messaging;
using Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace OrderAndishehTest.ViewModels
{
    [TestClass]
    public class ContaineringViewModelTest
    {
        IErsalItemService itemService;
        public ContaineringViewModelTest()
        {
            itemService = new DesignErsalItemService();
        }
        [TestMethod]
        public void ContaineringVMIntializeDefault()
        {
            ContaineringListViewModel vm = new ContaineringListViewModel(itemService);

            Assert.AreEqual(0, vm.ContinarViewModels.Count);
        }

        [TestMethod]
        public void ContaineringVMSendItems_WithRanaded_NoRanande()
        {
            ContaineringListViewModel vm = new ContaineringListViewModel(itemService);

            List<ItemDto> items = GetItems();
            Messenger.Default.Send<List<ItemDto>>(items, "SendItemListForContaining");

            Assert.AreEqual(2, vm.ContinarViewModels.Count);
        }

        private List<ItemDto> GetItems()
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
        public void ContaineringVMSendItems_NoRanande_2Maghsad()
        {
            ContaineringListViewModel vm = new ContaineringListViewModel(itemService);

            List<ItemDto> items = GetItems2();
            Messenger.Default.Send<List<ItemDto>>(items, "SendItemListForContaining");

            Assert.AreEqual(2, vm.ContinarViewModels.Count);
        }

        private List<ItemDto> GetItems2()
        {
            return new List<ItemDto>() 
                { 
                    new ItemDto() 
                    { 
                        Id = 1,
                        ItemKala = new KalaDto(){Name = "111",IsPalletFelezi=true}, 
                        ItemMaghsad = new MaghsadDto(){Name="aaa"},
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
        public void ContaineringVMSendItems_NoRanande_NoMaghsad()
        {
            ContaineringListViewModel vm = new ContaineringListViewModel(itemService);

            List<ItemDto> items = GetItems3();
            Messenger.Default.Send<List<ItemDto>>(items, "SendItemListForContaining");

            Assert.AreEqual(1, vm.ContinarViewModels.Count);
        }

        private List<ItemDto> GetItems3()
        {
            return new List<ItemDto>() 
                { 
                    new ItemDto() 
                    { 
                        Id = 1,
                        ItemKala = new KalaDto(){Name = "111",IsPalletFelezi=true}, 
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
