﻿
//using GalaSoft.MvvmLight;
//using GalaSoft.MvvmLight.CommandWpf;
//using GalaSoft.MvvmLight.Messaging;
//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Linq;
//using System.Windows.Forms;

//namespace OrdersAndisheh.ViewModel
//{
//    public class TahvilforoshViewModel : ViewModelBase
//    {
//        SefareshService ss;
//        //ExcelService exService;
//        Sefaresh sefaresh;
//        public TahvilforoshViewModel(ISefareshService service)
//        {
//            ss = new SefareshService();
//            sefaresh = new Sefaresh();
//            Errors = new List<string>();
//            sefaresh.Items = new ObservableCollection<ItemSefaresh>();
//            TahvilFroshs = new List<TahvilFroshData>();
//            Messenger.Default.Register<string>(this, "sefareshForTahvilSet", ThisSefaresh);
//        }

//        private void ThisSefaresh(string obj)
//        {
//            sefaresh = ss.LoadSefaresh(obj);
//            RaisePropertyChanged(() => this.ErsalListForTahvilFrosh);
//        }

//        private string file;

//        public string FilePath
//        {
//            get { return file; }
//            private set 
//            { 
//                file = value;
//                RaisePropertyChanged(() => FilePath);
//            }
//        }

//        private List<TahvilFroshData> TahvilFroshs;
//        //private ObservableCollection<ItemSefaresh> myVar;

//        public ObservableCollection<ItemSefaresh> ErsalListForTahvilFrosh
//        {
//            get { return sefaresh.Items; }
//            //set 
//            //{
//            //    myVar = value;
//            //    RaisePropertyChanged(() => ErsalListForTahvilFrosh);
//            //}
//        }

//        public List<string> Errors { get; set; }



//        private RelayCommand _myCommand6;

//        /// <summary>
//        /// Gets the GetFile.
//        /// </summary>
//        public RelayCommand GetFile
//        {
//            get
//            {
//                return _myCommand6 ?? (_myCommand6 = new RelayCommand(
//                    ExecuteGetFile,
//                    CanExecuteGetFile));
//            }
//        }

//        private void ExecuteGetFile()
//        {

//            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
//            {

//                if (openFileDialog1.ShowDialog() == DialogResult.OK)
//                {
//                    openFileDialog1.Filter = "Excel Files (.xlsx)|*.xlsx|All Files (*.*)|*.*";
//                    openFileDialog1.FilterIndex = 1;
//                    FilePath = openFileDialog1.FileName;
//                    CalculateData();
//                }
//            }
//        }

//        private void CalculateData()
//        {
//            try
//            {
//                TahvilFroshs = new List<TahvilFroshData>();
//                ExcelImportService s = new ExcelImportService();
//                TahvilFroshs = s.GetTahvilfroshData(FilePath);
//                CalculateSefareshWithData();
//            }
//            catch (Exception ree)
//            {

//                MessageBox.Show(ree.Message.ToString());
//            }
//        }
//        private bool CanExecuteGetFile()
//        {
//            return true;
//        }

//        private void CalculateSefareshWithData()
//        {
            
//            //var isImen = !TahvilFroshs.Any(p => int.Parse(p.CodeKala) < 15009000);

//            //var t = TahvilFroshs.Where(p => p.CodeKala.StartsWith("15")).ToList();

//            //foreach (var item in t)
//            //{
//            //    var ddddd = item.CodeKala.Substring(0, 4);
//            //    var iiiii = ddddd.Substring(3, 1);
//            //    var o = iiiii;
//            //}


//            //15001067 -> Substring(0, 4)= 1500 -> Substring(3,1) = 0 => Andisheh
//            //15010001 -> Substring(0, 4)= 1501 -> Substring(3,1) = 1 => ImenSazan
//            var isImen = TahvilFroshs.Where(p => p.CodeKala.StartsWith("15"))
//                .Any(p => (p.CodeKala.Substring(0, 4)).Substring(3,1) == "1");
            
//            CheckMoreThanOneTarikh();

//            var ItemForCheck = sefaresh.Items.Where(p => p.IsImenKala == isImen);
//            int NotOkCount = 0;
//            do
//            {

