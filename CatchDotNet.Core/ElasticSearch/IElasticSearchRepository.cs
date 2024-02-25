namespace CatchDotNet.Core.ElasticSearch
{
    public interface IElasticSearchRepository<T>
    {
        /// <summary>
        /// Create index if it is not exist
        /// </summary>
        /// <param name="indexName"></param>
        /// <returns></returns>
        Task CreateIndex(string indexName = null);

        /// <summary>
        /// Insert a document in elastic Search
        /// </summary>
        /// <param name="document"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="indexName"></param>
        /// <returns></returns>
        Task InsertDocumentAsync(T document, string indexName = null, CancellationToken cancellationToken=default);
    }
}
