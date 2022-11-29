using ProductOwner.Microservice.Model;

namespace INFORMACOESCADASTRAIS.Services
{
    public interface IProductService
    {
        public void SendProductOffer(ProductOfferDetail productOfferDetails);
    }
}
