using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using MegaSolution.WebAssembly.Contracts;
using MegaSolution.WebAssembly.Models;
using System.Net.Http;

namespace MegaSolution.WebAssembly.Services
{
    public class ProfessionRepository : BaseRepository<Profession>, IProfessionRepository
    {
        private readonly HttpClient _client;
        private readonly ILocalStorageService _localStorage;
        public ProfessionRepository(HttpClient client,
            ILocalStorageService localStorage) : base(client, localStorage)
        {
            _client = client;
            _localStorage = localStorage;
        }
    }
}
