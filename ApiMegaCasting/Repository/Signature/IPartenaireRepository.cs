using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMegaCasting.Repository.Signature
{
    public interface IPartenaireRepository
    {
        //Liste de tous les partenaires
        Task<IEnumerable<Partenaire>> GetPartenaires();
        //Liste de partenaire par libelle
        Task<IEnumerable<Partenaire>> SearchByName(string libelle);
        //Liste de partenaire par adresse
        Task<IEnumerable<Partenaire>> SearchByAddress(string adresse);
        //Partenaire par id
        Task<Partenaire> GetPartenaire(int idPartenaire);

        //Partenaire par Email
        Task<Partenaire> GetPartenaireByEmail(string email);
        //Partenaire par libelle
        Task<Partenaire> GetPartenaireByName(string libelle);
        //Partenaire par login
        Task<Partenaire> GetPartenaireByLogin(string login);
        //Ajouter un partenaire
        Task<Partenaire> AddPartenaire(Partenaire partenaire);
        //Mettre à jour un partenaire
        Task<Partenaire> UpdatePartenaire(Partenaire partenaire);
        //Supprimer un partenaire
        Task<Partenaire> DeletePartenaire(int idPartenaire);
    }
}
