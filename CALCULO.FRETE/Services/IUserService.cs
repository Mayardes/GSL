using CALCULOFRETE.Model;

namespace CALCULOFRETE.Services
{
    public interface IUserService
    {
        public Task<IEnumerable<ProductOfferDetail>> GetProductListAsync();
        public Task<ProductOfferDetail> GetProductByIdAsync(int id);
        public Task<ProductOfferDetail> AddProductAsync(ProductOfferDetail product);
    }
}
