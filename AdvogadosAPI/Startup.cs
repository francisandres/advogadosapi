using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvogadosAPI.DataContext;
using AdvogadosAPI.Repositório;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AdvogadosAPI
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
            services.AddDbContext<AdvogadosContexto>(opt =>
               opt.UseInMemoryDatabase("Advogados"));

            services.AddScoped<IAdvgRepositorio, AdvgRepositorio>();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsLaw", p =>
                {
                    p.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
                }

                );
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Entidades.Cliente, DTO.ClienteDTO>();
                cfg.CreateMap<Entidades.ProcessoCliente, DTO.ProcessoClienteDTO>();
            });

            app.UseCors(c => c.WithOrigins("http://localhost:4200").AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
            );

            app.UseMvc();
        }
    }
}
