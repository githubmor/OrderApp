using Core.Models;
using System.Collections.Generic;

namespace Core.Services
{
    public interface IErsalService : IBaseService
    {
        ErsalDto SaveNewErsal(string tarikh);

        bool DeleteErsal(string tarikh);

        ErsalDto AcceptErsal(string tarikh);

        List<ErsalState> GetErsalStates(bool isShowAccepted);

        ErsalDto GetErsal(string tarikh);

        List<int> GetErsalYears();

        void Versioning(string p);
    }
}