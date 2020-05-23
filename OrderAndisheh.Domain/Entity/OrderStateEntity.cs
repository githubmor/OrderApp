namespace OrderAndisheh.Domain.Entity
{
    public class OrderStateEntity
    {
        public int Tarikh { get; set; }
        public int Version { get; set; }
        public bool IsTahvilSet { get; set; }
        public bool IsDriverSet { get; set; }
        public bool IsDestinationSet { get; set; }
    }
}