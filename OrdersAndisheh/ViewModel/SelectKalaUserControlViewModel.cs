
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

namespace OrdersAndisheh.ViewModel
{
    public class SelectKalaUserControlViewModel : ViewModelBase
    {
        private IErsalItemService service;
        private List<KalaElectionDto> kalaha;
        public SelectKalaUserControlViewModel(IErsalItemService _service)
        {
            service = _service;
            kalaha = service.GetKalasList();
            ItemsList = kalaha.ConvertToSelectKalaListViewRow();
            RaisePropertyChanged("ItemsList");
            SelectionItemList = new ObservableCollection<KalaDto>();
        }

        public List<SelectKalaListViewRow> ItemsList { get; set; }
        public SelectKalaListViewRow ItemsSelectedItem { get; set; }
        public ObservableCollection<KalaDto> SelectionItemList { get; set; }
        public KalaDto SelectionSelectedItem { get; set; }

        public List<KalaDto> GetSelectedKalas()
        {
            return SelectionItemList.ToList();
        }
      
        private RelayCommand _Andisheh;
        public RelayCommand Andisheh
        {
            get
            {
                return _Andisheh ?? (_Andisheh = new RelayCommand(
                    () =>
                    {
                        ItemsList = kalaha.Where(p => p.Sherkat == Sherkat.Andisheh).ToList().ConvertToSelectKalaListViewRow();
                        RaisePropertyChanged("ItemsList");
                    }));
            }
        }
        private RelayCommand _Imen;
        public RelayCommand Imen
        {
            get
            {
                return _Imen ?? (_Imen = new RelayCommand(
                    () =>
                    {
                        ItemsList = kalaha.Where(p => p.Sherkat == Sherkat.Imen).ToList().ConvertToSelectKalaListViewRow();
                        RaisePropertyChanged("ItemsList");
                    }));
            }
        }
        private RelayCommand _Sazeh;
        public RelayCommand Sazeh
        {
            get
            {
                return _Sazeh ?? (_Sazeh = new RelayCommand(
                    () =>
                    {
                        ItemsList = kalaha.Where(p => p.Moshtari == Moshtari.Sazehgostar).ToList().ConvertToSelectKalaListViewRow();
                        RaisePropertyChanged("ItemsList");
                    }));
            }
        }
        private RelayCommand _Sapco;
        public RelayCommand Sapco
        {
            get
            {
                return _Sapco ?? (_Sapco = new RelayCommand(
                    () =>
                    {
                        ItemsList = kalaha.Where(p => p.Moshtari == Moshtari.Sapco).ToList().ConvertToSelectKalaListViewRow();
                        RaisePropertyChanged("ItemsList");
                    }));
            }
        }

        private RelayCommand _AddThisItem;
        public RelayCommand AddThisItem
        {
            get
            {
                return _AddThisItem ?? (_AddThisItem = new RelayCommand(
                    () =>
                    {
                        SelectionItemList.Add(kalaha.Single(p => p.Code == ItemsSelectedItem.CodeKala).getKalaDto());
                    }));
            }
        }

        private RelayCommand _RemoveThisItem;
        public RelayCommand RemoveThisItem
        {
            get
            {
                return _RemoveThisItem ?? (_RemoveThisItem = new RelayCommand(
                    () =>
                    {
                        SelectionItemList.Remove(SelectionSelectedItem);
                    }));
            }
        }

       
    }

    public static class DictionaryExtensionMethods
    {
        public static List<SelectKalaListViewRow> ConvertToSelectKalaListViewRow(
            this List<KalaElectionDto> list)
        {
            return list.ConvertAll<SelectKalaListViewRow>(p => new SelectKalaListViewRow(p));
        }
    }

    public class SelectKalaListViewRow
    {
        private KalaElectionDto dto;
        public SelectKalaListViewRow(KalaElectionDto _dto)
        {
            this.dto = _dto;
        }
        public string CodeKala
        {
            get { return dto.Code; }
        }
        public string KalaName
        {
            get { return dto.Name; }
        }


    }
    
}