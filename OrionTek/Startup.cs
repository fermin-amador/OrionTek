using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
using OrionTek.Business.Services;
using OrionTek.Data;
using OrionTek.Data.Models;
using OrionTek.Data.Repositories;
using OrionTek.Interfaces.Repositories;
using OrionTek.Interfaces.Services;
using OrionTek.Services;

namespace OrionTek
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
            services.AddControllers().AddNewtonsoftJson(options =>
            { options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore; });


            //Swagger
            AddSwagger(services);

            //SQLServer
            services.AddDbContext<OrionTekDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DB")));

            //Services
            services.AddScoped<IClienteServices,ClienteServices>();
            services.AddScoped<IEmpresaServices,EmpresaServices>();
            services.AddScoped<IDireccionServices,DireccionServices>();

            //Repositories
            services.AddScoped<IClienteRepository,ClienteRepository>();
            services.AddScoped<IEmpresaRepository,EmpresaRepository>();
            services.AddScoped<IDireccionRepository, DireccionRepository>();

            // Add Cors
            services.AddCors(x => x.AddPolicy("Cors", settings =>   
            settings.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

           

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("Cors");

            app.UseHttpsRedirection();

            //Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "OrionTek API V1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }



        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"OrionTek {groupName}",
                    Version = groupName,
                    Description = "Foo API",
                    Contact = new OpenApiContact
                    {
                        Name = "OrionTek Company",
                        Email = string.Empty,
                        Url = new Uri("https://foo.com/"),
                    }
                });
            });
        }



    }
}
