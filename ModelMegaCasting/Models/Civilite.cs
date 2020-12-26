using System;
using System.Collections.Generic;

#nullable disable

namespace ApiMegaCasting
{
    public partial class Civilite
    {
        public Civilite()
        {
            Employes = new HashSet<Employe>();
            Internautes = new HashSet<Internaute>();
        }

        public int Id { get; set; }
        public string Libelle { get; set; }

        public virtual ICollection<Employe> Employes { get; set; }
        public virtual ICollection<Internaute> Internautes { get; set; }
    }
}
