using Core.Models;
using Core.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace OrdersAndisheh.ViewModel
{
    public class MaghsadItemUserControlViewModel : ViewModelBase
    {
        private IErsalItemService service;

        public MaghsadItemUserControlViewModel(IErsalItemService _service)
        {
            KalaList = new List<TedadItemRow>();

            service = _service;

            Messenger.Default.Register<List<ItemDto>>(this, "GetKala", GetKala);
        }

        private void GetKala(List<ItemDto> kalas)
        {
            KalaList = kalas.ConvertAll<TedadItemRow>(p => new TedadItemRow(p));
        }

        public List<TedadItemRow> KalaList { get; set; }

        public List<MaghsadDto> Maghased { get { return service.GetMaghasedList(); } }
        public MaghsadDto SelectionMaghsad { get; set; }

        private RelayCommand _NewMaghsad;

        public RelayCommand NewMaghsad
        {
            get
            {
                return _NewMaghsad ?? (_NewMaghsad = new RelayCommand(
                    () =>
                    {
                        RaisePropertyChanged("Maghased");
                    }));
            }
        }

        private RelayCommand _SetMaghsad;

        public RelayCommand SetMaghsad
        {
            get
            {
                return _SetMaghsad ?? (_SetMaghsad = new RelayCommand(
                    () =>
                    {
                        KalaList.Where(p => p.IsSelected).ToList().ForEach(p => p.SetMaghsad(SelectionMaghsad));
                    }));
            }
        }
    }

    public class TedadItemRow : INotifyPropertyChanged
    {
        private ItemDto kala;

        //public TedadItemRow()
        //{
        //    kala = new ItemDto();
        //}

        public TedadItemRow(ItemDto _kala)
        {
            this.kala = _kala;
        }

        public string Name { get { return (kala != null ? kala.ItemKala.Name : ""); } }
        public int Tedad { get; set; }
        public bool IsSelected { get; set; }
        public string MaghsadName { get { return ((kala != null && kala.ItemMaghsad != null) ? kala.ItemMaghsad.Name : ""); } }

        public void SetMaghsad(MaghsadDto er)
        {
            kala.ItemMaghsad = er;
            NotifyPropertyChanged("MaghsadName");
            IsSelected = false;
            NotifyPropertyChanged("IsSelected");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}