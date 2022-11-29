using INFORMACOESCADASTRAIS.Data;
using INFORMACOESCADASTRAIS.Repositories;

namespace INFORMACOESCADASTRAIS.Service
{
    public class MercadoriaServices : MercadoriaRepository
    {
        public MercadoriaServices(CadastroContext context) : base(context)
        {
        }
    }
}
