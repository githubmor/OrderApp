using System.Collections.Generic;

namespace OrderAndisheh.Domain.Entity
{
    public class TahvilOrderEntity : BaseOrderEntity
    {
        public TahvilOrderEntity(int tarikh)
            : base(tarikh)
        {
            TahvilFroshs = new System.Collections.Generic.List<TahvilFroshEntity>();
        }
        public TahvilOrderEntity(int tarikh,List<TahvilFroshEntity> tahvilFroshs)
            : base(tarikh)
        {
            TahvilFroshs = tahvilFroshs;
        }

        public List<TahvilFroshEntity> TahvilFroshs { get; set; }
    }
}