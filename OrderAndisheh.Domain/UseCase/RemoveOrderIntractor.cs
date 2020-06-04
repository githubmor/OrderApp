using OrderAndisheh.Domain.Entity;
using OrderAndisheh.Domain.Repository;

namespace OrderAndisheh.Domain.UseCase
{
    public class RemoveOrderIntractor : IRequestHandler<BaseOrderEntity, bool>
    {
        private IOrderRepository _repository;

        public RemoveOrderIntractor(IOrderRepository repository)
        {
            _repository = repository;
        }

        public bool Handle(BaseOrderEntity order)
        {
            return _repository.RemoveOrder(order);
        }
    }
}