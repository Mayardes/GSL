using RASTREIOMERCADORIAS.Data;
using RASTREIOMERCADORIAS.Repositories;

namespace RASTREIOMERCADORIAS.Service
{
    public class DepositoServices : DepositoRepository
    {
        public DepositoServices(CadastroContext context) : base(context)
        {
        }
    }
}
