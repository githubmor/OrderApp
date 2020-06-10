using System;
using System.Collections.Generic;

namespace OrderAndisheh.Domain.Entity
{
    public class TahvilOrderEntity : BaseOrderEntity
    {
        public TahvilOrderEntity(int tarikh, List<TahvilFroshEntity> tahvilFroshs)
            : base(tarikh)
        {
            if (tahvilFroshs == null || tahvilFroshs.Count == 0)
            {
                throw new ArgumentNullException("تحويل فروش به تاريخ " + Tarikh + " نمي تواند تهي باشد", "tahvilFroshs");
            }
            TahvilFroshs = tahvilFroshs;
        }

        public List<TahvilFroshEntity> TahvilFroshs { get; private set; }
    }
}