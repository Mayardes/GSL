using INFORMACOESCADASTRAIS.Repositories;
using ProductOwner.Microservice.Data;

namespace INFORMACOESCADASTRAIS.Service
{
    public class MercadoriaServices : MercadoriaRepository
    {
        public MercadoriaServices(CadastroContext context) : base(context)
        {
        }
    }
}
