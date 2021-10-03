using System.Collections.Generic;
using GQLServer.Data.Http;
using GQLServer.Data.Repository;
using GQLServer.Graph.Query;
using GQLServer.Service.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GQLServer
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
            services.AddScoped<ICovid, Covid>();
            services.AddScoped<ICovidService, CovidService>();
            services.AddHttpFactory(x =>
            {
                var getObject = Configuration.GetSection("CovidApi");


                var headers = new Dictionary<string, string>();
                headers.Add("X-RapidAPI-Host", getObject.GetSection("Host").Value);
                headers.Add("X-RapidAPI-Key", getObject.GetSection("ApiKey").Value);

                x.Headers = headers;
                x.Uri = getObject.GetSection("Url").Value;

            });

            services.AddGraphQLServer()
                    .AddQueryType<Query>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
        }
    }
}
