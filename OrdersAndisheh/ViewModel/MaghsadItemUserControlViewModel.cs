
using Core.Models;
using Core.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using OrdersAndisheh.View;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace OrdersAndisheh.ViewModel
{
    public class MaghsadItemUserControlViewModel : ViewModelBase
    {
        private IErsalItemService service;
        //private List<KalaDto> kalaha;
        public MaghsadItemUserControlViewModel(IErsalItemService _service)
        {
            KalaList = new List<TedadItemRow>();
            
            service = _service;

            Messenger.Default.Register<List<TedadItemRow>>(this, "GetKala", GetKala);
            
        }

        private void GetKala(List<TedadItemRow> kalas)
        {
            KalaList = kalas;
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
        //private RelayCommand _Imen;
        //public RelayCommand Imen
        //{
        //    get
        //    {
        //        return _Imen ?? (_Imen = new RelayCommand(
        //            () =>
        //            {
        //                ItemsList = kalaha.Where(p => p.Sherkat == Sherkat.Imen).ToList().ConvertToSelectKalaListViewRow();
        //                RaisePropertyChanged("ItemsList");
        //            }));
        //    }
        //}
        //private RelayCommand _Sazeh;
        //public RelayCommand Sazeh
        //{
        //    get
        //    {
        //        return _Sazeh ?? (_Sazeh = new RelayCommand(
        //            () =>
        //            {
        //                ItemsList = kalaha.Where(p => p.Moshtari == Moshtari.Sazehgostar).ToList().ConvertToSelectKalaListViewRow();
        //                RaisePropertyChanged("ItemsList");
        //            }));
        //    }
        //}
        //private RelayCommand _Sapco;
        //public RelayCommand Sapco
        //{
        //    get
        //    {
        //        return _Sapco ?? (_Sapco = new RelayCommand(
        //            () =>
        //            {
        //                ItemsList = kalaha.Where(p => p.Moshtari == Moshtari.Sapco).ToList().ConvertToSelectKalaListViewRow();
        //                RaisePropertyChanged("ItemsList");
        //            }));
        //    }
        //}

        //private RelayCommand _AddThisItem;
        //public RelayCommand AddThisItem
        //{
        //    get
        //    {
        //        return _AddThisItem ?? (_AddThisItem = new RelayCommand(
        //            () =>
        //            {
        //                SelectionItemList.Add(kalaha.Single(p => p.Code == ItemsSelectedItem.CodeKala).getKalaDto());
        //            }));
        //    }
        //}

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
        public TedadItemRow()
        {
            kala = new ItemDto();
        }  
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

    //public static class DictionaryExtensionMethods
    //{
    //    public static List<SelectKalaListViewRow> ConvertToSelectKalaListViewRow(
    //        this List<KalaElectionDto> list)
    //    {
    //        return list.ConvertAll<SelectKalaListViewRow>(p => new SelectKalaListViewRow(p));
    //    }
    //}
    
}