using System;
using System.Collections.Generic;

#nullable disable

namespace ApiMegaCasting
{
    public partial class Studio
    {
        public Studio()
        {
            Offres = new HashSet<Offre>();
        }

        public int Id { get; set; }
        public string Siret { get; set; }
        public string Adresse { get; set; }
        public int NumeroAdresse { get; set; }
        public string Libelle { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }

        public virtual ICollection<Offre> Offres { get; set; }
    }
}
