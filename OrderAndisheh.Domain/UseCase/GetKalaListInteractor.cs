using OrderAndisheh.Domain.Entity;
using OrderAndisheh.Domain.Interfaces;
using OrderAndisheh.Domain.Repository;

namespace OrderAndisheh.Domain.UseCase
{
    public class GetKalaListInteractor : IRequestHandler<IKalaType, KalaEntity>
    {
        private IKalaRepository _repository;

        public GetKalaListInteractor(IKalaRepository repository)
        {
            _repository = repository;
        }

        public KalaEntity Handle(IKalaType data)
        {
            return _repository.getKalaList(data);
        }
    }
}