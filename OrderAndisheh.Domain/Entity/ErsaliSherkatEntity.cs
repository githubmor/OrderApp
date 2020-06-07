using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderAndisheh.Domain.Entity
{
    public class ErsaliSherkatEntity : BaseSherkatEntity
    {
        public ErsaliSherkatEntity(string sherkatName, List<ErsalKalaEntity> ersaliKala)
            : base(sherkatName)
        {
            if (ersaliKala.Count == 0)
            {
                throw new ArgumentNullException
                    ("كالاهاي ارسالي در ارسالي شركت نمي تواند تهي باشد", "ersaliKala");
            }
            ErsaliKala = ersaliKala;
        }

        public List<ErsalKalaEntity> ErsaliKala { get; private set; }

        public List<ErsalKalaEntity> getKalaErsaliByCustomer(BaseCustomerEntity customer)
        {
            if (customer != null)
            {
                return ErsaliKala.Where(p => p.Customer.CustomerName == customer.CustomerName).ToList();
            }
            else
                return new List<ErsalKalaEntity>();
        }
    }
}