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
            var result = _repository.CreateNewSalMali(data);

            if (result)
                return _repository.ChangeSalMali(data);
            else
                return false;
        }
    }
}