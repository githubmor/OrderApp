using GalaSoft.MvvmLight;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Core.Models;

namespace OrdersAndisheh.ViewModel
{

    public class ContainerUserControlViewModel : ViewModelBase
    {

        public ContainerUserControlViewModel(List<ItemDto> _items, List<RanandeDto> _ranandeha)
        {
            Mahmole = new MahmoleList();
            _items.ForEach(p => Mahmole.Add(new ContainerRow(p)));
            Ranandeha = _ranandeha;
           
        }

        public MahmoleList Mahmole { get; set; }
        public List<RanandeDto> Ranandeha { get; set; }
        public RanandeDto SelectedRanande { get; set; }
       

        public int VaznKol
        {
            get { return Mahmole.VaznKol; }
        }
        public string JaigahCount
        {
            get { return (CountJaighahFeleziPallet() + Mahmole.ChobiPalletCount).ToString(); }
        }

        private double CountJaighahFeleziPallet()
        {
            return Math.Ceiling((double)Mahmole.FeleziPalletCount / 2);
        }

        public string Maghased
        {
            get { return Mahmole.Maghased; }
        }

        public int FeleziPalletCount 
        {
            get
            {
                return Mahmole.FeleziPalletCount;
            }
        }

        public int ChobiPalletCount 
        {
            get
            {
                return Mahmole.ChobiPalletCount;
            }
        }
    }

    public class ContainerRow
    {
        private ItemDto dto;

        public ContainerRow(ItemDto p)
        {
            // TODO: Complete member initialization
            this.dto = p;
        }

        public string Name { get { return dto.ItemKala.Name; } }
        public int Vazn { get { return dto.Vazn; } }

        public int PalletCount { get { return dto.PalletCount; } }

        //true = Felezi , false = chobi
        public bool PalletKind { get { return (dto.ItemKala!=null?dto.ItemKala.IsPalletFelezi:false); } }
        public string Pallet {
            get
            {
                return PalletCount + (PalletKind ? " F" : " C");
            }
        }

        public string Maghsad { get { return (dto.ItemMaghsad != null ? dto.ItemMaghsad.Name : ""); } }
    }

    public class MahmoleList :ObservableCollection<ContainerRow>
    {
        public int VaznKol { 
            get
            { 
                int sum = 0;
                Items.ToList().ForEach(p => sum = sum + p.Vazn);
                return sum;
            } 
        }

        public int FeleziPalletCount { 
            get 
            {
                int sum = 0;
                Items.Where(p => p.PalletKind).ToList().ForEach(p => sum = sum + p.PalletCount);
                return sum;
            } 
        }

        public int ChobiPalletCount
        {
            get
            {
                int sum = 0;
                Items.Where(p => !p.PalletKind).ToList().ForEach(p => sum = sum + p.PalletCount);
                return sum;
            }
        }

        public string Maghased
        {
            get
            {
                string sum = " ";
                Items.Select(p=>p.Maghsad).Distinct().ToList().ForEach(p => sum = sum + " - " + p);
                return sum;
            }
        }
    }
}