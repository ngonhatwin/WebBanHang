using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBanHang.Data;
using WebBanHang.Models;

namespace WebBanHang.Repository
{
    public class KhachHangRepository : IRepository<MKhachHang>
    {
        private readonly QlbhContext context_;

        public KhachHangRepository(QlbhContext context)
        {
            context_ = context;
        }

        public async Task Create(MKhachHang khachHang)
        {
            var khachhang = new Khachhang
            {
                MaKhachHang = khachHang.Id,
                TenCongTy = khachHang.NameCompany,
                TenGiaoDich = khachHang.NameTrade,
                DienThoai = khachHang.Telephone,
                Email = khachHang.Email,
                Fax = khachHang.Fax,
                DiaChi = khachHang.Address
            };
            context_.Add(khachhang);
            await context_.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var khachhang = (from kh in context_.Khachhangs
                             where kh.MaKhachHang == id
                             select kh
                             ).SingleOrDefault();

            if (khachhang != null)
            {
                context_.Khachhangs.Remove(khachhang);
                await context_.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<MKhachHang>> GetAll()
        {
            var khachhang = await context_.Khachhangs.ToListAsync();
            return khachhang.Select(kh => new MKhachHang
            {
                Id = kh.MaKhachHang,
                NameCompany = kh.TenCongTy,
                NameTrade = kh.TenGiaoDich,
                Email = kh.Email,
                Telephone = kh.DienThoai,
                Fax = kh.Fax,
                Address = kh.DiaChi
            });
        }

        public async Task<MKhachHang> GetById(int id)
        {
            var khachhang = await context_.Khachhangs
                .Where(kh => kh.MaKhachHang == id)
                .SingleOrDefaultAsync();

            if (khachhang != null)
            {
                return new MKhachHang
                {
                    NameCompany = khachhang.TenCongTy,
                    NameTrade = khachhang.TenGiaoDich,
                    Email = khachhang.Email,
                    Telephone = khachhang.DienThoai,
                    Fax = khachhang.Fax,
                    Address = khachhang.DiaChi
                };
            }
            return null;
        }

        public async Task<IEnumerable<MKhachHang>> GetPage(int page, int pageSize)
        {
            return (IEnumerable<MKhachHang>)await context_.Khachhangs.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<IEnumerable<MKhachHang>> Search(string keyword)
        {
            var khachhang = await context_.Khachhangs
                .Where(kh => kh.TenCongTy.Contains(keyword))
                .ToListAsync();

            // Chuyển đổi danh sách các đối tượng Khachhang sang danh sách các đối tượng MKhachHang
            var result = khachhang.Select(kh => new MKhachHang
            {
                NameCompany = kh.TenCongTy,
                NameTrade = kh.TenGiaoDich,
                Email = kh.Email,
                Telephone = kh.DienThoai,
                Fax = kh.Fax,
                Address = kh.DiaChi
            }).ToList();

            return result;
        }

        public async Task Update(int id, MKhachHang khachHang)
        {
            var existingKhachHang = context_.Khachhangs.SingleOrDefault(kh => kh.MaKhachHang == id);

            if (existingKhachHang != null)
            {
                existingKhachHang.TenCongTy = khachHang.NameCompany;
                existingKhachHang.TenGiaoDich = khachHang.NameTrade;
                existingKhachHang.Email = khachHang.Email;
                existingKhachHang.DiaChi = khachHang.Address;
                existingKhachHang.DienThoai = khachHang.Telephone;
                existingKhachHang.Fax = khachHang.Fax;
                await context_.SaveChangesAsync();
            }
        }

    }
}
