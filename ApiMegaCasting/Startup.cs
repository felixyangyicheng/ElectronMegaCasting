using ModelMegaCasting;
using ApiMegaCasting.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMegaCasting.Repository.Signature;

namespace ApiMegaCasting
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));

            #region Repository
            services.AddScoped<ICiviliteRepository, CiviliteRepository>();
            services.AddScoped<IContratRepository, ContratRepository>();
            services.AddScoped<IDomaineMetierRepository, DomaineMetierRepository>();
            services.AddScoped<IEmployeRepository, EmployeRepository>();
            services.AddScoped<IGroupeEmployeRepository, GroupeEmployeRepository>();
            services.AddScoped<IInternauteRepository, InternauteRepository>();
            services.AddScoped<IMertierRepository, MetierRepository>();
            services.AddScoped<IOffreInternauteRepository, OffreInternauteRepository>();
            services.AddScoped<IOffreRepository, OffreRepository>();
            services.AddScoped<IPartenaireRepository, PartenaireRepository>();
            services.AddScoped<IStudioRepository, StudioRepository>();
            services.AddScoped<ITypeContratRepository, TypeContratRepository>();
            #endregion
            services.AddControllers().AddNewtonsoftJson(options=>
            options.SerializerSettings.ReferenceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiMegaCasting", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiMegaCasting v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
