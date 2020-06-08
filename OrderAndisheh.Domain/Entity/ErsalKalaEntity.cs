using System;
using System.Collections.Generic;

namespace OrderAndisheh.Domain.Entity
{
    public class ErsalKalaEntity : BaseKalaEntity
    {
        public ErsalKalaEntity(string name, string codeAnbar, string faniCode, string codeJense,
            int tedadErsali, int zaribMasrafDarKhodro, List<KhodorEntity> khodors, BaseCustomerEntity customer)
            : base(name, codeAnbar, faniCode, codeJense)
        {
            if (customer == null)
            {
                throw new ArgumentNullException("مشتري در كالاي ارسالي " + name 
                    + " نمي تواند تهي باشد", "customer");
            }
            if (khodors == null || khodors.Count == 0)
            {
                throw new ArgumentNullException("خودرو ها در كالاي ارسالي " + name 
                    + " نمي تواند تهي باشد", "khodors");
            }
            if (zaribMasrafDarKhodro == 0)
            {
                throw new ArgumentNullException("ضريب مصرف در كالاي ارسالي " + name 
                    + " نمي تواند صفر باشد", "zaribMasrafDarKhodro");
            }
            TedadErsali = tedadErsali;
            ZaribMasrafDarKhodro = zaribMasrafDarKhodro;
            Khodors = khodors;
            Customer = customer;
        }

        public int TedadErsali { get; private set; }
        public int ZaribMasrafDarKhodro { get; private set; }
        public List<KhodorEntity> Khodors { get; private set; }
        public BaseCustomerEntity Customer { get; private set; }
    }
}