using OrderAndisheh.Domain.Entity;
using OrderAndisheh.Domain.Interfaces;
using OrderAndisheh.Domain.Repository;
using System.Collections.Generic;

namespace OrderAndisheh.Domain.UseCase
{
    public class GetKalaListInteractor : IRequestHandler<IKalaType, List<KalaEntity>>
    {
        private IKalaRepository _repository;

        public GetKalaListInteractor(IKalaRepository repository)
        {
            _repository = repository;
        }

        public List<KalaEntity> Handle(IKalaType kalaType)
        {
            return _repository.getKalaList(kalaType);
        }
    }
}