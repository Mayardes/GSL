using CALCULOFRETE.Data;
using CALCULOFRETE.Repositories;

namespace CALCULOFRETE.Service
{
    public class DepositoServices : DepositoRepository
    {
        public DepositoServices(LegadoContext context) : base(context)
        {
        }
    }
}
