using Core.Models;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersAndisheh.DesignService
{
    public class DesignErsalItemService : IErsalItemService
    {
        public bool AddOrUpdateErsalItems(string tarikh, List<Core.Models.ItemDto> newItems)
        {
            return true;
        }

        public List<Core.Models.ItemDto> GetItems(string tarikh)
        {
            return new List<Core.Models.ItemDto>() 
                { 
                    new ItemDto() 
                    { 
                        Id = 1,
                        ItemKala = new KalaDto(){Name = "111"}, 
                        ItemMaghsad = new MaghsadDto(){Name = "سايپا"},
                        ItemRanande = new RanandeDto(){Name = "قريشي"},
                        Karton = 5,
                        PalletCount = 8,
                        Vazn = 658
                    },
                    new ItemDto() 
                    { 
                        Id = 2,
                        ItemKala = new KalaDto(){Name = "121"}, 
                        ItemRanande = new RanandeDto(){Name = "قريشي"},
                        ItemMaghsad = new MaghsadDto(){Name = "سايپا"},
                        Karton = 50,
                        PalletCount = 204,
                        Tedad = 784,
                        Vazn = 45
                    },
                    new ItemDto() 
                    { 
                        Id = 3,
                        ItemKala = new KalaDto(){Name = "111"}, 
                        ItemMaghsad = new MaghsadDto(){Name = "سايپا"},
                        ItemRanande = new RanandeDto(){Name = "قريشي"},
                        Karton = 5,
                        PalletCount = 8,
                        Tedad = 6588,
                        Vazn = 658
                    },
                    
                };
        }


        public List<KalaElectionDto> GetKalasList()
        {
            return new List<KalaElectionDto>()
            {
                new KalaElectionDto(){Code = "15001020",Name="AAAAA",Moshtari=Moshtari.Sapco,Sherkat=Sherkat.Andisheh},
                new KalaElectionDto(){Code = "15001068",Name="BBBBB",Moshtari=Moshtari.Sazehgostar,Sherkat=Sherkat.Andisheh},
                new KalaElectionDto(){Code = "14500001",Name="CCCCC",Moshtari=Moshtari.Sazehgostar,Sherkat=Sherkat.Imen}
            };
        }

        public void ChangeDatabase(int year)
        {
            throw new NotImplementedException();
        }


        public List<MaghsadDto> GetMaghasedList()
        {
            return new List<MaghsadDto>()
            {
                new MaghsadDto(){Name="kashan"},
                new MaghsadDto(){Name="saipa"},
                new MaghsadDto(){Name="pars"},
                new MaghsadDto(){Name="babol"}
            };
        }
    }
}
