using Web.API.Client;

namespace Web.View
{
    public class CustomerApiClient : IWebApiClient<string, Customer>
    {
        private readonly HttpClient _httpClient;
        swaggerClient _client => new swaggerClient(_httpClient);

        public CustomerApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        //Customers
        public async Task CreateAsync(Customer customer)
        {
            await _client.CustomersPOSTAsync(customer);
        }

        public async Task DeleteAsync(string id)
        {
            await _client.CustomersDELETEAsync(id);
        }

        public async Task<Customer> GetByIdAsync(string id)
        {
            return await _client.CustomersGETAsync(id);
        }

        public async Task<IEnumerable<Customer>> GetAsync()
        {
            return await _client.CustomersAllAsync();
        }

        public async Task UpdateAsync(string id, Customer customer)
        {
            await _client.CustomersPUTAsync(id, customer);
        }
    }
}
