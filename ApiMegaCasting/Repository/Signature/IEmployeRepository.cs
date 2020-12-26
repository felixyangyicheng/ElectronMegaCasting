using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMegaCasting.Repository.Signature
{
    public interface IEmployeRepository
    {
        // Rechercher employé par nom et civilité, nullable pour civilité
        Task<IEnumerable<Employe>> Search(string nom, Civilite? civilite);
        //Liste de tous les employés
        Task<IEnumerable<Employe>> GetEmployes();

        //Employé par Id
        Task<Employe> GetEmploye(int idEmploye);
        //Employé par Login
        Task<Employe> GetEmployeByLogin(string login);
        //Ajouter un employé
        Task<Employe> AddEmploye(Employe employe);
        //Mettre à jour un employé
        Task<Employe> UpdateEmploye(Employe employe);
        //Supprimer un employé
        Task<Employe> DeleteEmploye(int idEmploye);
    }
}
