using OrderAndisheh.Domain.Entity;
using OrderAndisheh.Domain.Repository;

namespace OrderAndisheh.Domain.UseCase
{
    public class UpdateOrderInteractor : IRequestHandler<OrderEntity, bool>
    {
        private IOrderRepository _repository;

        public UpdateOrderInteractor(IOrderRepository repository)
        {
            _repository = repository;
        }

        public bool Handle(OrderEntity data)
        {
            return _repository.UpdateOrder(data);
        }
    }
}