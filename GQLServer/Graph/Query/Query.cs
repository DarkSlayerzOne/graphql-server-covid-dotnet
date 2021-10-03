using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GQLServer.Domain.Dto;
using GQLServer.Service.Service;
using HotChocolate;
using Microsoft.Extensions.Logging;

namespace GQLServer.Graph.Query
{
     
    [GraphQLDescription("Covid 19 data query.")]
    public class Query
    {
        private readonly ICovidService _covid;

        private readonly ILogger<Query> _queryLogger;

        public Query(ICovidService covid, ILogger<Query> queryLogger)
        {
            _covid = covid ?? throw new ArgumentNullException(nameof(covid));
            _queryLogger = queryLogger ?? throw new ArgumentNullException(nameof(queryLogger));
        }

        public Task<IEnumerable<CovidByDataCodeDto>> QueryCovidData(string code)
        {
            this._queryLogger.LogInformation("Initiate call api covid data by country code");
            return this._covid.CovidByDataCode(code);
        }

        public Task<IEnumerable<CovidDailyReportDto>> QueryCovidDailyReport(string countryName, string date)
        {
            this._queryLogger.LogInformation("Initiate call api of covid daily report");
            return this._covid.CovidDailyReport(countryName, date);
        }

    }
}