//                //TODO  باید یه کاری کنیم که همون اول حالت هر سفارش مشخص شود
//                NotOkCount = ItemForCheck.Where(p => p.TahvilFrosh < 1).ToList().Count;

//                foreach (var sefaresh_item in ItemForCheck.Where(i => i.TahvilFrosh == 0).ToList())
//                {
//                    var tahvil = CheckByCodeKala(sefaresh_item,
//                        TahvilFroshs.Where(p => !p.IsOk).Where(p => p.CodeKala == sefaresh_item.CodeKala).ToList());
//                    sefaresh_item.TahvilFrosh = tahvil;
//                }

//                foreach (var sefaresh_item in ItemForCheck.Where(i => i.TahvilFrosh == 0).ToList())
//                {
//                    var tahvil = CheckByTedadKala(sefaresh_item,
//                        TahvilFroshs.Where(p => !p.IsOk).Where(p => p.CodeKala == sefaresh_item.CodeKala).ToList());
//                    sefaresh_item.TahvilFrosh = tahvil;
//                }
//                foreach (var sefaresh_item in ItemForCheck.Where(i => i.TahvilFrosh == 0).ToList())
//                {
//                    var tahvil = CheckBySameTahvilNumber(sefaresh_item,
//                        ItemForCheck
//                        .Where(p => p.Maghsad == sefaresh_item.Maghsad)
//                        .Where(o => o.Ranande == sefaresh_item.Ranande)
//                        .Where(o => o.IsImenKala == sefaresh_item.IsImenKala)
//                        .Where(p => p.TahvilFrosh > 0).Select(p => p.TahvilFrosh).Distinct()
//                        .ToList(),
//                        TahvilFroshs.Where(p => !p.IsOk)
//                        .Where(p => p.CodeKala == sefaresh_item.CodeKala)
//                        .Where(p=>p.Tedad==sefaresh_item.Tedad)
//                        .ToList());
//                    sefaresh_item.TahvilFrosh = tahvil;
//                }

//            } while (NotOkCount != ItemForCheck.Where(p => p.TahvilFrosh < 1).ToList().Count);

//            var nuy = TahvilFroshs.Where(isa => !isa.IsOk).ToList();
//            foreach (var de in nuy)
//            {
//                Errors.Add("برای تحویل فروش " +
//                    de.TahvilFroshNum + " کالای " +
//                    de.KalaName + " به تعداد " +
//                    de.Tedad + " آیتمی در سفارش وجود ندارد");
//            }

//            RaisePropertyChanged(() => Errors);
//            RaisePropertyChanged(() => ErsalListForTahvilFrosh);
//        }

//        private short CheckBySameTahvilNumber(ItemSefaresh item, List<short> tahvilWithSameMDAndTahvilOk,
//            List<TahvilFroshData> tahvilsWithSameItemCode)
//        {
//            short e = 0;
//            foreach (var ismd in tahvilWithSameMDAndTahvilOk)
//            {
//                var find = tahvilsWithSameItemCode
//                    .Where(p => p.TahvilFroshNum == ismd)
//                    .ToList();
//                if (find.Count==1)
//                {
//                    find.First().IsOk = true;
//                    e = find.First().TahvilFroshNum;
//                }
//            }
//            return e;
//        }

//        private short CheckByTedadKala(ItemSefaresh item, List<TahvilFroshData> tahvilsWithSameItemCode)
//        {
//            var fi = tahvilsWithSameItemCode.Where(p => p.Tedad == item.Tedad).ToList();

//            if (fi.Count==1)
//            {
//                fi.First().IsOk = true;
//                return fi.First().TahvilFroshNum;
//            }
//            else
//            {
//                return 0;
//            }
//        }

//        private short CheckByCodeKala(ItemSefaresh item, List<TahvilFroshData> tahvilsWithSameCodeKala)
//        {
//            //var findedTahvils = tahvils.Where(p => p.CodeKala == item.CodeKala).ToList();

