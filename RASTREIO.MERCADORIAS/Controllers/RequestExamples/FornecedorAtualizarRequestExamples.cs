using Bogus;
using Bogus.Extensions.Brazil;
using INFORMACOESCADASTRAIS.Dto;
using Swashbuckle.AspNetCore.Filters;

namespace INFORMACOESCADASTRAIS.Controllers.RequestExemples
{
    public class FornecedorAtualizarRequestExamples : IExamplesProvider<FornecedorDto>
    {
        public FornecedorDto GetExamples()
        {
            var faker = new Faker("pt_BR");

            return new FornecedorDto()
            {
                Id = Guid.NewGuid(),
                Nome = faker.Person.FullName,
                Contato = faker.Person.Phone,
                CpfCnpj = faker.Person.Cpf().Replace(".","").Replace("-",""),
                Email = faker.Person.Email,
                Descricao = faker.Lorem.Paragraph(),
                RazaoSocial = faker.Company.CompanySuffix()
            };
        }
    }
}
