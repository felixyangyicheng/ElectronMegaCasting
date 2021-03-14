using ApiMegaCasting;
using AutoMapper;
using ElectronMegaCasting.Models;
using ElectronMegaCasting.Services.Signature;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronMegaCasting.Pages.PagesContrat
{
    public class EditContratBase : ComponentBase
    {
        [Inject]
        public IContratService ContratService { get; set; }
        public string PageHeeaderText { get; set; }
        private Contrat Contrat { get; set; }
        public EditContratModel EditContratModel { get; set; } = new EditContratModel();

        [Inject]
        public ITypeContratService TypeContratService { get; set; }
        public List<TypeContrat> TypeContrats { get; set; } = new List<TypeContrat>();
        [Inject]
        public IOffreService OffreService { get; set; }
        public List<Offre> Offres { get; set; } = new List<Offre>();

        [Parameter]
        public string Id { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected async override Task OnInitializedAsync()
        {
            int.TryParse(Id, out int contratId);
            if (contratId != 0)
            {
                PageHeeaderText = "Modifier le contrat";
                Contrat = await ContratService.GetContrat(int.Parse(Id));

            }
            else
            {
                PageHeeaderText = "Nouveau contrat";
                Contrat = new Contrat
                {
                    CodeContrat = "Saisir-un-code-unique",
                    DebutContrat = DateTime.Now,
                    DureContrat = 0,
                    IdOffre = 1,
                    IdTypeContrat = 1,
                    FichierContrat = "Ficher.pdf"
                };
            }

            Offres = (await OffreService.GetOffres()).ToList();
            TypeContrats = (await TypeContratService.GetTypeContrats()).ToList();
            Mapper.Map(Contrat, EditContratModel);

        }

        protected async Task HandleValidSubmit()
        {
            Mapper.Map(EditContratModel, Contrat);
            Contrat result = null;

            if (Contrat.Id != 0)
            {
                result = await ContratService.UpdateContrat(Contrat);
            }
            else
            {
                result = await ContratService.AddContrat(Contrat);

            }
            if (result != null)
            {
                NavigationManager.NavigateTo("/");
            }

        }

        protected async Task Delete_Click()
        {
            await ContratService.DeleteContrat(Contrat.Id);
            NavigationManager.NavigateTo("/");
        }
    }
}
