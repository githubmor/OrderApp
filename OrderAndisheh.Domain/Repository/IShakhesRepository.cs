namespace OrderAndisheh.Domain.Repository
{
    public interface IShakhesRepository
    {
        Entity.ShakhesEntity getShakhesh(int mah);

        bool SetAmarTolid(Entity.TolidMahaneEntity data);
    }
}