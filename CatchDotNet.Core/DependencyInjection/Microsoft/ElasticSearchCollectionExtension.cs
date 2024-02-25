using CatchDotNet.Core.ElasticSearch;
using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace CatchDotNet.Core.DependencyInjection.Microsoft
{
    public static class ElasticSearchCollectionExtension
    {
        public static IServiceCollection AddElasticSearch(this IServiceCollection services, IConfiguration configuration, ElasticsearchClientSettings? settings=null)
        {
            // Configuration elastic search
            var client = new ElasticsearchClient();
            if (settings is null)
            {
                var config = configuration.GetSection("ElasticSearch").Get<ElasticSearchConfigurationModel>();

               

                if (config is not null)
                {
                    var defaultSettings = new ElasticsearchClientSettings(new Uri(config.Url))
                   .Authentication(new BasicAuthentication(config.UserName, config.Password))
                   .PrettyJson();

                    client = new ElasticsearchClient(defaultSettings);

                    //services.AddSingleton<IElasticsearchClientSettings>(settings);
                    //services.AddScoped<IElasticSearchClientContext, ElasticSearchClientContext>(s=>s.)

                }
            }
            else
            {
                client = new ElasticsearchClient(settings);           
            }



            //services.AddScoped<ElasticSearchClientContext>();
            services.TryAddSingleton(client);

            return services;
        }
    }
}
