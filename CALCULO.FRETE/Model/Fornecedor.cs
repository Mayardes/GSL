namespace CALCULOFRETE.Model
{
    public class Fornecedor
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CpfCnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string Descricao { get; set; }
        public string Email { get; set; }
        public string Contato { get; set; }
        public ICollection<Mercadoria> Mercadorias { get; set; }
    }
}
