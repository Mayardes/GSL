using Bogus;
using Bogus.Extensions.Brazil;
using SEGURANCAAUTENTICACAO.Model;
using Swashbuckle.AspNetCore.Filters;

namespace SEGURANCAAUTENTICACAO.Controllers.RequestExemples
{
    public class ClienteCadastrarRequestExamples : IExamplesProvider<Cliente>
    {
        public Cliente GetExamples()
        {
            var faker = new Faker("pt_BR");

            return new Cliente()
            {
                Id = Guid.NewGuid(),
                Nome = faker.Person.FullName,
                Contato = faker.Person.Phone,
                CpfCnpj = faker.Person.Cpf().Replace(".","").Replace("-",""),
                Email = faker.Person.Email,
                CEP = faker.Address.ZipCode()
            };
        }
    }
}
