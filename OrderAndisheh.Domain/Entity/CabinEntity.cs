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
            if (mahmoles != null)
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
        }

        private MahmoleEntity GetDuplicateMahmoleOrNull(MahmoleEntity mahmole)
        {
            return Mahmoles.SingleOrDefault(p => p.DestinationName == mahmole.DestinationName);
        }

        public DriverEntity Driver { get; set; }

        public string Drivername { get { return Driver != null ? Driver.Name : ""; } }

        public int getCabinVazn()
        {
            return Mahmoles.Sum(it => it.getMahmoleVazn());
        }

        public int getCabinPalletCount()
        {
            return Mahmoles.Sum(it => it.getMahmolePalletCount());
        }

        public int getCabinJaighah()
        {
            var palletChobi = Mahmoles.Sum(it => it.getMahmolePalletChobiCount());
            var palletFelezi = Mahmoles.Sum(it => it.getMahmolePalletFeleziCount());

            return (palletFelezi / 2) + palletChobi;
        }

    }
}