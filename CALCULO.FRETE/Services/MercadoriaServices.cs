using CALCULOFRETE.Data;
using CALCULOFRETE.Repositories;

namespace CALCULOFRETE.Service
{
    public class MercadoriaServices : MercadoriaRepository
    {
        public MercadoriaServices(LegadoContext context) : base(context)
        {
        }
    }
}
