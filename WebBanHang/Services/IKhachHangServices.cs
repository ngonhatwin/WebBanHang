using WebBanHang.Models;

namespace WebBanHang.Services
{
    public interface IKhachHangServices
    {
        Task<IEnumerable<MKhachHang>> GetAll();
        Task<MKhachHang> GetByID(int id);
        Task Create(MKhachHang khachHang);
        Task Update(int id, MKhachHang khachHang);
        Task Delete(int id);
        Task<IEnumerable<MKhachHang>> GetPageKhachHang(int page, int pageSize);
        //Task<IEnumerable<MKhachHang>> SearchKhachHang(string keyword);
    }
}
