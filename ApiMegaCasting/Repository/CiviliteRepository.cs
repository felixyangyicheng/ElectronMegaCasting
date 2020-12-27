using ApiMegaCasting.Repository.Signature;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMegaCasting.Repository
{
    public class CiviliteRepository: ICiviliteRepository
    {
        private readonly AppDbContext _appDbContext;
        public CiviliteRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task<Civilite> GetCivilite(int civiliteId)
        {
            return await _appDbContext.Civilites
                .FirstOrDefaultAsync(c => c.Id == civiliteId);
        }

        public async Task<IEnumerable<Civilite>> GetCivilites()
        {
            return await _appDbContext.Civilites.ToListAsync();
        }
    }
}
