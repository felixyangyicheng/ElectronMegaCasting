using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.Toast.Services;
using MegaSolution.WebAssembly.Contracts;
using MegaSolution.WebAssembly.Models;
using MegaSolution.WebAssembly.Static;
using Microsoft.AspNetCore.Components;

namespace MegaSolution.WebAssembly.Pages.ProfessionSectors
{
    public class IndexBase : ComponentBase
    {
        [Inject]
        public IProfessionSectorRepository _repo { get; set; }

        protected IList<ProfessionSector> Model;

        protected async override Task OnInitializedAsync()
        {
            Model = await _repo.Get(Endpoints.ProfessionSectorEndpoint);

        }
    }
}
