using OrderAndisheh.Domain.Entity;
using OrderAndisheh.Domain.Repository;
using System;

namespace OrderAndisheh.Domain.UseCase
{
    public class ChangeCurrentSalMaliInteractor : IRequestHandler<SalMaliEntity, Boolean>
    {
        private ISalMaliRepository _repository;

        public ChangeCurrentSalMaliInteractor(ISalMaliRepository repository)
        {
            _repository = repository;
        }

        public bool Handle(SalMaliEntity data)
        {
            return _repository.ChangeSalMali(data);
        }
    }
}