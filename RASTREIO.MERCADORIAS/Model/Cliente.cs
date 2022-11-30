namespace INFORMACOESCADASTRAIS.Model
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CpfCnpj { get; set; }
        public string Email { get; set; }
        public string Contato { get; set; }
        public string CEP { get; set; }
    }
}
