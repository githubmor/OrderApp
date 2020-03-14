using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrdersAndisheh.ViewModel;
using Core.Services;
using OrdersAndisheh.DesignService;

namespace OrderAndishehTest.ViewModels
{
    [TestClass]
    public class FirstViewModelTest
    {
        
        [TestMethod]
        public void ViewModelIntializeTest()
        {
            IErsalService service = new DesignErsalService();
            FirstViewModel vm = new FirstViewModel(service);

            Assert.IsFalse(vm.IsShowAcceptedSefaresh);
            Assert.AreEqual(vm.SaleMali.Count, service.GetErsalYears().Count);
            Assert.AreEqual(vm.Sefareshat.Count, 
                service.GetErsalStates(vm.IsShowAcceptedSefaresh).Count);
            Assert.AreEqual(vm.SelectedSalMali, vm.SaleMali[0]);
            Assert.IsNull(vm.SelectedSefareshTarikh);
        }
        [TestMethod]
        public void ViewModelChangeShowAcceptedSefareshTest()
        {
            IErsalService service = new DesignErsalService();
            FirstViewModel vm = new FirstViewModel(service);
            vm.IsShowAcceptedSefaresh = true;

            Assert.IsTrue(vm.IsShowAcceptedSefaresh);
            Assert.AreEqual(vm.Sefareshat.Count,
                service.GetErsalStates(vm.IsShowAcceptedSefaresh).Count);
            Assert.IsNull(vm.SelectedSefareshTarikh);

            vm.IsShowAcceptedSefaresh = false;
            Assert.IsFalse(vm.IsShowAcceptedSefaresh);
            Assert.AreEqual(vm.Sefareshat.Count,
                service.GetErsalStates(vm.IsShowAcceptedSefaresh).Count);
            Assert.IsNull(vm.SelectedSefareshTarikh);
        }
        [TestMethod]
        public void ViewModelChangeShowhAcceptedSefareshTest()
        {
            #warning بايد بعد از تغيير سال مالي در كانكشن تغيير ايجاد شود
            IErsalService service = new DesignErsalService();
            FirstViewModel vm = new FirstViewModel(service);
            vm.SelectedSalMali = service.GetErsalYears()[1];

            Assert.AreEqual(vm.SelectedSalMali, vm.SaleMali[1]);

        }
    }
}
