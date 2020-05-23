using OrderAndisheh.Domain.Entity;
using OrderAndisheh.Domain.Interfaces;
using OrderAndisheh.Domain.Repository;

namespace OrderAndisheh.Domain.UseCase
{
    public class GetDriverListInteractor : IRequestHandler<ICarType, DriverEntity>
    {
        private IDriverRepository _repository;

        public GetDriverListInteractor(IDriverRepository repository)
        {
            _repository = repository;
        }

        public DriverEntity Handle(ICarType data)
        {
            return _repository.getDriverList(data);
        }
    }
}