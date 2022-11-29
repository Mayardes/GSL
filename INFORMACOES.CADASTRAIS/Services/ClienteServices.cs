using INFORMACOESCADASTRAIS.Repositories;
using ProductOwner.Microservice.Data;

namespace INFORMACOESCADASTRAIS.Service
{
    public class ClienteServices : ClienteRepository
    {
        public ClienteServices(CadastroContext context) : base(context)
        {
        }
    }
}
