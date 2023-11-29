namespace WebBanHang.Models
{
    public class MMatHang
    {
        public string Id { get; set; }  = string.Empty;
        public string Name { get; set; } = string.Empty;
        
        public string IdCompany { get; set; } = string.Empty;
        public string IdType { get; set; } = string.Empty;
        public int Amount { get; set; }
        public int UnitOfCal { get; set; }
        public decimal Price { get; set; }
    }
}
