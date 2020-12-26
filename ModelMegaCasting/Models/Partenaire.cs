using System;
using System.Collections.Generic;

#nullable disable

namespace ApiMegaCasting
{
    public partial class Partenaire
    {
        public int Id { get; set; }
        public string Siret { get; set; }
        public string Adresse { get; set; }
        public int NumeroAdresse { get; set; }
        public string Libelle { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
