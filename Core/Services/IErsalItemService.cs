using Core.Models;
using System.Collections.Generic;

namespace Core.Services
{
    public interface IErsalItemService : IBaseService
    {
        bool AddOrUpdateErsalItems(string tarikh, List<ItemDto> newItems);

        List<ItemDto> GetItems(string tarikh);

        List<KalaElectionDto> GetKalasList();

        List<MaghsadDto> GetMaghasedList();
    }
}