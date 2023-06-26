namespace Bank_Api.DTO
{
    public class BancoDto : IBancoDto
    {
        public int Id { get; set; }
        public string Uid { get; set; }
        public string AccountNumber { get; set; }
        public string Iban { get; set; }
        public string BankName { get; set; }
        public string RoutingNumber { get; set; }
        public string SwiftBic { get; set; }
    }
}
