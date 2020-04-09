
using Core.Models;
using Core.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using OrdersAndisheh.Model;
using OrdersAndisheh.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Validation;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace OrdersAndisheh.ViewModel
{
    public class FirstViewModel : ViewModelBase
    {
        private IErsalService ersal_service;
        ISaleMaliManager manger;
        public FirstViewModel(IErsalService _service, ISaleMaliManager _manager)
        {
            manger = _manager;
#error نمی توان اینجا از سال مالی اینطوری استفاده کرد
            SaleMaliManager.OnChangeSalaMali = () => { ReOpenApplication(); };
            manger.CheckOutSalMali();
            
            ersal_service = _service;
        }

        public string Today
        {
            get { return "سفارش امروز - " + getTarikhDiffToday(0); }
        }
        public string Tommorow
        {
            get { return "سفارش فردا - " + getTarikhDiffToday(1); }
        }

        public string YesterDay
        {
            get { return "سفارش ديروز - " + getTarikhDiffToday(-1); }
        }

       

        private RelayCommand _TommorowSefareshCommand;
        public RelayCommand TommorowSefareshCommand
        {
            get
            {
                return _TommorowSefareshCommand ?? (_TommorowSefareshCommand = new RelayCommand(
                    () =>
                    {
                        MainViewNew v = new MainViewNew();
                        Messenger.Default.Send<string>(getTarikhDiffToday(1), "Open");
                        v.ShowDialog();
                        RaisePropertyChanged(() => this.Sefareshat);
                    }));
            }
        }

        private RelayCommand _TodaySefareshCommand;
        public RelayCommand TodaySefareshCommand
        {
            get
            {
                return _TodaySefareshCommand ?? (_TodaySefareshCommand = new RelayCommand(
                    () =>
                    {
                        MainViewNew v = new MainViewNew();
                        Messenger.Default.Send<string>(getTarikhDiffToday(0), "Open");
                        v.ShowDialog();
                        RaisePropertyChanged(() => this.Sefareshat);
                    }));
            }
        }

        private RelayCommand _YesterDaySefaresh;
        public RelayCommand YesterDaySefareshCommand
        {
            get
            {
                return _YesterDaySefaresh ?? (_YesterDaySefaresh = new RelayCommand(
                    () =>
                    {
                        MainViewNew v = new MainViewNew();
                        Messenger.Default.Send<string>(getTarikhDiffToday(-1), "Open");
                        v.ShowDialog();
                        RaisePropertyChanged(() => this.Sefareshat);
                    }));
            }
        }

        private RelayCommand _BasicData;
        public RelayCommand BasicDataCommand
        {
            get
            {
                return _BasicData ?? (_BasicData = new RelayCommand(
                    () =>
                    {
                        throw new NotImplementedException();
                        //MainViewNew v = new MainViewNew();
                        //v.ShowDialog();
                        //Messenger.Default.Send<string>(today, "Editsefaresh");
                        //RaisePropertyChanged(() => this.CheckSefareshs);
                    }));
            }
        }

        private RelayCommand _OpenSefaresh;
        public RelayCommand OpenSefareshCommand
        {
            get
            {
                return _OpenSefaresh ?? (_OpenSefaresh = new RelayCommand(
                    () =>
                    {
                        MainViewNew v = new MainViewNew();
                        Messenger.Default.Send<string>(SelectedSefareshTarikh.TarikhSefaresh, "Open");
                        v.ShowDialog();
                        RaisePropertyChanged(() => this.Sefareshat);
                    }));
            }
        }

        private bool isShowAcceptedSefaresh;

        public bool IsShowAcceptedSefaresh
        {
            get { return isShowAcceptedSefaresh; }
            set 
            { 
                isShowAcceptedSefaresh = value;
                RaisePropertyChanged("IsShowAcceptedSefaresh");
                RaisePropertyChanged("Sefareshat");
            }
        }
        public ObservableCollection<ErsalState> Sefareshat
        {
            get { return new ObservableCollection<ErsalState>(ersal_service.GetErsalStates(isShowAcceptedSefaresh)); }
        }

        public ErsalState SelectedSefareshTarikh { get; set; }

        public List<int> SaleMali
        {
            get 
            { 
                var sals = manger.GetSalMalis();
                SelectedSalMali = sals[0];
                return sals;
            }
        }

        private int seleMali;
        public int SelectedSalMali {
            get { return seleMali; } 
            set 
            {
                seleMali = value;
                manger.ChangeSalMaliTo(value);
                RaisePropertyChanged("SelectedSalMali");
            } 
        }

        private void ReOpenApplication()
        {
            throw new NotImplementedException();
        }

        private static string getTarikhDiffToday(int diff)
        {
            return PersianDateTime.Now.AddDays(diff).ToString(PersianDateTimeFormat.Date);
        }







        #region NotUsed
        /// <summary>
        /// زير اين خط هنوز اوكي نشده
        /// </summary>
        //public string selectedYear
        //{
        //    get { return se; }
        //    set
        //    {
        //        if (string.IsNullOrEmpty(value))
        //        {
        //            se = PersianDateTime.Now.Year.ToString();
        //        }
        //        else
        //        {
        //            se = value;
        //            RaisePropertyChanged(() => CheckSefareshs);
        //        }
        //    }
        //}


        //public List<int> Years
        //{
        //    get { return ersal_service.GetErsalYears(); }
        //}

        //public List<ErsalState> CheckSefareshs
        //{
        //    get
        //    {
        //        return ersal_service.GetErsalStates(selectedYear);
        //    }
        //}

        //public ErsalState SelectedSefareshCheck { get; set; }





        //private RelayCommand _EditSefaresh;

        ///// <summary>
        ///// Gets the EditSefaresh.
        ///// </summary>
        //public RelayCommand EditSefaresh
        //{
        //    get
        //    {
        //        return _EditSefaresh ?? (_EditSefaresh = new RelayCommand(
        //            ExecuteEditSefaresh,
        //            CanExecuteEditSefaresh));
        //    }
        //}

        //private void ExecuteEditSefaresh()
        //{
        //    if (SelectedSefareshCheck != null)
        //    {
        //        MainViewNew v = new MainViewNew();
        //        Messenger.Default.Send<string>(SelectedSefareshCheck.TarikhSefaresh, "EditSefaresh");
        //        v.ShowDialog();
        //        //ReloadList(SelectedSefareshCheck);
        //        RaisePropertyChanged(() => this.CheckSefareshs);
        //    }
        //}

        //private bool CanExecuteEditSefaresh()
        //{
        //    return SelectedSefareshCheck != null;
        //}

        //#region BackUp

        //private RelayCommand _myCommand45;

        ///// <summary>
        ///// Gets the BackUpDatabase.
        ///// </summary>
        //public RelayCommand BackUpDatabase
        //{
        //    get
        //    {
        //        return _myCommand45
        //            ?? (_myCommand45 = new RelayCommand(ExecuteBackUpDatabase));
        //    }
        //}

        //private void ExecuteBackUpDatabase()
        //{
        //    OpenFileDialog folderDialog = new OpenFileDialog();
        //    folderDialog.InitialDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        //    folderDialog.ShowDialog();
        //    //if (folderDialog.ShowDialog() == DialogResult.OK)
        //    //{
        //    //    string sourcePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        //    //    string sourceFile = "OrderDbCompact.sdf";
        //    //    string destinationPath = folderDialog.SelectedPath;
        //    //    string destinationFile = "BackUp.sdf";
        //    //    string sourceFileName = Path.Combine(sourcePath, sourceFile);
        //    //    string destinationFileName = Path.Combine(destinationPath, destinationFile);

        //    //    try
        //    //    {
        //    //        //conn.disconnect();
        //    //        //ss.Dispose();
        //    //        File.Copy(sourceFileName, destinationFileName, true);
        //    //        MessageBox.Show("Database backup saved.");
        //    //    }
        //    //    catch (Exception ex)
        //    //    {
        //    //        MessageBox.Show(ex.ToString());
        //    //    }
        //    //    finally
        //    //    {
        //    //        //conn.connect();
        //    //    }
        //    //}
        //}

        //private RelayCommand _myCommand65656;

        ///// <summary>
        ///// Gets the RestoreDatabase.
        ///// </summary>
        //public RelayCommand RestoreDatabase
        //{
        //    get
        //    {
        //        return _myCommand65656
        //            ?? (_myCommand65656 = new RelayCommand(ExecuteRestoreDatabase));
        //    }
        //}

        //private void ExecuteRestoreDatabase()
        //{
        //    OpenFileDialog folderDialog = new OpenFileDialog();
        //    if (folderDialog.ShowDialog() == DialogResult.OK)
        //    {
        //        string destinationPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        //        string destinationFile = "OrderDbCompact.sdf";
        //        string sourceFileName = folderDialog.FileName;
        //        //string sourceFile = "OrderDbCompactB.sdf";
        //        //string sourceFileName = Path.Combine(sourcePath, sourceFile);
        //        string destinationFileName = Path.Combine(destinationPath, destinationFile);

        //        try
        //        {
        //            //conn.disconnect();
        //            //ss.Dispose();
        //            File.Copy(sourceFileName, destinationFileName, true);
        //            MessageBox.Show("Database Restored.");
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.ToString());
        //        }
        //        finally
        //        {
        //            //conn.connect();
        //        }
        //        //RaisePropertyChanged(() => this.CheckSefareshs);
        //    }
        //}

        //#endregion BackUp

        //private RelayCommand _myCommand565;

        ///// <summary>
        ///// Gets the OracleRelation.
        ///// </summary>
        //public RelayCommand OracleRelation
        //{
        //    get
        //    {
        //        return _myCommand565
        //            ?? (_myCommand565 = new RelayCommand(ExecuteOracleRelation));
        //    }
        //}

        //private void ExecuteOracleRelation()
        //{
        //    //ImportView v = new ImportView();
        //    //v.ShowDialog();

        //    AmarTolidKhodroView v = new AmarTolidKhodroView();
        //    v.ShowDialog();
        //}

        //private RelayCommand _myCommand654654;

        ///// <summary>
        ///// Gets the DataUIEdition.
        ///// </summary>
        //public RelayCommand DataUIEdition
        //{
        //    get
        //    {
        //        return _myCommand654654
        //            ?? (_myCommand654654 = new RelayCommand(ExecuteDataUIEdition));
        //    }
        //}

        //private void ExecuteDataUIEdition()
        //{
        //    //DataUIView v = new DataUIView();
        //    //v.Show();
        //}

        //private RelayCommand _myCommand6459653;

        ///// <summary>
        ///// Gets the CheckTempDriver.
        ///// </summary>
        //public RelayCommand BackUpAsExcel
        //{
        //    get
        //    {
        //        return _myCommand6459653
        //            ?? (_myCommand6459653 = new RelayCommand(ExecuteBackUpAsExcel, CanExecuteBackUpAsExcel));
        //    }
        //}

        //private bool CanExecuteBackUpAsExcel()
        //{
        //    return SelectedSefareshCheck != null;
        //}

        //private void ExecuteBackUpAsExcel()
        //{
        //    //try
        //    //{
        //    //    ExcelBackUp p = new ExcelBackUp(ersal_service);

        //    //    string y = p.ExportLastSavedSefaresh(SelectedSefareshCheck.TarikhSefaresh);

        //    //    MessageBox.Show("اطلاعات در آدرس " + y + " ذخیره شد");
        //    //}
        //    //catch (Exception r)
        //    //{
        //    //    MessageBox.Show(r.Message.ToString());
        //    //}
        //}





        //private RelayCommand _myCommand5252656;

        ///// <summary>
        ///// Gets the SetTahvilfrosh.
        ///// </summary>
        //public RelayCommand SetTahvilfrosh
        //{
        //    get
        //    {
        //        return _myCommand5252656 ?? (_myCommand5252656 = new RelayCommand(
        //            ExecuteSetTahvilfrosh,
        //            CanExecuteSetTahvilfrosh));
        //    }
        //}

        //private void ExecuteSetTahvilfrosh()
        //{
        //    try
        //    {
        //        TahvilfroshView v = new TahvilfroshView();
        //        Messenger.Default.Send<string>(SelectedSefareshCheck.TarikhSefaresh, "sefareshForTahvilSet");
        //        v.ShowDialog();
        //        RaisePropertyChanged(() => this.CheckSefareshs);
        //    }
        //    catch (Exception r)
        //    {

        //        MessageBox.Show(r.Message.ToString());
        //    }
        //}

        //private bool CanExecuteSetTahvilfrosh()
        //{
        //    return SelectedSefareshCheck != null;
        //}

        //private RelayCommand _myCommand6565656562252;

        ///// <summary>
        ///// Gets the CheckAsns.
        ///// </summary>
        //public RelayCommand CheckAsns
        //{
        //    get
        //    {
        //        return _myCommand6565656562252 ?? (_myCommand6565656562252 = new RelayCommand(
        //            ExecuteCheckAsns,
        //            CanExecuteCheckAsns));
        //    }
        //}

        //private void ExecuteCheckAsns()
        //{
        //    //AsnView v = new AsnView();
        //    //Messenger.Default.Send<string>(SelectedSefareshCheck.TarikhSefaresh, "sefareshForAsn");
        //    //v.Show();
        //}

        //private bool CanExecuteCheckAsns()
        //{
        //    return SelectedSefareshCheck != null;
        //}

        //private RelayCommand _myCommand43556111;

        ///// <summary>
        ///// Gets the AcceptSefaresh.
        ///// </summary>
        //public RelayCommand AcceptSefaresh
        //{
        //    get
        //    {
        //        return _myCommand43556111 ?? (_myCommand43556111 = new RelayCommand(
        //            ExecuteAcceptSefaresh,
        //            CanExecuteAcceptSefaresh));
        //    }
        //}

        //private void ExecuteAcceptSefaresh()
        //{
        //    try
        //    {
        //        ersal_service.AcceptErsal(SelectedSefareshCheck.TarikhSefaresh);
        //        //ExcelBackUp p = new ExcelBackUp(ersal_service);
        //        //string y = p.ExportLastSavedSefaresh(SelectedSefareshCheck.TarikhSefaresh);
        //        //MessageBox.Show("اطلاعات در آدرس " + y + " ذخیره شد");
        //        //RaisePropertyChanged(() => this.CheckSefareshs);
        //    }
        //    catch (Exception t)
        //    {
        //        MessageBox.Show(t.Message.ToString());
        //    }
        //}

        //private bool CanExecuteAcceptSefaresh()
        //{
        //    return SelectedSefareshCheck != null && SelectedSefareshCheck.IsEveryThingOk;
        //}

        //private RelayCommand _myCommand5656565478111;

        ///// <summary>
        ///// Gets the ErsalReporting.
        ///// </summary>
        //public RelayCommand ErsalReporting
        //{
        //    get
        //    {
        //        return _myCommand5656565478111
        //            ?? (_myCommand5656565478111 = new RelayCommand(ExecuteErsalReporting));
        //    }
        //}

        //private void ExecuteErsalReporting()
        //{
        //    //ErsalReportViewModel vm = new ErsalReportViewModel(int.Parse(selectedYear));
        //    //ErsalReportView v = new ErsalReportView();
        //    //v.DataContext = vm;
        //    //v.Show();
        //}

        //private RelayCommand _myCommand5465656565656;

        ///// <summary>
        ///// Gets the PalletReporting.
        ///// </summary>
        //public RelayCommand PalletReporting
        //{
        //    get
        //    {
        //        return _myCommand5465656565656
        //            ?? (_myCommand5465656565656 = new RelayCommand(ExecutePalletReporting));
        //    }
        //}

        //private void ExecutePalletReporting()
        //{
        //    //PalletReportViewModel vm = new PalletReportViewModel(int.Parse(selectedYear));
        //    //PalletReportView v = new PalletReportView();
        //    //v.DataContext = vm;
        //    //v.Show();
        //}

        //private RelayCommand _myCommand52333565656;

        ///// <summary>
        ///// Gets the PalletReporting.
        ///// </summary>
        //public RelayCommand Shakhes
        //{
        //    get
        //    {
        //        return _myCommand52333565656
        //            ?? (_myCommand52333565656 = new RelayCommand(ExecuteShakhes));
        //    }
        //}

        //private void ExecuteShakhes()
        //{
        //    ShakhesView v = new ShakhesView();
        //    v.ShowDialog();
        //}

        //private RelayCommand _myCommand75555;

        ///// <summary>
        ///// Gets the PelaskoReport.
        ///// </summary>
        //public RelayCommand PelaskoReport
        //{
        //    get
        //    {
        //        return _myCommand75555
        //            ?? (_myCommand75555 = new RelayCommand(ExecutePelaskoReport));
        //    }
        //}

        //private void ExecutePelaskoReport()
        //{
        //    //var items = ersal_service.LoadAllPelaskosefaresh();

        //    //foreach (var er in items)
        //    //{
        //    //    er.Des = er.OrderDetail.Order.Tarikh;
        //    //}

        //    //FileManagar f = new FileManagar();
        //    //using (FolderBrowserDialog dialog = new FolderBrowserDialog())
        //    //{
        //    //    if (dialog.ShowDialog() == DialogResult.OK)
        //    //    {
        //    //        f.CreatePlaskoreport(items, dialog.SelectedPath + "/pelasko.xlsx");
        //    //    }
        //    //}
        //}

        //private RelayCommand _myCommand5595;
        //private string se = PersianDateTime.Now.Year.ToString();

        ///// <summary>
        ///// Gets the DatabaseChecking.
        ///// </summary>
        //public RelayCommand DatabaseChecking
        //{
        //    get
        //    {
        //        return _myCommand5595
        //            ?? (_myCommand5595 = new RelayCommand(ExecuteDatabaseChecking));
        //    }
        //}

        //private void ExecuteDatabaseChecking()
        //{
        //    //ersal_service.DatabaseChecking();
        //    //MessageBox.Show("دیتابیس آماده شد");
        //}

        //private RelayCommand _myCommand55777795;

        ///// <summary>
        ///// Gets the DatabaseChecking.
        ///// </summary>
        //public RelayCommand NewForm
        //{
        //    get
        //    {
        //        return _myCommand55777795
        //            ?? (_myCommand55777795 = new RelayCommand(ExecuteNewForm));
        //    }
        //}

        //private void ExecuteNewForm()
        //{
        //    MainViewNew v = new MainViewNew();
        //    v.ShowDialog();
        //    RaisePropertyChanged(() => this.CheckSefareshs);
        //} 
        #endregion
    }
    
}