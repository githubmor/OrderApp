using System;

namespace OrderAndisheh.Domain.Entity
{
    public class BaseCustomerEntity
    {
        public BaseCustomerEntity(string customerName)
        {
            if (string.IsNullOrEmpty(customerName))
            {
                throw new ArgumentNullException("نام مشتري در مشتري نمي تواند تهي باشد", "customerName");
            }
            CustomerName = customerName;
        }

        public string CustomerName { get; private set; }
    }
}