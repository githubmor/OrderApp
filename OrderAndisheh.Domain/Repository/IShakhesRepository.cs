using OrderAndisheh.Domain.Interfaces;
namespace OrderAndisheh.Domain.Repository
{
    public interface IShakhesRepository
    {
        Entity.ShakhesEntity getShakhesh(IShakhesRange mah);

        bool SetAmarTolid(Entity.TolidMahaneEntity data);
    }
}