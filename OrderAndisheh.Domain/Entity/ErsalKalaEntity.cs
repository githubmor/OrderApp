using System.Collections.Generic;

namespace OrderAndisheh.Domain.Entity
{
    public class ErsalKalaEntity : BaseKalaEntity
    {
        public ErsalKalaEntity()
        {
            Khodros = new List<KhodorEntity>();
        }

        public List<KhodorEntity> Khodros { get; set; }
    }
}