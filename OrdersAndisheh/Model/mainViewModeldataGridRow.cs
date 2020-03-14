using Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersAndisheh.Model
{
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
                Tedad>0 & PalletCount>0 & TahvilFrosh>0 ;
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
