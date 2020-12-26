using System;
using System.Collections.Generic;

#nullable disable

namespace ApiMegaCasting
{
    public partial class Metier
    {
        public Metier()
        {
            Offres = new HashSet<Offre>();
        }

        public int Id { get; set; }
        public string Libelle { get; set; }
        public int IdDomaineMetier { get; set; }

        public virtual DomaineMetier IdDomaineMetierNavigation { get; set; }
        public virtual ICollection<Offre> Offres { get; set; }
    }
}
