using Core.Models;
using System.Collections.Generic;

namespace Core.Services
{
    public interface IGozareshService
    {
        List<PalletGozaresh> GetPalletGozaresh(int az_tarikh, int ta_tarikh);

        List<SefareshatGozaresh> GetSefareshatGozaresh(int az_tarikh, int ta_tarikh);

        List<RanadeGozaresh> GetRanadeGozaresh(int az_tarikh, int ta_tarikh);

        List<KalaGozaresh> GetKalaGozaresh(int az_tarikh, int ta_tarikh);
    }
}