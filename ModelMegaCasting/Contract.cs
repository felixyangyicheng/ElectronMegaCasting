using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelMegaCasting
{
    public class Contract
    {
        public int ContractId { get; set; }
        [Required]
        public DateTime ContractBegins { get; set; }
        [Required]
        public int ContractDuration { get; set; }
        [Required]
        [StringLength(5, MinimumLength = 2)]
        public string ContractReference { get; set; }
        [Required]
        public string ContractPdfFile { get; set; }
        
        
        public ContractType ContractType { get; set; }
        [Required]
        public int OfferId { get; set; }
        [ValidateComplexType]
        public Offer Offer { get; set; }
    }
}
