using System;
using System.Collections.Generic;

namespace OrderAndisheh.Domain.Entity
{
    public class TahvilFroshEntity
    {
        public TahvilFroshEntity(List<ProductEntity> products, int tahvilNumber)
        {
            if (products.Count==0)
            {
                throw new ArgumentNullException("كالاهاي تحويل فروش نمي تواند تهي باشد");
            }
            if (tahvilNumber<1)
            {
                throw new ArgumentNullException("شماره تحويل فروش نميتواند صفر باشد");
            }
            Products = products;
            TahvilNumber = tahvilNumber;
        }
        public List<ProductEntity> Products { get;private set; }
        public int TahvilNumber { get; private set; }
    }
}