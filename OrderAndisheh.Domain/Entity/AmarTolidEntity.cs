using System;

namespace OrderAndisheh.Domain.Entity
{
    public class AmarTolidEntity:KhodorEntity
    {
        public AmarTolidEntity(string name, CustomerEntity customer, int TedadTolid)
            :base(name,customer)
        {
            this.TedadTolid = TedadTolid;
        }
        public int TedadTolid { get; private set; }
        
    }
}