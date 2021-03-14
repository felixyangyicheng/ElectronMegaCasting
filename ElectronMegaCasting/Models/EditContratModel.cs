using ApiMegaCasting;
using System;
using System.ComponentModel.DataAnnotations;

namespace ElectronMegaCasting.Models
{
    public class EditContratModel
    {
        public int Id { get; set; }
        [Required]
        public int IdTypeContrat { get; set; }
        [Required]
        public DateTime DebutContrat { get; set; }
        [Required]
        public int DureContrat { get; set; }
        [Required]
        [MaxLength(50)]
        public string CodeContrat { get; set; }
        [Required]
        public string FichierContrat { get; set; }
        [Required]
        public int IdOffre { get; set; }
        [ValidateComplexType]
        public virtual Offre IdOffreNavigation { get; set; } = new Offre();
        [ValidateComplexType]
        public virtual TypeContrat IdTypeContratNavigation { get; set; } = new TypeContrat();
    }
}
