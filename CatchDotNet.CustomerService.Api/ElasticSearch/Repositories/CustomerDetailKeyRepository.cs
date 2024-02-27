using CatchDotNet.Core.ElasticSearch;
using CatchDotNet.CustomerService.Api.Domain.Customers;
using Elastic.Clients.Elasticsearch;

namespace CatchDotNet.CustomerService.Api.ElasticSearch.Repositories
{
    public class CustomerDetailKeyRepository : ElasticSearchRepository<CustomerDetailKey>, ICustomerDetailKeyRepository
    {
        

        public CustomerDetailKeyRepository(ILogger<ElasticSearchRepository<CustomerDetailKey>> logger, ElasticsearchClient client) : base(logger, client)
        {
                
        }


    }
}
