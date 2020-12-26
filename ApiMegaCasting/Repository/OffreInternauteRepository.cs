using ApiMegaCasting.Repository.Signature;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMegaCasting.Repository
{
    public class OffreInternauteRepository: IOffreInternauteRepository
    {
        private readonly AppDbContext _app;
        public OffreInternauteRepository(AppDbContext app)
        {
            this._app = app;
        }

        public async Task<IEnumerable<OffresInternaute>> GetOffresInternautes()
        {
            return await _app.OffresInternautes.ToListAsync();
        }
    }
}
