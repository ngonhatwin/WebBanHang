namespace WebBanHang.Models
{
    public class MNhanVien
    {
        public string Id { get; set; } = string.Empty;
        public string FristName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfB {  get; set; }
        public DateTime DateofW { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Telephone { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public decimal Allowances { get; set; }
    }
}
