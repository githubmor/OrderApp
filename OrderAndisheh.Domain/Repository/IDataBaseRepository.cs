using OrderAndisheh.Domain.Interfaces;

namespace OrderAndisheh.Domain.Repository
{
    public interface IDataBaseRepository
    {
        bool BackUpDataBase(IFile data);

        bool RestoreDataBase(IFile data);

        bool ChangeDataBaseBackUpAddress(string address);
    }
}