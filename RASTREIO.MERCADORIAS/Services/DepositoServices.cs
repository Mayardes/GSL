using INFORMACOESCADASTRAIS.Data;
using INFORMACOESCADASTRAIS.Repositories;

namespace INFORMACOESCADASTRAIS.Service
{
    public class DepositoServices : DepositoRepository
    {
        public DepositoServices(CadastroContext context) : base(context)
        {
        }
    }
}
