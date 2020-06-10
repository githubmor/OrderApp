using System;

namespace OrderAndisheh.Domain.Entity
{
    public class BaseSherkatEntity
    {
        public BaseSherkatEntity(string sherkatName)
        {
            if (string.IsNullOrEmpty(sherkatName))
            {
                throw new ArgumentNullException("نام شركت در شركت نمي تواند تهي باشد", "sherkatName");
            }
            SherkatName = sherkatName;
        }

        public string SherkatName { get; private set; }
    }
}