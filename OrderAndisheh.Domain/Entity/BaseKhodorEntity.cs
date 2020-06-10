using System;

namespace OrderAndisheh.Domain.Entity
{
    public class BaseKhodorEntity
    {
        public BaseKhodorEntity(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("نام خودر در خودرو نمي تواند تهي باشد", "name");
            }
            Name = name;
        }

        public string Name { get; private set; }
    }
}