namespace GQLServer.Data.Http
{
    public class HttpConfigurations
    {
        public string Uri { get; set; }

        public string SerlizedObject { get; set; }

        public HttpConfigurations(string uri, string serialized)
        {
            Uri = uri;
            SerlizedObject = serialized;
        }

    }
}
