using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderAndisheh.Domain.Entity
{
    public class ShakhesKalaEntity
    {
        public ShakhesKalaEntity(ErsalKalaEntity ersalKala, List<AmarTolidKhodroEntity> amarTolids)
        {
            if (amarTolids == null || amarTolids.Count == 0)
            {
                throw new ArgumentNullException("آمار توليد در شاخص كالا نمي تواند تهي باشد");
            }
            if (ersalKala == null)
            {
                throw new ArgumentNullException("كالاي ارسالي در شاخص كالا نمي تواند تهي باشد");
            }
            amarTolids.ForEach(it =>
            {
                var amartoliNotUsed = ersalKala.Khodors.Exists(p => p.Name != it.Name);
                if (amartoliNotUsed)
                {
                    throw new IndexOutOfRangeException("آمار توليد خودرو " + it.Name + " در خودرهاي كالاي ارسالي " + ersalKala.Name + " وجود ندارد");
                }
            });
            ErsalKala = ersalKala;
            AmarTolids = amarTolids;
        }

        public ErsalKalaEntity ErsalKala { get; private set; }
        public List<AmarTolidKhodroEntity> AmarTolids { get; private set; }

        public int getKalaDarsadSahm()
        {
            var sum = AmarTolids.Sum(p => p.TedadTolid);

            if (sum == 0)
                return 0;
            else
                return (ErsalKala.getTedadInKhodro() * 100) / sum;
        }
    }
}