using System;
using System.Collections.Generic;

namespace OrderAndisheh.Domain.Entity
{
    public class TolidMahaneEntity
    {
        public TolidMahaneEntity(int mah, List<AmarTolidEntity> amarTolids)
        {
            if (mah<1||mah>13)
            {
                throw new ArgumentNullException("ماه توليد در توليد ماهانه نمي تواند خارج از محدود 1 -12  باشد");
            }
            if (amarTolids.Count==0)
            {
                throw new ArgumentNullException("آمار توليد در توليد ماهانه نمي تواند تهي باشد");
            }
            Mah = mah;
            AmarTolids = amarTolids;
        }
        public int Mah { get; private set; }
        public List<AmarTolidEntity> AmarTolids { get; private set; }
    }
}