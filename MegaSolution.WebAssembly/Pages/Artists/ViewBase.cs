﻿using Blazored.Toast.Services;
using MegaSolution.WebAssembly.Contracts;
using MegaSolution.WebAssembly.Models;
using MegaSolution.WebAssembly.Static;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.WebAssembly.Pages.Artists
{
    public class ViewBase : ComponentBase
    {
        [Inject]
        public IArtistRepository _repo { get; set; }
        [Inject]

        public NavigationManager _navManager { get; set; }
        [Inject]

        public IToastService _toastService { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected Artist Model = new Artist();

        protected override async Task OnInitializedAsync()
        {
            int id = Convert.ToInt32(Id);
            Model = await _repo.Get(Endpoints.ArtistEndpoint, id);

        }

        protected void BackToList()
        {
            _navManager.NavigateTo("/artists/");
        }

        protected void GoToEdit()
        {
            _navManager.NavigateTo($"/artists/edit/{Model.ArtistId}");
        }

        protected void GoToDelete()
        {
            _navManager.NavigateTo($"/artists/delete/{Model.ArtistId}");
        }
    }
}
