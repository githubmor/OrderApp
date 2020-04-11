
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.CommandWpf;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Core.Services;
using Core.Models;

namespace OrdersAndisheh.ViewModel
{

    public class ContaineringViewModel : ViewModelBase
    {
        IErsalItemService service;
        //int pos = 1;
        public ContaineringViewModel(IErsalItemService _service)
        {
            service = _service;
            //ErsalItems = new List<ItemDto>();
            ContinarViewModels = new ObservableCollection<ContainerViewModel>();
            Messenger.Default.Register<List<ItemDto>>(this, "SendItemListForContaining", SendItemListForContaining);
        }

        private void SendItemListForContaining(List<ItemDto> items)
        {
            //ErsalItems = items;
            var ranandehList = service.GetRanandehList();

            var bedoneMaghsad = items.Where(p => p.ItemMaghsad == null).ToList();
            if (bedoneMaghsad.Count > 0)
            {
                //همه بدون مقصد ها داخل یک کانتینر
                ContinarViewModels.Add(new ContainerViewModel(bedoneMaghsad, ranandehList));
            }
            

            var MaghsadDar = items.Where(p => p.ItemMaghsad != null).ToList();
            
            var MaghsadDarRanandehDar = MaghsadDar.Where(p => p.ItemRanande != null).ToList();
            if (MaghsadDarRanandehDar.Count > 0)
            {
                //همه مقصد دار ها چه با راننده چه کانتین بندی شده داخل کانتین خودشون براساس راننده
                MaghsadDarRanandehDar.GroupBy(p => p.ItemRanande).ToList().ForEach(group =>
                    ContinarViewModels.Add(new ContainerViewModel(group.ToList(), ranandehList)));
            }

            
            var MaghsadDarBedoneranande = MaghsadDar.Where(p => p.ItemRanande == null).ToList();
            if (MaghsadDarBedoneranande.Count > 0)
            {
                //همه مقصد دارها بدون راننده داخل کانتین خودشون براساس مقصد هاشون
                MaghsadDarBedoneranande.GroupBy(p => p.ItemMaghsad).ToList().ForEach(group =>
                   ContinarViewModels.Add(new ContainerViewModel(group.ToList(), ranandehList)));
            }
            ////آیتم هایی که راننده موقت دارند باید در کانتین خود قرار گرفته و راننده آنها انتخاب شود
            //var tempDriver = ErsalItems.Where(t => t.Driver != null).Select(p => p.Ranande).Distinct();
            //foreach (var item in tempDriver)
            //{
            //    //if (!string.IsNullOrEmpty(item))
            //    //{

            //    var pe = new ObservableCollection<ItemSefaresh>(ErsalItems.Where(o => o.Ranande == item).ToList());
            //    DriverViewModels.Add(new DriverContainerViewModel(service, pe, pos));
            //    pos += 1;

            //    //}
            //}

            ////لیست آیتم هایی که راننده موقت ندارند بر اساس مقصد کانتین بندی شوند
            //var ma = ErsalItems.Where(i => i.Driver == null).Select(p => p.Maghsad).Distinct();

            //foreach (var item in ma)
            //{
            //    if (!string.IsNullOrEmpty(item))
            //    {
            //        var p = new ObservableCollection<ItemSefaresh>(ErsalItems.Where(o => o.Maghsad == item).ToList());
            //        DriverViewModels.Add(new DriverContainerViewModel(service, p, pos));
            //        pos += 1;
            //    }
            //}

            //var ooo1 = ErsalItems.Where(p => p.Driver != null).ToList();
            //for (int i = 0; i < ooo1.Count; i++)
            //{
            //    ErsalItems.Remove(ooo1[i]);
            //}

            //var ooo = ErsalItems.Where(p => p.Maghsad != "").ToList();
            //for (int i = 0; i < ooo.Count; i++)
            //{
            //    ErsalItems.Remove(ooo[i]);
            //}
        }

        //private ObservableCollection<ItemSefaresh> ersalItems = new ObservableCollection<ItemSefaresh>();
        //public List<ItemDto> ErsalItems { get; set; }
        //public List<RanandeDto> Ranadeha { get; set; }
        //{
        //    get { return ersalItems; }
        //    set
        //    {
        //        ersalItems = value;
        //        RaisePropertyChanged(() => this.ErsalItems);
        //    }
        //}


        public ObservableCollection<ContainerViewModel> ContinarViewModels { get; set; }

        private RelayCommand _myCommand1;

        /// <summary>
        /// Gets the AddNewContainer.
        /// </summary>
        public RelayCommand AddNewContainer
        {
            get
            {
                return _myCommand1
                    ?? (_myCommand1 = new RelayCommand(ExecuteAddNewContainer));
            }
        }

        private void ExecuteAddNewContainer()
        {
            //DriverViewModels.Add(new DriverContainerViewModel(service, pos));
            //pos += 1;
        }

        private RelayCommand _SaveContainers;

        /// <summary>
        /// Gets the SaveDrivers.
        /// </summary>
        public RelayCommand SaveContainers
        {
            get
            {
                return _SaveContainers
                    ?? (_SaveContainers = new RelayCommand(ExecuteSaveContainers));
            }
        }

        private void ExecuteSaveContainers()
        {
            //List<Driver> te = new List<Driver>();
            //foreach (var item in DriverViewModels)
            //{
            //    if (item.SelectedDriver == null)
            //    {
            //        Driver p = new Driver()
            //        {
            //            Name = getDriverName(item.VaznKol, item.JaigahCount) + item.DriverNumber,
            //            Tol = 0,
            //            TempDriver = new TempDriver() { Name = item.DriverNumber.ToString() }
            //        };
            //        service.AddDriver(p);
            //        item.SelectedDriver = p;
            //    }
            //    if (item.TempDriverForDel != null)
            //    {
            //        te.Add(item.TempDriverForDel);
            //    }

            //    item.AssignDriver();

            //    service.Save();

            //}
            //service.DelNoUsedTempDrivers(te);

        }

        //private string getDriverName(int vaznBar, string jaigah)
        //{
        //    int jaigahcount = int.Parse(jaigah);
        //    if (vaznBar < 2000 & jaigahcount < 2)
        //    {
        //        return "نیسان ";
        //    }
        //    else if (vaznBar < 3200 & jaigahcount < 6)
        //    {
        //        return "مینی خاور ";
        //    }
        //    else if (vaznBar < 4200 & jaigahcount < 8)
        //    {
        //        return "مینی خاور ";
        //    }
        //    else if (vaznBar < 5700 & jaigahcount < 8)
        //    {
        //        return "911 ";
        //    }
        //    else if (vaznBar < 10000 & jaigahcount < 8)
        //    {
        //        return "تک ";
        //    }
        //    else
        //    {
        //        return "ماشین ";
        //    }
        //}

    }
}