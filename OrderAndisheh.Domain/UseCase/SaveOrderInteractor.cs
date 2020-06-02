using OrderAndisheh.Domain.Entity;
using OrderAndisheh.Domain.Repository;

namespace OrderAndisheh.Domain.UseCase
{
    public class SaveOrderInteractor : IRequestHandler<OrderEntity, bool>
    {
        private IOrderRepository _repository;

        public SaveOrderInteractor(IOrderRepository repository)
        {
            _repository = repository;
        }

        public bool Handle(OrderEntity order)
        {
            return _repository.SaveOrder(order);
        }
    }
}