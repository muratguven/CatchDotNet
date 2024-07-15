using CatchDotNet.Core.ElasticSearch;
using Elastic.Clients.Elasticsearch;

namespace CatchDotNet.WebApi;

public class CustomerDetailKeyRepository : ElasticSearchRepository<CustomerDetailKey>, ICustomerDetailKeyRepository
{
    

    public CustomerDetailKeyRepository(ILogger<ElasticSearchRepository<CustomerDetailKey>> logger, ElasticsearchClient client) : base(logger, client)
    {
            
    }


}
