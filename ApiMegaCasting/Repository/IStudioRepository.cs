using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMegaCasting.Repository
{
    public interface IStudioRepository
    {
        //Liste de tous les Studios
        Task<IEnumerable<Studio>> GetStudios();
        //Liste de Studio par libelle
        Task<IEnumerable<Studio>> SearchByName(string libelle);
        //Liste de Studio par adresse
        Task<IEnumerable<Studio>> SearchByAddress(string adresse);
        //Studio par id
        Task<Studio> GetStudio(int idStudio);

        //Studio par Email
        Task<Studio> GetStudioByEmail(string email);
        //Studio par libelle
        Task<Studio> GetStudioByName(string libelle);
        //Ajouter un Studio
        Task<Studio> AddStudio(Studio Studio);
        //Mettre à jour un Studio
        Task<Studio> UpdateStudio(Studio Studio);
        //Supprimer un Studio
        Task<Studio> DeleteStudio(int idStudio);
    }
}
