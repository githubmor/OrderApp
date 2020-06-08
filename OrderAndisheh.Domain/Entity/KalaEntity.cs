using System;

namespace OrderAndisheh.Domain.Entity
{
    public class KalaEntity : BaseKalaEntity
    {
        public KalaEntity(string name, string codeAnbar, string faniCode, string codeJense,
           PalletEntity pallet, int tedadDarPallet, int tedadDarBaste, int weighWithPallet)
            : base(name, codeAnbar, faniCode, codeJense)
        {
            if (tedadDarPallet <= 0 )
            {
                throw new ArgumentNullException("تعداد در پالت در كالاي " + name
                    + " نبايد صفر باشد", "tedadDarPallet");
            }
            if (weighWithPallet <= 0)
            {
                throw new ArgumentNullException("وزن با پالت در كالاي " + name
                    + " نمي تواند صفر باشد", "weighWithPallet");
            }
            if (pallet == null)
            {
                throw new NullReferenceException("پالت در كالاي  " + name + " نمي تواند تهي باشد");
            }
            TedadDarPallet = tedadDarPallet;
            TedadDarBaste = tedadDarBaste;
            WeighWithPallet = weighWithPallet;
            Pallet = pallet;
        }

        public PalletEntity Pallet { get; private set; }
        public int TedadDarPallet { get; private set; }
        public int TedadDarBaste { get; private set; }
        public int WeighWithPallet { get; private set; }

        public int getPalletVazn()
        {
            return Pallet.Vazn;
        }
        public bool IsFeleziPallet()
        {
            return Pallet.IsFelezi;
        }

        public int getVaznKhales()
        {
            return WeighWithPallet - Pallet.Vazn;
        }

        public float getOneProductVazn()
        {
            return getVaznKhales() / (float)TedadDarPallet;
        }
    }
}