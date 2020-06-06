using System;
using System.Linq;
using System.Collections.Generic;

namespace OrderAndisheh.Domain.Entity
{
    public class ErsalKalaEntity : BaseKalaEntity
    {
        public ErsalKalaEntity(string name, string codeAnbar, string faniCode, string codeJense,
            int tedadErsali, int zaribMasrafDarKhodro, List<KhodorEntity> khodors,BaseCustomerEntity customer)
            : base(name, codeAnbar, faniCode, codeJense)
        {
            if (customer == null)
            {
                throw new ArgumentNullException("مشتري كالاي ارسالي نمي تواند تهي باشد");
            }
            if (khodors.Count == 0)
            {
                throw new ArgumentNullException("خودرو هاي كالاي ارسالي نمي تواند تهي باشد");
            }
            if (zaribMasrafDarKhodro == 0)
            {
                throw new ArgumentNullException("ضريب مصرف كالاي ارسالي نمي تواند صفر باشد");
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

        public bool IsUsedInKhodro(KhodorEntity khodro)
        {
            return Khodors.Any(p => p.Name == khodro.Name);
        }
    }
}