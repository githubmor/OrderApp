using System;

namespace OrderAndisheh.Domain.Entity
{
    public class DriverEntity
    {
        public DriverEntity(string name, string mobile, string codeMeli, string pelak)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("نام راننده نمی تواند تهی باشد");
            }
            Name = name;
            Mobile = mobile;
            CodeMeli = codeMeli;
            Pelak = pelak;
        }

        public string Name { get; private set; }
        public string Mobile { get; private set; }
        public string CodeMeli { get; private set; }
        public string Pelak { get; private set; }
    }
}