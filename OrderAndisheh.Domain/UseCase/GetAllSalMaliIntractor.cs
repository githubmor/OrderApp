using OrderAndisheh.Domain.Entity;
using OrderAndisheh.Domain.Repository;
using System.Collections.Generic;

namespace OrderAndisheh.Domain.UseCase
{
    public class GetAllSalMaliIntractor : IRequestHandler<bool, List<SalMaliEntity>>
    {
        private ISalMaliRepository _repository;

        public GetAllSalMaliIntractor(ISalMaliRepository repository)
        {
            _repository = repository;
        }

        public List<SalMaliEntity> Handle(bool data)
        {
            return _repository.GetAllSalMali();
        }
    }
}