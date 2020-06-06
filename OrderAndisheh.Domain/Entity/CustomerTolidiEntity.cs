using System;
using System.Collections.Generic;
namespace OrderAndisheh.Domain.Entity
{
    public class CustomerTolidiEntity : BaseCustomerEntity
    {
        public CustomerTolidiEntity(string customerName, List<AmarTolidEntity> amarTolids)
            : base(customerName)
        {
            if (amarTolids.Count==0)
            {
                throw new ArgumentNullException("آمار توليدي در مشتري توليد نمي تواند تهي باشد");
            }
            AmarTolids = amarTolids;
        }
        public List<AmarTolidEntity> AmarTolids { get; private set; }
    }
}