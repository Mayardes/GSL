namespace CALCULOFRETE.Models
{
    public class Frete
    {
        public Guid Id { get; set;}
        public bool IsPac { get; set;}
        public bool IsSedex { get; set;}
        public string Cep { get; set;}
    }
}
