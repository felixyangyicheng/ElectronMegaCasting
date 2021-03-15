using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaSolution.WebAssembly.Contracts;
using MegaSolution.WebAssembly.Models;
using MegaSolution.WebAssembly.Static;
using Microsoft.AspNetCore.Components;

namespace MegaSolution.WebAssembly.Pages.Studios
{
    public class IndexBase : ComponentBase
    {
        [Inject]
        public IStudioRepository _repo { get; set; }

        protected IList<Studio> Model;

        protected async override Task OnInitializedAsync()
        {
            Model = await _repo.Get(Endpoints.StudioEndpoint);

        }
    }
}
