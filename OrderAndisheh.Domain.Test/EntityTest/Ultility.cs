using OrderAndisheh.Domain.Entity;
using System.Collections.Generic;

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
            MahmoleEntity m = new MahmoleEntity(new List<ProductEntity>() { p }, de);
            return new List<MahmoleEntity>() { m };
        }

        public static List<MahmoleEntity> getMahmoleList2()
        {
            PalletEntity pallet2 = new PalletEntity("GP8", 200);

            KalaEntity kala2 = new KalaEntity("name2", "codeAnbar2", "fani", "jens",
                pallet2, 120, 10, 800);

            ProductEntity p2 = new ProductEntity(kala2, 120);
            DestinationEntity de = new DestinationEntity("Saipa");
            MahmoleEntity m2 = new MahmoleEntity(new List<ProductEntity>() { p2 }, de);

            return new List<MahmoleEntity>() { m2 };
        }

        public static List<MahmoleEntity> getMahmoleList3()
        {
            PalletEntity pallet2 = new PalletEntity("GP8", 200);

            KalaEntity kala2 = new KalaEntity("name2", "codeAnbar", "fani", "jens",
                pallet2, 120, 10, 800);

            ProductEntity p2 = new ProductEntity(kala2, 120);
            DestinationEntity de2 = new DestinationEntity("Sapco");
            MahmoleEntity m2 = new MahmoleEntity(new List<ProductEntity>() { p2 }, de2);

            return new List<MahmoleEntity>() { m2 };
        }

        public static List<AmarTolidKhodroEntity> getAmarTolids()
        {
            return new List<AmarTolidKhodroEntity>() { new AmarTolidKhodroEntity("206", 2000) };
        }

        public static List<BaseKhodorEntity> getKhodroList()
        {
            return new List<BaseKhodorEntity>() { new BaseKhodorEntity("206") };
        }

        public static List<BaseKhodorEntity> getKhodroList2()
        {
            return new List<BaseKhodorEntity>() { new BaseKhodorEntity("207") };
        }

        public static BaseCustomerEntity getCustomer()
        {
            return new BaseCustomerEntity("Sapco");
        }

        public static List<ErsalKalaEntity> getErsali()
        {
            return new List<ErsalKalaEntity>() { new ErsalKalaEntity("name", "codeAnbar", "fani", "jens", 200, 2,
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

        public static DestinationEntity getDestination()
        {
            return new DestinationEntity("Saipa");
        }

        public static List<ProductEntity> getProductList()
        {
            PalletEntity pallet = new PalletEntity("GP8", 200);

            KalaEntity kala = new KalaEntity("name", "codeAnbar", "fani", "jens",
                pallet, 120, 10, 800);

            return new List<ProductEntity>() { new ProductEntity(kala, 120) };
        }

        public static List<CabinEntity> getCabinList()
        {
            PalletEntity pallet = new PalletEntity("GP8", 200);

            KalaEntity kala = new KalaEntity("name", "codeAnbar", "fani", "jens",
                pallet, 120, 10, 800);

            ProductEntity p = new ProductEntity(kala, 120);
            DestinationEntity de = new DestinationEntity("Saipa");
            MahmoleEntity m = new MahmoleEntity(new List<ProductEntity>() { p }, de);

            DriverEntity d = new DriverEntity("name", "mobile", "codeMeli", "pelak");

            return new List<CabinEntity>() { new CabinEntity(new List<MahmoleEntity>() { m }, d) };
        }

        public static List<CabinEntity> getCabinList2()
        {
            PalletEntity pallet2 = new PalletEntity("GP8", 200);

            KalaEntity kala2 = new KalaEntity("name", "codeAnbar2", "fani", "jens",
                pallet2, 120, 10, 800);

            ProductEntity p2 = new ProductEntity(kala2, 120);
            DestinationEntity de2 = new DestinationEntity("Saipa");
            MahmoleEntity m2 = new MahmoleEntity(new List<ProductEntity>() { p2 }, de2);

            DriverEntity d2 = new DriverEntity("name2", "mobile", "codeMeli", "pelak");

            return new List<CabinEntity>() { new CabinEntity(new List<MahmoleEntity>() { m2 }, d2) };
        }

        public static List<CabinEntity> getCabinList3()
        {
            PalletEntity pallet = new PalletEntity("GP8", 200);

            KalaEntity kala2 = new KalaEntity("name2", "codeAnbar2", "fani", "jens",
                pallet, 120, 10, 800);

            ProductEntity p = new ProductEntity(kala2, 120);
            DestinationEntity de = new DestinationEntity("Saipa");
            MahmoleEntity m = new MahmoleEntity(new List<ProductEntity>() { p }, de);

            DriverEntity d = new DriverEntity("name", "mobile", "codeMeli", "pelak");

            return new List<CabinEntity>() { new CabinEntity(new List<MahmoleEntity>() { m }, d) };
        }

        internal static KalaEntity getkalaBastei()
        {
            PalletEntity pallet = new PalletEntity("GP8", 200);

            return new KalaEntity("name", "codeAnbar", "fani", "jens",
                pallet, 120, 10, 800);
        }

        internal static KalaEntity getkalaNoBastei()
        {
            PalletEntity pallet = new PalletEntity("GP8", 200);

            return new KalaEntity("name", "codeAnbar", "fani", "jens",
                pallet, 120, 0, 800);
        }

        internal static List<ErsaliSherkatEntity> getErsaliSherkat()
        {
            return new List<ErsaliSherkatEntity>() { new ErsaliSherkatEntity("Andisheh", getErsali()) };
        }

        internal static List<CustomerTolidiEntity> getCustomerTolidi()
        {
            return new List<CustomerTolidiEntity>() { new CustomerTolidiEntity("Sapco", getAmarTolids()) };
        }

        internal static ErsalKalaEntity getOneErsali()
        {
            return new ErsalKalaEntity("name", "codeAnbar", "fani", "jens", 200, 2,
                getKhodroList(), getCustomer());
        }

        internal static List<TahvilFroshEntity> getTahvilList()
        {
            TahvilFroshEntity t = new TahvilFroshEntity(getProductList(), 15);
            return new List<TahvilFroshEntity>() { t };
        }

    }
}