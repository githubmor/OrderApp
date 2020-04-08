using Core.Models;
using System.Collections.Generic;

namespace Core.Services
{
    public interface IErsalItemService : IBaseService
    {
        bool AddOrUpdateErsalItems(string tarikh, List<ItemDto> newItems);

        List<ItemDto> GetItems(string tarikh);

        List<KalaElectionDto> GetKalasListSortByMostAndLastErsal();

        List<MaghsadDto> GetMaghasedListByKalaList(List<ItemDto> items);
    }
}