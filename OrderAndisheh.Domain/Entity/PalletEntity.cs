using System;

namespace OrderAndisheh.Domain.Entity
{
    public class PalletEntity
    {
        public PalletEntity(string name, int vazn, bool isFelezi = false)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("نام پالت در پالت نمی تواند تهی باشد", "name");
            }
            if (vazn <= 0)
            {
                throw new ArgumentNullException("وزن پالت در پالت " + name + " نمی تواند صفر باشد", "vazn");
            }
            Name = name;
            Vazn = vazn;
            IsFelezi = isFelezi;
        }

        public string Name { get; private set; }
        public int Vazn { get; private set; }
        public bool IsFelezi { get; private set; }
    }
}