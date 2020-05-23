using OrderAndisheh.Domain.Entity;
using OrderAndisheh.Domain.Repository;

namespace OrderAndisheh.Domain.UseCase
{
    public class OpenOrderIntractor : IRequestHandler<int, OrderEntity>
    {
        private IOrderRepository _repository;

        public OpenOrderIntractor(IOrderRepository repository)
        {
            _repository = repository;
        }

        public OrderEntity Handle(int tarikh)
        {
            return _repository.GetOrder(tarikh);
        }
    }
}