using System;
using System.Collections.Generic;

#nullable disable

namespace ApiMegaCasting
{
    public partial class DomaineMetier
    {
        public DomaineMetier()
        {
            Metiers = new HashSet<Metier>();
        }

        public int Id { get; set; }
        public string Libelle { get; set; }

        public virtual ICollection<Metier> Metiers { get; set; }
    }
}
