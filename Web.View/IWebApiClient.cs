namespace Web.View
{
    /// <summary>
    /// 建立swaggerClient 介面
    /// </summary>
    public interface IWebApiClient<Key, Model>
    {
        // Define methods for interacting with the web API here
        // For example:
        Task<IEnumerable<Model>> GetAsync();
        Task<Model> GetByIdAsync(Key id);
        Task CreateAsync(Model customer);
        Task UpdateAsync(Key id, Model customer);
        Task DeleteAsync(Key id);
    }
}
