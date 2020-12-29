using ApiMegaCasting;
using ElectronMegaCasting.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronMegaCasting.Pages
{
    public class CiviliteListBase:ComponentBase
    {
        [Inject]
        public ICiviliteService _CiviliteService { get; set; }
        public IEnumerable<Civilite> Civilites { get; set; }


        protected override async Task OnInitializedAsync()
        {
            Civilites = (await _CiviliteService.GetCivilites()).ToList();
        }
    }
}
