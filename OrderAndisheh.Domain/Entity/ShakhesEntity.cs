using System;
using System.Collections.Generic;

namespace OrderAndisheh.Domain.Entity
{
    public class ShakhesEntity
    {
        public List<TolidEntity> Tolidi { get; set; }
        public List<ErsalEntity> Ersali { get; set; }

        public int ErsaliSum { get { return getErsaliSum(); } }

        private int getErsaliSum()
        {
            throw new NotImplementedException();
        }

        public int ErsalPercent { get { return getErsalPercent(); } }

        private int getErsalPercent()
        {
            throw new NotImplementedException();
        }
    }
}