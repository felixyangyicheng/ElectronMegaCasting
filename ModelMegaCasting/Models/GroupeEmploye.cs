using System;
using System.Collections.Generic;

#nullable disable

namespace ApiMegaCasting
{
    public partial class GroupeEmploye
    {
        public GroupeEmploye()
        {
            Employes = new HashSet<Employe>();
        }

        public int Id { get; set; }
        public string Libelle { get; set; }

        public virtual ICollection<Employe> Employes { get; set; }
    }
}
