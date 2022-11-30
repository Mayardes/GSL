using RASTREIOMERCADORIAS.Data;
using RASTREIOMERCADORIAS.Repositories;

namespace RASTREIOMERCADORIAS.Service
{
    public class FornecedorServices : FornecedorRepository
    {
        public FornecedorServices(CadastroContext context) : base(context)
        {
        }
    }
}
