using OrderAndisheh.Domain.Interfaces;
using OrderAndisheh.Domain.Repository;

namespace OrderAndisheh.Domain.UseCase
{
    public class RestoreDatabaseInteractor : IRequestHandler<IFile, bool>
    {
        private IDataBaseRepository _repository;

        public RestoreDatabaseInteractor(IDataBaseRepository repository)
        {
            _repository = repository;
        }

        public bool Handle(IFile data)
        {
            return _repository.RestoreDataBase(data);
        }
    }
}