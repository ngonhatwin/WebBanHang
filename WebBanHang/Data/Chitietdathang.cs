﻿using System;
using System.Collections.Generic;

namespace WebBanHang.Data;

public partial class Chitietdathang
{
    public int SoHoaDon { get; set; }

    public string MaHang { get; set; } = null!;

    public decimal? GiaBan { get; set; }

    public short? SoLuong { get; set; }

    public decimal? MuaGiamGia { get; set; }

    public virtual Mathang MaHangNavigation { get; set; } = null!;

    public virtual Dondathang SoHoaDonNavigation { get; set; } = null!;
}
