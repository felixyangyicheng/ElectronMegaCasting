using ApiMegaCasting.Models;
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



        public Task<Profession> GetProfession(int professionId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Profession>> GetProfessions()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Profession>> SearchProfession(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Profession> UpdateProfession(Profession profession)
        {
            throw new NotImplementedException();
        }
    }
}
