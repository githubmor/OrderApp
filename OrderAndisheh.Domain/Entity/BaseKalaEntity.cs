using System;

namespace OrderAndisheh.Domain.Entity
{
    public class BaseKalaEntity
    {
        public BaseKalaEntity(string name, string codeAnbar, string faniCode, string codeJense)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(codeAnbar))
            {
                throw new ArgumentNullException("نام يا كد انبار كالا نباید تهي باشد");
            }
            Name = name;
            CodeAnbar = codeAnbar;
            FaniCode = faniCode;
            CodeJense = codeJense;
        }

        public string Name { get; private set; }
        public string CodeAnbar { get; private set; }
        public string FaniCode { get; private set; }
        public string CodeJense { get; private set; }
    }
}