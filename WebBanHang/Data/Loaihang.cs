using System;
using System.Collections.Generic;

namespace WebBanHang.Data;

public partial class Loaihang
{
    public string MaLoaiHang { get; set; } = null!;

    public string? TenLoaiHang { get; set; }

    public virtual ICollection<Mathang> Mathangs { get; set; } = new List<Mathang>();
}
