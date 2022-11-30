using CALCULOFRETE.Data;
using CALCULOFRETE.Repositories;

namespace CALCULOFRETE.Service
{
    public class ClienteServices : ClienteRepository
    {
        public ClienteServices(FreteClienteDBContext context) : base(context)
        {
        }
    }
}
