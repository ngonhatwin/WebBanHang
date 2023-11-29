using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebBanHang.Data;

public partial class QlbhContext : DbContext
{
    public QlbhContext()
    {
    }

    public QlbhContext(DbContextOptions<QlbhContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Chitietdathang> Chitietdathangs { get; set; }

    public virtual DbSet<Dondathang> Dondathangs { get; set; }

    public virtual DbSet<Khachhang> Khachhangs { get; set; }

    public virtual DbSet<Loaihang> Loaihangs { get; set; }

    public virtual DbSet<Mathang> Mathangs { get; set; }

    public virtual DbSet<Nhacungcap> Nhacungcaps { get; set; }

    public virtual DbSet<Nhanvien> Nhanviens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-SR6CI3Q\\SQLEXPRESS;Initial Catalog=QLBH;Persist Security Info=True;User ID=sa;Password=123456789aA;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chitietdathang>(entity =>
        {
            entity.HasKey(e => new { e.SoHoaDon, e.MaHang }).HasName("PK__CHITIETD__C0B293E3F7734376");

            entity.ToTable("CHITIETDATHANG");

            entity.Property(e => e.MaHang)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.GiaBan).HasColumnType("numeric(10, 2)");
            entity.Property(e => e.MuaGiamGia).HasColumnType("numeric(10, 2)");

            entity.HasOne(d => d.MaHangNavigation).WithMany(p => p.Chitietdathangs)
                .HasForeignKey(d => d.MaHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CHITIETDA__MaHan__47DBAE45");

            entity.HasOne(d => d.SoHoaDonNavigation).WithMany(p => p.Chitietdathangs)
                .HasForeignKey(d => d.SoHoaDon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CHITIETDA__SoHoa__46E78A0C");
        });

        modelBuilder.Entity<Dondathang>(entity =>
        {
            entity.HasKey(e => e.SoHoaDon).HasName("PK__DONDATHA__012E9E5222984517");

            entity.ToTable("DONDATHANG");

            entity.Property(e => e.SoHoaDon).ValueGeneratedNever();
            entity.Property(e => e.MaNhanVien)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.NgayChuyenHang).HasColumnType("smalldatetime");
            entity.Property(e => e.NgayDatHang).HasColumnType("smalldatetime");
            entity.Property(e => e.NgayGiaoHang).HasColumnType("smalldatetime");
            entity.Property(e => e.NoiGiaoHang).HasMaxLength(50);

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.Dondathangs)
                .HasForeignKey(d => d.MaKhachHang)
                .HasConstraintName("FK__DONDATHAN__MaKha__4316F928");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.Dondathangs)
                .HasForeignKey(d => d.MaNhanVien)
                .HasConstraintName("FK__DONDATHAN__MaNha__440B1D61");
        });

        modelBuilder.Entity<Khachhang>(entity =>
        {
            entity.HasKey(e => e.MaKhachHang).HasName("PK__KHACHHAN__88D2F0E5C1A97A8C");

            entity.ToTable("KHACHHANG");

            entity.Property(e => e.MaKhachHang).ValueGeneratedNever();
            entity.Property(e => e.DiaChi).HasMaxLength(50);
            entity.Property(e => e.DienThoai)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Fax)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.TenCongTy).HasMaxLength(50);
            entity.Property(e => e.TenGiaoDich).HasMaxLength(20);
        });

        modelBuilder.Entity<Loaihang>(entity =>
        {
            entity.HasKey(e => e.MaLoaiHang).HasName("PK__LOAIHANG__5EEA416059AB5BD6");

            entity.ToTable("LOAIHANG");

            entity.Property(e => e.MaLoaiHang)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TenLoaiHang).HasMaxLength(30);
        });

        modelBuilder.Entity<Mathang>(entity =>
        {
            entity.HasKey(e => e.MaHang).HasName("PK__MATHANG__19C0DB1DFD57749E");

            entity.ToTable("MATHANG");

            entity.Property(e => e.MaHang)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DonViTinh).HasMaxLength(10);
            entity.Property(e => e.GiaHang).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.MaCongTy)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MaLoaiHang)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TenHang).HasMaxLength(30);

            entity.HasOne(d => d.MaCongTyNavigation).WithMany(p => p.Mathangs)
                .HasForeignKey(d => d.MaCongTy)
                .HasConstraintName("FK__MATHANG__MaCongT__3D5E1FD2");

            entity.HasOne(d => d.MaLoaiHangNavigation).WithMany(p => p.Mathangs)
                .HasForeignKey(d => d.MaLoaiHang)
                .HasConstraintName("FK__MATHANG__MaLoaiH__3E52440B");
        });

        modelBuilder.Entity<Nhacungcap>(entity =>
        {
            entity.HasKey(e => e.MaCongTy).HasName("PK__NHACUNGC__E452D3DB32FE8E0B");

            entity.ToTable("NHACUNGCAP");

            entity.Property(e => e.MaCongTy)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DiaChi).HasMaxLength(50);
            entity.Property(e => e.DienThoai)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Fax)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.TenCongTy).HasMaxLength(40);
            entity.Property(e => e.TenGiaDich).HasMaxLength(30);
        });

        modelBuilder.Entity<Nhanvien>(entity =>
        {
            entity.HasKey(e => e.MaNhanVien).HasName("PK__NHANVIEN__77B2CA47B58AF99D");

            entity.ToTable("NHANVIEN");

            entity.Property(e => e.MaNhanVien)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DiaChi).HasMaxLength(50);
            entity.Property(e => e.DienThoai)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Ho).HasMaxLength(20);
            entity.Property(e => e.LuongCoBan).HasColumnType("numeric(10, 2)");
            entity.Property(e => e.NgayLamViec).HasColumnType("datetime");
            entity.Property(e => e.NgaySinh).HasColumnType("datetime");
            entity.Property(e => e.PhuCap).HasColumnType("numeric(10, 2)");
            entity.Property(e => e.Ten).HasMaxLength(10);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
