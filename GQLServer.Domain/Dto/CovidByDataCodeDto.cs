using System;

namespace GQLServer.Domain.Dto
{
    public record CovidByDataCodeDto
    {
        public string Country { get; set; }

        public int Confirmed { get; set; }

        public int Recovered { get; set; }

        public int Critical { get; set; }

        public int Deaths { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public DateTime? Date { get; set; }

        public CovidByDataCodeDto(string country,
                                  int confirmed,
                                  int recovered,
                                  int critical,
                                  int deaths, 
                                  string latitude, 
                                  string longitude, 
                                  DateTime? date)
        {
            Country = country;
            Confirmed = confirmed;
            Recovered = recovered;
            Critical = critical;
            Deaths = deaths;
            Latitude = latitude;
            Longitude = longitude;
            Date = date;
        }

    }
}
