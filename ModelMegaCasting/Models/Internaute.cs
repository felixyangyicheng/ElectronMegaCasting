using DataAnnotationsExtensions;
using ModelMegaCasting.CustomValidator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ApiMegaCasting
{
    public partial class Internaute
    {
        public Internaute()
        {
            OffresInternautes = new HashSet<OffresInternaute>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
        public DateTime DateInscription { get; set; }
        public int IdCivilite { get; set; }
        public string LienGoogle { get; set; }
        public string Login { get; set; }
        
        public string Password { get; set; }
        public string Cv { get; set; }

        [EmailAddress]
        [EmailDomainValidator(AllowDomain = "fr", ErrorMessage = "Only .fr Email is allowed")]
        public string Email { get; set; }

        public virtual Civilite IdCiviliteNavigation { get; set; }
        public virtual ICollection<OffresInternaute> OffresInternautes { get; set; }
    }
}
