using Elastic.Clients.Elasticsearch;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CatchDotNet.Core.ElasticSearch;

public class ElasticSearchRepository<T> : IElasticSearchRepository<T>
{

    private readonly ElasticsearchClient Client;
    private readonly ILogger<ElasticSearchRepository<T>> _logger;

    public ElasticSearchRepository(ILogger<ElasticSearchRepository<T>> logger,
                                   ElasticsearchClient client)
    {        
        _logger = logger;
        Client = client;
    }


    public async Task CreateIndex(string indexName=null)
    {
        if(indexName is null)
        {
            // if index name is null, Create name of T index
            var any = await Client.Indices.ExistsAsync(nameof(T));
            if (any.Exists)
            {
                return;
            }

          var result = await Client.Indices.CreateAsync(nameof(T), s=>s.Index(nameof(T)).Settings(o=>o.NumberOfShards(1).NumberOfReplicas(1)));
          if(result.IsValidResponse)
            _logger.LogInformation($"Created { nameof(T) } name's index in the elasticsearch.");
           return; 
        }

        var anyName = await Client.Indices.ExistsAsync(indexName);
        if (anyName.Exists)
        {
            return;
        }

        await Client.Indices.CreateAsync(indexName, s => s.Index(indexName).Settings(o => o.NumberOfShards(1).NumberOfReplicas(1)));
        _logger.LogInformation($"Created {indexName} name's index in the elasticsearch.");
        return;

    }

    public async Task InsertDocumentAsync(T document, string indexName = null, CancellationToken cancellationToken = default)
    {

        if(document is null)
        {
            _logger.LogError($"Document can not null");
            throw new ArgumentNullException($"Document can not null!");
        }

        if (document.GetType().GetProperty("Id") == null)
        {
            throw new Exception($"'{typeof(T).Name}' document must include 'Id' property that is type of Guid!");
        }


        if (document.GetType().GetProperty("Id")?.GetValue(document, null) == null)
        {
            document.GetType().GetProperty("Id")?.SetValue(document, Guid.NewGuid());
        }

        var name = indexName is null ? nameof(T) : indexName;

        var result = await Client.CreateAsync(document,d=>d.Index(name), cancellationToken);

        if (!result.IsValidResponse)
        {
            _logger.LogError($"{JsonSerializer.Serialize(result.ElasticsearchServerError?.Error)} | {result.DebugInformation}");
            throw new Exception($"{JsonSerializer.Serialize(result.ElasticsearchServerError?.Error)} | {result.DebugInformation}");
        }
    }
}
