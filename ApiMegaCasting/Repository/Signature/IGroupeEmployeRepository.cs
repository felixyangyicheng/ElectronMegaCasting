using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMegaCasting.Repository.Signature
{
    public interface IGroupeEmployeRepository
    {
        //Liste de tous les groupes
        Task<IEnumerable<GroupeEmploye>> GetGroupeEmployes();
        //Groupe par Id
        Task<GroupeEmploye> GetGroupeEmploye(int idGroupe);

        //Groupe par libellé
        Task<GroupeEmploye> GetGroupeEmployeByName(string libelle);

        //Ajouter un groupe
        Task<GroupeEmploye> AddGroupeEmploye(GroupeEmploye groupeEmploye);
        //Mettre à jour un groupe
        Task<GroupeEmploye> UpdateGroupeEmploye(GroupeEmploye groupeEmploye);

        //Supprimer un greoupe
        Task<GroupeEmploye> DeleteGroupeEmploye(int idGroupe);
    }
}
