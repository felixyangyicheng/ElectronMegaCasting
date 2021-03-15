using Blazored.Toast.Services;
using MegaSolution.WebAssembly.Contracts;
using MegaSolution.WebAssembly.Models;
using MegaSolution.WebAssembly.Static;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.WebAssembly.Pages.Contracts
{
    public class ViewBase : ComponentBase
    {
        [Inject]
        public IContractRepository _repo { get; set; }
        [Inject]
        public NavigationManager _navManager { get; set; }
        [Inject]
        public IToastService _toastService { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected Contract Model = new Contract();

        protected override async Task OnInitializedAsync()
        {
            int id = Convert.ToInt32(Id);
            Model = await _repo.Get(Endpoints.ContractEndpoint, id);

        }

        protected void BackToList()
        {
            _navManager.NavigateTo("/contracts/");
        }


    }
}
