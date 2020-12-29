using ApiMegaCasting;
using ElectronMegaCasting.Services.Signature;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronMegaCasting.Pages.PagesContrat
{
    public class ContratDetailsBase : ComponentBase
    {
        public Contrat Contrat { get; set; } = new Contrat();
        protected string ButtonText { get; set; } = "Cacher";
        protected string CssClass { get; set; } = null;
        [Inject]
        public IContratService ContratService { get; set; }
        [Parameter]
        public string Id { get; set; }

        protected async override Task OnInitializedAsync()
        {
            //Si la valuer {id} n'est pas précisée dans l'URL d'Api, la valeur par défaut sera 1.
            Id = Id ?? "1";
            Contrat = await ContratService.GetContrat(int.Parse(Id));
        }

        protected void Button_Click()
        {
            if (ButtonText == "Cacher")
            {
                ButtonText = "Cacher";
                CssClass = "HideFooter";
            }
            else
            {
                CssClass = null;
                ButtonText = "Cacher";
            }
        }
    }
}
