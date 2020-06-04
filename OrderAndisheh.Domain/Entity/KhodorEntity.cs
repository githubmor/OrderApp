using System;
namespace OrderAndisheh.Domain.Entity
{
    public class KhodorEntity
    {
        public KhodorEntity(string name, CustomerEntity customer)
        {
            if (string.IsNullOrEmpty(name)||customer==null)
            {
                throw new ArgumentNullException("نام خودرو يا مشتري تهي مي باشد");
            }
            Name = name;
            Customer = customer;
        }
        public string Name { get; private set; }
        public CustomerEntity Customer { get; private set; }
    }
}