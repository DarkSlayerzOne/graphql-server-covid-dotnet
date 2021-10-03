using System.Net.Http;

namespace GQLServer.Data.Http
{
    public class CovidClient
    {
        public HttpClient HttpCLient { get; set; }

        public CovidClient(HttpClient http)
        {
            this.HttpCLient = http;
        }

    }
}
