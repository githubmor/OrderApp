using OrderAndisheh.Domain.Entity;
using OrderAndisheh.Domain.Interfaces;
using OrderAndisheh.Domain.Repository;
using System;

namespace OrderAndisheh.Domain.UseCase
{
    public class GetShakhesInteractor : IRequestHandler<IShakhesRange, ShakhesEntity>
    {
        private IShakhesRepository _repository;

        public GetShakhesInteractor(IShakhesRepository repository)
        {
            _repository = repository;
        }

        public ShakhesEntity Handle(IShakhesRange range)
        {
            return _repository.getShakhesh(range);
        }

    }
}