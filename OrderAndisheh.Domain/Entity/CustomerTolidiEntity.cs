using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderAndisheh.Domain.Entity
{
    public class CustomerTolidiEntity : BaseCustomerEntity
    {
        public CustomerTolidiEntity(string customerName, List<AmarTolidKhodroEntity> amarTolids)
            : base(customerName)
        {
            if (amarTolids.Count == 0)
            {
                throw new ArgumentNullException("آمار توليدي در مشتري توليد " +
                    customerName + " نمي تواند تهي باشد", "amarTolids");
            }
            AmarTolids = amarTolids;
        }

        public List<AmarTolidKhodroEntity> AmarTolids { get; private set; }

        public List<AmarTolidKhodroEntity> getAmarTolidi(List<BaseKhodorEntity> khodors)
        {
            var result = new List<AmarTolidKhodroEntity>();
            if (khodors != null)
            {
                khodors.ForEach(i =>
                {
                    var re = getAmarTolidThisKhodroOrNull(i.Name);
                    if (re != null)
                    {
                        result.Add(re);
                    }
                });
            }

            return result;
        }

        private AmarTolidKhodroEntity getAmarTolidThisKhodroOrNull(string name)
        {
            return AmarTolids.SingleOrDefault(u => u.Name == name);
        }
    }
}