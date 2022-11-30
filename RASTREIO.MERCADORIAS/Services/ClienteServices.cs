using RASTREIOMERCADORIAS.Data;
using RASTREIOMERCADORIAS.Repositories;

namespace RASTREIOMERCADORIAS.Service
{
    public class ClienteServices : ClienteRepository
    {
        public ClienteServices(CadastroContext context) : base(context)
        {
        }
    }
}
