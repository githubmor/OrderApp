using OrderAndisheh.Domain.Interfaces;
using OrderAndisheh.Domain.Repository;

namespace OrderAndisheh.Domain.UseCase
{
    public class BackupDatabaseInteractor : IRequestHandler<IFile, bool>
    {
        private IBackUpRepository _repository;

        public BackupDatabaseInteractor(IBackUpRepository repository)
        {
            _repository = repository;
        }

        public bool Handle(IFile data)
        {
            return _repository.BackUpDataBase(data);
        }
    }
}