namespace OrderAndisheh.Domain.Entity
{
    public class KalaEntity : BaseKalaEntity
    {
        public int TedadDarPallet { get; set; }
        public int TedadDarBaste { get; set; }
        public string CodeJense { get; set; }
        public int WeighWithPallet { get; set; }

        public int getPalletCount(int tedad)
        {
            //بايد تعداد كمتر از يك حدي را يك پالت حساب كند
            return tedad / TedadDarPallet;
        }

        public int getBasteCount(int tedad)
        {
            // بايد در صورتي تعداد بسته بدهد كه تعداد از تعداد بچ كمتر باشد و بسته اي هم باشد
            return tedad / TedadDarBaste;
        }

        public int getVazn(int _tedad)
        {
            return 0;
        }
    }
}