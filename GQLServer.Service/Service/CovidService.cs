using System.Collections.Generic;
using System.Threading.Tasks;
using GQLServer.Data.Repository;
using GQLServer.Domain.Dto;

namespace GQLServer.Service.Service
{
    public class CovidService : ICovidService
    {
        private readonly ICovid _covid;

        public CovidService(ICovid covid)
        {
            _covid = covid;
        }

        public Task<IEnumerable<CovidByDataCodeDto>> CovidByDataCode(string code)
                => this._covid.CovidByDataCode(code);

        public Task<IEnumerable<CovidDailyReportDto>> CovidDailyReport(string countryName, string date)
                => this._covid.CovidDailyReport(countryName, date);
    }
}
