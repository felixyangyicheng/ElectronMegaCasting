using ModelMegaCasting.CustomValidator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelMegaCasting
{
    public class Artist
    {
        public int ArtistId { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string FirstName { get; set; }
        [StringLength(100, MinimumLength = 2)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        [EmailDomainValidator(AllowDomain = "fr", ErrorMessage = "Only .fr Email is allowed")]
        public string Email { get; set; }
        public string ProfilePhoto { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }
        public string ArtistName { get; set; }
        public Civilities Civilities { get; set; }
        public string CV { get; set; }
    }
}
