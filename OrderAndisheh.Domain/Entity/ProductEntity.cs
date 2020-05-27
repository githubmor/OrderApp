namespace OrderAndisheh.Domain.Entity
{
    public class ProductEntity
    {
        private KalaEntity _kala;
        private int _tedad;

        public ProductEntity(KalaEntity kala, int tedad)
        {
            _kala = kala;
            _tedad = tedad;
            TedadPallet = kala.getPalletCount(tedad);
            TedadBaste = kala.getBasteCount(tedad);
        }

        public int TedadPallet { get; set; }
        public int TedadBaste { get; set; }

        public int vazn { get { return getVazn(); } }

        private int getVazn()
        {
            return _kala.getVazn(_tedad);
        }
    }
}