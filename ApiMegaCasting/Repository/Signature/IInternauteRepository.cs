using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMegaCasting.Repository.Signature
{
    public interface IInternauteRepository
    {
        //Liste de tous les internautes
        Task<IEnumerable<Internaute>> GetInternautes();
        //Internaute par id
        Task<Internaute> GetInternaute(int idInternaute);
        //Liste Internaute par Nom
        Task<IEnumerable<Internaute>> Search(string nom, Civilite? civilite);
        //Internaute par login
        Task<Internaute> GetInternauteByLogin(string login);
        //Internaute par email
        Task<Internaute> GetInternauteByEmail(string email);
        //Ajouter un internaute
        Task<Internaute> AddInternaute(Internaute internaute);
        //Mettre à jour un internaute
        Task<Internaute> UpdateInternaute(Internaute internaute);
        //Supprimer un internaute
        Task<Internaute> DeleteInternaute(int idInternaute);
    }
}
