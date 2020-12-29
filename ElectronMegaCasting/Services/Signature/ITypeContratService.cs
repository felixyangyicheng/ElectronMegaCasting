using ApiMegaCasting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronMegaCasting.Services.Signature
{
    public interface ITypeContratService
    {
        //Liste de tous les types de contrat
        Task<IEnumerable<TypeContrat>> GetTypeContrats();
        //type par id
        Task<TypeContrat> GetTypeContrat(int idTypeContrat);
        //Ajouter un type
        Task<TypeContrat> AddTypeContrat(TypeContrat newTypeContrat);
        //Mettre à jour un type
        Task<TypeContrat> UpdateTypeContrat(TypeContrat updateTypeContrat);
        //Supprimer un type
        Task DeleteTypeContrat(int idTypeContrat);
    }
}
