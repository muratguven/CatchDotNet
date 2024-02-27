using CatchDotNet.Core.ElasticSearch;

namespace CatchDotNet.CustomerService.Api.Domain.Customers
{
    public interface ICustomerDetailKeyRepository : IElasticSearchRepository<CustomerDetailKey>
    {

    }
}
