using ModelMegaCasting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMegaCasting.Repository
{
    public interface IProfessionRepository
    {
        Task<IEnumerable<Profession>> GetProfessions();

        Task<Profession> GetProfession(int professionId);

        Task<Profession> AddProfession(Profession profession);

        Task<Profession> UpdateProfession(Profession profession);

        Task<Profession> DeleteProfession(int professionId);
        Task<IEnumerable<Profession>> SearchProfession(string name);
    }
}
