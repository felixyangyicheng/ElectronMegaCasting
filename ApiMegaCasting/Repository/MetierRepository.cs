using ApiMegaCasting.Repository.Signature;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMegaCasting.Repository
{
    public class MetierRepository: IMertierRepository
    {
        private readonly AppDbContext _appDbContext;
        public MetierRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task<Metier> AddMetier(Metier metier)
        {
            var result = await _appDbContext.Metiers.AddAsync(metier);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Metier> DeleteMetier(int idMetier)
        {
            var result = await _appDbContext.Metiers.FirstOrDefaultAsync(m => m.Id == idMetier);
            if (result!=null)
            {
                if (!result.Offres.Any())
                {
                    _appDbContext.Metiers.Remove(result);
                    await _appDbContext.SaveChangesAsync();
                    return result;
                }
                return null;
            }
            return null;
        }

        public async Task<Metier> GetMetier(int idMetier)
        {
            return await _appDbContext.Metiers
                .Include(m=>m.IdDomaineMetierNavigation)
                .FirstOrDefaultAsync(m => m.Id == idMetier);
        }

        public async Task<Metier> GetMetierByName(string libelle)
        {
            return await _appDbContext.Metiers
                .Include(m => m.IdDomaineMetierNavigation)
                .FirstOrDefaultAsync(m => m.Libelle == libelle);
        }

        public async Task<IEnumerable<Metier>> GetMetiers()
        {
            return await _appDbContext.Metiers.ToListAsync();
        }

        public async Task<IEnumerable<Metier>> Search(string libelle)
        {
            IQueryable<Metier> query = _appDbContext.Metiers;
            if (!string.IsNullOrEmpty(libelle))
            {
                query = query.Where(m => m.Libelle.Contains(libelle));
            }
            return await query.ToListAsync();
        }

        public async Task<Metier> UpdateMetier(Metier metier)
        {
            var result = await _appDbContext.Metiers.FirstOrDefaultAsync(m => m.Id == metier.Id);
            if (result!=null)
            {
                result.Libelle = metier.Libelle;
                result.IdDomaineMetier = metier.IdDomaineMetier;
                await _appDbContext.SaveChangesAsync();
                return result;

            }
            return null;
        }
    }

}
