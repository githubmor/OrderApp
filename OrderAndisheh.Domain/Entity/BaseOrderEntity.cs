namespace OrderAndisheh.Domain.Entity
{
    public class BaseOrderEntity
    {
        public int Tarikh { get; set; }
        public bool IsAccepted { get; set; }
        public int Version { get; set; }
    }
}