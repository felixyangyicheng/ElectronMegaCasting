using ApiMegaCasting;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ElectronMegaCasting.Services
{
    public class CiviliteService: ICiviliteService
    {
        private readonly HttpClient _httpClient;
        public CiviliteService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<Civilite> GetCivilite(int id)
        {
            return await _httpClient.GetJsonAsync<Civilite>($"api/civilite/{id}");
        }

        public async Task<IEnumerable<Civilite>> GetCivilites()
        {
            return await _httpClient.GetJsonAsync<Civilite[]>($"api/civilites");
        }
    }
}
