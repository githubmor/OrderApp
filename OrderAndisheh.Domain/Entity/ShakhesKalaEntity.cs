using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAndisheh.Domain.Entity
{
    public class ShakhesKalaEntity
    {
        public ShakhesKalaEntity(ErsalKalaEntity ersalKala, List<AmarTolidKhodroEntity> amarTolids)
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
        public List<AmarTolidKhodroEntity> AmarTolids { get; private set; }

        public int getDarsadSahm()
        {
            var sum = AmarTolids.Sum(p => p.TedadTolid);
            if (sum == 0)
                return 0;
            else
            return ((ErsalKala.TedadErsali / ErsalKala.ZaribMasrafDarKhodro) * 100) / sum;
        }
    }
}
