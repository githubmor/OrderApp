//using OrderAndisheh.Domain.Entity;
//using OrderAndisheh.Domain.Repository;

//namespace OrderAndisheh.Domain.UseCase
//{
//    public class AcceptOrderInteractor : IRequestHandler<BaseOrderEntity, bool>
//    {
//        private IOrderRepository _repository;

//        public AcceptOrderInteractor(IOrderRepository repository)
//        {
//            _repository = repository;
//        }

//        public bool Handle(BaseOrderEntity data)
//        {
//            return _repository.UpdateAcceptance(data);
//        }
//    }
//}