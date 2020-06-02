using System.Collections.Generic;
using System.Linq;

namespace OrderAndisheh.Domain.Entity
{
    public class CabinEntity
    {
        public CabinEntity(List<MahmoleEntity> mahmoles, DriverEntity driver = null)
            : this(driver)
        {
            Mahmoles = new System.Collections.Generic.List<MahmoleEntity>();
            Driver = driver;
            Mahmoles = mahmoles;
        }

        public CabinEntity(DriverEntity driver = null)
        {
            Mahmoles = new System.Collections.Generic.List<MahmoleEntity>();
            Driver = driver;
        }

        public System.Collections.Generic.List<MahmoleEntity> Mahmoles { get; private set; }

        public void AddMahmole(System.Collections.Generic.List<MahmoleEntity> mahmoles)
        {
            mahmoles.ForEach(it =>
            {
                var myMahmole = GetDuplicateMahmole(it);
                if (myMahmole != null)
                {
                    myMahmole.AddProduct(it.Products);
                }
                else
                {
                    Mahmoles.Add(it);
                }
            });
        }

        private MahmoleEntity GetDuplicateMahmole(MahmoleEntity mahmole)
        {
            return Mahmoles.SingleOrDefault(p => p.DestinationName == mahmole.DestinationName);
        }

        public DriverEntity Driver { get; set; }
        public string Drivername { get { return Driver != null ? Driver.Name : ""; } }
        public int VaznCabin { get { return getAllmahmoleVazn(); } }

        private int getAllmahmoleVazn()
        {
            return Mahmoles.Sum(it => it.VaznMahmole);
        }
    }
}