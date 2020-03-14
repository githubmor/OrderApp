using Core.Models;
using System.Collections.Generic;

namespace Core.Services
{
    public interface IReportService
    {
        void ExportReport(ErsalReportKind kind, ErsalDto ersal, List<ItemDto> items);
    }

    public enum ErsalReportKind
    {
        Bazres, Andisheh, Imen, Kontrol, ListErsal, Bime, KaverMadarek, BargePanjere, Kartabl, CheckList
    }
}