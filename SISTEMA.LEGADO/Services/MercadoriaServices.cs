using SISTEMALEGADO.Data;
using SISTEMALEGADO.Repositories;

namespace SISTEMALEGADO.Service
{
    public class MercadoriaServices : MercadoriaRepository
    {
        public MercadoriaServices(LegadoContext context) : base(context)
        {
        }
    }
}
