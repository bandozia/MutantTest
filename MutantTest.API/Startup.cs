using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MutantTest.Infra.Service;
using Microsoft.EntityFrameworkCore;
using MutantTest.Infra.Repository;
using MutantTest.API.Service;

namespace MutantTest.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
                
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(config => 
            {
                config.JsonSerializerOptions.WriteIndented = true;                               
            });

            services.AddSwaggerGen(s => {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                s.IncludeXmlComments(xmlPath);
            });

            services.AddLogging(builder => {
                builder.AddFilter("Microsoft.EntityFrameworkCore", LogLevel.Critical);
                builder.AddFilter("Microsoft", LogLevel.Error);
            });

            services.AddDbContext<CoreContext>(options => options.UseMySql(Configuration.GetConnectionString("Core")));
            services.AddHttpClient<IDataDownloadService, DataDownloadService>();                        
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserDataService, UserDataService>();
        }
                
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory, CoreContext coreContext)
        {
            loggerFactory.AddFile($"{Directory.GetCurrentDirectory()}/Logs/log.txt");
            
            coreContext.Database.EnsureCreated();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(s => s.SwaggerEndpoint("/swagger/v1/swagger.json", "Mutant Test API"));
            }

            app.UseRouting();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
