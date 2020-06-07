using System;
using System.Linq;
using System.Collections.Generic;
namespace OrderAndisheh.Domain.Entity
{
    public class CustomerTolidiEntity : BaseCustomerEntity
    {
        public CustomerTolidiEntity(string customerName, List<AmarTolidKhodroEntity> amarTolids)
            : base(customerName)
        {
            if (amarTolids.Count==0)
            {
                throw new ArgumentNullException("آمار توليدي در مشتري توليد نمي تواند تهي باشد");
            }
            AmarTolids = amarTolids;
        }
        public List<AmarTolidKhodroEntity> AmarTolids { get; private set; }

        public List<AmarTolidKhodroEntity> getAmarTolidi(ErsalKalaEntity kala){
            List<AmarTolidKhodroEntity> selectedAmarTolis = new List<AmarTolidKhodroEntity>();
            kala.Khodors.ForEach(i =>
            {
                selectedAmarTolis.Add(AmarTolids.Single(u => u.Name == i.Name));
            });

            return selectedAmarTolis;
        }
    }
}