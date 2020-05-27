namespace OrderAndisheh.Domain.Entity
{
    public class ShakhesEntity
    {
        public SherkatEntity Sherkat { get; set; }
        public CustomerEntity Customer { get; set; }

        public float getDarSadSahm()
        {
            return 0F;
        }

        public int getTedadErsal()
        {
            return 0;
        }
    }
}