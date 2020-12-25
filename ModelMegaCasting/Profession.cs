using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelMegaCasting
{
    public class Profession
    {
        public int ProfessionId { get; set; }
        [Required]
        public string ProfessionName { get; set; }
        [Required]
        public int ProfessionSectorId { get; set; }
        [ValidateComplexType]
        public ProfessionSector ProfessionSector { get; set; }
    }
}
