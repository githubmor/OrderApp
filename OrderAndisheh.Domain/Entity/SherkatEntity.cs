using System.Collections.Generic;

namespace OrderAndisheh.Domain.Entity
{
    public class SherkatEntity
    {
        public SherkatEntity()
        {
            Ersali = new List<ErsalEntity>();
        }

        public string SherkatName { get; set; }
        public List<ErsalEntity> Ersali { get; set; }
    }
}