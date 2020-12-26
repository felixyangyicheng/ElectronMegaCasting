using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMegaCasting.Repository.Signature
{
    public interface IDomaineMetierRepository
    {
        //Liste de tous les domaines
        Task<IEnumerable<DomaineMetier>> GetDomaineMetiers();
        //DomaineMetier par Id
        Task<DomaineMetier> GetDomaineMetier(int IdDomaine);
        //DomaineMetier par Libelle
        Task<DomaineMetier> GetDomaineMetierByName(string libelle);
        //Ajouter un domaine
        Task<DomaineMetier> AddDomaineMetier(DomaineMetier domaineMetier);
        //Mettre à jour un domaine
        Task<DomaineMetier> UpdateDomaineMetier(DomaineMetier domaine);
        //Supprimer un domaine
        Task<DomaineMetier> DeleteDomaineMetier(int IdDomaine);
    }
}
