using OrderAndisheh.Domain.Entity;
using OrderAndisheh.Domain.Repository;
using System.Collections.Generic;

namespace OrderAndisheh.Domain.UseCase
{
    public class ShowOrderStateListInteractor : IRequestHandler<bool, List<OrderStateEntity>>
    {
        private IOrderRepository _repository;

        public ShowOrderStateListInteractor(IOrderRepository repository)
        {
            _repository = repository;
        }

        public List<OrderStateEntity> Handle(bool showAccepted)
        {
            return _repository.GetOrderState(showAccepted);
        }
    }
}