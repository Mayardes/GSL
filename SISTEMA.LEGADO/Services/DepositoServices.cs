using SISTEMALEGADO.Data;
using SISTEMALEGADO.Repositories;

namespace SISTEMALEGADO.Service
{
    public class DepositoServices : DepositoRepository
    {
        public DepositoServices(LegadoContext context) : base(context)
        {
        }
    }
}
