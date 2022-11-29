using Bogus;
using INFORMACOESCADASTRAIS.Model;
using Swashbuckle.AspNetCore.Filters;

namespace INFORMACOESCADASTRAIS.Controllers.RequestExemples
{
    public class MercadoriaCadastrarRequestExamples : IExamplesProvider<Mercadoria>
    {
        public Mercadoria GetExamples()
        {
            var faker = new Faker("pt_BR");

            return new Mercadoria()
            {
                Id = Guid.NewGuid(),
                Nome = faker.Commerce.ProductName(),
                Estoque = faker.Random.Number(1,99),
                Descricao = faker.Lorem.Text(),
                ValorUnitario = Convert.ToDecimal(faker.Commerce.Price(100,1000,2)),
                ClienteId = faker.Random.Guid(),
                DepositoId = faker.Random.Guid(),
                FornecedorId = faker.Random.Guid()
            };
        }
    }
}
