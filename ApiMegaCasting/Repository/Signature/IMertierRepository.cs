using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMegaCasting.Repository.Signature
{
    public interface IMertierRepository
    {
        //List de tous les métiers
        Task<IEnumerable<Metier>> GetMetiers();
        //Liste de Métiers par nom
        Task<IEnumerable<Metier>> Search(string libelle);
        //Métier par Id
        Task<Metier> GetMetier(int idMetier);

        //Métier par nom
        Task<Metier> GetMetierByName(string libelle);
        //Ajouter un métier
        Task<Metier> AddMetier(Metier metier);

        //Mettre à jour un métier
        Task<Metier> UpdateMetier(Metier metier);

        //Supprimer un métier
        Task<Metier> DeleteMetier(int idMetier);
    }
}
