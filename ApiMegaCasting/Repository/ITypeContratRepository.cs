using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMegaCasting.Repository
{
    public interface ITypeContratRepository
    {
        //Liste de tous les types de contrat
        Task<IEnumerable<TypeContrat>> GetTypeContrats();
        //type par id
        Task<TypeContrat> GetTypeContrat(int idTypeContrat);
        //Ajouter un type
        Task<TypeContrat> AddTypeContrat(TypeContrat TypeContrat);
        //Mettre à jour un type
        Task<TypeContrat> UpdateTypeContrat(TypeContrat TypeContrat);
        //Supprimer un type
        Task<TypeContrat> DeleteTypeContrat(int idTypeContrat);
    }
}
