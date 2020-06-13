using OrderAndisheh.Domain.Entity;
using System.Collections.Generic;

namespace OrderAndisheh.Domain.Repository
{
    public interface IOrderRepository
    {
        List<OrderStateEntity> GetOrderState(bool showAccepted);

        OrderEntity GetOrder(int tarikh);

        bool SaveOrder(OrderEntity data);

        bool RemoveOrder(BaseOrderEntity data);
    }
}