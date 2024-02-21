using CatchDotNet.Core;
using CatchDotNet.Core.Data;

namespace CatchDotNet.CustomerService.Api
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        /// <summary>
        /// Paged List
        /// </summary>
        /// <param name="totalCount"></param>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<List<Customer>> GetPagedListAsync(int skip, int pageSize, CancellationToken cancellationToken);
        /// <summary>
        /// Get total customer count
        /// </summary>
        /// <returns></returns>
        Task<int> GetTotalCountAsync(CancellationToken cancellationToken);
        /// <summary>
        /// Add a customer's detail 
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="detail"></param>
        /// <returns></returns>
        Task CreateCustomerDetailAsync(Guid customerId, CustomerDetail detail, CancellationToken cancellationToken);
        /// <summary>
        /// Has the customer detail 
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<bool> HasDetail(Guid customerId, string key, CancellationToken cancellationToken);
    }
}
