using System;

namespace OrderAndisheh.Domain.Entity
{
    public class KalaEntity : BaseKalaEntity
    {
        public KalaEntity(string name, string codeAnbar, string faniCode, string codeJense,
           PalletEntity pallet, int tedadDarPallet, int tedadDarBaste, int weighWithPallet)
            : base(name, codeAnbar, faniCode, codeJense)
        {
            if (tedadDarPallet <= 0 || weighWithPallet <= 0)
            {
                throw new ArgumentNullException("كالا " + name + " : تعداد در پالت يا وزن كالا تعيين نشده");
            }
            if (pallet == null)
            {
                throw new NullReferenceException("كالا " + name + " : نوع پالت مشخص نشده");
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
    }
}