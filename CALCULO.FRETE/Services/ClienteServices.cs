using SISTEMALEGADO.Data;
using SISTEMALEGADO.Repositories;

namespace SISTEMALEGADO.Service
{
    public class ClienteServices : ClienteRepository
    {
        public ClienteServices(LegadoContext context) : base(context)
        {
        }
    }
}
