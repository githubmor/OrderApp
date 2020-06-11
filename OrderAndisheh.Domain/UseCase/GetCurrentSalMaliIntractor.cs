using OrderAndisheh.Domain.Entity;
using OrderAndisheh.Domain.Repository;

namespace OrderAndisheh.Domain.UseCase
{
    public class GetCurrentSalMaliIntractor : IRequestHandler<bool, SalMaliEntity>
    {
        private ISalMaliRepository _repository;

        public GetCurrentSalMaliIntractor(ISalMaliRepository repository)
        {
            _repository = repository;
        }

        public SalMaliEntity Handle(bool data)
        {
            return _repository.GetCurrentSalMali();
        }
    }
}