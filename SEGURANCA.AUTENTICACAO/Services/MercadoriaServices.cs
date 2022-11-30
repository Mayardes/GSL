using SEGURANCAAUTENTICACAO.Data;
using SEGURANCAAUTENTICACAO.Repositories;

namespace SEGURANCAAUTENTICACAO.Service
{
    public class MercadoriaServices : MercadoriaRepository
    {
        public MercadoriaServices(LegadoContext context) : base(context)
        {
        }
    }
}
