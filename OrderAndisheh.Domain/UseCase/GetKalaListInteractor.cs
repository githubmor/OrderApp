using OrderAndisheh.Domain.Entity;
using OrderAndisheh.Domain.Interfaces;
using OrderAndisheh.Domain.Repository;

namespace OrderAndisheh.Domain.UseCase
{
    public class GetKalaListInteractor : IRequestHandler<IKalaType, System.Collections.Generic.List<KalaEntity>>
    {
        private IKalaRepository _repository;

        public GetKalaListInteractor(IKalaRepository repository)
        {
            _repository = repository;
        }

        public System.Collections.Generic.List<KalaEntity> Handle(IKalaType kalaType)
        {
            return _repository.getKalaList(kalaType);
        }
    }
}