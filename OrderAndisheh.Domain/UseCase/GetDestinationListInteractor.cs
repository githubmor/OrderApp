using OrderAndisheh.Domain.Entity;
using OrderAndisheh.Domain.Interfaces;
using OrderAndisheh.Domain.Repository;

namespace OrderAndisheh.Domain.UseCase
{
    public class GetDestinationListInteractor : IRequestHandler<IKalaDestinationType, DestinationEntity>
    {
        private IDestinationRepository _repository;

        public GetDestinationListInteractor(IDestinationRepository repository)
        {
            _repository = repository;
        }

        public DestinationEntity Handle(IKalaDestinationType data)
        {
            return _repository.getDestinationList(data);
        }
    }
}