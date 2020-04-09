using Core.Models;
using System.Collections.Generic;

namespace Core.Services
{
    public interface IShakhesService : IBaseService
    {
        void SetTolidKhodro(List<TolidKhodro> tolids);

        List<Shakesh> GetShakhes(int mah);
    }
}