namespace OrderAndisheh.Domain.Repository
{
    public interface IKalaRepository
    {
        System.Collections.Generic.List<OrderAndisheh.Domain.Entity.KalaEntity> getKalaList(Interfaces.IKalaType data);
    }
}