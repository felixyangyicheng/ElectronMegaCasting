using ApiMegaCasting;
using ElectronMegaCasting.Services.Signature;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ElectronMegaCasting.Services
{
    public class ContratService:IContratService
    {
        private readonly HttpClient _httpClient;
        public ContratService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<Contrat> AddContrat(Contrat contrat)
        {
            return await _httpClient.PostJsonAsync<Contrat>($"api/contrats", contrat);
        }

        public async Task DeleteContrat(int IdContrat)
        {
            await _httpClient.DeleteAsync($"api/contrats/{IdContrat}");
        }

        public async Task<Contrat> GetContrat(int IdContrat)
        {
            return await _httpClient.GetJsonAsync<Contrat>($"api/contrats/{IdContrat}");
        }

        public async Task<Contrat> GetContratByCode(string codeContrat)
        {
            return await _httpClient.GetJsonAsync<Contrat>($"api/contrats/code/{codeContrat}");
        }

        public async Task<IEnumerable<Contrat>> GetContrats()
        {
            return await _httpClient.GetJsonAsync<Contrat[]>($"api/contrats");
        }

        public async Task<IEnumerable<Contrat>> Search(string codeContrat)
        {
            return await _httpClient.GetJsonAsync<Contrat[]>($"api/contrats/search?code={codeContrat}");
        }

        public async Task<Contrat> UpdateContrat(Contrat contrat)
        {
            return await _httpClient.PutJsonAsync<Contrat>($"api/contrats", contrat); ;
        }
    }
}
