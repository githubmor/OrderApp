using System;
using System.Collections.Generic;

namespace OrderAndisheh.Domain.Entity
{
    public class ErsalKalaEntity : BaseKalaEntity
    {
        public ErsalKalaEntity(string name, string codeAnbar, string faniCode, string codeJense,
            SherkatEntity sherkat,int tedadErsali)
            : base(name, codeAnbar, faniCode, codeJense)
        {
            if (sherkat==null)
            {
                throw new ArgumentNullException("شركت در كالاي ارسالي نميتواند تهي باشد");
            }
            Sherkat = sherkat;
            TedadErsali = tedadErsali;
        }
        public int TedadErsali { get; private set; }
        public SherkatEntity Sherkat { get; private set; }
    }
}