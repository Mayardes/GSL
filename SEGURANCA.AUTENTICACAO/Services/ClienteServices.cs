using SEGURANCAAUTENTICACAO.Data;
using SEGURANCAAUTENTICACAO.Repositories;

namespace SEGURANCAAUTENTICACAO.Service
{
    public class ClienteServices : ClienteRepository
    {
        public ClienteServices(LegadoContext context) : base(context)
        {
        }
    }
}
