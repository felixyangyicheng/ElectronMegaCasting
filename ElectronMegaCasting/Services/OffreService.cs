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
    public class OffreService:IOffreService
    {
        private readonly HttpClient _httpClient;
        public OffreService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
           
        }

        public async Task<Offre> AddOffre(Offre offre)
        {
            return await _httpClient.PostJsonAsync<Offre>($"api/offres", offre);
        }

        public async Task DeleteOffre(int idOffre)
        {
            await _httpClient.DeleteAsync($"api/offres/{idOffre}");
        }

        public async Task<Offre> GetOffre(int idOffre)
        {
            return await _httpClient.GetJsonAsync<Offre>($"api/offres/{idOffre}");
        }

        public async Task<Offre> GetOffreByCode(string code)
        {
            return await _httpClient.GetJsonAsync<Offre>($"api/offres/code/{code}");
        }

        public async Task<IEnumerable<Offre>> GetOffres()
        {
            return await _httpClient.GetJsonAsync<Offre[]>($"api/offres");
        }

        public async Task<IEnumerable<Offre>> SearchByLocation(string localisation)
        {
            return await _httpClient.GetJsonAsync<Offre[]>($"api/offres/location/{localisation}");
        }

        public async Task<IEnumerable<Offre>> SearchByTitle(string intitule)
        {
            return await _httpClient.GetJsonAsync<Offre[]>($"api/offres/title/{intitule}");
        }

        public async Task<Offre> UpdateOffre(Offre offre)
        {
            return await _httpClient.PutJsonAsync<Offre>($"api/offres", offre);
        }
    }
}
