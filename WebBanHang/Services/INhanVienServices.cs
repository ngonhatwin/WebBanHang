using WebBanHang.Models;

namespace WebBanHang.Services
{
    public interface INhanVienServices
    {
        Task<IEnumerable<MNhanVien>> GetAll();
        Task<MNhanVien> GetByID(int id);
        Task Create(MNhanVien Nhanvien);
        Task Update(int id ,MNhanVien Nhanvien);
        Task Delete(int id);
        Task<IEnumerable<MNhanVien>> GetPageNhanVien(int page, int pageSize);
        //Task<IEnumerable<MNhanVien>> SearchKhachHang(string keyword);
    }
}
