using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using WebBanHang.Data;
using WebBanHang.Models;

namespace WebBanHang.Repository
{
    public class NhanVienRepository : IRepository<MNhanVien>
    {
        private readonly QlbhContext context_;

        public NhanVienRepository(QlbhContext context)
        {
            context_ = context;
        }

        public async Task Create(MNhanVien nhanvien)
        {
            var Nhanvien = new Nhanvien
            {
                Ho = nhanvien.FristName,
                Ten = nhanvien.LastName,
                NgaySinh = nhanvien.DateOfB,
                NgayLamViec = nhanvien.DateofW,
                DienThoai = nhanvien.Telephone,
                DiaChi = nhanvien.Address,
                LuongCoBan = nhanvien.Salary,
                PhuCap = nhanvien.Allowances
            };
            context_.Add(Nhanvien);
            await context_.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var Nhanvien = (from nv in context_.Nhanviens
                            where nv.MaNhanVien == id.ToString()
                            select nv
                             ).SingleOrDefault();

            if (Nhanvien != null)
            {
                context_.Nhanviens.Remove(Nhanvien);
                await context_.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<MNhanVien>> GetAll()
        {
            var Nhanvien = await context_.Nhanviens.ToListAsync();
            return Nhanvien.Select(nv => new MNhanVien
            {
                FristName = nv.Ho,
                LastName = nv.Ten,
                DateOfB = (DateTime)nv.NgaySinh,
                DateofW = (DateTime)nv.NgayLamViec,
                Telephone = nv.DienThoai,
                Address = nv.DiaChi,
                Salary = (decimal)nv.LuongCoBan,
                Allowances = (decimal)nv.PhuCap
            });
        }

        public async Task<MNhanVien> GetById(int id)
        {
            var Nhanvien = await context_.Nhanviens
                .Where(nv => nv.MaNhanVien == id.ToString())
                .SingleOrDefaultAsync();

            if (Nhanvien != null)
            {
                return new MNhanVien
                {
                    FristName = Nhanvien.Ten,
                    LastName = Nhanvien.Ho,
                    DateOfB = (DateTime)Nhanvien.NgaySinh,
                    DateofW = (DateTime)Nhanvien.NgayLamViec,
                    Telephone = Nhanvien.DiaChi,
                    Address = Nhanvien.DiaChi,
                    Salary = (decimal)Nhanvien.LuongCoBan,
                    Allowances = (decimal)Nhanvien.PhuCap
                };
            }
            return null;
        }

        public async Task<IEnumerable<MNhanVien>> GetPage(int page, int pageSize)
        {
            return (IEnumerable<MNhanVien>)await context_.Nhanviens.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<IEnumerable<MNhanVien>> Search(string keyword)
        {
            var Nhanvien = await context_.Nhanviens
                .Where(nv => nv.Ten.Contains(keyword))
                .ToListAsync();


            var result = Nhanvien.Select(nv => new MNhanVien
            {
                FristName = nv.Ten,
                LastName = nv.Ho,
                DateOfB = (DateTime)nv.NgaySinh,
                DateofW = (DateTime)nv.NgayLamViec,
                Telephone = nv.DiaChi,
                Address = nv.DiaChi,
                Salary = (decimal)nv.LuongCoBan,
                Allowances = (decimal)nv.PhuCap

            }).ToList();

            return result;
        }

        public async Task Update(int id, MNhanVien nhanvien)
        {
            var existNhanVien = context_.Nhanviens.SingleOrDefault(nv => nv.MaNhanVien == id.ToString());

            if (existNhanVien != null)
            {
                existNhanVien.Ten = nhanvien.FristName;
                existNhanVien.Ho = nhanvien.LastName;
                existNhanVien.NgaySinh = nhanvien.DateOfB;
                existNhanVien.NgayLamViec = nhanvien.DateofW;
                existNhanVien.DiaChi = nhanvien.Address;
                existNhanVien.LuongCoBan = nhanvien.Salary;
                existNhanVien.PhuCap = nhanvien.Allowances;
                existNhanVien.DienThoai = nhanvien.Telephone;
                await context_.SaveChangesAsync();
            }
        }
    }
}
