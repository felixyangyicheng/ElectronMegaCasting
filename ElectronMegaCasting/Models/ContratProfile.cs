
using ApiMegaCasting;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronMegaCasting.Models
{
    public class ContratProfile:Profile
    {
        public ContratProfile()
        {
            CreateMap<Contrat, EditContratModel>().ReverseMap();
        }
    }
}
