using Core.Models;
using System.Collections.Generic;

namespace Core.Services
{
    public interface IContainerService
    {
        List<Container> getBasicContainering(List<ItemDto> items);

        void SaveContainers(List<Container> Containers);
    }
}