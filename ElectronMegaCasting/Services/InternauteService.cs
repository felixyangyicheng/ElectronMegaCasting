using ElectronMegaCasting.Services.Signature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ElectronMegaCasting.Services
{
    public class InternauteService: IInternauteService
    {
        private readonly HttpClient _httpClient;
        public InternauteService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }
    }
}
