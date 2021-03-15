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
    public class IndexBase : ComponentBase
    {
        [Inject]
        public IContractRepository _repo { get; set; }
        [Inject]
        public IToastService _toastService { get; set; }

        protected IList<Contract> Model;

        protected async override Task OnInitializedAsync()
        {
            Model = await _repo.Get(Endpoints.ContractEndpoint);
        }
    }
}
