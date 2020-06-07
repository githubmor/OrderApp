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

            var ErsaliSherkat = getErsaliSherkatBySherkat(sherkat);

            var CustomerTolid = getCustormerTolidiByCustomer(customer);

            var KalaErsali = ErsaliSherkat.getKalaErsaliByCustomer(customer);

            return getShakhesAvreg(getShakhesKala(CustomerTolid, KalaErsali));
        }

        private static int getShakhesAvreg(List<ShakhesKalaEntity> shakhesKala)
        {
            return (int)shakhesKala.Average(p => p.getDarsadSahm());
        }

        private static List<ShakhesKalaEntity> getShakhesKala(CustomerTolidiEntity selectedCustomer, List<ErsalKalaEntity> kalaha)
        {
            List<ShakhesKalaEntity> shakhesKala = new List<ShakhesKalaEntity>();

            kalaha.ToList().ForEach(kala =>
            {
                shakhesKala.Add(new ShakhesKalaEntity(kala, selectedCustomer.getAmarTolidi(kala.Khodors)));
            });
            return shakhesKala;
        }

        private CustomerTolidiEntity getCustormerTolidiByCustomer(BaseCustomerEntity customer)
        {
            return CustomerTolidi.Single(p => p.CustomerName == customer.CustomerName);
        }

        private ErsaliSherkatEntity getErsaliSherkatBySherkat(BaseSherkatEntity sherkat)
        {
            return ErsaliSherkat.Single(p => p.SherkatName == sherkat.SherkatName);
        }
        
    }


}