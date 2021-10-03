using System.Collections.Generic;

namespace GQLClient
{
    public record CovidResponse
    {
        public List<CovidByCountry> QueryCovidDailyReport { get; set; }
    }

   
}
