namespace PrimeNumber.Domain.Entities
{
    public class PrimeNumberRequestLog : DomainEntity
    {
        public string Request { get; set; }
        public DateTime DateRequest { get; set; }
        public string Response { get; set; }
        public DateTime DateResponse { get; set; }
        public string User { get; set; }
    }
}
