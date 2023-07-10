using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentApiService.Domain.Interfaces.clients;
using PaymentApiService.Domain.OpenPayModels;

namespace PaymentService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenPayCustomerController : ControllerBase
    {
        private readonly IOpenPayCustomerClient openPayCustomer;

        public OpenPayCustomerController(IOpenPayCustomerClient openPayCustomer)
        {
            this.openPayCustomer = openPayCustomer;
        }

        [HttpGet]
        public async Task<ActionResult> GetCustomers()
        {
            return Ok(await this.openPayCustomer.GetOpenPayCustomers());
        }

        [HttpGet("{customerId}")]
        public async Task<ActionResult> GetCustomer([FromRoute] string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
            {
                return BadRequest();
            }
            var customer = await this.openPayCustomer.GetOpenPayCustomer(customerId);   
            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult> AddCustomer(OpenPayCustomerRequest customer)
        {
            try
            {
                var result = await this.openPayCustomer.AddOpenPayCustomer(customer);
                return Ok(result);  
            }
            catch (Exception ex)
            {

                throw new Exception($"Error : {ex.Message}");
            }
        }

        [HttpDelete("{customerId}")]
        public async Task<ActionResult> DeleteCustomer([FromRoute] string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
            {
                return BadRequest();
            }
            //var customer = await this.openPayCustomer.GetOpenPayCustomer(customerId);
            //if (customer == null) { }
            //

            bool deleted = await this.openPayCustomer.DeleteOpenPayCustomer(customerId);

            if (!deleted)
            {
                return Conflict();
            } 

            return Ok();
        }
    }
}
