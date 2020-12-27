using ApiMegaCasting.Repository.Signature;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMegaCasting.Repository
{
    public class PartenaireRepository: IPartenaireRepository
    {
        private readonly AppDbContext _appDbContext;
        public PartenaireRepository(AppDbContext app)
        {
            this._appDbContext = app;
        }

        public async Task<Partenaire> AddPartenaire(Partenaire partenaire)
        {
            var result = await _appDbContext.Partenaires.AddAsync(partenaire);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Partenaire> DeletePartenaire(int idPartenaire)
        {
            var result = await _appDbContext.Partenaires
                 .FirstOrDefaultAsync(p=>p.Id==idPartenaire);
            if (result!=null)
            {
                _appDbContext.Partenaires.Remove(result);
                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Partenaire> GetPartenaire(int idPartenaire)
        {
            return await _appDbContext.Partenaires.FirstOrDefaultAsync(p => p.Id==idPartenaire) ;
        }

        public async Task<Partenaire> GetPartenaireByEmail(string email)
        {
            return await _appDbContext.Partenaires.FirstOrDefaultAsync(p => p.Email == email);
        }

        public async Task<Partenaire> GetPartenaireByLogin(string login)
        {
            return await _appDbContext.Partenaires.FirstOrDefaultAsync(p => p.Login == login);
        }

        public async Task<Partenaire> GetPartenaireByName(string libelle)
        {
            return await _appDbContext.Partenaires.FirstOrDefaultAsync(p => p.Libelle == libelle);
        }

        public async Task<IEnumerable<Partenaire>> GetPartenaires()
        {
            return await _appDbContext.Partenaires.ToListAsync();
        }

        public async Task<IEnumerable<Partenaire>> SearchByAddress(string adresse)
        {
            IQueryable<Partenaire> query =  _appDbContext.Partenaires;
            if (!string.IsNullOrEmpty(adresse))
            {
                query = query.Where(p => p.Adresse.Contains(adresse));
            }
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Partenaire>> SearchByName(string libelle)
        {
            IQueryable<Partenaire> query = _appDbContext.Partenaires;
            if (!string.IsNullOrEmpty(libelle))
            {
                query = query.Where(p => p.Adresse.Contains(libelle));
            }
            return await query.ToListAsync();
        }

        public async Task<Partenaire> UpdatePartenaire(Partenaire partenaire)
        {
            var result = await _appDbContext.Partenaires
                 .FirstOrDefaultAsync(p => p.Id == partenaire.Id);
            if (result!=null)
            {
                result.Siret = partenaire.Siret;
                result.Adresse = partenaire.Siret;
                result.NumeroAdresse = partenaire.NumeroAdresse;
                result.Libelle = partenaire.Libelle;
                result.Email = partenaire.Email;
                result.Telephone = partenaire.Telephone;
                result.Login = partenaire.Login;
                result.Password = partenaire.Password;

                await _appDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}
