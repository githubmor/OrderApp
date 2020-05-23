namespace OrderAndisheh.Domain.Repository
{
    public interface IDestinationRepository
    {
        Entity.DestinationEntity getDestinationList(Interfaces.IKalaDestinationType data);
    }
}