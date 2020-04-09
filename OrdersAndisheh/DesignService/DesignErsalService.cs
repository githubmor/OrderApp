using Core.Models;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersAndisheh.DesignService
{
    public class DesignErsalService : IErsalService
    {
        
        public bool DeleteErsal(string tarikh)
        {
            throw new NotImplementedException();
        }

        public ErsalDto AcceptErsal(string tarikh)
        {
            return new ErsalDto() { Tarikh = tarikh,IsAccepted = true };
        }

        public Core.Models.ErsalDto GetErsal(string tarikh)
        {
            return getErsals().SingleOrDefault(p=>p.Tarikh==tarikh);
        }
        private List<ErsalDto> getErsals()
        {
            return new List<ErsalDto>()
            {
                new ErsalDto() { Tarikh = "1398/11/28",IsAccepted = false },
                new ErsalDto() { Tarikh = "1398/11/29",IsAccepted = false },
                new ErsalDto() { Tarikh = "1398/11/30",IsAccepted = true },
                new ErsalDto() { Tarikh = "1398/11/27",IsAccepted = false },
            };
        }

        public List<int> GetErsalYears()
        {
            return new List<int>(){1398,1399,1400};
        }


        public List<ErsalState> GetErsalStates(bool isShowAccepted)
        {
            if (isShowAccepted)
                return getErsals()
                    .ConvertAll<ErsalState>(k => new ErsalState() { TarikhSefaresh = k.Tarikh, IsEveryThingOk = k.IsAccepted });
            else
                return getErsals().Where(p => !p.IsAccepted).ToList()
                    .ConvertAll<ErsalState>(k => new ErsalState() { TarikhSefaresh = k.Tarikh, IsEveryThingOk = k.IsAccepted });
        }

        public ErsalDto SaveNewErsal(string tarikh)
        {
            return new ErsalDto() { Tarikh = tarikh };
        }

        private int year;

        public void ChangeDatabase(int _year)
        {
            year = _year;
        }
    }
}
