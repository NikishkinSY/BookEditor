using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BookEditor_Repository.Interfaces;
using BookEditor_Repository.Repositories;
using BookEditor_Model.Context;
using BookEditor_Web.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using BookEditor_Web.Modules;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Diagnostics;
using System.Text;

namespace BookEditor_Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true);
            Configuration = builder.Build();
        }

        public static IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver =
                    new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling =
                Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddDbContext<BookEditorContext>(options => 
                options.UseSqlServer(Startup.Configuration["ConnectionStrings:DefaultConnection"]));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
        {
            loggerFactory.AddConsole();

            //error handler
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    context.Response.StatusCode = 500; // or another Status accordingly to Exception Type
                    var error = context.Features.Get<IExceptionHandlerFeature>();
                    if (error != null)
                    {
                        serviceProvider.GetService<ILogger<Startup>>().LogError("{err}", error?.Error);
                        await context.Response.WriteAsync($"Error: {error?.Error.Message}");
                    }
                });
            });

            app.UseStaticFiles();

            app.UseMvc();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Book}/{action=Index}/{id?}");
            });

            //create maps
            Automapper.Configurate();

            //sample data
            var sampleData = new SampleData(
                serviceProvider.GetService<IBookRepository>(),
                serviceProvider.GetService<IAuthorRepository>());
            sampleData.Seed();
        }
    }
}
