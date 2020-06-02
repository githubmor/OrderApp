using OrderAndisheh.Domain.Entity;
using System.Collections.Generic;

namespace OrderAndisheh.Domain.Repository
{
    public interface IDestinationRepository
    {
        List<DestinationEntity> getDestinationList(Interfaces.IKalaDestinationType data);
    }
}