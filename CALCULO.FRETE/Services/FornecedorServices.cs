using SISTEMALEGADO.Data;
using SISTEMALEGADO.Repositories;

namespace SISTEMALEGADO.Service
{
    public class FornecedorServices : FornecedorRepository
    {
        public FornecedorServices(LegadoContext context) : base(context)
        {
        }
    }
}
