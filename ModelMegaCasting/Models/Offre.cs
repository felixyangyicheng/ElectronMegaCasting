using System;
using System.Collections.Generic;

#nullable disable

namespace ApiMegaCasting
{
    public partial class Offre
    {
        public Offre()
        {
            Contrats = new HashSet<Contrat>();
            OffresInternautes = new HashSet<OffresInternaute>();
        }

        public int Id { get; set; }
        public int IdStudio { get; set; }
        public string Intitule { get; set; }
        public int IdMetier { get; set; }
        public DateTime DatePublication { get; set; }
        public int DureDiffusion { get; set; }
        public int NombrePostes { get; set; }
        public string DescriptionPoste { get; set; }
        public string DescriptionProfile { get; set; }
        public int IdEmploye { get; set; }
        public string Localisation { get; set; }
        public string CodeOffre { get; set; }

        public virtual Employe IdEmployeNavigation { get; set; }
        public virtual Metier IdMetierNavigation { get; set; }
        public virtual Studio IdStudioNavigation { get; set; }
        public virtual ICollection<Contrat> Contrats { get; set; }
        public virtual ICollection<OffresInternaute> OffresInternautes { get; set; }
    }
}
