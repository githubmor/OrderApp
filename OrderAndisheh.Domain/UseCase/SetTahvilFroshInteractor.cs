using OrderAndisheh.Domain.Entity;
using OrderAndisheh.Domain.Repository;

namespace OrderAndisheh.Domain.UseCase
{
    public class SetTahvilFroshInteractor : IRequestHandler<TahvilOrderEntity, bool>
    {
        private ITahvilRepository _repository;

        public SetTahvilFroshInteractor(ITahvilRepository repository)
        {
            _repository = repository;
        }

        public bool Handle(TahvilOrderEntity data)
        {
            return _repository.SetTahvilFrosh(data);
        }
    }
}