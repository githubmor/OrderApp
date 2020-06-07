using System.Collections.Generic;
using System.Linq;

namespace OrderAndisheh.Domain.Entity
{
    public class CabinEntity
    {
        public CabinEntity(List<MahmoleEntity> mahmoles, DriverEntity driver = null)
            : this(driver)
        {
            Mahmoles = mahmoles;
        }

        public CabinEntity(DriverEntity driver = null)
        {
            Mahmoles = new List<MahmoleEntity>();
            Driver = driver;
        }

        public List<MahmoleEntity> Mahmoles { get; private set; }

        public void AddMahmole(List<MahmoleEntity> mahmoles)
        {
            mahmoles.ForEach(it =>
            {
                var myMahmole = GetDuplicateMahmoleOrNull(it);
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

        private MahmoleEntity GetDuplicateMahmoleOrNull(MahmoleEntity mahmole)
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