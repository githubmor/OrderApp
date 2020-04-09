using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrdersAndisheh.ViewModel;
using Core.Services;
using OrdersAndisheh.DesignService;
using GalaSoft.MvvmLight.Messaging;
using System.Linq;

namespace OrderAndishehTest.ViewModels
{
    [TestClass]
    public class MainViewModelTest
    {
        
        [TestMethod]
        public void ViewModelIntializeBeforeOpenTarikhTest()
        {
            IErsalService service = new DesignErsalService();
            IErsalItemService itemService = new DesignErsalItemService();
            MainViewModelNew vm = new MainViewModelNew(service,itemService);

            Assert.AreEqual(vm.Items.Count, 0);
            Assert.IsNull(vm.Statuses);
            Assert.AreEqual(vm.Tarikh, "");


        }
        [TestMethod]
        public void ViewModelOpenSefareshTest()
        {
            IErsalService service = new DesignErsalService();
            IErsalItemService itemService = new DesignErsalItemService();
            MainViewModelNew vm = new MainViewModelNew(service, itemService);

            string tarikh = "1398/11/28";
            Messenger.Default.Send<string>(tarikh, "Open");

            Assert.AreEqual(vm.Items.Count, 3);
            Assert.AreEqual(vm.Statuses, "سفارش تاريخ " + tarikh + " باز شد");
            Assert.AreEqual(vm.Tarikh, tarikh);
            Assert.IsFalse(vm.Accept.CanExecute(null));
            Assert.IsFalse(vm.Save.CanExecute(null));

        }

        [TestMethod]
        public void ViewModelOpenNewSefareshTest()
        {
            IErsalService service = new DesignErsalService();
            IErsalItemService itemService = new DesignErsalItemService();
            MainViewModelNew vm = new MainViewModelNew(service, itemService);

            string tarikh = "1398/11/26";
            Messenger.Default.Send<string>(tarikh, "Open");

            Assert.AreEqual(vm.Items.Count, 0);
            Assert.AreEqual(vm.Statuses, "سفارش جديد به " + tarikh + " ايجاد شد");
            Assert.AreEqual(vm.Tarikh, tarikh);
            Assert.IsFalse(vm.Accept.CanExecute(null));
            Assert.IsFalse(vm.Save.CanExecute(null));

        }

        [TestMethod]
        public void ViewModelSaveChangesTest()
        {
            IErsalService service = new DesignErsalService();
            IErsalItemService itemService = new DesignErsalItemService();
            MainViewModelNew vm = new MainViewModelNew(service, itemService);

            string tarikh = "1398/11/28";
            Messenger.Default.Send<string>(tarikh, "Open");

            vm.Items.First().Tedad = 54;//آيتم كامل شد

            Assert.IsFalse(vm.Accept.CanExecute(null));
            Assert.IsTrue(vm.Save.CanExecute(null));

            vm.Save.Execute(null);

            vm.Items.ToList().ForEach(p => p.dto.TahvilFrosh = 20);


            Assert.IsTrue(vm.Accept.CanExecute(null));
            Assert.IsFalse(vm.Save.CanExecute(null));

            vm.Accept.Execute(null);

            Assert.IsFalse(vm.Accept.CanExecute(null));
            Assert.IsFalse(vm.Save.CanExecute(null));
        }
        
    }
}
