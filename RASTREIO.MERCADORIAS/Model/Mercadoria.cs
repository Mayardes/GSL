using Newtonsoft.Json;

namespace RASTREIOMERCADORIAS.Model
{
    public class Mercadoria
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Estoque { get; set; }
        public decimal ValorUnitario { get; set; }
        public Cliente Cliente { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public Deposito Deposito { get; set; }

        [JsonIgnore]
        public Guid ClienteId { get; set; }

        [JsonIgnore]
        public Guid FornecedorId { get; set; }

        [JsonIgnore]
        public Guid DepositoId { get; set; }
    }
}
