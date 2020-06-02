using System.Collections.Generic;

namespace OrderAndisheh.Domain.Entity
{
    public class ErsalKalaEntity : BaseKalaEntity
    {
        public ErsalKalaEntity(string name, string codeAnbar, string faniCode, string codeJense)
            : base(name, codeAnbar, faniCode, codeJense)
        {
            Khodros = new List<KhodorEntity>();
        }

        public List<KhodorEntity> Khodros { get; set; }
    }
}