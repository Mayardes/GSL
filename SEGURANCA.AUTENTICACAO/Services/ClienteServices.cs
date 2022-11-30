using SEGURANCAAUTENTICACAO.Data;
using SEGURANCAAUTENTICACAO.Repositories;

namespace SEGURANCAAUTENTICACAO.Service
{
    public class UsuarioServices : UsuarioRepository
    {
        public UsuarioServices(LoginContext context) : base(context)
        {
        }
    }
}
