using System;
using System.Collections.Generic;
using GQLServer.Domain.Model;

namespace GQLServer.Domain.Dto
{
    public record CovidDailyReportDto
    {
        public string Country { get; set; }

        public IEnumerable<Provinces> Provinces { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public DateTime? Date { get; set; }

        public CovidDailyReportDto(string country, IEnumerable<Provinces> provinces, string latitude, string longitude, DateTime? date)
        {
            Country = country;
            Provinces = provinces;
            Latitude = latitude;
            Longitude = longitude;
            Date = date;
        }


    }
}
