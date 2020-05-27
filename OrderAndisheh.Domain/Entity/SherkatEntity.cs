using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
