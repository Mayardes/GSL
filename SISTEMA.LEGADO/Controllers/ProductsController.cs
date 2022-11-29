using Microsoft.AspNetCore.Mvc;
using SISTEMALEGADO.Model;

namespace SISTEMALEGADO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductsController()
        {
        }


        [HttpPost("sendoffer")]
        public async Task<IActionResult>SendProductOfferAsync(ProductOfferDetail productOfferDetails)
        {
            try
            {
                //productService.SendProductOffer(productOfferDetails);
                return Ok(productOfferDetails);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
