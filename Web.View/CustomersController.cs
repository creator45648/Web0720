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
        public async Task<ActionResult<IEnumerable<Customer>>> Get()
        {
            try
            {
                var customers = await webApiClient.GetAsync();
                return Ok(customers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> Get(string id)
        {
            try
            {
                var customer = await webApiClient.GetByIdAsync(id);
                if (customer == null)
                {
                    return NotFound();
                }
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST api/<CustomersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Customer value)
        {
            try
            {
                await webApiClient.CreateAsync(value);
                return CreatedAtAction(nameof(Get), new { id = value.CustomerId }, value);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Customer value)
        {
            try
            {
                if (id != value.CustomerId)
                {
                    return BadRequest("ID mismatch");
                }
                
                await webApiClient.UpdateAsync(id, value);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await webApiClient.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
