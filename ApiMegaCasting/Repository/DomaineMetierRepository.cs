using ApiMegaCasting.Repository.Signature;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMegaCasting.Repository
{
    public class DomaineMetierRepository : IDomaineMetierRepository
    {
        private readonly AppDbContext _appDbContext;
        public DomaineMetierRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task<DomaineMetier> AddDomaineMetier(DomaineMetier domaineMetier)
        {
            var result = await _appDbContext.DomaineMetiers.AddAsync(domaineMetier);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<DomaineMetier> DeleteDomaineMetier(int IdDomaine)
        {
            var result = await _appDbContext.DomaineMetiers
                 .FirstOrDefaultAsync(dm => dm.Id == IdDomaine);
            if (!result.Metiers.Any())
            {
                _appDbContext.DomaineMetiers.Remove(result);
                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<DomaineMetier> GetDomaineMetier(int IdDomaine)
        {
            return await _appDbContext.DomaineMetiers
                     .FirstOrDefaultAsync(dm => dm.Id == IdDomaine);
        }

        public async Task<DomaineMetier> GetDomaineMetierByName(string libelle)
        {
            return await _appDbContext.DomaineMetiers
                .FirstOrDefaultAsync(dm => dm.Libelle == libelle);
        }

        public async Task<IEnumerable<DomaineMetier>> GetDomaineMetiers()
        {
            return await _appDbContext.DomaineMetiers.ToListAsync();
        }

        public async Task<DomaineMetier> UpdateDomaineMetier(DomaineMetier domaine)
        {
            var result = await _appDbContext.DomaineMetiers
                .FirstOrDefaultAsync(dm => dm.Id == domaine.Id);
            if (result != null)
            {
                result.Libelle = domaine.Libelle;
                await _appDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}
