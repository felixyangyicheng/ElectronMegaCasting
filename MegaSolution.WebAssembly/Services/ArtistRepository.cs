using Blazored.LocalStorage;
using MegaSolution.WebAssembly.Contracts;
using MegaSolution.WebAssembly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MegaSolution.WebAssembly.Services
{
    public class ArtistRepository : BaseRepository<Artist>, IArtistRepository
    {
        private readonly HttpClient _client;
        private readonly ILocalStorageService _localStorage;
        public ArtistRepository(HttpClient client,
            ILocalStorageService localStorage) : base(client, localStorage)
        {
            _client = client;
            _localStorage = localStorage;
        }
    }
}
