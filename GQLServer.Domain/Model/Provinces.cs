namespace GQLServer.Domain.Model
{
    public record Provinces
    {
        public string Province { get; set; }

        public int Confirmed { get; set; }

        public int Recovered { get; set; }

        public int Deaths { get; set; }

        public int Active { get; set; }

        public Provinces(string province, int confirmed, int recovered, int deaths, int active)
        {
            Province = province;
            Confirmed = confirmed;
            Recovered = recovered;
            Deaths = deaths;
            Active = active;
        }

    }
}
