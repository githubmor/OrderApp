using System;

namespace OrderAndisheh.Domain.Entity
{
    public class AmarTolidEntity:KhodorEntity
    {
        public AmarTolidEntity(string name, int TedadTolid)
            :base(name)
        {
            this.TedadTolid = TedadTolid;
        }
        public int TedadTolid { get; private set; }
        
    }
}