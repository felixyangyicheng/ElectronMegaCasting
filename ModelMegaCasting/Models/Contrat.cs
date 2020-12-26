using System;
using System.Collections.Generic;

#nullable disable

namespace ApiMegaCasting
{
    public partial class Contrat
    {
        public int Id { get; set; }
        public int IdTypeContrat { get; set; }
        public DateTime DebutContrat { get; set; }
        public int DureContrat { get; set; }
        public string CodeContrat { get; set; }
        public string FichierContrat { get; set; }
        public int IdOffre { get; set; }

        public virtual Offre IdOffreNavigation { get; set; }
        public virtual TypeContrat IdTypeContratNavigation { get; set; }
    }
}
