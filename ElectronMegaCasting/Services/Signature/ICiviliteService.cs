using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMegaCasting;


namespace ElectronMegaCasting.Services
{
    public interface ICiviliteService
    {
        Task<IEnumerable<Civilite>> GetCivilites();
        Task<Civilite> GetCivilite(int id);
    }
}
