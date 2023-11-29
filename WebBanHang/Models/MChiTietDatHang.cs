namespace WebBanHang.Models
{
    public class MChiTietDatHang
    {
        public int Id { get; set; }
        public string Id_Product { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public decimal discount { get; set; }
    }
}
