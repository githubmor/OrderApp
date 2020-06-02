using System;

namespace OrderAndisheh.Domain.Entity
{
    public class ProductEntity
    {
        public ProductEntity(KalaEntity kala, int tedad)
        {
            if (kala == null)
            {
                throw new NullReferenceException("کالا در سفارش نمی تواند تهی باشد");
            }
            Kala = kala;
            Tedad = tedad;
            TedadPallet = getPalletCount();
            TedadBaste = getBasteCount();
        }

        private int _tedad;

        public int Tedad
        {
            get { return _tedad; }
            set
            {
                _tedad = value;
                TedadPallet = getPalletCount();
                TedadBaste = getBasteCount();
            }
        }

        public KalaEntity Kala { get; private set; }

        public string TedadBaste { get; private set; }
        public int TedadPallet { get; set; }

        public int vazn { get { return getVazn(); } }

        private int getPalletCount()
        {
            return PalletCalCulate();
        }

        private int PalletCalCulate()
        {
            var reminder = getTedadReminderAfterPalleting();
            return (int)getPalletingFloat(Tedad) + getReminderCanBeOnePallet(getPalletingFloat(reminder));
        }

        private int getTedadReminderAfterPalleting()
        {
            return getReminder(Tedad, Kala.TedadDarPallet);
        }

        private float getPalletingFloat(int num)
        {
            return getDivision(num, Kala.TedadDarPallet);
        }

        private int getReminderCanBeOnePallet(float num)
        {
            if (num > 0.5F)
                return 1;
            else
                return 0;
        }

        private string getBasteCount()
        {
            return KartonCalCulate();
        }

        private string KartonCalCulate()
        {
            if (IsBasteii())
            {
                return getDivisionTedadToTedadDarBaste().ToString() +
                    (getReminderToTedadDarBaste() > 0 ? "[" + getReminderToTedadDarBaste() + "]" : "");
            }
            else
            {
                return "";
            }
        }

        private int getReminderToTedadDarBaste()
        {
            return getReminder(Tedad, Kala.TedadDarBaste);
        }

        private int getReminder(int num1, int num2)
        {
            return num1 % num2;
        }

        private int getDivisionTedadToTedadDarBaste()
        {
            return (int)getDivision(Tedad, Kala.TedadDarBaste);
        }

        private float getDivision(int num1, int num2)
        {
            return num1 / (float)num2;
        }

        private bool IsBasteii()
        {
            return Kala.TedadDarBaste > 0;
        }

        private int getVazn()
        {
            return VaznCalCulate();
        }

        private int VaznCalCulate()
        {
            if (Kala.WeighWithPallet != null && Kala.WeighWithPallet > 0)
            {
                if (Kala.TedadDarPallet > 0)
                {
                    double OneProductWeight;
                    int p = (int)Kala.WeighWithPallet - (int)Kala.Pallet.Vazn;
                    OneProductWeight = (double)(p / (double)Kala.TedadDarPallet);

                    return (int)(Tedad * OneProductWeight) + (int)(TedadPallet * Kala.Pallet.Vazn);
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
    }
}