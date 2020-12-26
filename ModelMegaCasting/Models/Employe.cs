using System;
using System.Collections.Generic;

#nullable disable

namespace ApiMegaCasting
{
    public partial class Employe
    {
        public Employe()
        {
            Offres = new HashSet<Offre>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int IdCivilite { get; set; }
        public int IdGroupeEmployes { get; set; }
        public string Login { get; set; }

        
        public string Password { get; set; }

        public virtual Civilite IdCiviliteNavigation { get; set; }
        public virtual GroupeEmploye IdGroupeEmployesNavigation { get; set; }
        public virtual ICollection<Offre> Offres { get; set; }
    }
}
