using System;

namespace OrderAndisheh.Domain.Entity
{
    public class ProductEntity
    {
        public ProductEntity(KalaEntity kala, int tedad)
        {
            if (kala == null)
            {
                throw new NullReferenceException("کالا در ايتم كالا نمی تواند تهی باشد");
            }
            Kala = kala;
            Tedad = tedad;
            TedadPallet = getDefaultPalletCount();
            TedadBaste = getBasteCount();
        }

        private int _tedad;

        public int Tedad
        {
            get { return _tedad; }
            set
            {
                _tedad = value;
                TedadPallet = getDefaultPalletCount();
                TedadBaste = getBasteCount();
            }
        }

        public KalaEntity Kala { get; private set; }

        public string TedadBaste { get; private set; }
        public int TedadPallet { get; set; }

        private int getDefaultPalletCount()
        {
            return PalletCalCulate();
        }

        private int PalletCalCulate()
        {
            return getPalleting() + getPalletingReminderAfterPalleting();
        }

        private int getPalletingReminderAfterPalleting()
        {
            return getCanBeOnePallet(getReminderAfterPalleting());
        }

        private int getReminderAfterPalleting()
        {
            return Tedad % Kala.TedadDarPallet;
        }

        private int getPalleting()
        {
            return Tedad / Kala.TedadDarPallet;
        }

        private int getCanBeOnePallet(int tedad)
        {
            if (tedad > getTedadLimitForPalleting())
                return 1;
            else
                return 0;
        }

        private int getTedadLimitForPalleting()
        {
            return Kala.TedadDarPallet / 2;
        }

        private string getBasteCount()
        {
            return KartonCalCulate();
        }

        private string KartonCalCulate()
        {
            if (IsBasteii())
            {
                return getBastebandi().ToString() +
                    (getReminderAfterBasteBandi() > 0 ? "[" + getReminderAfterBasteBandi() + "]" : "");
            }
            else
            {
                return "";
            }
        }

        private int getReminderAfterBasteBandi()
        {
            return Tedad % Kala.TedadDarBaste;
        }

        private int getBastebandi()
        {
            return Tedad / Kala.TedadDarBaste;
        }

        private bool IsBasteii()
        {
            return Kala.TedadDarBaste > 0;
        }

        public int getVazn()
        {
            return VaznCalCulate();
        }

        private int VaznCalCulate()
        {
            return getVaznKhalesKala() + getVaznPalletha();
        }

        private int getVaznPalletha()
        {
            return (int)(TedadPallet * Kala.getPalletVazn());
        }

        private int getVaznKhalesKala()
        {
            return (int)(Tedad * Kala.getOneProductVazn());
        }
    }
}