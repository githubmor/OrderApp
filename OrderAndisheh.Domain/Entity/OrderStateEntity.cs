namespace OrderAndisheh.Domain.Entity
{
    public class OrderStateEntity : BaseOrderEntity
    {
        public OrderStateEntity(int tarikh, bool isTedadSet, bool isTahvilSet, bool isDriverSet, bool isDestinationSet)
            : base(tarikh)
        {
            IsTedadSet = isTedadSet;
            IsTahvilSet = isTahvilSet;
            IsDriverSet = isDriverSet;
            IsDestinationSet = isDestinationSet;
        }

        public bool IsTedadSet { get; private set; }
        public bool IsTahvilSet { get; private set; }
        public bool IsDriverSet { get; private set; }
        public bool IsDestinationSet { get; private set; }
    }
}