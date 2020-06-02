using System;

namespace OrderAndisheh.Domain.Entity
{
    public class DestinationEntity
    {
        public DestinationEntity(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("نام مقصد نمیتواند تهی باشد");
            }
            Name = name;
        }

        public string Name { get; private set; }
    }
}