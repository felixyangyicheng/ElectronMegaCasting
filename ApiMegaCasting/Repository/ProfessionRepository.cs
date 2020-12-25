using ApiMegaCasting.Models;
using Microsoft.EntityFrameworkCore;
using ModelMegaCasting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMegaCasting.Repository
{
    public class ProfessionRepository : IProfessionRepository
    {
        private readonly AppDbContext _appDbContext;
        public ProfessionRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task<Profession> AddProfession(Profession profession)
        {
            var result = await _appDbContext.Professions.AddAsync(profession);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Profession> DeleteProfession(int professionId)
        {
            var result = await _appDbContext.Professions.FirstOrDefaultAsync(p => p.ProfessionId == professionId);
            if (result!=null)
            {
                _appDbContext.Professions.Remove(result);
                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Profession> GetProfession(int professionId)
        {
            return await _appDbContext.Professions
                .Include(p => p.ProfessionSector)
                .FirstOrDefaultAsync(p => p.ProfessionId == professionId);
        }

        public async Task<Profession> GetProfessionByName(string name)
        {
            return await _appDbContext.Professions
                .FirstOrDefaultAsync(p => p.ProfessionName == name);
        }

        public async Task<IEnumerable<Profession>> GetProfessions()
        {
            return await _appDbContext.Professions.ToListAsync();
        }

        public async  Task<IEnumerable<Profession>> SearchProfession(string name)
        {
            IQueryable<Profession> query = _appDbContext.Professions;
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(p => p.ProfessionName.Contains(name));
            }
            return await query.ToListAsync();
        }

        public async Task<Profession> UpdateProfession(Profession profession)
        {
            var result = await _appDbContext.Professions
                .FirstOrDefaultAsync(p => p.ProfessionId == profession.ProfessionId);
            if (result!=null)
            {
                result.ProfessionName = profession.ProfessionName;
                result.ProfessionSectorId = profession.ProfessionSectorId;

                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
