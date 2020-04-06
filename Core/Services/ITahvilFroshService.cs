using Core.Models;
using System.Collections.Generic;

namespace Core.Services
{
    public interface ITahvilFroshService : IBaseService
    {
        List<Tahvil> ReadTahvilDataFromFile(string address);

        void SaveTahvilFrosh(List<Tahvil> tahvils);
    }
}