using Elastic.Clients.Elasticsearch;

namespace CatchDotNet.Core.ElasticSearch
{
    public class ElasticSearchClientContext : IElasticSearchClientContext
    {
        private readonly IElasticsearchClientSettings settings;

        public ElasticSearchClientContext(IElasticsearchClientSettings settings)
        {
            this.settings = settings;
            SetClient();
        }

        public ElasticsearchClient Client { get; protected set; }

        private void SetClient()
        {

            Client = new ElasticsearchClient(settings);

        }

       


    }
}
