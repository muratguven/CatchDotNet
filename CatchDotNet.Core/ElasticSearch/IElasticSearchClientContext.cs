using Elastic.Clients.Elasticsearch;

namespace CatchDotNet.Core.ElasticSearch
{
    public interface IElasticSearchClientContext
    {
        ElasticsearchClient Client { get; }
    }
}
