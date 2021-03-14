using Blazored.LocalStorage;
using MegaSolution.WebAssembly.Contracts;
using MegaSolution.WebAssembly.Models;
using MegaSolution.WebAssembly.Providers;
using MegaSolution.WebAssembly.Static;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MegaSolution.WebAssembly.Services
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly HttpClient _client;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public AuthenticationRepository(HttpClient client,
            ILocalStorageService localStorage,
            AuthenticationStateProvider authenticationStateProvider)
        {
            _client = client;
            _localStorage = localStorage;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<bool> Login(LoginModel user)
        {
            var response = await _client.PostAsJsonAsync(Endpoints.LoginEndpoint, user);
            Console.WriteLine(response.StatusCode);
            if (!response.IsSuccessStatusCode)
            {
                return false;
            }

            var content = await response.Content.ReadAsStringAsync();
            var token = JsonConvert.DeserializeObject<TokenResponse>(content);

            //stocker Token
            await _localStorage.SetItemAsync("authToken", token.Token);

            //Changer statut d'authentification de l'application
            await ((ApiAuthenticationStateProvider)_authenticationStateProvider)
                .LoggedIn();

            _client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", token.Token);

            return true;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((ApiAuthenticationStateProvider)_authenticationStateProvider)
                .LoggedOut();
        }

        public async Task<bool> Register(RegistrationModel user)
        {
            var response = await _client.PostAsJsonAsync(Endpoints.RegisterEndpoint
                , user);
            return response.IsSuccessStatusCode;
        }
    }
}
