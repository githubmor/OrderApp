using Core.Models;
using Core.Services;
using System;
using System.Collections.Generic;

namespace OrdersAndisheh.DesignService
{
    public class DesignErsalItemService : IErsalItemService
    {
        public bool AddOrUpdateErsalItems(string tarikh, List<Core.Models.ItemDto> newItems)
        {
            return true;
        }

        public List<ItemDto> GetItems(string tarikh)
        {
            var rList = GetRanandehList();
            var mList = GetMaghasedListByKalaList(null);
            return new List<ItemDto>() 
                { 
                    new ItemDto() 
                    { 
                        Id = 1,
                        ItemKala = new KalaDto(){Name = "111"}, 
                        ItemMaghsad = mList[0],
                        ItemRanande = rList[1],
                        Karton = 5,
                        PalletCount = 8,
                        Vazn = 658
                    },
                    new ItemDto() 
                    { 
                        Id = 2,
                        ItemKala = new KalaDto(){Name = "121"}, 
                        ItemRanande = rList[1],
                        ItemMaghsad = mList[1],
                        Karton = 50,
                        PalletCount = 204,
                        Tedad = 784,
                        Vazn = 45
                    },
                    new ItemDto() 
                    { 
                        Id = 3,
                        ItemKala = new KalaDto(){Name = "111"}, 
                        ItemRanande = rList[2],
                        Karton = 5,
                        PalletCount = 8,
                        Tedad = 6588,
                        Vazn = 658
                    },
                    new ItemDto()
                    {
                        Id = 3,
                        ItemKala = new KalaDto(){Name = "111"},
                        ItemMaghsad = mList[2],
                        Karton = 5,
                        PalletCount = 8,
                        Tedad = 6588,
                        Vazn = 658
                    },
                    new ItemDto()
                    {
                        Id = 3,
                        ItemKala = new KalaDto(){Name = "111"},
                        Karton = 5,
                        PalletCount = 8,
                        Tedad = 6588,
                        Vazn = 658
                    }

                };
        }


        public List<KalaElectionDto> GetKalasListSortByMostAndLastErsal()
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

        public List<MaghsadDto> GetMaghasedListByKalaList(List<ItemDto> items)
        {
            return new List<MaghsadDto>()
            {
                new MaghsadDto(){Name="kashan"},
                new MaghsadDto(){Name="saipa"},
                new MaghsadDto(){Name="pars"},
                new MaghsadDto(){Name="babol"}
            };
        }


        public List<RanandeDto> GetRanandehList()
        {
            return new List<RanandeDto>()
            {
                new RanandeDto(){Name="contin 1",isContainer = true},
                new RanandeDto(){Name="maleki"},
                new RanandeDto(){Name="contin 2",isContainer = true},
                new RanandeDto(){Name="abasnasab"}
            };
        }
    }
}
