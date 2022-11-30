using SEGURANCAAUTENTICACAO.Enum;

namespace SEGURANCAAUTENTICACAO.Model
{
    public class Usuario
    {
        public string Nome { get; set;}
        public string Senha { get; set;}
        public PerfilEnum Perfil { get; set;}
    }
}
