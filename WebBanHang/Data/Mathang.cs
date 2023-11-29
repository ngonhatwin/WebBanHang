using System;
using System.Collections.Generic;

namespace WebBanHang.Data;

public partial class Mathang
{
    public string MaHang { get; set; } = null!;

    public string? TenHang { get; set; }

    public string? MaCongTy { get; set; }

    public string? MaLoaiHang { get; set; }

    public int? SoLuong { get; set; }

    public string? DonViTinh { get; set; }

    public decimal? GiaHang { get; set; }

    public virtual ICollection<Chitietdathang> Chitietdathangs { get; set; } = new List<Chitietdathang>();

    public virtual Nhacungcap? MaCongTyNavigation { get; set; }

    public virtual Loaihang? MaLoaiHangNavigation { get; set; }
}
