using SEGURANCAAUTENTICACAO.Data;
using SEGURANCAAUTENTICACAO.Repositories;

namespace SEGURANCAAUTENTICACAO.Service
{
    public class DepositoServices : DepositoRepository
    {
        public DepositoServices(LegadoContext context) : base(context)
        {
        }
    }
}
