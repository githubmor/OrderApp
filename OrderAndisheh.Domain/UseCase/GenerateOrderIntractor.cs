//using OrderAndisheh.Domain.Entity;
//using OrderAndisheh.Domain.Repository;

//namespace OrderAndisheh.Domain.UseCase
//{
//    public class GenerateOrderIntractor : IRequestHandler<int, OrderEntity?>
//    {
//        private IOrderRepository _repository;

//        public GenerateOrderIntractor(IOrderRepository repository)
//        {
//            _repository = repository;
//        }

//        public OrderEntity? Handle(int tarikh)
//        {
//            return _repository.GetOrder(tarikh);
//        }
//    }
//}