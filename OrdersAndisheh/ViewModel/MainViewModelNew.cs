using Core.Models;
using Core.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using OrdersAndisheh.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace OrdersAndisheh.ViewModel
{
    public class MainViewModelNew : ViewModelBase
    {
        #region Fields

        private ErsalDto ersal;
        private IErsalService service;
        private IErsalItemService itemService;
        private bool needToSave;

        #endregion Fields

        public MainViewModelNew(IErsalService _service, IErsalItemService _itemService)
        {
            service = _service;
            itemService = _itemService;
            mainViewModeldataGridRow.OnItemChenged = () => needToSave = true;
            Messenger.Default.Register<string>(this, "Open", OpenErsal);
            Items = new ObservableCollection<mainViewModeldataGridRow>();

            //For test Ui as messanger call
            //OpenErsal("1398/11/28");
        }

        #region Property

        public string Tarikh
        {
            get { return ersal != null ? ersal.Tarikh : ""; }
        }

        public ObservableCollection<mainViewModeldataGridRow> Items { get; set; }
        public string Statuses { get; set; }

        #endregion Property

        #region Methods

        private void OpenErsal(string tarikh)
        {
            ersal = service.GetErsal(tarikh);
            if (ersal != null)
            {
                LoadItems();
                Statuses = "سفارش تاريخ " + tarikh + " باز شد";
            }
            else
            {
                ersal = new ErsalDto();
                ersal.Tarikh = tarikh;
                Statuses = "سفارش جديد به " + tarikh + " ايجاد شد";
            }
        }

        private void LoadItems()
        {
            Items = new ObservableCollection<mainViewModeldataGridRow>(itemService.GetItems(Tarikh)
                .ConvertAll<mainViewModeldataGridRow>(p => new mainViewModeldataGridRow(p)));
            RaisePropertyChanged("Items");
        }

        private List<ItemDto> getSelectedItem()
        {
            if (Items.Any(p => p.IsSelected))
            {
                return Items.Where(p => p.IsSelected).ToList().ConvertAll<ItemDto>(o => o.dto);
            }
            else
            {
                return Items.ToList().ConvertAll<ItemDto>(o => o.dto);
            }
        }

        #endregion Methods

        #region Command

        private RelayCommand _Save;

        public RelayCommand Save
        {
            get
            {
                return _Save ?? (_Save = new RelayCommand(
                    () =>
                    {
                        ersal = service.SaveNewErsal(ersal.Tarikh);
#warning بايد پرسيده شود ورژن بزنيم يا نه
                        service.Versioning(ersal.Tarikh);
                        Statuses = "سفارش ذخيره شد";
                        needToSave = false;
                    },
                    () =>
                    {
                        return needToSave;
                    }
                    ));
            }
        }

        private RelayCommand _Accept;

        public RelayCommand Accept
        {
            get
            {
                return _Accept ?? (_Accept = new RelayCommand(
                    () =>
                    {
                        ersal = service.AcceptErsal(ersal.Tarikh);
                        Statuses = "سفارش تثبيت شد";
                    },
                    () =>
                    {
                        return Items.Count > 0 && Items.All(p => p.IsAllOKForAccept()) & !needToSave &
                            (ersal != null ? !ersal.IsAccepted : false);
                    }
                    ));
            }
        }

        private RelayCommand _TahvilFrosh;

        public RelayCommand TahvilFrosh
        {
            get
            {
                return _TahvilFrosh ?? (_TahvilFrosh = new RelayCommand(
                    () =>
                    {
                        //throw new NotImplementedException();
                        LoadItems();
                    }
                    ));
            }
        }

        private RelayCommand _NewItem;

        public RelayCommand NewItem
        {
            get
            {
                return _NewItem ?? (_NewItem = new RelayCommand(
                    () =>
                    {
                        var op = new NewItemView();
                        Messenger.Default.Send<string>(Tarikh, "Tarikh");
                        op.Show();
                        LoadItems();
                    }
                    ));
            }
        }

        private RelayCommand _Maghased;

        public RelayCommand Maghased
        {
            get
            {
                return _Maghased ?? (_Maghased = new RelayCommand(
                    () =>
                    {
                        #warning وقتي روي ستون انتخاب كليك ميشود بايد روي رديف ديگر كليك كند تا همه را بتواند انتقال دهد
                        //يعني بايد كاري كنيم كه وقتي چك باكس را كليك كرد انتخاب شود
                        var op = new NewItemView();
                        Messenger.Default.Send<List<ItemDto>>(Items.Where(p => p.IsSelected).ToList().ConvertAll<ItemDto>(p => p.dto)
                            , "SendItemsFromMain");
                        Messenger.Default.Send<string>(Tarikh, "Tarikh");
                        op.Show();
                        LoadItems();
                    }, () => { return Items.Any(p => p.IsSelected); }
                    ));
            }
        }

        private RelayCommand _Containering;

        public RelayCommand Containering
        {
            get
            {
                return _Containering ?? (_Containering = new RelayCommand(
                    () =>
                    {
                        var op = new ContineringListView();
                        Messenger.Default.Send<List<ItemDto>>(Items.Where(p => p.IsSelected).ToList().ConvertAll<ItemDto>(p => p.dto)
                            , "SendItemListForContaining");
                        Messenger.Default.Send<string>(Tarikh, "Tarikh");
                        op.Show();
                        LoadItems();
                    }
                    ,() => { return Items.Any(p => p.IsSelected); }));
            }
        }

        //private RelayCommand _Verzhen;

        //public RelayCommand Verzhen
        //{
        //    get
        //    {
        //        return _Verzhen ?? (_Verzhen = new RelayCommand(
        //            () =>
        //            {
        //                service.ExportNewVersion()
        //            }
        //            ));
        //    }
        //}

        private RelayCommand _Summery;

        public RelayCommand Summery
        {
            get
            {
                return _Summery ?? (_Summery = new RelayCommand(
                    () =>
                    {
                        throw new NotImplementedException();
                    }
                    ));
            }
        }

        private RelayCommand _AllReportExport;

        public RelayCommand AllReportExport
        {
            get
            {
                return _AllReportExport ?? (_AllReportExport = new RelayCommand(
                    () =>
                    {
                        throw new NotImplementedException();
                    }
                    ));
            }
        }

        private RelayCommand _ListErsalNahaiExport;

        public RelayCommand ListErsalNahaiExport
        {
            get
            {
                return _ListErsalNahaiExport ?? (_ListErsalNahaiExport = new RelayCommand(
                    () =>
                    {
                        throw new NotImplementedException();
                    }
                    ));
            }
        }

        private RelayCommand _BargeMadarekExport;

        public RelayCommand BargeMadarekExport
        {
            get
            {
                return _BargeMadarekExport ?? (_BargeMadarekExport = new RelayCommand(
                    () =>
                    {
                        throw new NotImplementedException();
                    }
                    ));
            }
        }

        private RelayCommand _PanjerehBargeExport;

        public RelayCommand PanjerehBargeExport
        {
            get
            {
                return _PanjerehBargeExport ?? (_PanjerehBargeExport = new RelayCommand(
                    () =>
                    {
                        throw new NotImplementedException();
                    }
                    ));
            }
        }

        private RelayCommand _CheckListTafkikExport;

        public RelayCommand CheckListTafkikExport
        {
            get
            {
                return _CheckListTafkikExport ?? (_CheckListTafkikExport = new RelayCommand(
                    () =>
                    {
                        throw new NotImplementedException();
                    }
                    ));
            }
        }

        private RelayCommand _KartabletafkikExport;

        public RelayCommand KartabletafkikExport
        {
            get
            {
                return _KartabletafkikExport ?? (_KartabletafkikExport = new RelayCommand(
                    () =>
                    {
                        throw new NotImplementedException();
                    }
                    ));
            }
        }

        private RelayCommand _BimeReportExport;

        public RelayCommand BimeReportExport
        {
            get
            {
                return _BimeReportExport ?? (_BimeReportExport = new RelayCommand(
                    () =>
                    {
                        throw new NotImplementedException();
                    }
                    ));
            }
        }

        #endregion Command

        //public MainViewModelNew(IErsalService _service,IErsalItemService _itemService)
        //{
        //    service = _service;
        //    itemService = _itemService;

        //    //erasl = new ErsalDto(getToday());

        //    //CanEdit = true;

        //    //typeList = Enum.GetValues(typeof(ItemType)).OfType<ItemType>().ToList();

        //    Messenger.Default.Register<string>(this, "Editsefaresh", LoadThisDateSefaresh);

        //    //Item.OnItemChenged = () => NeedToSaveUpdate = true;

        //    //Item.OnItemSelected = () => RaisePropertyChanged(() => changeing);

        //    //LoadGoodsAsync();
        //    //loadDriversAsync();
        //    //loadDestinationAsync();
        //    //loadDriverpriorityAsync();
        //}

        //#region Field

        ////private List<ItemType> typeList;

        ////private bool IsEdit, NeedToSaveUpdate;
        //private IErsalService service;
        //private IErsalItemService itemService;

        //#endregion Field

        //#region private Methode
        //private void LoadThisDateSefaresh(string tarikh)
        //{
        //    erasl = service.GetErsal(tarikh);
        //    RaisePropertyChanged(() => Tarikh);
        //    //loadSefareshAsync(tarikh);
        //}
        //private void changeState()
        //{
        //    //KalaChanged = erasl.Items.Any(p => p.IsNew);
        //    //TedadChanged = erasl.Items.Any(p => p.IsTedadChanged);
        //    //CustomerChanged = erasl.Items.Any(p => p.IsCustomerChanged);
        //    //DriverChanged = erasl.Items.Any(p => p.IsDriverChanged);
        //}

        //private string getToday()
        //{
        //    return PersianDateTime.Now.ToString(PersianDateTimeFormat.Date);
        //}

        //private async Task loadDestinationAsync()
        //{
        //    //Task<List<Maghsad>> LoadDestinationsTask = ErsalService.LoadMaghsadAsync();
        //    //Destinations = await LoadDestinationsTask;
        //    //RaisePropertyChanged(() => this.Destinations);
        //}

        //private async Task loadDriverpriorityAsync()
        //{
        //    //DriverPriorety = await ErsalService.GetDrivePriority(Tarikh);
        //    //RaisePropertyChanged(() => DriverPriorety);
        //}

        //private async Task loadDriversAsync()
        //{
        //    //Task<List<Ranande>> loadDriveTask = ErsalService.LoadDriversAsync();
        //    //Drivers = await loadDriveTask;
        //    //RaisePropertyChanged(() => this.Drivers);
        //}

        //private async Task loadDriversVaznAsync()
        //{
        //    //DriversVazn = await erasl.GetDriversSummeryAsync();
        //    //RaisePropertyChanged(() => this.DriversVazn);
        //}

        //private async Task LoadGoodsAsync()
        //{
        //    //Task<List<Kala>> LoadGoodsTask = ErsalService.LoadGoodsAsync();
        //    //Goods = await LoadGoodsTask;
        //    //RaisePropertyChanged(() => this.Goods);
        //}

        //private async Task loadMaghsadVaznAsync()
        //{
        //    //MaghsadVazn = await erasl.GetMaghsadSummeryAsync();
        //    //RaisePropertyChanged(() => this.MaghsadVazn);
        //}

        //private void loadPalletDriverMaghsadVazn()
        //{
        //    loadPalletHaAsync();
        //    loadDriversVaznAsync();
        //    loadMaghsadVaznAsync();
        //}

        //private async Task loadPalletHaAsync()
        //{
        //    //palletHa = await erasl.GetPalletsSummeryAsync();
        //    //RaisePropertyChanged(() => this.palletHa);
        //}

        //private async Task loadSefareshAsync(string tarikh)
        //{
        //    //erasl = await ErsalService.LoadEraslAsync(tarikh);

        //    //for (int i = 0; i < erasl.Items.Count; i++)
        //    //{
        //    //    erasl.Items[i].ItemMaghsad = Destinations.Single(p => p.MaghsadId == erasl.Items[i].ItemMaghsad.MaghsadId);
        //    //    erasl.Items[i].ItemRanande = Drivers.Single(p => p.RanandeId == erasl.Items[i].ItemRanande.RanandeId);
        //    //}

        //    //RaisePropertyChanged(() => Items);

        //    //IsEdit = true;
        //    //NeedToSaveUpdate = false;
        //    //CanEdit = !erasl.Accepted;
        //    //showStatuse("سفارش تاريخ " + tarikh + "بار گذاری شد");

        //    //RaisePropertyChanged(() => this.Tarikh);
        //    //RaisePropertyChanged(() => this.SaveText);
        //    ////var p = SelectedKala.Weight;
        //    //loadPalletDriverMaghsadVazn();
        //}

        //#endregion private Methode

        //#region Property

        ////private bool canEdit;
        //private string description;
        //private int palletCount;
        //private short tedad;

        ////public bool CanEdit
        ////{
        ////    get { return canEdit; }
        ////    set
        ////    {
        ////        canEdit = value;
        ////        RaisePropertyChanged(() => CanEdit);
        ////    }
        ////}

        ////public bool changeing
        ////{
        ////    get { return CanEdit & Items.Any(p => p.IsSelected); }
        ////}

        //public bool CustomerChanged { get; set; }

        //public string Description
        //{
        //    get { return description; }
        //    set
        //    {
        //        description = value;
        //        RaisePropertyChanged(() => Description);
        //    }
        //}

        ////public List<Maghsad> Destinations { get; set; }
        //public bool DriverChanged { get; set; }
        //public string DriverPriorety { get; set; }
        ////public List<Ranande> Drivers { get; set; }
        //public string DriversVazn { get; set; }
        ////public List<Kala> Goods { get; set; }

        ////private Item clickedKala;
        ////public Item ClickedKala
        ////{
        ////    get { return clickedKala; }
        ////    set
        ////    {
        ////        clickedKala = value;
        ////        SelectedDriver = value.ItemRanande;
        ////        SelectedDestenation = value.ItemMaghsad;
        ////        RaisePropertyChanged(() => ClickedKala);
        ////        RaisePropertyChanged(() => SelectedDriver);
        ////        RaisePropertyChanged(() => SelectedDestenation);
        ////    }
        ////}
        ////public ObservableCollection<Item> Items
        ////{
        ////    get { return erasl.Items; }
        ////    set
        ////    {
        ////        erasl.Items = value;
        ////        RaisePropertyChanged(() => Items);
        ////    }
        ////}

        ////public bool KalaChanged { get; set; }
        ////public string MaghsadVazn { get; set; }

        ////public int PalletCount
        ////{
        ////    get { return palletCount; }
        ////    set
        ////    {
        ////        palletCount = value;
        ////        NeedToSaveUpdate = true;
        ////        RaisePropertyChanged(() => PalletCount);
        ////    }
        ////}

        ////public string palletHa { get; set; }

        ////public string SaveText
        ////{
        ////    get { return (CanEdit ? "ذخیره" : "فعال کردن"); }
        ////}
        ////private Maghsad selectedDestenation;
        ////public Maghsad SelectedDestenation
        ////{
        ////    get { return selectedDestenation; }
        ////    set
        ////    {
        ////        selectedDestenation = value;
        ////        RaisePropertyChanged(() => SelectedDestenation);
        ////    }
        ////}

        ////private Ranande selectedDriver;
        ////public Ranande SelectedDriver
        ////{
        ////    get { return selectedDriver; }
        ////    set
        ////    {
        ////        selectedDriver = value;
        ////        RaisePropertyChanged(() => SelectedDriver);
        ////    }
        ////}
        ////public Kala SelectedKala { get; set; }
        ////public String Statuses { get; set; }

        //public string Tarikh
        //{
        //    get { return erasl != null ? erasl.Tarikh : ""; }
        //    //set
        //    //{
        //    //    try
        //    //    {
        //    //        erasl.Tarikh = value;
        //    //        RaisePropertyChanged(() => Tarikh);
        //    //        NeedToSaveUpdate = true;
        //    //    }
        //    //    catch (Exception r)
        //    //    {
        //    //        MessageBox.Show(r.Message.ToString());
        //    //    }
        //    //}
        //}

        //public short Tedad
        //{
        //    get { return tedad; }
        //    set
        //    {
        //        tedad = value;
        //        NeedToSaveUpdate = true;
        //        RaisePropertyChanged(() => Tedad);
        //        RaisePropertyChanged(() => PalletCount);
        //    }
        //}

        //public bool TedadChanged { get; set; }

        //public List<ItemType> TypeList
        //{
        //    get { return typeList; }
        //    set
        //    {
        //        typeList = value;
        //        RaisePropertyChanged(() => TypeList);
        //    }
        //}

        //#endregion Property

        //#region Command

        //#region RelayCommandProperty
        //private RelayCommand _myCommand10;
        //private RelayCommand _myCommand111;
        //private RelayCommand _myCommand465;
        //private RelayCommand _myCommand465666;
        //private RelayCommand _myCommand54664751;
        //private RelayCommand _myCommand5565656952;
        //private RelayCommand _myCommand55666;
        //private RelayCommand _myCommand5654652542244;
        //private RelayCommand _myCommand565656;
        //private RelayCommand _myCommand659658785;
        //private RelayCommand _myCommand7;
        //private RelayCommand _myCommand74656;
        //private RelayCommand _myCommand746567;
        //private RelayCommand _myCommand79;
        //private RelayCommand _myCommand8;
        //private RelayCommand _myCommand9;
        //private RelayCommand _myCommand95685658655;
        //private RelayCommand _myCommand95685658655755;
        //private RelayCommand _myCommand96565;
        //private RelayCommand _myCommand96595;
        //private RelayCommand _myCommand995663;
        //private RelayCommand _myCommand99566asdasd3;
        //private RelayCommand _saveSefares;
        //private RelayCommand addDriverDestenation;
        //private RelayCommand addNewItem;

        //private RelayCommand createBazresList;

        //private RelayCommand delItem;

        //public RelayCommand ADDDriverDestenation
        //{
        //    get
        //    {
        //        return addDriverDestenation ?? (addDriverDestenation = new RelayCommand(
        //            ExecuteADDDriverDestenation,
        //            CanExecuteADDDriverDestenation));
        //    }
        //}

        //public RelayCommand AddNewItem
        //{
        //    get
        //    {
        //        return addNewItem ?? (addNewItem = new RelayCommand(
        //            ExecuteAddNewItem,
        //            CanExecuteAddNewItem));
        //    }
        //}

        //public RelayCommand AllExport
        //{
        //    get
        //    {
        //        return _myCommand99566asdasd3 ?? (_myCommand99566asdasd3 = new RelayCommand(
        //            ExecuteAllReport,
        //            CanExecuteAllReport));
        //    }
        //}

        //public RelayCommand BargeMadarekExport
        //{
        //    get
        //    {
        //        return _myCommand659658785
        //            ?? (_myCommand659658785 = new RelayCommand(ExecuteBargeMadarekExport, CanExecuteBargeMadarekExport));
        //    }
        //}

        //public RelayCommand BimeReportExport
        //{
        //    get
        //    {
        //        return _myCommand995663 ?? (_myCommand995663 = new RelayCommand(
        //            ExecuteBimeReport,
        //            CanExecuteBimeReport));
        //    }
        //}

        //public RelayCommand CheckListTafkikExport
        //{
        //    get
        //    {
        //        return _myCommand5565656952 ?? (_myCommand5565656952 = new RelayCommand(
        //            ExecuteCheckListTafkik,
        //            CanExecuteCheckListTafkik));
        //    }
        //}

        //public RelayCommand CheckReportPrint
        //{
        //    get
        //    {
        //        return _myCommand95685658655 ?? (_myCommand95685658655 = new RelayCommand(
        //            ExecuteCheckReportPrint,
        //            CanExecuteCheckReportPrint));
        //    }
        //}

        //public RelayCommand CreateAnbarList
        //{
        //    get
        //    {
        //        return _myCommand8 ?? (_myCommand8 = new RelayCommand(
        //            ExecuteCreateAnbarList,
        //            CanExecuteCreateAnbarList));
        //    }
        //}

        //public RelayCommand CreateAndishehList
        //{
        //    get
        //    {
        //        return _myCommand79 ?? (_myCommand79 = new RelayCommand(
        //            ExecuteCreateAndishehList,
        //            CanExecuteCreateAndishehList));
        //    }
        //}

        //public RelayCommand CreateBazresLists
        //{
        //    get
        //    {
        //        return createBazresList ?? (createBazresList = new RelayCommand(
        //            ExecuteCreateBazresLists,
        //            CanExecuteCreateBazresLists));
        //    }
        //}

        //public RelayCommand CreateImensazanList
        //{
        //    get
        //    {
        //        return _myCommand9 ?? (_myCommand9 = new RelayCommand(
        //            ExecuteCreateImensazanList,
        //            CanExecuteCreateImensazanList));
        //    }
        //}

        //public RelayCommand CreateKontrolList
        //{
        //    get
        //    {
        //        return _myCommand10 ?? (_myCommand10 = new RelayCommand(
        //            ExecuteCreateKontrolList,
        //            CanExecuteCreateKontrolList));
        //    }
        //}

        //public RelayCommand CreateMaliReport
        //{
        //    get
        //    {
        //        return _myCommand96595 ?? (_myCommand96595 = new RelayCommand(
        //            ExecuteCreateMaliReport,
        //            CanExecuteCreateMaliReport));
        //    }
        //}

        //public RelayCommand DeleteItem
        //{
        //    get
        //    {
        //        return delItem ?? (delItem = new RelayCommand(
        //            ExecuteDelItem,
        //            CanExecuteDelItem));
        //    }
        //}

        //public RelayCommand DriverWorksSet
        //{
        //    get
        //    {
        //        return _myCommand465666 ?? (_myCommand465666 = new RelayCommand(
        //            ExecuteDriverWorksSet,
        //            CanExecuteDriverWorksSet));
        //    }
        //}

        //public RelayCommand KartabletafkikExport
        //{
        //    get
        //    {
        //        return _myCommand95685658655755 ?? (_myCommand95685658655755 = new RelayCommand(
        //            ExecuteKartabletafkikExport,
        //            CanExecuteKartabletafkikExport));
        //    }
        //}

        //public RelayCommand LastAmountSet
        //{
        //    get
        //    {
        //        return _myCommand54664751
        //            ?? (_myCommand54664751 = new RelayCommand(ExecuteLastAmountSet));
        //    }
        //}

        //public RelayCommand ListErsalNahaiExport
        //{
        //    get
        //    {
        //        return _myCommand7 ?? (_myCommand7 = new RelayCommand(
        //            ExecuteListErsalNahaiExport,
        //            CanExecuteListErsalNahaiExport));
        //    }
        //}

        //public RelayCommand LoadSefaresh
        //{
        //    get
        //    {
        //        return _myCommand111 ?? (_myCommand111 = new RelayCommand(
        //            ExecuteLoadSefaresh,
        //            CanExecuteLoadSefaresh));
        //    }
        //}

        //public RelayCommand PalletTablo
        //{
        //    get
        //    {
        //        return _myCommand96565
        //            ?? (_myCommand96565 = new RelayCommand(ExecutePalletTablo));
        //    }
        //}

        //public RelayCommand PanjerehBargeExport
        //{
        //    get
        //    {
        //        return _myCommand55666
        //            ?? (_myCommand55666 = new RelayCommand(ExecutePanjerehBarge, CanExecutePanjerehBarge));
        //    }
        //}

        //public RelayCommand SaveSefaresh
        //{
        //    get
        //    {
        //        return _saveSefares ?? (_saveSefares = new RelayCommand(
        //            ExecuteSaveSefaresh,
        //            CanExecuteSaveSefaresh));
        //    }
        //}

        //public RelayCommand SelectDriver
        //{
        //    get
        //    {
        //        return _myCommand465 ?? (_myCommand465 = new RelayCommand(
        //            ExecuteSelectDriver,
        //            CanExecuteSelectDriver));
        //    }
        //}

        //public RelayCommand ShowCustomer
        //{
        //    get
        //    {
        //        return _myCommand565656
        //            ?? (_myCommand565656 = new RelayCommand(ExecuteShowCustomer));
        //    }
        //}

        //public RelayCommand ShowDrivers
        //{
        //    get
        //    {
        //        return _myCommand746567
        //            ?? (_myCommand746567 = new RelayCommand(ExecuteShowDrivers));
        //    }
        //}

        //public RelayCommand ShowGoods
        //{
        //    get
        //    {
        //        return _myCommand74656
        //            ?? (_myCommand74656 = new RelayCommand(ExecuteShowGoods));
        //    }
        //}

        //#endregion
        //private async Task AllReportAsync()
        //{
        //    ExportFactory f = new ExportFactory()
        //       .addExporter(ExportKind.BargeMadarek)
        //       .addExporter(ExportKind.PanjereBarge)
        //       .addExporter(ExportKind.ChekListTafkik)
        //       .addExporter(ExportKind.KartablTafkik)
        //       .addExporter(ExportKind.ListErsalNahai)
        //       .addExporter(ExportKind.Bime);
        //    await f.SetSefareshAsync(erasl);
        //    await f.ExportIts();
        //    showStatuse("گزارش كلي ساخته شد");
        //}

        //private async Task BargeMadarekReport()
        //{
        //    ExportFactory d = new ExportFactory().addExporter(ExportKind.BargeMadarek);
        //    await d.SetSefareshAsync(erasl);
        //    await d.ExportIts();
        //    showStatuse("گزارش برگه مدارك ساخته شد");
        //}

        //private async Task BimeReportAsync()
        //{
        //    ExportFactory d = new ExportFactory().addExporter(ExportKind.BargeMadarek);
        //    await d.SetSefareshAsync(erasl);
        //    await d.ExportIts();
        //    showStatuse("گزارش بيمه ساخته شد");
        //}

        //private bool CanExecuteADDDriverDestenation()
        //{
        //    return Items.Any(p => p.IsSelected);
        //}

        //private bool CanExecuteAddNewItem()
        //{
        //    return SelectedKala != null;
        //}

        //private bool CanExecuteAllReport()
        //{
        //    return true;
        //}

        //private bool CanExecuteBargeMadarekExport()
        //{
        //    return true;
        //}

        //private bool CanExecuteBimeReport()
        //{
        //    return true;
        //}

        //private bool CanExecuteCheckListTafkik()
        //{
        //    return true;
        //}

        //private bool CanExecuteCheckReportPrint()
        //{
        //    return true;
        //}

        //private bool CanExecuteCreateAnbarList()
        //{
        //    return !NeedToSaveUpdate & (KalaChanged | TedadChanged);
        //}

        //private bool CanExecuteCreateAndishehList()
        //{
        //    return !NeedToSaveUpdate & (KalaChanged | TedadChanged);
        //}

        //private bool CanExecuteCreateBazresLists()
        //{
        //    return !NeedToSaveUpdate & (KalaChanged | TedadChanged);
        //}

        //private bool CanExecuteCreateImensazanList()
        //{
        //    return !NeedToSaveUpdate & (KalaChanged | TedadChanged);
        //}

        //private bool CanExecuteCreateKontrolList()
        //{
        //    //TODO باید اینجا فقط زمانی اینا فعال باشن که اولا ثبت شده باشد یعنی در حال ویرایش و دوما هیچ تغییر ثبت نشده جدیدی وجود نداشته باشد
        //    return !NeedToSaveUpdate & (KalaChanged | CustomerChanged);
        //}

        //private bool CanExecuteCreateMaliReport()
        //{
        //    return !NeedToSaveUpdate & (KalaChanged | TedadChanged | CustomerChanged);
        //}

        //private bool CanExecuteDelItem()
        //{
        //    return Items.Any(p => p.IsSelected);
        //}

        //private bool CanExecuteDriverWorksSet()
        //{
        //    return Items.Any(p => p.ItemRanande != null);
        //}

        //private bool CanExecuteKartabletafkikExport()
        //{
        //    return true;
        //}

        //private bool CanExecuteListErsalNahaiExport()
        //{
        //    return !NeedToSaveUpdate;
        //}

        //private bool CanExecuteLoadSefaresh()
        //{
        //    return !string.IsNullOrEmpty(Tarikh);
        //}

        //private bool CanExecutePanjerehBarge()
        //{
        //    return true;
        //}

        //private bool CanExecuteSaveSefaresh()
        //{
        //    if (CanEdit)
        //    {
        //        return Items.Count > 0 & !string.IsNullOrEmpty(Tarikh) & NeedToSaveUpdate;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        //private bool CanExecuteSelectDriver()
        //{
        //    return !NeedToSaveUpdate;
        //}

        //private void changeSelectedItemsMaghsad(List<Item> selectedItems)
        //{
        //    string selectedMaghsadName = (SelectedDestenation != null ? SelectedDestenation.Name : "تهی");

        //    var selectedMaghsadNameDistinct = selectedItems.Select(p => (p.ItemMaghsad!=null?p.ItemMaghsad.Name:null)).Distinct().ToList();

        //    foreach (var selectedMaghsadNameItem in selectedMaghsadNameDistinct)
        //    {
        //        if (selectedMaghsadNameItem == null)
        //        {
        //            var emptyMaghsads = selectedItems.Where(p => p.ItemMaghsad == null);
        //            foreach (var emptyMaghsad in emptyMaghsads)
        //            {
        //                emptyMaghsad.ItemMaghsad = SelectedDestenation;
        //            }
        //        }
        //        else if (selectedMaghsadNameItem != selectedMaghsadName)
        //        {
        //            DialogResult result = MessageBox.Show("آیا میخواهید مقصد را از " +
        //                selectedMaghsadNameItem + " به " + selectedMaghsadName + " تغییر دهید ؟",
        //                        "اخطار", MessageBoxButtons.YesNo);
        //            if (result == DialogResult.Yes)
        //            {
        //                var oij = selectedItems
        //                    .Where(p =>(p.ItemMaghsad != null ? p.ItemMaghsad.Name == selectedMaghsadNameItem : false));
        //                foreach (var item in oij)
        //                {
        //                    item.ItemMaghsad = SelectedDestenation;
        //                }
        //            }
        //        }
        //    }
        //}

        //private void changeSelectedItemsRanande(List<Item> selectedItems)
        //{
        //    string selectedRanandeName = (SelectedDriver != null ? SelectedDriver.Name : "تهی");

        //    var selectedRanandeDistinct = selectedItems.Select(p => (p.ItemRanande!=null?p.ItemRanande.Name:null)).Distinct().ToList();

        //    foreach (var selectedRanandeItem in selectedRanandeDistinct)
        //    {
        //        if (selectedRanandeItem == null)
        //        {
        //            var oii = selectedItems.Where(p => p.ItemRanande == null);
        //            foreach (var emptyRanande in oii)
        //            {
        //                emptyRanande.ItemRanande = SelectedDriver;
        //            }

        //        }
        //        else if (selectedRanandeItem != selectedRanandeName)
        //        {
        //            DialogResult result = MessageBox.Show("آیا میخواهید راننده را از " +
        //                selectedRanandeItem + " به " + selectedRanandeName + " تغییر دهید ؟",
        //                        "اخطار", MessageBoxButtons.YesNo);
        //            if (result == DialogResult.Yes)
        //            {
        //                var rt = selectedItems
        //                    .Where(p => (p.ItemRanande != null ? p.ItemRanande.Name == selectedRanandeItem : false));
        //                foreach (var item in rt)
        //                {
        //                    item.ItemRanande = SelectedDriver;
        //                }
        //            }
        //        }
        //    }
        //}

        //private async Task checkListReport()
        //{
        //    ExportFactory d = new ExportFactory().addExporter(ExportKind.ChekListTafkik);
        //    await d.SetSefareshAsync(erasl);
        //    await d.ExportIts();
        //    showStatuse("گزارش  چك ليست تفكيكي ساخته شد");
        //}

        //private void ExecuteADDDriverDestenation()
        //{
        //    var itemss = Items.Where(p => p.IsSelected).ToList();
        //    changeSelectedItemsMaghsad(itemss);
        //    changeSelectedItemsRanande(itemss);
        //    foreach (var item in Items)
        //    {
        //        item.IsSelected = false;
        //    }
        //    NeedToSaveUpdate = true;

        //    DriverChanged = true;
        //    CustomerChanged = true;

        //    SelectedDestenation = null;

        //    RaisePropertyChanged(() => SelectedDestenation);
        //    RaisePropertyChanged(() => SelectedDriver);

        //    loadDriversVaznAsync();
        //    loadMaghsadVaznAsync();
        //}

        //private void ExecuteAddNewItem()
        //{
        //    if (SelectedKala != null)
        //    {
        //        Item s = new Item(SelectedKala)
        //        {
        //            Des = Description,
        //            PalletCount = PalletCount,
        //            Tedad = Tedad,
        //            ItemKind = (byte) ItemType.عادی
        //        };
        //        Items.Add(s);
        //        //}
        //        showStatuse("كالاي " + SelectedKala.Name + " به ليست اضافه شد");
        //        NeedToSaveUpdate = true;

        //        Tedad = 0;
        //        Description = "";
        //        SelectedKala = null;

        //        RaisePropertyChanged(() => SelectedKala);
        //        RaisePropertyChanged(() => this.Statuses);
        //        loadDriversVaznAsync();
        //        loadMaghsadVaznAsync();
        //    }
        //}

        //private void ExecuteAllReport()
        //{
        //    AllReportAsync();
        //}

        //private void ExecuteBargeMadarekExport()
        //{
        //    try
        //    {
        //        BargeMadarekReport();
        //    }
        //    catch (Exception rrr)
        //    {
        //        MessageBox.Show(rrr.Message.ToString()); ;
        //    }
        //}

        //private void ExecuteBimeReport()
        //{
        //    BimeReportAsync();
        //}

        //private void ExecuteCheckListTafkik()
        //{
        //    try
        //    {
        //        checkListReport();
        //    }
        //    catch (Exception rrr)
        //    {
        //        MessageBox.Show(rrr.Message.ToString());
        //    }
        //}

        //private void ExecuteCheckReportPrint()
        //{
        //    //ديگه اين معني نداره
        //    //ReportManager rp = new ReportManager(sefaresh);
        //    //rp.CreatCheckReport(false);
        //    //changeState();
        //    //MessageBox.Show("گزارش ساخته شد");
        //}

        //private void ExecuteCreateAnbarList()
        //{
        //    try
        //    {
        //        ReportManager rp = new ReportManager(erasl);
        //        rp.CreatAnbarReportOnDeskTop();
        //        changeState();
        //        showStatuse("گزارش ساخته شد");
        //    }
        //    catch (Exception rt)
        //    {
        //        MessageBox.Show(rt.Message.ToString());
        //    }
        //}

        //private void ExecuteCreateAndishehList()
        //{
        //    ReportManager rp = new ReportManager(erasl);
        //    rp.CreatAndishehReportOnDeskTop();
        //    changeState();
        //    MessageBox.Show("گزارش ساخته شد");
        //    //RaisePropertyChanged(() => Items);
        //}

        //private void ExecuteCreateBazresLists()
        //{
        //    ReportManager rp = new ReportManager(erasl);
        //    rp.CreatAllBazresReportOnDeskTop();
        //    changeState();

        //    showStatuse("گزارش ساخته شد");
        //}

        //private void ExecuteCreateImensazanList()
        //{
        //    ReportManager rp = new ReportManager(erasl);
        //    rp.CreatImenSazanReportOnDeskTop();
        //    changeState();
        //    MessageBox.Show("گزارش ساخته شد");
        //}

        //private void ExecuteCreateKontrolList()
        //{
        //    try
        //    {
        //        ReportManager rp = new ReportManager(erasl);
        //        rp.CreatKontrolReportOnDeskTop();
        //        changeState();
        //        MessageBox.Show("گزارش ساخته شد");
        //    }
        //    catch (Exception rrr)
        //    {
        //        MessageBox.Show(rrr.Message.ToString()); ;
        //    }
        //}

        //private void ExecuteCreateMaliReport()
        //{
        //    ReportManager rp = new ReportManager(erasl);
        //    rp.CreatMaliReport(false);
        //    changeState();
        //    MessageBox.Show("گزارش ساخته شد");
        //}

        //private void ExecuteDelItem()
        //{
        //    string kalahaiDel = string.Join(", ", Items.Where(p => p.IsSelected).Select(z => z.ItemKala.Name));

        //    showStatuse(kalahaiDel + " حذف شدند");

        //    Items.RemoveAll(p => p.IsSelected);

        //    NeedToSaveUpdate = true;

        //    loadDriversVaznAsync();
        //    loadMaghsadVaznAsync();
        //}

        //private void ExecuteDriverWorksSet()
        //{
        //    DriverWorksViewModel vm = new DriverWorksViewModel(erasl.Tarikh);
        //    DriverWorksView v = new DriverWorksView();
        //    v.DataContext = vm;
        //    v.ShowDialog();
        //    //RaisePropertyChanged(() => Items);
        //}

        //private void ExecuteKartabletafkikExport()
        //{
        //    kartableReport();
        //}

        //private void ExecuteLastAmountSet()
        //{
        //    LastAmountView v = new LastAmountView();
        //    v.ShowDialog();
        //    RaisePropertyChanged(() => Items);
        //}

        //private void ExecuteListErsalNahaiExport()
        //{
        //    ListErsalReport();
        //}

        //private void ExecuteLoadSefaresh()
        //{
        //    if (NeedToSaveUpdate)
        //    {
        //        DialogResult result = MessageBox.Show("آيا مطمئن هستيد ميخواهيد اطلاعات را دوباره بارگذاري كنيد ؟ اطلاعات ذخيره نشده حذف خواهد شد",
        //                    "اطلاع", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        //        if (result == DialogResult.Yes)
        //        {
        //            this.LoadThisDateSefaresh(Tarikh);
        //        }
        //    }
        //    else
        //    {
        //        this.LoadThisDateSefaresh(Tarikh);
        //    }
        //    RaisePropertyChanged(() => Items);
        //    loadDriversVaznAsync();
        //    loadMaghsadVaznAsync();
        //}

        //private void ExecutePalletTablo()
        //{
        //    ReportManager rp = new ReportManager(erasl);
        //    rp.CreatPalletTabloReportOnDeskTop(false);
        //    changeState();
        //    MessageBox.Show("گزارش ساخته شد");
        //}

        //private void ExecutePanjerehBarge()
        //{
        //    try
        //    {
        //        PanjeReport();
        //    }
        //    catch (Exception rrr)
        //    {
        //        MessageBox.Show(rrr.Message.ToString()); ;
        //    }
        //}

        //private void ExecuteSaveSefaresh()
        //{
        //    try
        //    {
        //        if (CanEdit)
        //        {
        //            if (IsEdit)
        //            {
        //                updateSefaresh();
        //            }
        //            else
        //            {
        //                SaveNewsefaresh();
        //            }
        //            var res = MessageBox.Show("آيا مي خواهيد گزارش بسازيد ؟", "گزارش ساز", MessageBoxButtons.YesNo);

        //            if (res == DialogResult.Yes)
        //            {
        //                FirstAllReport();
        //            }
        //        }
        //        else
        //        {
        //            unacceptedAsync();
        //        }
        //        NeedToSaveUpdate = false;

        //        loadDriversVaznAsync();
        //        loadMaghsadVaznAsync();

        //        RaisePropertyChanged(() => this.SaveText);
        //    }
        //    catch (DbEntityValidationException e)
        //    {
        //        foreach (var eve in e.EntityValidationErrors)
        //        {
        //            MessageBox.Show("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:" + "\n" +
        //                eve.Entry.Entity.GetType().Name + "\n" + eve.Entry.State);
        //            foreach (var ve in eve.ValidationErrors)
        //            {
        //                MessageBox.Show("- Property: \"{0}\", Error: \"{1}\"" + "\n" +
        //                    ve.PropertyName + "\n" + ve.ErrorMessage);
        //            }
        //        }
        //        throw;
        //    }
        //    catch (Exception r)
        //    {
        //        MessageBox.Show(r.InnerException.Message.ToString());
        //    }
        //}

        //private void ExecuteSelectDriver()
        //{
        //    DriverSelectionViewModel vm = new DriverSelectionViewModel();
        //    DriverSelectionView v = new DriverSelectionView();
        //    v.DataContext = vm;
        //    Messenger.Default.Send<string>(Tarikh, "ThisSefaresh");
        //    v.ShowDialog();
        //    ExecuteLoadSefaresh();

        //    changeState();
        //}

        //private void ExecuteShowCustomer()
        //{
        //    CustomersView p = new CustomersView();
        //    p.ShowDialog();
        //}

        //private void ExecuteShowDrivers()
        //{
        //    DriversView p = new DriversView();
        //    p.Show();
        //}

        //private void ExecuteShowGoods()
        //{
        //    ProductsView p = new ProductsView();
        //    p.Show();
        //}

        //private async Task FirstAllReport()
        //{
        //    ExportFactory f = new ExportFactory()
        //        .addExporter(ExportKind.BazresTafkik)
        //        .addExporter(ExportKind.Andisheh)
        //        .addExporter(ExportKind.ImenSazan)
        //        .addExporter(ExportKind.Kontrol)
        //        .addExporter(ExportKind.ListErsalNahai);
        //    await f.SetSefareshAsync(erasl);
        //    await f.ExportIts();
        //    showStatuse("گزارشات ساخته شد");
        //}

        //private async Task kartableReport()
        //{
        //    ExportFactory f = new ExportFactory().addExporter(ExportKind.KartablTafkik);
        //    await f.SetSefareshAsync(erasl);
        //    await f.ExportIts();
        //    changeState();
        //    showStatuse("گزارش  كارتابل ساخته شد");
        //}

        //private async Task ListErsalReport()
        //{
        //    ExportFactory d = new ExportFactory().addExporter(ExportKind.ListErsalNahai);
        //    await d.SetSefareshAsync(erasl);
        //    await d.ExportIts();
        //    changeState();
        //    showStatuse("گزارش ليست نهايي ساخته شد");
        //}

        //private async Task PanjeReport()
        //{
        //    ExportFactory d = new ExportFactory().addExporter(ExportKind.PanjereBarge);
        //    await d.SetSefareshAsync(erasl);
        //    await d.ExportIts();
        //    showStatuse("گزارش برگه پنجره ساخته شد");
        //}

        //private async Task SaveNewsefaresh()
        //{
        //    await ErsalService.SaveSefareshAsync(erasl);
        //    IsEdit = true;
        //    changeState();
        //    showStatuse("اطلاعات سفارش روز " + Tarikh + " ذخیره شد");
        //}

        //private void showStatuse(string message)
        //{
        //    Statuses = message;
        //    RaisePropertyChanged(() => Statuses);
        //}

        //private async Task unacceptedAsync()
        //{
        //    await ErsalService.UnAcceptSefareshAsync(Tarikh);
        //    CanEdit = true;
        //}

        //private async Task updateSefaresh()
        //{
        //    changeState();

        //    await ErsalService.UpdateSefareshAsync(erasl);
        //    showStatuse("اطلاعات سفارش روز " + Tarikh + " ویرایش شد");
        //}

        //#endregion Command
    }

    public static class Extension
    {
        public static void ReplaceItem<T>(this ObservableCollection<T> col, Func<T, bool> match, T newItem)
        {
            var oldItem = col.FirstOrDefault(i => match(i));
            var oldIndex = col.IndexOf(oldItem);
            col[oldIndex] = newItem;
        }
    }

    //به خاطر اين  مستقيم از ديتياو استفاده نكرديم كه بتوانيم چيزي روي جدول ميخواهيم رو نشون بديم
    public class mainViewModeldataGridRow : INotifyPropertyChanged
    {
        public mainViewModeldataGridRow(ItemDto _dto)
        {
            dto = _dto;
        }

        public bool IsSelected
        {
            get { return dto.IsSelected; }
            set
            {
                dto.IsSelected = value;
                NotifyPropertyChanged("IsSelected");
            }
        }

        public string ItemKalaName
        {
            get { return dto.ItemKala.Name; }
        }

        public int Tedad
        {
            get { return dto.Tedad; }
            set
            {
                dto.Tedad = value;
                NotifyPropertyChanged("Tedad");
                OnItemChenged.Invoke();
            }
        }

        public int Karton
        {
            get { return dto.Karton; }
        }

        public int PalletCount
        {
            get { return dto.PalletCount; }
            set
            {
                dto.PalletCount = value;
                NotifyPropertyChanged("PalletCount");
                OnItemChenged.Invoke();
            }
        }

        public string ItemMaghsadName
        {
            get { return dto.ItemMaghsad != null ? dto.ItemMaghsad.Name : ""; }
        }

        public int Vazn
        {
            get { return dto.Vazn; }
        }

        public string ItemRanandeName
        {
            get { return dto.ItemRanande != null ? dto.ItemRanande.Name : ""; }
        }

        public string ItemKind
        {
            get { return dto.ItemKind.ToString(); }
        }

        public string Des
        {
            get { return dto.Des; }
            set
            {
                dto.Des = value;
                NotifyPropertyChanged("Des");
                OnItemChenged.Invoke();
            }
        }

        public int TahvilFrosh
        {
            get { return dto.TahvilFrosh; }
        }

        public bool IsAllOKForAccept()
        {
            return
                !string.IsNullOrEmpty(ItemMaghsadName) &
                !string.IsNullOrEmpty(ItemRanandeName) &
                Tedad > 0 & PalletCount > 0 & TahvilFrosh > 0;
        }

        public ItemDto dto { get; set; }

        public static Action OnItemChenged;

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