using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAndisheh.Domain.Entity
{
    public class ErsalKalaEntity :BaseKalaEntity
    {
        public ErsalKalaEntity()
        {
            Khodros = new List<KhodorEntity>();
        }
        public List<KhodorEntity> Khodros { get; set; }
    }
}
