using System;

namespace OrderAndisheh.Domain.Entity
{
    public class PalletEntity
    {
        public PalletEntity(string name, int vazn)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("نام پالت نمی تواند تهی باشد");
            }
            if (vazn <= 0)
            {
                throw new ArgumentNullException("وزن پالت نمی تواند صفر باشد");
            }
            Name = name;
            Vazn = vazn;
        }

        public string Name { get; private set; }
        public int Vazn { get; private set; }
    }
}