//            if (tahvilsWithSameCodeKala.Count == 1)
//            {
//                if (tahvilsWithSameCodeKala.First().Tedad == item.Tedad)
//                {
//                    tahvilsWithSameCodeKala.First().IsOk = true;
//                    return tahvilsWithSameCodeKala.First().TahvilFroshNum;
//                }
//                else if (item.TahvilFrosh != -1)
//                {
//                    Errors.Add("احتمالا تعداد کالای " +
//                       item.Kala + " بجای " + item.Tedad + " عدد " +
//                        tahvilsWithSameCodeKala.First().Tedad + " عدد در تحویل فروش " 
//                        + tahvilsWithSameCodeKala.First().TahvilFroshNum + " ثبت شده است");
//                    return -1;
//                }
//                else
//                {
//                    return 0;
//                }
                
//            }
//            else if (tahvilsWithSameCodeKala.Count == 0)
//            {
//                Errors.Add("برای کالای "
//                        + item.Kala + " ارسالی به "
//                        + item.Maghsad + " تحویل فروشی ثبت نشده");
//                return -2;
//            }
//            else
//            {
//                return 0;
//            }
//        }
//        private void CheckMoreThanOneTarikh()
//        {
//            List<string> tar = TahvilFroshs.Select(p => p.TarikhSanad).Distinct().ToList();
//            string tarikhha = "";
//            string rr = "";
//            if (tar.Count() > 1)
//            {
//                for (int i = 0; i < tar.Count(); i++)
//                {
//                    tarikhha += tar[i] + "-";
//                }
//                rr = "فایل شامل اسناد بیش از یک تاریخ می باشد " + tarikhha;
//                Errors.Add(rr);
//            }
//        }

//        private RelayCommand _myCommand55555772;
            
//        /// <summary>
//        /// Gets the SaveTahvilFrosh.
//        /// </summary>
//        public RelayCommand SaveTahvilFrosh
//        {
//            get
//            {
//                return _myCommand55555772 ?? (_myCommand55555772 = new RelayCommand(
//                    ExecuteSaveTahvilFrosh,
//                    CanExecuteSaveTahvilFrosh));
//            }
//        }

//        private void ExecuteSaveTahvilFrosh()
//        {
//            MessageBox.Show("تحویل فروش  تاریخ " + sefaresh.Tarikh + " ثبت شد " );
//            ss.Save();
//        }

//        private bool CanExecuteSaveTahvilFrosh()
//        {
//            return !sefaresh.Items.Any(p=>p.TahvilFrosh<1);
//        }

//        private RelayCommand _myCommand55555sdf772;

//        /// <summary>
//        /// Gets the SaveTahvilFrosh.
//        /// </summary>
//        public RelayCommand ClearTahvilFrosh
//        {
//            get
//            {
//                return _myCommand55555sdf772 ?? (_myCommand55555sdf772 = new RelayCommand(
//                    ExecuteClearTahvilFrosh,
//                    CanExecuteClearTahvilFrosh));
//            }
//        }

//        private void ExecuteClearTahvilFrosh()
//        {
//            foreach (var item in sefaresh.Items)
//            {
//                item.TahvilFrosh = 0;
//            }
//        }

//        private bool CanExecuteClearTahvilFrosh()
//        {
//            return sefaresh.Items.Any(p => p.TahvilFrosh > 0);
//        }

//        private RelayCommand _myCommand5555as72;

//        /// <summary>
//        /// Gets the SaveTahvilFrosh.
//        /// </summary>
//        public RelayCommand TempSaveTahvilFrosh
//        {
//            get
//            {
//                return _myCommand5555as72 ?? (_myCommand5555as72 = new RelayCommand(
//                    ExecuteTempSaveTahvilFrosh,
//                    CanExecuteTempSaveTahvilFrosh));
//            }
//        }

//        private void ExecuteTempSaveTahvilFrosh()
//        {
//            foreach (var item in sefaresh.Items.Where(p => p.TahvilFrosh <= 0))
//            {
//                item.TahvilFrosh = short.Parse("9999");
//            }
//            ExecuteSaveTahvilFrosh();
//        }

//        private bool CanExecuteTempSaveTahvilFrosh()
//        {
//            return sefaresh.Items.Any(p => p.TahvilFrosh <=0);
//        }
//    }

    
//}
