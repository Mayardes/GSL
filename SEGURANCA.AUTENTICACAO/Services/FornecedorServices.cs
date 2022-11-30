using SEGURANCAAUTENTICACAO.Data;
using SEGURANCAAUTENTICACAO.Repositories;

namespace SEGURANCAAUTENTICACAO.Service
{
    public class FornecedorServices : FornecedorRepository
    {
        public FornecedorServices(LegadoContext context) : base(context)
        {
        }
    }
}
