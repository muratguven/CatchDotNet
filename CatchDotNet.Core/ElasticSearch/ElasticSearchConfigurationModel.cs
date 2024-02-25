using Elastic.Clients.Elasticsearch;

namespace CatchDotNet.Core.ElasticSearch;

public record ElasticSearchConfigurationModel 
{
    public required string Url { get; init; }
    public required string UserName { get; init; }
    public required string Password { get; init; }
    public string? FingerPrint
    {
        get; init;
    }
}
