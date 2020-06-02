namespace OrderAndisheh.Domain.Entity
{
    public class OrderStateEntity : BaseOrderEntity
    {
        public OrderStateEntity(int tarikh, int version = 0, bool isAccepted = false)
            : base(tarikh, version, isAccepted)
        {
        }

        public bool IsTedadSet { get; set; }
        public bool IsTahvilSet { get; set; }
        public bool IsDriverSet { get; set; }
        public bool IsDestinationSet { get; set; }
    }
}