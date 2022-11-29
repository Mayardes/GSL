using INFORMACOESCADASTRAIS.Services;
using Microsoft.AspNetCore.Mvc;
using ProductOwner.Microservice.Model;

namespace INFORMACOESCADASTRAIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService productService;

        public ProductsController(ProductService _productService)
        {
            productService = _productService;
        }


        [HttpPost("sendoffer")]
        public async Task<IActionResult>SendProductOfferAsync(ProductOfferDetail productOfferDetails)
        {
            try
            {
                productService.SendProductOffer(productOfferDetails);
                return Ok(productOfferDetails);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
