using OrderAndisheh.Domain.Entity;
using OrderAndisheh.Domain.Repository;
using System;

namespace OrderAndisheh.Domain.UseCase
{
    public class GetShakhesInteractor : IRequestHandler<int, ShakhesEntity>
    {
        private IShakhesRepository _repository;

        public GetShakhesInteractor(IShakhesRepository repository)
        {
            _repository = repository;
        }

        public ShakhesEntity Handle(int mah)
        {
            if (IsMahInRagne(mah))
            {
                throw new ArgumentException("ماه در ساخص گيري در محدوده مشخص نمي باشد", "mah");
            }
            return _repository.getShakhesh(mah);
        }

        private bool IsMahInRagne(int mah)
        {
            return mah > 0 && mah < 13;
        }
    }
}