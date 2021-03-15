using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.Toast.Services;
using MegaSolution.WebAssembly.Contracts;
using MegaSolution.WebAssembly.Models;
using MegaSolution.WebAssembly.Static;
using Microsoft.AspNetCore.Components;

namespace MegaSolution.WebAssembly.Pages.Studios
{
    public class ViewBase : ComponentBase
    {
        [Inject]
        public IStudioRepository _repo { get; set; }
        [Inject]

        public NavigationManager _navManager { get; set; }
        [Inject]

        public IToastService _toastService { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected Studio Model = new Studio();

        protected override async Task OnInitializedAsync()
        {
            int id = Convert.ToInt32(Id);
            Model = await _repo.Get(Endpoints.StudioEndpoint, id);

        }

        protected void BackToList()
        {
            _navManager.NavigateTo("/studios/");
        }
    }
}
