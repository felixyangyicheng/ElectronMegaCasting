using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMegaCasting.Repository
{
    public interface ICiviliteRepository
    {
        Task<IEnumerable<Civilite>> GetCivilites();
        Task<Civilite> GetCivilite(int civiliteId);

    }
}
