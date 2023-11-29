namespace WebBanHang.Models
{
    public class MDonDatHang
    {
        public int Id { get; set; }
        public int Id_Customer {  get; set; }
        public string Id_Emloyee { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public DateTime DeliDate { get; set; }
        public DateTime ShipDate { get; set; }
        public string Address { get; set; } = string.Empty;
    }
}
