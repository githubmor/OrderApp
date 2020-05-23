namespace OrderAndisheh.Domain.Repository
{
    public interface IReportRepository
    {
        bool GenerateReport(Interfaces.IReport data);
    }
}