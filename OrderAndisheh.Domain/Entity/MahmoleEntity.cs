using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderAndisheh.Domain.Entity
{
    public class MahmoleEntity
    {
        public MahmoleEntity()
        {
            Products = new System.Collections.Generic.List<ProductEntity>();
        }

        public MahmoleEntity(DestinationEntity destination)
            : this()
        {
            Destination = destination;
        }

        public MahmoleEntity(DestinationEntity destination, System.Collections.Generic.List<ProductEntity> product)
            : this(destination)
        {
            Products = product;
        }

        public MahmoleEntity(List<ProductEntity> product)
            : this()
        {
            Products = product;
        }

        public System.Collections.Generic.List<ProductEntity> Products { get; private set; }

        public void AddProduct(System.Collections.Generic.List<ProductEntity> product)
        {
            var re = new List<ProductEntity>();
            product.ForEach(it =>
            {
                if (HasDuplicateKala(it))
                {
                    throw new ArgumentException("آیتم " + it.Kala.Name + " در محموله موجود است و امکان افزودن کالای تکراری وجود ندارد");
                }
                else
                {
                    re.Add(it);
                }
            });
            Products.AddRange(re);
        }

        private bool HasDuplicateKala(ProductEntity product)
        {
            return Products.Any(it => it.Kala.CodeAnbar == product.Kala.CodeAnbar);
        }

        public DestinationEntity Destination { get; set; }

        public string DestinationName { get { return Destination != null ? Destination.Name : ""; } }
        public int VaznMahmole { get { return getAllVazn(); } }

        private int getAllVazn()
        {
            return Products.Sum(it => it.vazn);
        }
    }
}