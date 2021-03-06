﻿using System;

namespace OrderAndisheh.Domain.Entity
{
    public class AmarTolidKhodroEntity : BaseKhodorEntity
    {
        public AmarTolidKhodroEntity(string name, int tedadTolid)
            : base(name)
        {
            if (tedadTolid == 0)
            {
                throw new ArgumentException("تعداد توليد در آمار توليد " + name + " نمي تواند صفر باشد ", "tedadTolid");
            }
            this.TedadTolid = tedadTolid;
        }

        public int TedadTolid { get; private set; }
    }
}