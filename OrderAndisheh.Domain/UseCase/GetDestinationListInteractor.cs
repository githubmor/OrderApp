using OrderAndisheh.Domain.Entity;
using OrderAndisheh.Domain.Interfaces;
using OrderAndisheh.Domain.Repository;
using System.Collections.Generic;

namespace OrderAndisheh.Domain.UseCase
{
    public class GetDestinationListInteractor : IRequestHandler<IKalaDestinationType, List<DestinationEntity>>
    {
        private IDestinationRepository _repository;

        public GetDestinationListInteractor(IDestinationRepository repository)
        {
            _repository = repository;
        }

        public List<DestinationEntity> Handle(IKalaDestinationType data)
        {
            return _repository.getDestinationList(data);
        }
    }
}