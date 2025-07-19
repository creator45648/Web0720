using Microsoft.AspNetCore.Mvc;
using Web.API.Client;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.View
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IWebApiClient<string, Customer> webApiClient;

        public CustomersController(IWebApiClient<string, Customer> webApiClient)
        {
            this.webApiClient = webApiClient;
        }

        // GET: api/<CustomersController>
        [HttpGet]
        public async Task<IEnumerable<Customer>> Get()
        {
            return await webApiClient.GetAsync();
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public async Task<Customer> Get(string id)
        {
            return await webApiClient.GetByIdAsync(id);
        }

        // POST api/<CustomersController>
        [HttpPost]
        public async void Post([FromBody] Customer value)
        {
            await webApiClient.CreateAsync(value);
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public async void Put(int id, [FromBody] Customer value)
        {
            await webApiClient.UpdateAsync(value.CustomerId, value);
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public async void Delete(string id)
        {
            await webApiClient.DeleteAsync(id);
        }
    }
}
