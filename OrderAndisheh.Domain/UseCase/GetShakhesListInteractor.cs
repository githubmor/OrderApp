using OrderAndisheh.Domain.Entity;
using OrderAndisheh.Domain.Repository;

namespace OrderAndisheh.Domain.UseCase
{
    public class GetShakhesListInteractor : IRequestHandler<int, ShakhesEntity>
    {
        private IShakhesRepository _repository;

        public GetShakhesListInteractor(IShakhesRepository repository)
        {
            _repository = repository;
        }

        public ShakhesEntity Handle(int mah)
        {
            return _repository.getShakhesh(mah);
        }
    }
}