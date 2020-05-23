namespace OrderAndisheh.Domain.Repository
{
    public interface IDriverRepository
    {
        Entity.DriverEntity getDriverList(Interfaces.ICarType data);
    }
}