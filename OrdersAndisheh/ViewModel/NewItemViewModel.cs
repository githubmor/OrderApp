using Core.Models;
using Core.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            vaziat = false;
            stateManager();
        }

        private void SendItems(List<ItemDto> obj)
        {
            Items = obj;
            vaziat = true;
            stateManager();
        }
        private bool vaziat;
        //false = new Item , true = Edit maghsad 
        private void stateManager()
        {
            if (vaziat)
            {
                if (SelectedViewModel is SelectKalaUserControlViewModel)
                {
                    var t = SelectedViewModel as SelectKalaUserControlViewModel;
                    var newItems = t.GetSelectedKalas();
                    Items.AddRange(newItems.ConvertAll<ItemDto>(p => new ItemDto() { ItemKala = p }));
                }
                SelectedViewModel = new MaghsadItemUserControlViewModel(service);
                Messenger.Default.Send<List<TedadItemRow>>(Items.ConvertAll<TedadItemRow>(p => new TedadItemRow(p))
                    , "GetKala");
            }else
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
                        vaziat = true;
                        stateManager();
                    }, () => { 
                        return !vaziat; }));
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
                        vaziat = false;
                        stateManager();
                    }, () => { return vaziat; }));
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
                    }, (Window window) => { return vaziat; }));
            }
        }
        
    }
}
