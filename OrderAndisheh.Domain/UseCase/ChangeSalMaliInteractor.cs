using OrderAndisheh.Domain.Interfaces;
using OrderAndisheh.Domain.Repository;
using System;

namespace OrderAndisheh.Domain.UseCase
{
    public class ChangeSalMaliInteractor : IRequestHandler<ISalMali, Boolean>
    {
        private IDatabaseRepository _repository;

        public ChangeSalMaliInteractor(IDatabaseRepository repository)
        {
            _repository = repository;
        }

        public bool Handle(ISalMali data)
        {
            return _repository.ChangeSalMali(data);
        }
    }
}