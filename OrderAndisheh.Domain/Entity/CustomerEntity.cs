using System;
namespace OrderAndisheh.Domain.Entity
{
    public class CustomerEntity
    {
        public CustomerEntity(string customerName)
        {
            if (string.IsNullOrEmpty(customerName))
            {
                throw new ArgumentNullException("نام مشتري نمي تواند تهي باشد");
            }
            CustomerName = customerName;
        }
        public string CustomerName { get; private set; }
    }
}