using System;
namespace OrderAndisheh.Domain.Entity
{
    public class KhodorEntity
    {
        public KhodorEntity(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("نام خودر نمي تواند تهي باشد");
            }
            Name = name;
        }
        public string Name { get; private set; }
    }
}