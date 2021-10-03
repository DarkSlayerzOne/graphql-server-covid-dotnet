using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GQLServer.Data.Http;
using GQLServer.Domain.Dto;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace GQLServer.Data.Repository
{
    public class Covid : ICovid
    {

        private readonly CovidClient _covid;

        private readonly ILogger<Covid> _logger;

        public Covid(CovidClient covid, ILogger<Covid> logger)
        {
            _covid = covid ?? throw new ArgumentNullException(nameof(covid));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        public async Task<IEnumerable<CovidByDataCodeDto>> CovidByDataCode(string code)
        {
            try
            {

                var result = await this._covid.HttpCLient.GetAsync($"/country/code?code={code}");

                var response = JsonConvert.DeserializeObject<IEnumerable<CovidByDataCodeDto>>(await result.Content.ReadAsStringAsync());

                return response;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }

        }

        public async Task<IEnumerable<CovidDailyReportDto>> CovidDailyReport(string countryName, string date)
        {
            try
            {
                var result = await this._covid.HttpCLient.GetAsync($"/report/country/name?name={countryName}&date={date}");

                var response = JsonConvert.DeserializeObject<IEnumerable<CovidDailyReportDto>>(await result.Content.ReadAsStringAsync());

                return response;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }
        }


    }
}
