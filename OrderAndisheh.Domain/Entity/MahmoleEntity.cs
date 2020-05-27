using System.Linq;

namespace OrderAndisheh.Domain.Entity
{
    public class MahmoleEntity
    {
        public MahmoleEntity()
        {
            Product = new System.Collections.Generic.List<ProductEntity>();
        }
        public System.Collections.Generic.List<ProductEntity> Product { get; set; }
        public DestinationEntity Destination { get; set; }
        public int Vazn { get { return getAllVazn(); } }

        private int getAllVazn()
        {
            return Product.Sum(it => it.vazn);
        }
    }
}