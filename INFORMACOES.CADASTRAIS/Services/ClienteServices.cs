using INFORMACOESCADASTRAIS.Data;
using INFORMACOESCADASTRAIS.Repositories;

namespace INFORMACOESCADASTRAIS.Service
{
    public class ClienteServices : ClienteRepository
    {
        public ClienteServices(CadastroContext context) : base(context)
        {
        }
    }
}
