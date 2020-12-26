using ApiMegaCasting.Repository.Signature;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMegaCasting.Repository
{
    public class ContratRepository : IContratRepository
    {
        private readonly AppDbContext _appDbContext;
        public ContratRepository(AppDbContext app)
        {
            this._appDbContext = app;
        }
        public async Task<Contrat> AddContrat(Contrat contrat)
        {
            var result = await _appDbContext.Contrats.AddAsync(contrat);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Contrat> DeleteContrat(int IdContrat)
        {
            var result = await _appDbContext.Contrats
                 .FirstOrDefaultAsync(c => c.Id == IdContrat);
       
            if (result != null)
            {
                _appDbContext.Contrats.Remove(result);
                await _appDbContext.SaveChangesAsync();
                return result;
            
            }
                return null;
        }

        public async Task<Contrat> GetContrat(int IdContrat)
        {
            return await _appDbContext.Contrats
                .Include(c => c.IdOffreNavigation)
                .Include(c=>c.IdTypeContratNavigation)
                .FirstOrDefaultAsync(c => c.Id == IdContrat);
        }

        public async Task<Contrat> GetContratByCode(string codeContrat)
        {
            return await _appDbContext.Contrats
                 .Include(c => c.IdOffreNavigation)
                .Include(c => c.IdTypeContratNavigation)
                 .FirstOrDefaultAsync(c => c.CodeContrat == codeContrat);
        }

        public async Task<IEnumerable<Contrat>> GetContrats()
        {
            return await _appDbContext.Contrats.ToListAsync();
        }

        public async Task<IEnumerable<Contrat>> Search(string codeContrat)
        {
            IQueryable<Contrat> query = _appDbContext.Contrats;
            if (!string.IsNullOrEmpty(codeContrat))
            {
                query = query.Where(c => c.CodeContrat.Contains(codeContrat));
            }
            return await query.ToListAsync();
        }

        public async Task<Contrat> UpdateContrat(Contrat contrat)
        {
            var result = await _appDbContext.Contrats
                 .FirstOrDefaultAsync(c => c.Id == contrat.Id);
            if (result!=null)
            {
                result.DebutContrat = contrat.DebutContrat;
                result.IdTypeContrat = contrat.IdTypeContrat;
                result.DureContrat = contrat.DureContrat;
                result.CodeContrat = contrat.CodeContrat;
                result.FichierContrat = contrat.FichierContrat;
                result.IdOffre = contrat.IdOffre;
                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
