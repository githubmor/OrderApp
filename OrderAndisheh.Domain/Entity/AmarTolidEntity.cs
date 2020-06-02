using System;

namespace OrderAndisheh.Domain.Entity
{
    public class AmarTolidEntity
    {
        public AmarTolidEntity(KhodorEntity Khodor, int TedadTolid)
        {
            if (Khodor == null)
            {
                throw new NullReferenceException();
            }
            this._Khodor = Khodor;
            this._TedadTolid = TedadTolid;
        }

        private KhodorEntity _Khodor;

        public KhodorEntity Khodor
        {
            get { return _Khodor; }
        }

        private int _TedadTolid;

        public int TedadTolid
        {
            get { return _TedadTolid; }
        }
    }
}