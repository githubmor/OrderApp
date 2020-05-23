namespace OrderAndisheh.Domain.Entity
{
    public class CabinEntity
    {
        public CabinEntity()
        {
            Mahmoles = new System.Collections.Generic.List<MahmoleEntity>();
        }

        public System.Collections.Generic.List<MahmoleEntity> Mahmoles { get; set; }
        public DriverEntity Driver { get; set; }
    }
}