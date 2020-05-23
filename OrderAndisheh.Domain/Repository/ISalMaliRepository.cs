using OrderAndisheh.Domain.Interfaces;

namespace OrderAndisheh.Domain.Repository
{
    public interface IDatabaseRepository
    {
        bool ChangeSalMali(ISalMali data);

        bool BackUpDataBase(IFile data);
    }
}