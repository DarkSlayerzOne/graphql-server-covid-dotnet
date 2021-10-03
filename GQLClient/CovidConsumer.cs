using GraphQL.Client.Abstractions;

namespace GQLClient
{
    public class CovidConsumer
    {
        private readonly IGraphQLClient _client;

        public CovidConsumer(IGraphQLClient client)
        {
            _client = client;
        }

    }
}
