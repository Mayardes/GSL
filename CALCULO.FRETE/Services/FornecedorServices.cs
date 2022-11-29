using CALCULOFRETE.Data;
using CALCULOFRETE.Repositories;

namespace CALCULOFRETE.Service
{
    public class FornecedorServices : FornecedorRepository
    {
        public FornecedorServices(LegadoContext context) : base(context)
        {
        }
    }
}
