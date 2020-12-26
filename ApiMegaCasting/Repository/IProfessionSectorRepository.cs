using ModelMegaCasting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMegaCasting.Repository
{
    public interface IProfessionSectorRepository
    {
        
        Task<IEnumerable<ProfessionSector>> GetProfessionSectors();

        Task<ProfessionSector> GetProfessionSector(int sectorId);

        Task<ProfessionSector> GetProfessionSectorByName(string ssectorName);

        Task<ProfessionSector> AddProfessionSector(ProfessionSector professionSector);
        Task<ProfessionSector> UpdateProfessionSector(ProfessionSector professionSector);

        Task<ProfessionSector> DeleteProfessionSector(int sectorId);
    }
}
