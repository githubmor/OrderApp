namespace OrderAndisheh.Domain.Entity
{
    public class OrderStateEntity : BaseOrderEntity
    {
        public bool IsTedadSet { get; set; }
        public bool IsTahvilSet { get; set; }
        public bool IsDriverSet { get; set; }
        public bool IsDestinationSet { get; set; }
    }
}