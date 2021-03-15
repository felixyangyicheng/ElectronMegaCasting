using Blazored.LocalStorage;
using Blazored.Toast;
using MegaSolution.WebAssembly.Contracts;
using MegaSolution.WebAssembly.Providers;
using MegaSolution.WebAssembly.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MegaSolution.WebAssembly
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            _ = new JwtHeader();
            _ = new JwtPayload();


            builder.Services.AddScoped(sp => new HttpClient
            { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddBlazoredToast();
            builder.Services.AddScoped<ApiAuthenticationStateProvider>();
            builder.Services.AddScoped<AuthenticationStateProvider>(p =>
                p.GetRequiredService<ApiAuthenticationStateProvider>());
            builder.Services.AddTransient<IAuthenticationRepository, AuthenticationRepository>();
            builder.Services.AddTransient<IArtistRepository, ArtistRepository>();
            builder.Services.AddTransient<IContractRepository, ContractRepository>();

            builder.Services.AddTransient<IContractTypeRepository, ContractTypeRepository>();
            builder.Services.AddTransient<IProfessionRepository, ProfessionRepository>();
            builder.Services.AddTransient<IProfessionSectorRepository, ProfessionSectorRepository>();
            builder.Services.AddTransient<IStudioRepository, StudioRepository>();
            builder.Services.AddTransient<IOfferRepository, OfferRepository>();

            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            //builder.Services.AddTransient<IFileUpload, FileUpload>();
            await builder.Build().RunAsync();
        }
    }
}
