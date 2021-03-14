using ApiMegaCasting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronMegaCasting.Services.Signature
{
    public interface IContratService
    {
        //Rechercher Contrat avec le Code de contrat similaire (référence)
        Task<IEnumerable<Contrat>> Search(string codeContrat);
        // Liste de tous les contrats
        Task<IEnumerable<Contrat>> GetContrats();
        //Contrat par Id de contrat
        Task<Contrat> GetContrat(int IdContrat);
        //Rechercher Contrat avec le code de contrat
        //Task<Contrat> GetContratByCode(string codeContrat);
        //Ajouter un contrat
        Task<Contrat> AddContrat(Contrat contrat);
        //Metter à jour un contrat
        Task<Contrat> UpdateContrat(Contrat contrat);
        //Supprimer
        Task DeleteContrat(int IdContrat);
    }
}
