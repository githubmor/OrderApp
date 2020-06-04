using System;
using System.Collections.Generic;
namespace OrderAndisheh.Domain.Entity
{
    public class ShakhesKalaEntity
    {
        public ShakhesKalaEntity(ErsalKalaEntity ersali,int zaribMasrafDarKhodro,List<AmarTolidEntity> tolidi)
        {
            if (ersali==null)
            {
                throw new ArgumentNullException("ارسالي در شاخص كالا نمي تواند تهي باشد");
            }
            if (zaribMasrafDarKhodro == 0)
            {
                throw new ArgumentNullException("ضريب مصرف كالا در شاخص كالا نبايد صفر باشد");
            }
            if (tolidi.Count == 0)
            {
                throw new ArgumentNullException("توليدي خودرو در شاخص كالا نبايد تهي باشد");
            }
            Ersali = ersali;
            Tolidi = tolidi;
            ZaribMasrafDarKhodro = zaribMasrafDarKhodro;
        }
        public ErsalKalaEntity Ersali { get; private set; }
        public List<AmarTolidEntity> Tolidi { get; private set; }
        public int ZaribMasrafDarKhodro { get; private set; }

        public int getDarsadSahm()
        {
            return 0;
        }
    }
}