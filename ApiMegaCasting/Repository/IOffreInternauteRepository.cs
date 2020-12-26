using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMegaCasting.Repository
{
    public interface IOffreInternauteRepository
    {
        //Liste de tous les Offre-Internaute
        Task<IEnumerable<OffresInternaute>> GetOffresInternautes();
        
    }
}
