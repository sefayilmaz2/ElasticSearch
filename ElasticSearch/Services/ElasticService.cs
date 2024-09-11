using Elastic.Clients.Elasticsearch;
using ElasticSearch.Configuration;
using ElasticSearch.Models;
using Microsoft.Extensions.Options;

namespace ElasticSearch.Services
{
    public class ElasticService<T> : IElasticService<T>
    {
        private readonly ElasticsearchClient _client;
        private readonly ElasticSettings _elasticSettings;

        public ElasticService(IOptions<ElasticSettings> optionsMonitor)
        {
            _elasticSettings = optionsMonitor.Value;

            var settings = new ElasticsearchClientSettings(new Uri(_elasticSettings.Url))
                .DefaultIndex(_elasticSettings.DefaultIndex);

            _client = new ElasticsearchClient(settings);
        }

        public async Task<bool> AddOrUpdate(T item)
        {
            var response = await _client.IndexAsync(item, idx => idx.Index(_elasticSettings.DefaultIndex).OpType(OpType.Index));
            return response.IsValidResponse;
        }

        public async Task<bool> AddOrUpdateBulk(IEnumerable<T> items, string indexName)
        {
            var response = await _client.BulkAsync(b => b.Index(indexName).UpdateMany(items, ((ud, u) => ud.Doc(u).DocAsUpsert(true))));
            return response.IsValidResponse;
        }

        public async Task CreateIndexIfNotExistsAsync(string indexName)
        {
            if (!_client.Indices.Exists(indexName).Exists)
                await _client.Indices.CreateAsync(indexName);
        }

        public async Task<T> Get(string key)
        {
            var response = await _client.GetAsync<T>(key, g => g.Index(_elasticSettings.DefaultIndex));
            return response.Source;
        }

        public async Task<List<T>?> GetAll()
        {
            var response = await _client.SearchAsync<T>(s => s.Index(_elasticSettings.DefaultIndex));
            return response.IsValidResponse ? response.Documents.ToList() : default;
        }

        public async Task<bool> Remove(string key)
        {
            var response = await _client.DeleteAsync<T>(key, d => d.Index(_elasticSettings.DefaultIndex));
            return response.IsValidResponse;
        }

        public async Task<long?> RemoveAll()
        {
            var response = await _client.DeleteByQueryAsync<T>(d => d.Indices(_elasticSettings.DefaultIndex));
            return response.IsValidResponse ? response.Deleted : default;
        }
    }

}
