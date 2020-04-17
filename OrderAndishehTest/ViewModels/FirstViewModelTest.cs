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
        public void FirstViewModel_OpenWithDefalutData()
        {
            IErsalService service = new DesignErsalService();
            FirstViewModel vm = new FirstViewModel(service);

            Assert.IsFalse(vm.IsShowAcceptedSefaresh);
            //Assert.AreEqual(vm.SaleMali.Count, service.GetErsalYears().Count);
            Assert.AreEqual(vm.Sefareshat.Count, 
                service.GetErsalStates(vm.IsShowAcceptedSefaresh).Count);
            Assert.AreEqual(vm.SaleMali, "1300");
            Assert.IsNull(vm.SelectedSefareshTarikh);
        }
        [TestMethod]
        public void FirstViewModel_Change_IsShowAcceptedSefaresh()
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
        
    }
}
