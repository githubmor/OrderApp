using OrderAndisheh.Domain.Entity;
using System.Collections.Generic;

namespace OrderAndisheh.Domain.Repository
{
    public interface IDriverRepository
    {
        List<DriverEntity> getDriverList(Interfaces.ICarType data);
    }
}