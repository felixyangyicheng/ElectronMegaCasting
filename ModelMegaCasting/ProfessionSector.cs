using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelMegaCasting
{
    public class ProfessionSector
    {
        public int ProfessionSectorId { get; set; }
        [Required]
        public string SectorName { get; set; }
        public List<Profession> Professions { get; set; }
    }
}
