using System.Collections.Generic;
using System.Threading.Tasks;
using GQLServer.Domain.Dto;

namespace GQLServer.Data.Repository
{
    public interface ICovid
    {
       Task<IEnumerable<CovidByDataCodeDto>> CovidByDataCode(string code);

        Task<IEnumerable<CovidDailyReportDto>> CovidDailyReport(string countryName, string date);

    }
}
