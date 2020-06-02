using System.Collections.Generic;
using System.Linq;

namespace OrderAndisheh.Domain.Entity
{
    public class OrderEntity : BaseOrderEntity
    {
        public OrderEntity(int tarikh, int version = 0, bool isAccepted = false)
            : base(tarikh, version, isAccepted)
        {
            Cabins = new System.Collections.Generic.List<CabinEntity>();
        }

        public OrderEntity(int tarikh, System.Collections.Generic.List<CabinEntity> cabins,
            int version = 0, bool isAccepted = false)
            : this(tarikh, version, isAccepted)
        {
            Cabins = cabins;
        }

        public System.Collections.Generic.List<CabinEntity> Cabins { get; private set; }

        public void AddCabin(List<CabinEntity> cabins)
        {
            cabins.ForEach(it =>
            {
                var re = HasDuplicateDriver(it);
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

        private CabinEntity HasDuplicateDriver(CabinEntity cabin)
        {
            return Cabins.SingleOrDefault(it => it.Drivername == cabin.Drivername);
        }
    }
}