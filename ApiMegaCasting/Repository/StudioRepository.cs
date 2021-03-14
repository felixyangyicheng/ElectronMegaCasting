using ApiMegaCasting.Repository.Signature;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMegaCasting.Repository
{
    public class StudioRepository: IStudioRepository
    {
        private readonly AppDbContext _appDbContext;
        public StudioRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task<Studio> AddStudio(Studio Studio)
        {
            var result = await _appDbContext.Studios.AddAsync(Studio);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Studio> DeleteStudio(int idStudio)
        {
            var result = await _appDbContext.Studios
                .FirstOrDefaultAsync(p => p.Id == idStudio);
            if (result != null)
            {
                if (!result.Offres.Any())
                {
                    _appDbContext.Studios.Remove(result);
                    await _appDbContext.SaveChangesAsync();
                    return result;
                }
                return null;
            }
            return null;
        }

        public async Task<Studio> GetStudio(int idStudio)
        {
            return await _appDbContext.Studios
                .Include(s=>s.Offres)
                .FirstOrDefaultAsync(p => p.Id == idStudio);
        }

        public async Task<Studio> GetStudioByEmail(string email)
        {
            return await _appDbContext.Studios.FirstOrDefaultAsync(p => p.Email == email);
        }
    

        public async Task<Studio> GetStudioByName(string libelle)
        {
            return await _appDbContext.Studios.FirstOrDefaultAsync(p => p.Libelle == libelle);
        }

        public async Task<IEnumerable<Studio>> GetStudios()
        {
            return await _appDbContext.Studios
                .Include(s => s.Offres)
                .ToListAsync();
        }

        public async Task<IEnumerable<Studio>> SearchByAddress(string adresse)
        {
            IQueryable<Studio> query = _appDbContext.Studios;
            if (!string.IsNullOrEmpty(adresse))
            {
                query = query.Where(p => p.Adresse.Contains(adresse));
            }
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Studio>> SearchByName(string libelle)
        {
            IQueryable<Studio> query = _appDbContext.Studios;
            if (!string.IsNullOrEmpty(libelle))
            {
                query = query.Where(p => p.Adresse.Contains(libelle));
            }
            return await query.ToListAsync();
        }

        public async Task<Studio> UpdateStudio(Studio Studio)
        {
            var result = await _appDbContext.Studios
                 .FirstOrDefaultAsync(p => p.Id == Studio.Id);
            if (result != null)
            {
                result.Siret = Studio.Siret;
                result.Adresse = Studio.Siret;
                result.NumeroAdresse = Studio.NumeroAdresse;
                result.Libelle = Studio.Libelle;
                result.Email = Studio.Email;
                result.Telephone = Studio.Telephone;
                

                await _appDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}
