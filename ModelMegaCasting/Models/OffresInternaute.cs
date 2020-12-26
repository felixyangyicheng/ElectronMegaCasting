using System;
using System.Collections.Generic;

#nullable disable

namespace ApiMegaCasting
{
    public partial class OffresInternaute
    {
        public int IdInternaute { get; set; }
        public int IdOffre { get; set; }
        public DateTime DatePostulation { get; set; }

        public virtual Internaute IdInternauteNavigation { get; set; }
        public virtual Offre IdOffreNavigation { get; set; }
    }
}
