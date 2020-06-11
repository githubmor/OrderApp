using OrderAndisheh.Domain.Interfaces;

namespace OrderAndisheh.Domain.Repository
{
    public interface IBackUpRepository
    {
        bool BackUpDataBase(IFile data);
    }
}