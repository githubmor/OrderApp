using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderAndisheh.Domain.Entity
{
    public class ShakhesEntity
    {
        public ShakhesEntity(List<ErsaliSherkatEntity> ersaliSherkat, List<CustomerTolidiEntity> customerTolidi)
        {
            if (ersaliSherkat.Count == 0)
            {
                throw new ArgumentNullException("ارسالي شركت در شاخص كالا نمي تواند تهي باشد", "ersaliSherkat");
            }
            if (customerTolidi.Count == 0)
            {
                throw new ArgumentNullException("توليدي مشتري در شاخص كالا نبايد صفر باشد", "customerTolidi");
            }

            ErsaliSherkat = ersaliSherkat;
            CustomerTolidi = customerTolidi;
        }

        public List<ErsaliSherkatEntity> ErsaliSherkat { get; private set; }
        public List<CustomerTolidiEntity> CustomerTolidi { get; private set; }

        public Dictionary<Dictionary<BaseSherkatEntity, BaseCustomerEntity>, int> getDarsadSahmDic()
        {
            var re = new Dictionary<Dictionary<BaseSherkatEntity, BaseCustomerEntity>, int>();
            ErsaliSherkat.ForEach(sherkat =>
            {
                CustomerTolidi.ForEach(customer =>
                {
                    var key = new Dictionary<BaseSherkatEntity, BaseCustomerEntity>();
                    key.Add(sherkat, customer);
                    re.Add(key, getDarsadSahm(sherkat, customer));
                });
            });

            return re;
        }

        public int getDarsadSahm(BaseSherkatEntity sherkat, BaseCustomerEntity customer)
        {
            var ErsaliSherkat = getErsaliSherkatBySherkat(sherkat);

            var CustomerTolid = getCustormerTolidiByCustomer(customer);

            var KalaErsali = ErsaliSherkat.getKalaErsaliToCustomer(customer);

            return getShakhesAvreg(getShakhesKala(CustomerTolid, KalaErsali));
        }

        private int getShakhesAvreg(List<ShakhesKalaEntity> shakhesKala)
        {
            return (int)shakhesKala.Average(p => p.getKalaDarsadSahm());
        }

        private List<ShakhesKalaEntity> getShakhesKala(CustomerTolidiEntity selectedCustomer, List<ErsalKalaEntity> kalaha)
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