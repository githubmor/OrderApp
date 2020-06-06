using System;
namespace OrderAndisheh.Domain.Entity
{
    public class BaseCustomerEntity
    {
        public BaseCustomerEntity(string customerName)
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