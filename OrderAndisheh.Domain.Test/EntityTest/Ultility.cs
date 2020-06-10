using OrderAndisheh.Domain.Entity;
using System.Collections.Generic;

namespace OrderAndisheh.Domain.Test.EntityTest
{
    public static class Ultility
    {
        public static List<AmarTolidKhodroEntity> getAmarTolids()
        {
            return new List<AmarTolidKhodroEntity>() { new AmarTolidKhodroEntity("206", 2000) };
        }

        public static List<CabinEntity> getCabinList_Default()
        {
            return new List<CabinEntity>() { new CabinEntity(getMahmoleList_Default(), getDriver()) };
        }

        public static List<CabinEntity> getCabinList_DifMahmole_SameDriver()
        {
            return new List<CabinEntity>() { new CabinEntity(getMahmoleList_DifProduct_SameDestination(), getDriver()) };
        }

        public static List<CabinEntity> getCabinList_SameMahmole_DifDriver()
        {
            return new List<CabinEntity>() { new CabinEntity(getMahmoleList_Default(), getDriver("name2")) };
        }

        public static BaseCustomerEntity getCustomer(string name = "Sapco")
        {
            return new BaseCustomerEntity(name);
        }

        public static DestinationEntity getDestination(string name = "Saipa")
        {
            return new DestinationEntity(name);
        }

        public static DriverEntity getDriver(string name = "name")
        {
            return new DriverEntity(name, "mobile", "codeMeli", "pelak");
        }

        public static List<ErsalKalaEntity> getErsali()
        {
            return new List<ErsalKalaEntity>() { getOneErsali() };
        }

        public static List<BaseKhodorEntity> getKhodroList(string name = "206")
        {
            return new List<BaseKhodorEntity>() { new BaseKhodorEntity(name) };
        }

        public static List<MahmoleEntity> getMahmoleList_Default()
        {
            MahmoleEntity m = new MahmoleEntity(getProductList_Default(), getDestination());
            return new List<MahmoleEntity>() { m };
        }

        public static List<MahmoleEntity> getMahmoleList_DifProduct_SameDestination()
        {
            MahmoleEntity m2 = new MahmoleEntity(getProductList_DifKala(), getDestination());

            return new List<MahmoleEntity>() { m2 };
        }

        public static List<MahmoleEntity> getMahmoleList_SameProduct_DifDestination()
        {
            MahmoleEntity m2 = new MahmoleEntity(getProductList_Default(), getDestination("Sapco"));

            return new List<MahmoleEntity>() { m2 };
        }

        public static PalletEntity getpallet()
        {
            return new PalletEntity("GP8", 200);
        }

        public static List<ProductEntity> getProductList_Default()
        {
            return new List<ProductEntity>() { new ProductEntity(getkalaBastei(), 120) };
        }

        internal static List<CustomerTolidiEntity> getCustomerTolidi()
        {
            return new List<CustomerTolidiEntity>() { new CustomerTolidiEntity("Sapco", getAmarTolids()) };
        }

        internal static List<ErsaliSherkatEntity> getErsaliSherkat()
        {
            return new List<ErsaliSherkatEntity>() { new ErsaliSherkatEntity("Andisheh", getErsali()) };
        }

        internal static KalaEntity getkalaBastei(string codeAnbar = "codeAnbar", bool isbastei = true)
        {
            return new KalaEntity("name", codeAnbar, "fani", "jens",
                getpallet(), 120, (isbastei ? 10 : 0), 800);
        }

        internal static ErsalKalaEntity getOneErsali()
        {
            return new ErsalKalaEntity("name", "codeAnbar", "fani", "jens", 200, 2,
                getKhodroList(), getCustomer());
        }

        internal static List<TahvilFroshEntity> getTahvilList()
        {
            return new List<TahvilFroshEntity>() { new TahvilFroshEntity(getProductList_Default(), 15) };
        }

        private static List<ProductEntity> getProductList_DifKala()
        {
            return new List<ProductEntity>() { new ProductEntity(getkalaBastei("codeAnbar2"), 120) };
        }
    }
}