using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAndisheh.Domain.Entity
{
    public class ShakhesKalaEntity
    {
        public ShakhesKalaEntity(ErsalKalaEntity ersalKala, List<AmarTolidEntity> amarTolids)
        {
            if (amarTolids.Count == 0)
            {
                throw new ArgumentNullException("آمار توليد در شاخص كالا نمي تواند تهي باشد");
            }
            if (ersalKala == null)
            {
                throw new ArgumentNullException("كالاي ارسالي در شاخص كالا نمي تواند تهي باشد");
            }
            ErsalKala = ersalKala;
            AmarTolids = amarTolids;
        }
        public ErsalKalaEntity ErsalKala { get; private set; }
        public List<AmarTolidEntity> AmarTolids { get; private set; }

        public int getDarsadSahm()
        {
            return ((ErsalKala.TedadErsali / ErsalKala.ZaribMasrafDarKhodro) * 100) / AmarTolids.Sum(p => p.TedadTolid);
        }
    }
}
