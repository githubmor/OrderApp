using Core.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersAndisheh.ViewModel
{
    public class NewItemViewModel : ViewModelBase
    {
        private IErsalItemService service;
        public NewItemViewModel(IErsalItemService _service)
        {
            service = _service;
            SelectedViewModel = new SelectKalaUserControlViewModel(service);
        }
        private object selectedViewModel;

        public object SelectedViewModel
        {
            get { return selectedViewModel; }
            set 
            { 
                selectedViewModel = value; 
                RaisePropertyChanged("SelectedViewModel");
            }

        }

        private RelayCommand _Next;

        public RelayCommand Next
        {
            get
            {
                return _Next ?? (_Next = new RelayCommand(
                    () =>
                    {
                        SelectedViewModel = new SelectKalaUserControlViewModel(service);
                    }));
            }
        }
        private RelayCommand _Back;

        public RelayCommand Back
        {
            get
            {
                return _Back ?? (_Back = new RelayCommand(
                    () =>
                    {

                    }));
            }
        }
    }
}
