using GalaSoft.MvvmLight;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Core.Models;

namespace OrdersAndisheh.ViewModel
{

    public class ContainerViewModel : ViewModelBase
    {
        //int felaziPalletCount = 0;
        //int chobiPalletCount = 0;
        public ContainerViewModel(List<ItemDto> _items, List<RanandeDto> _ranandeha)
        {
            Mahmole = new MahmoleList();
            _items.ForEach(p => Mahmole.Add(new ContainerRow(p)));
            Ranandeha = _ranandeha;
            //ss = _ss;
            //TempDriverForDel = new TempDriver();
            //Mahmole = new ObservableCollection<ItemSefaresh>();
            //Mahmole.CollectionChanged += (sender, e) =>
            //{
            //    RaisePropertyChanged(() => this.VaznKol);
            //    RaisePropertyChanged(() => this.FeleziPalletCount);
            //    RaisePropertyChanged(() => this.ChobiPalletCount);
            //    RaisePropertyChanged(() => this.JaigahCount);
            //    RaisePropertyChanged(() => this.Maghased);
            //};
            //DriverNumber = position;
            //ss = new SefareshService();
            //driver = ss.LoadDrivers();
        }

        public MahmoleList Mahmole { get; set; }
        public List<RanandeDto> Ranandeha { get; set; }
        public RanandeDto SelectedRanande { get; set; }
        //private int driverNum;

        //public int DriverNumber
        //{
        //    get { return driverNum; }
        //    set
        //    {
        //        driverNum = value;
        //        RaisePropertyChanged(() => this.DriverNumber);
        //    }
        //}



        //public ContainerViewModel(ISefareshService _ss, ObservableCollection<ItemSefaresh> items, int position)
        //    : this(_ss, position)
        //{
        //    Mahmole = items;
        //    Mahmole.CollectionChanged += (sender, e) =>
        //    {
        //        RaisePropertyChanged(() => this.VaznKol);
        //        RaisePropertyChanged(() => this.JaigahCount);
        //        RaisePropertyChanged(() => this.FeleziPalletCount);
        //        RaisePropertyChanged(() => this.ChobiPalletCount);
        //        RaisePropertyChanged(() => this.Maghased);
        //    };
        //    if (Mahmole[0].Driver != null)
        //    {
        //        SelectedDriver = Mahmole[0].Driver;
        //    }
        //}



        //public List<Driver> Drivers
        //{
        //    get
        //    {
        //        return DriverCal();
        //    }
        //}

        //private List<Driver> DriverCal()
        //{
        //    //TODO باید اینجا راننده ای که به وزن محموله بخورد فقط بیاید
        //    return driver;//.Where(p => p.Ton < VaznKol).ToList();
        //}

        //private Driver myVar;

        //public Driver SelectedDriver
        //{
        //    get { return myVar; }
        //    set
        //    {
        //        if (myVar != null)
        //        {
        //            if (myVar.TempDriver != null)
        //            {
        //                TempDriverForDel = myVar;
        //            }
        //        }
        //        if (value.TempDriver != null)
        //        {
        //            if (value == TempDriverForDel)
        //            {
        //                TempDriverForDel = null;
        //            }
        //        }
        //        myVar = value;
        //        RaisePropertyChanged(() => this.SelectedDriver);
        //    }
        //}

        //public Driver TempDriverForDel { get; set; }

        //public ObservableCollection<ItemDto> Mahmole { get; set; }

        //private int vaznCal()
        //{
        //    //string re = "وزن ";
        //    int s = 0;
        //    foreach (var item in Mahmole)
        //    {
        //        s += item.Vazn;
        //    }
        //    return s;
        //}

        public int VaznKol
        {
            get { return Mahmole.VaznKol; }
        }
        public string JaigahCount
        {
            get { return (Math.Ceiling((double)Mahmole.FeleziPalletCount / 2) + Mahmole.ChobiPalletCount).ToString(); }
        }

        //private string JaigahCountCal()
        //{

        //    return (Math.Ceiling((double)Mahmole.FeleziPalletCount / 2) + Mahmole.ChobiPalletCount).ToString();
        //}

        public string Maghased
        {
            get { return Mahmole.Maghased; }
        }

        //private string MaghasedCal()
        //{
        //    string re = "";
        //    var o = Mahmole.Select(p => p.Maghsad).Distinct().ToList();
        //    for (int i = 0; i < o.Count; i++)
        //    {
        //        if (!string.IsNullOrEmpty(o[i]))
        //        {
        //            re += o[i] + (i + 1 < o.Count ? " - " : null);
        //        }
        //    }
        //    //foreach (var item in o)
        //    //{
        //    //    if (string.IsNullOrEmpty(item))
        //    //    {
        //    //        re += item + " - ";
        //    //    }
        //    //}
        //    return re;
        //}

        public int FeleziPalletCount //{ get; set; }
        {
            get
            {
                return Mahmole.FeleziPalletCount;
            }
        }

        //private int PalletFelezCount()
        //{
        //    felaziPalletCount = 0;
        //    foreach (var item in Mahmole)
        //    {
        //        if (item.Product.Pallet.Vazn > 30)
        //        {
        //            felaziPalletCount += item.PalletCount;
        //        }
        //    }

        //    return felaziPalletCount;
        //}
        public int ChobiPalletCount //{ get; set; }
        {
            get
            {
                return Mahmole.ChobiPalletCount;
            }
        }

        //private int PalletChobiCount()
        //{
        //    chobiPalletCount = 0;
        //    foreach (var item in Mahmole)
        //    {
        //        if (item.Product.Pallet.Vazn < 30)
        //        {
        //            chobiPalletCount += item.PalletCount;
        //        }
        //    }

        //    return chobiPalletCount;
        //}

        //براي اينه كه اگه كاربر نخواست سيو كنه الكي تغييرات نره داخل ابجكت
        //public void AssignDriver()
        //{
        //    foreach (var item in Mahmole)
        //    {
        //        item.Driver = SelectedDriver;
        //    }
        //}
    }

    public class ContainerRow
    {
        private ItemDto p;

        public ContainerRow(ItemDto p)
        {
            // TODO: Complete member initialization
            this.p = p;
        }


        public int Vazn { get; set; }

        public int PalletCount { get; set; }

        //true = Felezi , false = chobi
        public bool PalletKind { get; set; }

        public string Maghsad { get; set; }
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