using System.Collections.Generic;

namespace OrderAndisheh.Domain.Entity
{
    public class TahvilOrderEntity : BaseOrderEntity
    {
        public TahvilOrderEntity(int tarikh, int version = 0, bool isAccepted = false)
            : base(tarikh, version, isAccepted)
        {
            TahvilFroshs = new System.Collections.Generic.List<TahvilFroshEntity>();
        }

        public List<TahvilFroshEntity> TahvilFroshs { get; set; }
    }
}