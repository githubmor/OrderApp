namespace OrderAndisheh.Domain.Repository
{
    public interface IKalaRepository
    {
        Entity.KalaEntity getKalaList(Interfaces.IKalaType data);
    }
}