namespace SEGURANCAAUTENTICACAO.Model
{
    public class Mercadoria
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Estoque { get; set; }
        public decimal ValorUnitario { get; set; }
        public Guid ClienteId { get; set; }
        public Guid FornecedorId { get; set; }
        public Guid DepositoId { get; set; }
    }
}
