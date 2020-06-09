using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderAndisheh.Domain.Entity
{
    public class MahmoleEntity
    {
        public MahmoleEntity(DestinationEntity destination = null)
        {
            Products = new List<ProductEntity>();
            Destination = destination;
        }

        public MahmoleEntity(List<ProductEntity> product,DestinationEntity destination = null)
            : this(destination)
        {
            Products = product;
        }

        public List<ProductEntity> Products { get; private set; }

        public void AddProduct(List<ProductEntity> product)
        {
            if (product != null)
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
        }

        private bool HasDuplicateKala(ProductEntity product)
        {
            return Products.Any(it => it.Kala.CodeAnbar == product.Kala.CodeAnbar);
        }

        public DestinationEntity Destination { get; set; }

        public string DestinationName { get { return Destination != null ? Destination.Name : ""; } }

        public int getMahmoleVazn()
        {
            return Products.Sum(it => it.getVazn());
        }

        public int getMahmolePalletCount()
        {
            return Products.Sum(p => p.TedadPallet);
        }

        public int getMahmolePalletChobiCount()
        {
            return Products.Where(o => !o.Kala.IsFeleziPallet()).Sum(p => p.TedadPallet);
        }

        public int getMahmolePalletFeleziCount()
        {
            return Products.Where(o => o.Kala.IsFeleziPallet()).Sum(p => p.TedadPallet);
        }
    }
}