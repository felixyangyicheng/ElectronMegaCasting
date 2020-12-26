using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMegaCasting.Repository
{
    public interface IOffreRepository
    {
        //Liste de tous les offres
        Task<IEnumerable<Offre>> GetOffres();

        //Liste des offres par Intitulé
        Task<IEnumerable<Offre>> SearchByTitle(string intitule);

        //Liste des offres par localisation
        Task<IEnumerable<Offre>> SearchByLocation(string localisation);
        //Offre par CodeOffre
        Task<Offre> GetOffreByCode(string code);
        //Offre par Id
        Task<Offre> GetOffre(int idOffre);
        //Ajouter une offre
        Task<Offre> AddOffre(Offre offre);
        //Mettre à jour une offre
        Task<Offre> UpdateOffre(Offre offre);
        //Supprimer une offre
        Task<Offre> DeleteOffre(int idOffre);
    }
}
