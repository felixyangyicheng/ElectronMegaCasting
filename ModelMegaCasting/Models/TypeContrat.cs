using System;
using System.Collections.Generic;

#nullable disable

namespace ApiMegaCasting
{
    public partial class TypeContrat
    {
        public TypeContrat()
        {
            Contrats = new HashSet<Contrat>();
        }

        public int Id { get; set; }
        public string Libelle { get; set; }

        public virtual ICollection<Contrat> Contrats { get; set; }
    }
}
