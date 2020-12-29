using ApiMegaCasting;
using ElectronMegaCasting.Services.Signature;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronMegaCasting.Pages.PagesContrat
{
    public class ContratListBase:ComponentBase
    {
        [Inject]
        public IContratService ContratService { get; set; }
        public IEnumerable<Contrat> Contrats { get; set; }
        public bool ShowFooter { get; set; } = true;
        protected override async Task OnInitializedAsync()
        {
            Contrats = (await ContratService.GetContrats()).ToList();
        }

        protected async Task ContratDeleted()
        {
            Contrats = (await ContratService.GetContrats()).ToList();
        }
        protected int SelectedContratCount { get; set; }
        protected void ContratSelectionChanged(bool isSelected)
        {
            if (isSelected)
            {
                SelectedContratCount++;
            }
            else
            {
                SelectedContratCount--;
            }
        }
    }
}
