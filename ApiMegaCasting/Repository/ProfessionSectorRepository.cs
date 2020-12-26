using ApiMegaCasting.Models;
using Microsoft.EntityFrameworkCore;
using ModelMegaCasting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMegaCasting.Repository
{
    public class ProfessionSectorRepository : IProfessionSectorRepository
    {
        private readonly AppDbContext _appDbContext;
        public ProfessionSectorRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }
        public async Task<ProfessionSector> AddProfessionSector(ProfessionSector professionSector)
        {
            var result = await _appDbContext.ProfessionSectors.AddAsync(professionSector);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<ProfessionSector> DeleteProfessionSector(int sectorId)
        {
            var result = await _appDbContext.ProfessionSectors
                .FirstOrDefaultAsync(s=>s.ProfessionSectorId==sectorId);
            if (result!=null)
            {
                _appDbContext.ProfessionSectors.Remove(result);
                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<ProfessionSector> GetProfessionSector(int sectorId)
        {
            return await _appDbContext.ProfessionSectors
                .FirstOrDefaultAsync(s => s.ProfessionSectorId == sectorId);
        }

        public async Task<ProfessionSector> GetProfessionSectorByName(string sectorName)
        {
            return await _appDbContext.ProfessionSectors
                .FirstOrDefaultAsync(s => s.SectorName == sectorName);
        }

        public async Task<IEnumerable<ProfessionSector>> GetProfessionSectors()
        {
            return await _appDbContext.ProfessionSectors.ToListAsync();
        }

        public async Task<ProfessionSector> UpdateProfessionSector(ProfessionSector professionSector)
        {
            var result = await _appDbContext.ProfessionSectors
                .FirstOrDefaultAsync(s => s.ProfessionSectorId == professionSector.ProfessionSectorId);

            if (result!=null)
            {
                result.SectorName = professionSector.SectorName;
                await _appDbContext.SaveChangesAsync();
                return result;

            }
            return null;
        }
    }
}
