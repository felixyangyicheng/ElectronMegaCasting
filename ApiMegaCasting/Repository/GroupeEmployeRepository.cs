using ApiMegaCasting.Repository.Signature;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMegaCasting.Repository
{
    public class GroupeEmployeRepository : IGroupeEmployeRepository
    {
        private readonly AppDbContext _appDbContext;
        public GroupeEmployeRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task<GroupeEmploye> AddGroupeEmploye(GroupeEmploye groupeEmploye)
        {
            var result = await _appDbContext.GroupeEmployes.AddAsync(groupeEmploye);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<GroupeEmploye> DeleteGroupeEmploye(int idGroupe)
        {
            var result = await _appDbContext.GroupeEmployes
                .FirstOrDefaultAsync(e => e.Id == idGroupe);
            if (result!=null)
            {
                if (!result.Employes.Any())
                {
                    _appDbContext.GroupeEmployes.Remove(result);
                    await _appDbContext.SaveChangesAsync();
                    return result;
                }
                return null;
            }
            return null;
        }

        public async Task<GroupeEmploye> GetGroupeEmploye(int idGroupe)
        {
            return await _appDbContext.GroupeEmployes
                 .Include(e => e.Employes)
                .FirstOrDefaultAsync(e => e.Id == idGroupe);
        }

        public async Task<GroupeEmploye> GetGroupeEmployeByName(string libelle)
        {
            return await _appDbContext.GroupeEmployes
                  .Include(e => e.Employes)
                .FirstOrDefaultAsync(e => e.Libelle == libelle);
        }

        public async Task<IEnumerable<GroupeEmploye>> GetGroupeEmployes()
        {
            return await _appDbContext.GroupeEmployes
                  .Include(e => e.Employes)
                  .ToListAsync();
        }

        public async Task<GroupeEmploye> UpdateGroupeEmploye(GroupeEmploye groupeEmploye)
        {
            var result = await _appDbContext.GroupeEmployes
                 .FirstOrDefaultAsync(e => e.Id == groupeEmploye.Id);
            if (result!=null)
            {
                result.Libelle = groupeEmploye.Libelle;
                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
