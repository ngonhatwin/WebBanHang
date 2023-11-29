using WebBanHang.Models;
using WebBanHang.Repository;

namespace WebBanHang.Services
{
    public class KhachHangServices : IKhachHangServices
    {
        private readonly IRepository<MKhachHang> khachHangRepository_;

        public KhachHangServices(IRepository<MKhachHang> khachHangRepository)
        {
            khachHangRepository_ = khachHangRepository;
        }

        public async Task Create(MKhachHang khachHang)
        {
             await khachHangRepository_.Create(khachHang);
        }

        public async Task Delete(int id)
        {
             await khachHangRepository_.Delete(id);
        }

        public Task<IEnumerable<MKhachHang>> GetAll()
        {
            return khachHangRepository_.GetAll();
        }

        public async Task<MKhachHang> GetByID(int id)
        {
            return await khachHangRepository_.GetById(id);
        }

        public async Task<IEnumerable<MKhachHang>> GetPageKhachHang(int page, int pageSize)
        {
            return await khachHangRepository_.GetPage(page, pageSize);
        }

        //public Task<IEnumerable<MKhachHang>> SearchKhachHang(string keyword)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task Update(int id, MKhachHang khachHang)
        {
            await khachHangRepository_.Update(id, khachHang);
        }
    }
}
