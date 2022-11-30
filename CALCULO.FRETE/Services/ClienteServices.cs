using CALCULOFRETE.Data;
using CALCULOFRETE.Repositories;

namespace CALCULOFRETE.Service
{
    public class ClienteServices : ClienteRepository
    {
        public ClienteServices(LegadoContext context) : base(context)
        {
        }
    }
}
