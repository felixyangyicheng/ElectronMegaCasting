using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.Toast.Services;
using MegaSolution.WebAssembly.Contracts;
using MegaSolution.WebAssembly.Models;
using MegaSolution.WebAssembly.Static;
using Microsoft.AspNetCore.Components;

namespace MegaSolution.WebAssembly.Pages.Offers
{
    public class IndexBase : ComponentBase
    {
        [Inject]
        public IOfferRepository _repo { get; set; }
        [Inject]
        public IToastService _toastService { get; set; }
        [Inject]
        public NavigationManager _navManager { get; set; }

        protected IList<Offer> Model;




        protected string KeywordFilter = string.Empty;

        protected async override Task OnInitializedAsync()
        {

            Model = await _repo.Get(Endpoints.OfferEndpoint);

        }



        public object selectedSearchValue { get; set; }
        protected void MySearchHandler(object newValue)
        {
            selectedSearchValue = newValue;
        }
    }
}
