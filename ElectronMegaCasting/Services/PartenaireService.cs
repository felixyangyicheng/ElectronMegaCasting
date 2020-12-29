using ElectronMegaCasting.Services.Signature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ElectronMegaCasting.Services
{
    public class PartenaireService: IPartenaireService
    {
        private readonly HttpClient _httpClient;
        public PartenaireService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }
    }
}
