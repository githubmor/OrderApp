using OrderAndisheh.Domain.Entity;
using OrderAndisheh.Domain.Interfaces;
using OrderAndisheh.Domain.Repository;
using System;

namespace OrderAndisheh.Domain.UseCase
{
    public class CreateNewSalMaliIntractor : IRequestHandler<SalMaliEntity, Boolean>
    {
        private ISalMaliRepository _repository;

        public CreateNewSalMaliIntractor(ISalMaliRepository repository)
        {
            _repository = repository;
        }

        public bool Handle(SalMaliEntity data)
        {
            return _repository.CreateNewSalMali(data);

            //چون هر يوزكيس يك كار بايد انجام دهد . شايد نخواهيم با ايجاد سال مالي بهش تغيير كنيم
            //if (result)
            //    return _repository.ChangeSalMali(data);
            //else
            //    return false;
        }
    }
}