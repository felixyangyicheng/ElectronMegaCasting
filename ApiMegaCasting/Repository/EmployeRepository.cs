using ApiMegaCasting.Repository.Signature;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMegaCasting.Repository
{
    public class EmployeRepository : IEmployeRepository
    {
        private readonly AppDbContext _appDbContext;

        public EmployeRepository(AppDbContext app)
        {
            this._appDbContext = app;
        }

        public async Task<Employe> AddEmploye(Employe employe)
        {
            var result = await _appDbContext.Employes
                 .AddAsync(employe);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Employe> DeleteEmploye(int idEmploye)
        {
            var result = await _appDbContext.Employes
                .FirstOrDefaultAsync(e => e.Id == idEmploye);
            if (result!=null)
            {
                if (!result.Offres.Any())
                {
                    _appDbContext.Employes.Remove(result);
                    await _appDbContext.SaveChangesAsync();
                    return result;

                }
                return null;
            }
            return null;
        }

        public async Task<Employe> GetEmploye(int idEmploye)
        {
            return await _appDbContext.Employes
                .Include(e => e.IdCiviliteNavigation)
                .Include(e => e.IdGroupeEmployesNavigation)
                .Include(e => e.Offres)
                .FirstOrDefaultAsync(e => e.Id == idEmploye);
        }

        public async Task<Employe> GetEmployeByLogin(string login)
        {
            return await _appDbContext.Employes
                 .Include(e => e.IdCiviliteNavigation)
                .Include(e => e.IdGroupeEmployesNavigation)
                .Include(e => e.Offres)
                .FirstOrDefaultAsync(e => e.Login == login);
        }

        public async Task<IEnumerable<Employe>> GetEmployes()
        {
            return await _appDbContext.Employes
                 .Include(e => e.IdCiviliteNavigation)
                .Include(e => e.IdGroupeEmployesNavigation)
                .Include(e => e.Offres).ToListAsync();
        }

        public async Task<IEnumerable<Employe>> Search(string nom, Civilite? civilite)
        {
            IQueryable<Employe> query = _appDbContext.Employes;
            if (!string.IsNullOrEmpty(nom))
            {
                query = query.Where(e => e.Nom.Contains(nom) || e.Prenom.Contains(nom));
            }
            if (civilite != null)
            {
                query = query.Where(e => e.IdCiviliteNavigation == civilite); 
            }
            return await query.ToListAsync();
        }

        public async Task<Employe> UpdateEmploye(Employe employe)
        {
            var result = await _appDbContext.Employes
                 .FirstOrDefaultAsync(e => e.Id == employe.Id);
            if (result!=null)
            {
                result.Nom = employe.Nom;
                result.Prenom = employe.Prenom;
                result.IdCivilite = employe.IdCivilite;
                result.IdGroupeEmployes = employe.IdGroupeEmployes;
                result.Login = employe.Login;
                result.Password = employe.Password;
                await _appDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}
