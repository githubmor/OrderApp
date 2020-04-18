using Core.Models;
using Core.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace OrdersAndisheh.ViewModel
{
    public class SelectKalaUserControlViewModel : ViewModelBase
    {
        private IErsalItemService service;
        private List<KalaElectionDto> kalaha;

        public SelectKalaUserControlViewModel(IErsalItemService _service)
        {
            service = _service;
            kalaha = service.GetKalasListSortByMostAndLastErsal();
            AllKalaList = kalaha.ConvertToSelectKalaListViewRow();
            RaisePropertyChanged("AllKalaList");
            Selection_KalaList = new ObservableCollection<KalaDto>();
        }

        public List<SelectKalaListViewRow> AllKalaList { get; set; }
        public SelectKalaListViewRow SelectedKala { get; set; }
        public ObservableCollection<KalaDto> Selection_KalaList { get; set; }
        public KalaDto Selection_SelectedItem { get; set; }

        public List<KalaDto> GetSelectedKalas()
        {
            return Selection_KalaList.ToList();
        }

        private RelayCommand _Andisheh;

        public RelayCommand Andisheh
        {
            get
            {
                return _Andisheh ?? (_Andisheh = new RelayCommand(
                    () =>
                    {
                        AllKalaList = kalaha.Where(p => p.Sherkat == Sherkat.Andisheh).ToList().ConvertToSelectKalaListViewRow();
                        RaisePropertyChanged("AllKalaList");
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
                        AllKalaList = kalaha.Where(p => p.Sherkat == Sherkat.Imen).ToList().ConvertToSelectKalaListViewRow();
                        RaisePropertyChanged("AllKalaList");
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
                        AllKalaList = kalaha.Where(p => p.Moshtari == Moshtari.Sazehgostar).ToList().ConvertToSelectKalaListViewRow();
                        RaisePropertyChanged("AllKalaList");
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
                        AllKalaList = kalaha.Where(p => p.Moshtari == Moshtari.Sapco).ToList().ConvertToSelectKalaListViewRow();
                        RaisePropertyChanged("AllKalaList");
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
                        Selection_KalaList.Add(kalaha.Single(p => p.Code == SelectedKala.CodeKala).getKalaDto());
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
                        Selection_KalaList.Remove(Selection_SelectedItem);
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