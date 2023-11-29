using System;
using System.Collections.Generic;

namespace WebBanHang.Data;

public partial class Khachhang
{
    public int MaKhachHang { get; set; }

    public string? TenCongTy { get; set; }

    public string? TenGiaoDich { get; set; }

    public string? DiaChi { get; set; }

    public string? Email { get; set; }

    public string? DienThoai { get; set; }

    public string? Fax { get; set; }

    public virtual ICollection<Dondathang> Dondathangs { get; set; } = new List<Dondathang>();
}
