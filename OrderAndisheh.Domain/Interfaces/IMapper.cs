namespace OrderAndisheh.Domain.Interfaces
{
    public interface IMapper<in T, out TO>
    {
        TO MapFrom(T input);
    }
}