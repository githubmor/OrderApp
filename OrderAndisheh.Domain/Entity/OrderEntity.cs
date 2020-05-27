namespace OrderAndisheh.Domain.Entity
{
    public class OrderEntity : BaseOrderEntity
    {
        public OrderEntity()
        {
            Details = new System.Collections.Generic.List<CabinEntity>();
        }

        public System.Collections.Generic.List<CabinEntity> Details { get; set; }
    }
}