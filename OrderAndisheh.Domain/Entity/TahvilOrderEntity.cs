using System.Collections.Generic;

namespace OrderAndisheh.Domain.Entity
{
    public class TahvilOrderEntity : BaseOrderEntity
    {
        public List<TahvilFroshEntity> TahvilFroshs { get; set; }
    }
}