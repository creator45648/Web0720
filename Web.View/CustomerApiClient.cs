using Web.API.Client;

namespace Web.View
{
    public class CustomerApiClient : IWebApiClient<string, Customer>
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://localhost:5001/api/";

        public CustomerApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        swaggerClient _client => new swaggerClient(_baseUrl, _httpClient);
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
