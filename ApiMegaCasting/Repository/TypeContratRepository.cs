using ApiMegaCasting.Repository.Signature;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMegaCasting.Repository
{
    public class TypeContratRepository: ITypeContratRepository
    {
        private readonly AppDbContext _appDbContext;
        public TypeContratRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task<TypeContrat> AddTypeContrat(TypeContrat TypeContrat)
        {
            var result = await _appDbContext.TypeContrats.AddAsync(TypeContrat);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TypeContrat> DeleteTypeContrat(int idTypeContrat)
        {
            var result = await _appDbContext.TypeContrats
                  .FirstOrDefaultAsync(p => p.Id == idTypeContrat);
            if (result != null)
            {
                if (!result.Contrats.Any())
                {

                    _appDbContext.TypeContrats.Remove(result);
                    await _appDbContext.SaveChangesAsync();
                    return result;
                }
            }
            return null;
        }

        public async Task<TypeContrat> GetTypeContrat(int idTypeContrat)
        {
            return await _appDbContext.TypeContrats
                .Include(p=>p.Contrats)
                .FirstOrDefaultAsync(p => p.Id == idTypeContrat);
        }

        public async Task<IEnumerable<TypeContrat>> GetTypeContrats()
        {
            return await _appDbContext.TypeContrats
                 .Include(p => p.Contrats)
                .ToListAsync();
        }

        public async Task<TypeContrat> UpdateTypeContrat(TypeContrat TypeContrat)
        {
            var result = await _appDbContext.TypeContrats
                 .FirstOrDefaultAsync(p => p.Id == TypeContrat.Id);
            if (result != null)
            {
                result.Libelle = TypeContrat.Libelle;
               

                await _appDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}
