using RASTREIOMERCADORIAS.Data;
using RASTREIOMERCADORIAS.Repositories;

namespace RASTREIOMERCADORIAS.Service
{
    public class MercadoriaServices : MercadoriaRepository
    {
        public MercadoriaServices(CadastroContext context) : base(context)
        {
        }
    }
}
