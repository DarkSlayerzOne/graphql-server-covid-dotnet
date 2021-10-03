using System.Collections.Generic;

namespace GQLClient
{
    public class CovidByCountry
    {

        public string Country { get; set; }

        public IEnumerable<Provinces> Provinces { get; set; }

    }

    public class Provinces
    {

        public int Confirmed { get; set; }

        public int Recovered { get; set; }

        public int Active { get; set; }
    }



}
