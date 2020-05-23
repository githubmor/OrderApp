using System.Collections.Generic;

namespace OrderAndisheh.Domain.Entity
{
    public class TahvilFroshEntity
    {
        public List<ProductEntity> Products { get; set; }
        public int TahvilNumber { get; set; }
    }
}