//using OrderAndisheh.Domain.Interfaces;
//using OrderAndisheh.Domain.Repository;

//namespace OrderAndisheh.Domain.UseCase
//{
//    public class ReportGenaratorInteraction : IRequestHandler<IReport, bool>
//    {
//        private IReportRepository _repository;

//        public ReportGenaratorInteraction(IReportRepository repository)
//        {
//            _repository = repository;
//        }

//        public bool Handle(IReport data)
//        {
//            return _repository.GenerateReport(data);
//        }
//    }
//}