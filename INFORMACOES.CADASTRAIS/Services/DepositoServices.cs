using INFORMACOESCADASTRAIS.Repositories;
using ProductOwner.Microservice.Data;

namespace INFORMACOESCADASTRAIS.Service
{
    public class DepositoServices : DepositoRepository
    {
        public DepositoServices(CadastroContext context) : base(context)
        {
        }
    }
}
