using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelMegaCasting
{
    public class Studio
    {
        public int StudioId { get; set; }
        [Required]
        [StringLength(14, MinimumLength = 14)]
        public string Siret { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int AddressNumber { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string StudioName { get; set; }
        [Required]
        [StringLength(5, MinimumLength = 5)]
        public string PostCode { get; set; }
        [Required]
        public string City { get; set; }
    }
}
