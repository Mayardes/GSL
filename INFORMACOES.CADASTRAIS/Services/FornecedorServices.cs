using INFORMACOESCADASTRAIS.Repositories;
using ProductOwner.Microservice.Data;

namespace INFORMACOESCADASTRAIS.Service
{
    public class FornecedorServices : FornecedorRepository
    {
        public FornecedorServices(CadastroContext context) : base(context)
        {
        }
    }
}
