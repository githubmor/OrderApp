using Core.Models;
using Core.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.Generic;
using System.Windows;

namespace OrdersAndisheh.ViewModel
{
    public class NewItemViewModel : ViewModelBase
    {
        private IErsalItemService service;
        private List<ItemDto> Items;

        public NewItemViewModel(IErsalItemService _service)
        {
            service = _service;
            Items = new List<ItemDto>();
            Messenger.Default.Register<List<ItemDto>>(this, "SendItemsFromMain", SendItems);
            MustMaghsadShow = false;
            stateManager();
        }

        private void SendItems(List<ItemDto> obj)
        {
            Items = obj;
            MustMaghsadShow = true;
            stateManager();
        }

        private bool MustMaghsadShow;

        //false = new Item , true = Edit maghsad
        private void stateManager()
        {
            if (MustMaghsadShow)
            {
                if (SelectedViewModel is SelectKalaUserControlViewModel)
                {
                    var t = SelectedViewModel as SelectKalaUserControlViewModel;
                    var newItems = t.GetSelectedKalas();
                    Items.AddRange(newItems.ConvertAll<ItemDto>(p => new ItemDto() { ItemKala = p }));
                }
                SelectedViewModel = new MaghsadItemUserControlViewModel(service);
                Messenger.Default.Send<List<ItemDto>>(Items, "GetKala");
            }
            else
            {
                SelectedViewModel = new SelectKalaUserControlViewModel(service);
            }
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
                        MustMaghsadShow = true;
                        stateManager();
                    }, () =>
                    {
                        return !MustMaghsadShow;
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
                        MustMaghsadShow = false;
                        stateManager();
                    }, () => { return MustMaghsadShow; }));
            }
        }

        private RelayCommand<Window> _AddToSefaresh;

        public RelayCommand<Window> AddToSefaresh
        {
            get
            {
                return _AddToSefaresh ?? (_AddToSefaresh = new RelayCommand<Window>(
                    (Window window) =>
                    {
                        Messenger.Default.Send<List<ItemDto>>(Items, "newItems");
                        if (window != null)
                        {
                            window.Close();
                        }
                    }, (Window window) => { return MustMaghsadShow; }));
            }
        }
    }
}