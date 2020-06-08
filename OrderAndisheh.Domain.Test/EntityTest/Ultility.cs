using OrderAndisheh.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAndisheh.Domain.Test.EntityTest
{
    public static class Ultility
    {
        public static DriverEntity getDriver()
        {
            return new DriverEntity("name", "mobile", "codeMeli", "pelak");
        }

        public static List<MahmoleEntity> getMahmoleList()
        {
            PalletEntity pallet = new PalletEntity("GP8", 200);

            KalaEntity kala = new KalaEntity("name", "codeAnbar", "fani", "jens",
                pallet, 120, 10, 800);

            ProductEntity p = new ProductEntity(kala, 120);
            DestinationEntity de = new DestinationEntity("Saipa");
            MahmoleEntity m = new MahmoleEntity(de, new List<ProductEntity>() { p });
            return new List<MahmoleEntity>() { m };
        }

        public static List<MahmoleEntity> getMahmoleList2()
        {
            PalletEntity pallet2 = new PalletEntity("GP8", 200);

            KalaEntity kala2 = new KalaEntity("name2", "codeAnbar2", "fani", "jens",
                pallet2, 120, 10, 800);

            ProductEntity p2 = new ProductEntity(kala2, 120);
            DestinationEntity de = new DestinationEntity("Saipa");
            MahmoleEntity m2 = new MahmoleEntity(de, new List<ProductEntity>() { p2 });

            return new List<MahmoleEntity>() { m2 };
        }

        public static List<MahmoleEntity> getMahmoleList3()
        {
            PalletEntity pallet2 = new PalletEntity("GP8", 200);

            KalaEntity kala2 = new KalaEntity("name2", "codeAnbar", "fani", "jens",
                pallet2, 120, 10, 800);

            ProductEntity p2 = new ProductEntity(kala2, 120);
            DestinationEntity de2 = new DestinationEntity("Sapco");
            MahmoleEntity m2 = new MahmoleEntity(de2, new List<ProductEntity>() { p2 });

            return new List<MahmoleEntity>() { m2 };
        }

        public static List<AmarTolidKhodroEntity> getAmarTolids()
        {
            return new List<AmarTolidKhodroEntity>() { new AmarTolidKhodroEntity("206", 2000) };
        }
        public static List<KhodorEntity> getKhodroList()
        {
            return new List<KhodorEntity>() { new KhodorEntity("206") };
        }
        public static List<KhodorEntity> getKhodroList2()
        {
            return new List<KhodorEntity>() { new KhodorEntity("207") };
        }
        public static BaseCustomerEntity getCustomer()
        {
            return new BaseCustomerEntity("Sapco");
        }

        public static List<ErsalKalaEntity> getErsali()
        {
            return new List<ErsalKalaEntity>() { new ErsalKalaEntity("name", "codeAnbar", "fani", "jens", 20, 2,
                getKhodroList(), getCustomer()) };
        }

        public static BaseCustomerEntity getCustomer2()
        {
            return new BaseCustomerEntity("Sazeh");
        }

        public static PalletEntity getpallet()
        {
            return new PalletEntity("GP8", 200);
        }
    }
}
