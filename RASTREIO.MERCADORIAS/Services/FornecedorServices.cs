using INFORMACOESCADASTRAIS.Data;
using INFORMACOESCADASTRAIS.Repositories;

namespace INFORMACOESCADASTRAIS.Service
{
    public class FornecedorServices : FornecedorRepository
    {
        public FornecedorServices(CadastroContext context) : base(context)
        {
        }
    }
}
