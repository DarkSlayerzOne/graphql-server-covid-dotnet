using System;
using Microsoft.Extensions.DependencyInjection;
using GQLServer.Domain.Constants;
using Polly;
using Polly.Extensions.Http;
using System.Net.Http;

namespace GQLServer.Data.Http
{
    public static class HttpFactoryExtension
    {

        public static void AddHttpFactory(this IServiceCollection service, Action<Prerequisite> prerequisite)
        {

            var apiPrerequisite = new Prerequisite();
            prerequisite(apiPrerequisite);

           service.AddHttpClient<CovidClient>(x =>
           {
               x.BaseAddress = new Uri(apiPrerequisite.Uri);

               foreach (var headers in apiPrerequisite.Headers)
               {
                   x.DefaultRequestHeaders.Add(headers.Key, headers.Value);
               }

               x.DefaultRequestHeaders.Add("Accept", "application/json");
           })
             .SetHandlerLifetime(TimeSpan.FromMinutes(5))
             .AddPolicyHandler(GetRetryPolicy());

        }


        static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                    .HandleTransientHttpError()
                    .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                    .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }


    }
}
