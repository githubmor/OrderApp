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
        [TestMethod]
        public void ContaineringVMIntializedefault()
        {
            IErsalItemService itemService = new DesignErsalItemService();
            ContaineringListViewModel vm = new ContaineringListViewModel(itemService);

            Assert.AreEqual(0, vm.ContinarViewModels.Count);
        }

        [TestMethod]
        public void ContaineringVMSendItems()
        {
            IErsalItemService itemService = new DesignErsalItemService();
            ContaineringListViewModel vm = new ContaineringListViewModel(itemService);

            List<ItemDto> items = itemService.GetItems("");
            Messenger.Default.Send<List<ItemDto>>(items, "SendItemListForContaining");

            Assert.AreEqual(CalculateContainer(items), vm.ContinarViewModels.Count);
        }

        private static int CalculateContainer(List<ItemDto> items)
        {
            int sum = 0;

            var bedoneMaghsad = items.Where(p => p.ItemMaghsad == null).ToList();
            if (bedoneMaghsad.Count > 0)
            {
                //همه بدون مقصد ها داخل یک کانتینر
                sum = sum + 1;
            }


            var MaghsadDar = items.Where(p => p.ItemMaghsad != null).ToList();

            var MaghsadDarRanandehDar = MaghsadDar.Where(p => p.ItemRanande != null).ToList();
            if (MaghsadDarRanandehDar.Count > 0)
            {
                //همه مقصد دار ها چه با راننده چه کانتین بندی شده داخل کانتین خودشون براساس راننده
                MaghsadDarRanandehDar.GroupBy(p => p.ItemRanande).ToList().ForEach(group => sum = sum + 1);
            }


            var MaghsadDarBedoneranande = MaghsadDar.Where(p => p.ItemRanande == null).ToList();
            if (MaghsadDarBedoneranande.Count > 0)
            {
                //همه مقصد دارها بدون راننده داخل کانتین خودشون براساس مقصد هاشون
                MaghsadDarBedoneranande.GroupBy(p => p.ItemMaghsad).ToList().ForEach(group => sum = sum + 1);
            }
            return sum;
        }
    }
}
