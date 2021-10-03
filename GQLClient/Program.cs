using System;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Microsoft.Extensions.DependencyInjection;

namespace GQLClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            do
            {
                var collection = new ServiceCollection();
                collection.AddScoped<IGraphQLClient>(g => new GraphQLHttpClient("http://localhost:8300/graphql/",
                                                          new NewtonsoftJsonSerializer()));
                collection.AddScoped<CovidConsumer>();

                var serviceProvider = collection.BuildServiceProvider();
                var graphQlService = serviceProvider.GetService<IGraphQLClient>();

                Console.WriteLine("Check COVID 19 by country name and the specific date.");
                Console.WriteLine();
                Console.WriteLine("Type country a name");
                var countryName = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Type a date format should be YYYY-MM-DD");
                var date = Console.ReadLine();


                var query = new GraphQLRequest
                {
                    Query = @"
                            query QueryCovid($countryName: String, $date: String) {
                              queryCovidDailyReport(countryName: $countryName, date: $date) {
                                    country
                                    provinces {
                                      confirmed
                                      recovered
                                      active
                                   }
                               }
                            }
                          ",
                    OperationName = "QueryCovid",
                    Variables = new
                    {
                        CountryName = countryName,
                        Date = date
                    }

                };


                var result = await graphQlService.SendQueryAsync<CovidResponse>(query);
                var covidResult = result.Data.QueryCovidDailyReport;
                Console.WriteLine();
                Console.WriteLine("Here is the result");

                foreach (var covid in covidResult)
                {
                    Console.WriteLine($"Country: \t {covid.Country}");

                    foreach (var province in covid.Provinces)
                    {
                        Console.WriteLine($"Confirmed Cases: \t {province.Confirmed} \n" +
                                          $"Recovered Patients: \t {province.Recovered} \n" +
                                          $"Active Patients: \t {province.Active}");
                    }

                }


                Console.WriteLine();
                Console.WriteLine("PRESS ENTER TO DO ANOTHER");

                Console.ReadLine();

            } while (true);
        }
    }
}
