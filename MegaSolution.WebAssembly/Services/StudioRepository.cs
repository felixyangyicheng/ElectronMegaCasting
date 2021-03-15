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
    public class StudioRepository : BaseRepository<Studio>, IStudioRepository
    {
        private readonly HttpClient _client;
        private readonly ILocalStorageService _localStorage;
        public StudioRepository(HttpClient client,
            ILocalStorageService localStorage) : base(client, localStorage)
        {
            _client = client;
            _localStorage = localStorage;
        }
    }
}
