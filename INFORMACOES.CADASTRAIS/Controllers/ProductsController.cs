using INFORMACOESCADASTRAIS.RabbitMQService;
using Microsoft.AspNetCore.Mvc;
using ProductOwner.Microservice.Model;

namespace INFORMACOESCADASTRAIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpPost("sendoffer")]
        public async Task<IActionResult>SendProductOfferAsync(ProductOfferDetail productOfferDetails)
        {
            try
            {
                return Ok(productOfferDetails);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
