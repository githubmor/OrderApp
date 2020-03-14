﻿
//using GalaSoft.MvvmLight;
//using GalaSoft.MvvmLight.CommandWpf;

//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Linq;

//namespace OrdersAndisheh.ViewModel
//{
//    /// <summary>
//    /// This class contains properties that a View can data bind to.
//    /// <para>
//    /// See http://www.galasoft.ch/mvvm
//    /// </para>
//    /// </summary>
//    public class OracleRelationViewModel : ViewModelBase
//    {
//        ISefareshService service;
//        /// <summary>
//        /// Initializes a new instance of the OracleViewModel class.
//        /// </summary>
//        public OracleRelationViewModel(ISefareshService _service)
//        {
//            service = _service;
//            ComboCustomers = service.LoadDestinations();
//            ComboProducts = service.LoadGoods();
//            OracleCustomers = new ObservableCollection<Customer>(service.LoadOracleCustomer());

//        }

//        public List<Customer> ComboCustomers { get; set; }
//        private Customer selectedCustomerForAdd;

//        public Customer SelectedCustomerForAdd
//        {
//            get { return selectedCustomerForAdd; }
//            set 
//            { 
//                selectedCustomerForAdd = value;
//                RaisePropertyChanged(() => this.SelectedCustomerForAdd);
//            }
//        }
//        public List<Product> ComboProducts { get; set; }
//        private Product selectedProductForAdd;

//        public Product SelectedProductForAdd
//        {
//            get { return selectedProductForAdd; }
//            set 
//            { 
//                selectedProductForAdd = value;
//                RaisePropertyChanged(() => this.SelectedProductForAdd);
//            }
//        }

//        public ObservableCollection<Customer> OracleCustomers { get; set; }
//        private Customer selectedoCustomer;

//        public Customer SelectedoCustomer
//        {
//            get { return selectedoCustomer; }
//            set 
//            { 
//                selectedoCustomer = value;
//                RaisePropertyChanged(() => this.SelectedoCustomer);
//                RaisePropertyChanged(() => this.OracleProducts);
//            }
//        }

//        public ObservableCollection<Product> OracleProducts
//        {
//            get 
//            {
//                if (selectedoCustomer != null)
//                    return new ObservableCollection<Product>(SelectedoCustomer.Relations.Select(p=>p.Product).ToList());
//                else
//                    return null;
//            }
//            //set { selectedoProduct = value; }
//        }
//        private Product selectedoProduct;

//        public Product SelectedoProduct
//        {
//            get { return selectedoProduct; }
//            set 
//            { 
//                selectedoProduct = value;
//                RaisePropertyChanged(() => this.SelectedoProduct);
//            }
//        }

//        #region Command
//        private RelayCommand _myCommand1;

//        /// <summary>
//        /// Gets the AddNewOCustomer.
//        /// </summary>
//        public RelayCommand AddNewOCustomer
//        {
//            get
//            {
//                return _myCommand1 ?? (_myCommand1 = new RelayCommand(
//                    ExecuteAddNewOCustomer,
//                    CanExecuteAddNewOCustomer));
//            }
//        }

//        private void ExecuteAddNewOCustomer()
//        {
//            OracleCustomers.Add(SelectedCustomerForAdd);
//            RaisePropertyChanged(() => this.OracleProducts);
//        }

//        private bool CanExecuteAddNewOCustomer()
//        {
//            return SelectedCustomerForAdd!=null;
//        }

//        private RelayCommand _myCommand2;

//        /// <summary>
//        /// Gets the AddNewOProduct.
//        /// </summary>
//        public RelayCommand AddNewOProduct
//        {
//            get
//            {
//                return _myCommand2 ?? (_myCommand2 = new RelayCommand(
//                    ExecuteAddNewOProduct,
//                    CanExecuteAddNewOProduct));
//            }
//        }

//        private void ExecuteAddNewOProduct()
//        {
//            SelectedoCustomer.Relations.Add(new CustomerProductRelation() { Product = SelectedProductForAdd, Customer = SelectedoCustomer });
//        }

//        private bool CanExecuteAddNewOProduct()
//        {
//            return SelectedoCustomer!=null & SelectedProductForAdd!=null;
//        }

//        private RelayCommand _myCommand3;

//        /// <summary>
//        /// Gets the SaveChanges.
//        /// </summary>
//        public RelayCommand SaveChanges
//        {
//            get
//            {
//                return _myCommand3 ?? (_myCommand3 = new RelayCommand(
//                    ExecuteSaveChanges,
//                    CanExecuteSaveChanges));
//            }
//        }

//        private void ExecuteSaveChanges()
//        {
//            service.SaveOracleRelation(OracleCustomers.ToList());
//        }

//        private bool CanExecuteSaveChanges()
//        {
//            return true;
//        }

//        private RelayCommand _myCommand4;

//        /// <summary>
//        /// Gets the DelOCustomer.
//        /// </summary>
//        public RelayCommand DelOCustomer
//        {
//            get
//            {
//                return _myCommand4 ?? (_myCommand4 = new RelayCommand(
//                    ExecuteDelOCustomer,
//                    CanExecuteDelOCustomer));
//            }
//        }

//        private void ExecuteDelOCustomer()
//        {
//            OracleCustomers.Remove(SelectedoCustomer);
//        }

//        private bool CanExecuteDelOCustomer()
//        {
//            return SelectedoCustomer!=null;
//        }

//        private RelayCommand _myCommand5;

//        /// <summary>
//        /// Gets the DelOProduct.
//        /// </summary>
//        public RelayCommand DelOProduct
//        {
//            get
//            {
//                return _myCommand5 ?? (_myCommand5 = new RelayCommand(
//                    ExecuteDelOProduct,
//                    CanExecuteDelOProduct));
//            }
//        }

//        private void ExecuteDelOProduct()
//        {
//            //TODO اینو باید بعدا درست کنیم همینجوری نوشتم
//            SelectedoCustomer.Relations.Where(p=>p.Product==SelectedoProduct).ToList();
//        }

//        private bool CanExecuteDelOProduct()
//        {
//            return SelectedoCustomer!=null & SelectedoProduct!=null;
//        }

//        #endregion
//    }
//}