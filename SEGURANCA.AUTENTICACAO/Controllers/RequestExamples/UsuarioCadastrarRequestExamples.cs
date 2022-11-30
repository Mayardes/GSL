using Bogus;
using Bogus.Extensions.Brazil;
using SEGURANCAAUTENTICACAO.Enum;
using SEGURANCAAUTENTICACAO.Model;
using Swashbuckle.AspNetCore.Filters;

namespace SEGURANCAAUTENTICACAO.Controllers.RequestExemples
{
    public class UsuarioCadastrarRequestExamples : IExamplesProvider<Usuario>
    {
        public Usuario GetExamples()
        {
            var faker = new Faker("pt_BR");

            return new Usuario()
            {
                Id = Guid.NewGuid(),
                Nome = faker.Person.FullName,
                Senha = "",
                Perfil = PerfilEnum.Administrador
            };
        }
    }
}
