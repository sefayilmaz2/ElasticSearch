using ElasticSearch.Models;
namespace ElasticSearch.Services
{
    public interface IElasticService<T>
    {
        Task CreateIndexIfNotExistsAsync(string indexName);
        Task<bool> AddOrUpdate(T item);
        Task<bool> AddOrUpdateBulk(IEnumerable<T> items, string indexName);
        Task<T> Get(string key);
        Task<List<T>?> GetAll();
        Task<bool> Remove(string key);
        Task<long?> RemoveAll();
    }

}
