using OrderAndisheh.Domain.Entity;
using OrderAndisheh.Domain.Interfaces;
using OrderAndisheh.Domain.Repository;
using System.Collections.Generic;

namespace OrderAndisheh.Domain.UseCase
{
    public class GetDriverListInteractor : IRequestHandler<ICarType, List<DriverEntity>>
    {
        private IDriverRepository _repository;

        public GetDriverListInteractor(IDriverRepository repository)
        {
            _repository = repository;
        }

        public List<DriverEntity> Handle(ICarType data)
        {
            return _repository.getDriverList(data);
        }
    }
}