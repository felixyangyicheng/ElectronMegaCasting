using ApiMegaCasting.Repository.Signature;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMegaCasting.Repository
{
    public class InternauteRepository: IInternauteRepository
    {
        private readonly AppDbContext _appDbContext;
        public InternauteRepository(AppDbContext app)
        {
            this._appDbContext = app;
        }

        public async  Task<Internaute> AddInternaute(Internaute internaute)
        {
            var result = await _appDbContext.Internautes.AddAsync(internaute);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Internaute> DeleteInternaute(int idInternaute)
        {
            var result = await _appDbContext.Internautes
                 .FirstOrDefaultAsync(i => i.Id == idInternaute);
            if (result!=null)
            {
                if (!result.OffresInternautes.Any())
                {
                    _appDbContext.Internautes.Remove(result);
                    await _appDbContext.SaveChangesAsync();
                    return result;
                }
                return null;
            }
            return null;
        }

        public async Task<Internaute> GetInternaute(int idInternaute)
        {
            return await _appDbContext.Internautes
                 .Include(i => i.IdCiviliteNavigation)
                 .FirstOrDefaultAsync(i => i.Id == idInternaute);
        }

        public async Task<Internaute> GetInternauteByEmail(string email)
        {
            return await _appDbContext.Internautes
                 .Include(i => i.IdCiviliteNavigation)
                 .FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task<Internaute> GetInternauteByLogin(string login)
        {
            return await _appDbContext.Internautes
                 .Include(i => i.IdCiviliteNavigation)
                .FirstOrDefaultAsync(e => e.Login == login);
        }

        public async Task<IEnumerable<Internaute>> GetInternautes()
        {
            return await _appDbContext.Internautes.ToListAsync();
        }

        public async Task<IEnumerable<Internaute>> Search(string nom, Civilite civilite)
        {
            IQueryable<Internaute> query = _appDbContext.Internautes;
            if (!string.IsNullOrEmpty(nom))
            {
                query = query.Where(i => i.Nom.Contains(nom) || i.Prenom.Contains(nom));
            }
            if (civilite!=null)
            {
                query = query.Where(i => i.IdCiviliteNavigation == civilite);

            }
            return await query.ToListAsync();
        }

        public async Task<Internaute> UpdateInternaute(Internaute internaute)
        {
            var result = await _appDbContext.Internautes
                .FirstOrDefaultAsync(i => i.Id == internaute.Id);
            if (result!=null)
            {
                result.Email = internaute.Email;
                result.Cv = internaute.Cv;
                result.DateInscription = internaute.DateInscription;
                result.DateNaissance = internaute.DateNaissance;
                result.IdCivilite = internaute.IdCivilite;
                result.LienGoogle = internaute.LienGoogle;
                result.Login = internaute.Login;
                result.Password = internaute.Password;
                result.Nom = internaute.Nom;
                result.Prenom = internaute.Prenom;

                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
