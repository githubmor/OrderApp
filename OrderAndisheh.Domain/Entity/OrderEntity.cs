using System.Collections.Generic;
using System.Linq;

namespace OrderAndisheh.Domain.Entity
{
    public class OrderEntity : BaseOrderEntity
    {
        public OrderEntity(int tarikh, int version = 0, bool isAccepted = false)
            : base(tarikh, version, isAccepted)
        {
            Cabins = new List<CabinEntity>();
        }

        public OrderEntity(int tarikh, List<CabinEntity> cabins,
            int version = 0, bool isAccepted = false)
            : this(tarikh, version, isAccepted)
        {
            Cabins = cabins;
        }

        public List<CabinEntity> Cabins { get; private set; }

        public void AddCabin(List<CabinEntity> cabins)
        {
            if (cabins != null)
            {
                cabins.ForEach(it =>
                {
                    var re = HasDuplicateDriverOrNull(it);
                    if (re != null)
                    {
                        re.AddMahmole(it.Mahmoles);
                    }
                    else
                    {
                        Cabins.Add(it);
                    }
                });
            }
        }

        private CabinEntity HasDuplicateDriverOrNull(CabinEntity cabin)
        {
            return Cabins.SingleOrDefault(it => it.Drivername == cabin.Drivername);
        }
    }
}