using OrderAndisheh.Domain.Entity;
using OrderAndisheh.Domain.Repository;

namespace OrderAndisheh.Domain.UseCase
{
    public class AddAmarTolidInteractor : IRequestHandler<TolidMahaneEntity, bool>
    {
        private IShakhesRepository _repository;

        public AddAmarTolidInteractor(IShakhesRepository repository)
        {
            _repository = repository;
        }

        public bool Handle(TolidMahaneEntity data)
        {
            return _repository.SetAmarTolid(data);
        }
    }
}