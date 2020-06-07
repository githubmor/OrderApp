using System;

namespace OrderAndisheh.Domain.Entity
{
    public class DestinationEntity
    {
        public DestinationEntity(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("نام مقصد در مقصد نمیتواند تهی باشد", "name");
            }
            Name = name;
        }

        public string Name { get; private set; }
    }
}