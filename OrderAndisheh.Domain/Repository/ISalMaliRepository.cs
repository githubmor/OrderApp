using OrderAndisheh.Domain.Entity;
using System.Collections.Generic;

namespace OrderAndisheh.Domain.Repository
{
    public interface ISalMaliRepository
    {
        bool ChangeSalMali(SalMaliEntity data);

        bool CreateNewSalMali(SalMaliEntity data);

        List<Entity.SalMaliEntity> GetAllSalMali();

        Entity.SalMaliEntity GetCurrentSalMali();
    }
}