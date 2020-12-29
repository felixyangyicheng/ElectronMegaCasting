using ElectronMegaCasting.Services.Signature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ElectronMegaCasting.Services
{
    public class EmployeService: IEmployeService
    {
        private readonly HttpClient _httpClient;
        public EmployeService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }
    }
}
