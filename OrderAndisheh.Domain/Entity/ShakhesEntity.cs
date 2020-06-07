using System;
using System.Linq;
using System.Collections.Generic;
namespace OrderAndisheh.Domain.Entity
{
    public class ShakhesEntity
    {
        public ShakhesEntity(List<ErsaliSherkatEntity> ersaliSherkat, List<CustomerTolidiEntity> customerTolidi)
        {
            if (ersaliSherkat.Count == 0)
            {
                throw new ArgumentNullException("ارسالي شركت در شاخص كالا نمي تواند تهي باشد");
            }
            if (customerTolidi.Count == 0)
            {
                throw new ArgumentNullException("توليدي مشتري در شاخص كالا نبايد صفر باشد");
            }

            ErsaliSherkat = ersaliSherkat;
            CustomerTolidi = customerTolidi;
        }
        public List<ErsaliSherkatEntity> ErsaliSherkat { get; private set; }
        public List<CustomerTolidiEntity> CustomerTolidi { get; private set; }

        public int getDarsadSahm(BaseSherkatEntity sherkat,BaseCustomerEntity customer){

            var selectedSherkat = ErsaliSherkat.Single(p => p.SherkatName == sherkat.SherkatName);

            var kalaha = selectedSherkat.ErsaliKala.Where(p => p.Customer.CustomerName == customer.CustomerName);

            var selectedCustomer = CustomerTolidi.Single(p=>p.CustomerName==customer.CustomerName);

            List<ShakhesKalaEntity> shakhesKala = new List<ShakhesKalaEntity>();

            kalaha.ToList().ForEach(kala =>
            {
                shakhesKala.Add(new ShakhesKalaEntity(kala, selectedCustomer.getAmarTolidi(kala)));
            });

            return (int) shakhesKala.Average(p=>p.getDarsadSahm());
        }
        
    }


}