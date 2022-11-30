namespace SISTEMALEGADO.Model
{
    public class Deposito
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Contato { get; set; }
        public ICollection<Mercadoria> Mercadorias { get; set; }

    }
}
