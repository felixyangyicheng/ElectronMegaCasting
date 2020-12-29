using ApiMegaCasting;
using ElectronMegaCasting.Services.Signature;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ElectronMegaCasting.Services
{
    public class TypeContratService: ITypeContratService
    {
        private readonly HttpClient _httpClient;
        public TypeContratService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<TypeContrat> AddTypeContrat(TypeContrat newTypeContrat)
        {
            return await _httpClient.PostJsonAsync<TypeContrat>($"api/typecontrats", newTypeContrat);
        }

        public async Task DeleteTypeContrat(int idTypeContrat)
        {
            await _httpClient.DeleteAsync($"api/typecontrats/{idTypeContrat}");
        }

        public async Task<TypeContrat> GetTypeContrat(int idTypeContrat)
        {
            return await _httpClient.GetJsonAsync<TypeContrat>($"api/civilites/{idTypeContrat}");
        }

        public async Task<IEnumerable<TypeContrat>> GetTypeContrats()
        {
            return await _httpClient.GetJsonAsync<TypeContrat[]>($"api/typecontrats");
        }

        public async Task<TypeContrat> UpdateTypeContrat(TypeContrat updateTypeContrat)
        {
            return await _httpClient.PutJsonAsync<TypeContrat>($"api/typecontrats", updateTypeContrat);
        }
    }
}
