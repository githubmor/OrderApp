using OrderAndisheh.Domain.Interfaces;
using OrderAndisheh.Domain.Repository;

namespace OrderAndisheh.Domain.UseCase
{
    public class ChangeDatabaseBackUpAddressInteractor : IRequestHandler<string, bool>
    {
        private IDataBaseRepository _repository;

        public ChangeDatabaseBackUpAddressInteractor(IDataBaseRepository repository)
        {
            _repository = repository;
        }

        public bool Handle(string address)
        {
            return _repository.ChangeDataBaseBackUpAddress(address);
        }
    }
}