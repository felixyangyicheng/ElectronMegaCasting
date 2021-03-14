using ApiMegaCasting.Repository.Signature;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMegaCasting.Repository
{
    public class OffreRepository: IOffreRepository
    {
        private readonly AppDbContext _appDbContext;
        public OffreRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task<Offre> AddOffre(Offre offre)
        {
            var result = await _appDbContext.Offres.AddAsync(offre);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Offre> DeleteOffre(int idOffre)
        {
            var result = await _appDbContext.Offres
                 .FirstOrDefaultAsync(o => o.Id == idOffre);
            if (result!=null)
            {
                if (!result.Contrats.Any()&&!result.OffresInternautes.Any())
                {
                    _appDbContext.Offres.Remove(result);
                    await _appDbContext.SaveChangesAsync();
                    return result;
                }
                return null;
            }
            return null;
        }

        public async Task<Offre> GetOffre(int idOffre)
        {
            return await _appDbContext.Offres
                .Include(o=>o.Contrats)
                .Include(o=>o.IdEmployeNavigation)
                .Include(o=>o.IdMetierNavigation)
                .Include(o=>o.IdStudioNavigation)
                .FirstOrDefaultAsync(o => o.Id == idOffre);
        }

        public async Task<Offre> GetOffreByCode(string code)
        {
            return await _appDbContext.Offres
                .Include(o => o.Contrats)
                .Include(o => o.IdEmployeNavigation)
                .Include(o => o.IdMetierNavigation)
                .Include(o => o.IdStudioNavigation)
                .FirstOrDefaultAsync(o => o.CodeOffre == code);
        }

        public async Task<IEnumerable<Offre>> GetOffres()
        {
            return await _appDbContext.Offres.ToListAsync();
        }

        public async Task<IEnumerable<Offre>> SearchByLocation(string localisation)
        {
            IQueryable<Offre> query = _appDbContext.Offres;
            if (!string.IsNullOrEmpty(localisation))
            {
                query = query.Where(o => o.Localisation.Contains(localisation));
            }
            return await query.ToListAsync();
          
        }

        public async Task<IEnumerable<Offre>> SearchByTitle(string intitule)
        {
            IQueryable<Offre> query = _appDbContext.Offres;
            if (!string.IsNullOrEmpty(intitule))
            {
                query = query.Where(o => o.Intitule.Contains(intitule));
            }
            return await query.ToListAsync();

        }

        public async Task<Offre> UpdateOffre(Offre offre)
        {
            var result = await _appDbContext.Offres
                .FirstOrDefaultAsync(o=>o.Id== offre.Id);
            if (result!=null)
            {
                result.IdStudio = offre.IdStudio;
                result.Intitule = offre.Intitule;
                result.IdMetier = offre.IdMetier;
                result.DatePublication = offre.DatePublication;
                result.DureDiffusion = offre.DureDiffusion;
                result.NombrePostes = offre.NombrePostes;
                result.DescriptionPoste = offre.DescriptionPoste;
                result.DescriptionProfile = offre.DescriptionProfile;
                result.IdEmploye = offre.IdEmploye;
                result.Localisation = offre.Localisation;
                result.CodeOffre = offre.CodeOffre;

                await _appDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}
