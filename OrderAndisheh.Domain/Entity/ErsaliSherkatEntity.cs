using System;
using System.Collections.Generic;

namespace OrderAndisheh.Domain.Entity
{
    public class ErsaliSherkatEntity :BaseSherkatEntity
    {
        public ErsaliSherkatEntity(string sherkatName, List<ErsalKalaEntity> ersaliKala):base(sherkatName)
        {
            if (ersaliKala.Count == 0)
            {
                throw new ArgumentNullException("كالاهاي ارسالي نمي تواند تهي باشد");
            }
            ErsaliKala = ersaliKala;
        }

        public List<ErsalKalaEntity> ErsaliKala { get; private set; }
    }
}