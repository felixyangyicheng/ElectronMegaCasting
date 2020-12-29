using ApiMegaCasting;
using ElectronMegaCasting.Services.Signature;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronMegaCasting.Pages.PagesContrat
{
    public class DisplayContratBase : ComponentBase
    {
        [Parameter]
        public Contrat Contrat { get; set; }
        [Parameter]
        public bool ShowFooter { get; set; }
        [Parameter]
        public EventCallback<bool> OnContratSelection { get; set; }

        [Parameter]
        public EventCallback<int> OnContratDeleted { get; set; }
        [Inject]
        public IContratService ContratService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected ConfirmBase DeleteConfirmation { get; set; }

        protected void Delete_Click()
        {
            DeleteConfirmation.Show();
            // NavigationManager.NavigateTo("/", true);
        }
        protected async Task ConfirmDelete_Click(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                await ContratService.DeleteContrat(Contrat.Id);
                await OnContratDeleted.InvokeAsync(Contrat.Id);
            }
        }
        protected async Task CheckBoxChanged(ChangeEventArgs e)
        {
            await OnContratSelection.InvokeAsync((bool)e.Value);
        }
    }
}
