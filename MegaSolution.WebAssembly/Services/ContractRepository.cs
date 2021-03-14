using Blazored.LocalStorage;
using MegaSolution.WebAssembly.Contracts;
using MegaSolution.WebAssembly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MegaSolution.WebAssembly.Services
{
    public class ContractRepository : BaseRepository<Contract>, IContractRepository
    {
        private readonly HttpClient _client;
        private readonly ILocalStorageService _localStorage;
        public ContractRepository(HttpClient client,
            ILocalStorageService localStorage) : base(client, localStorage)
        {
            _client = client;
            _localStorage = localStorage;
        }
    }
}
