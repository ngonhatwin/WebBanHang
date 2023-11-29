﻿using WebBanHang.Models;
using WebBanHang.Repository;

namespace WebBanHang.Services
{
    public class NhanVienServices : INhanVienServices
    {
        private readonly IRepository<MNhanVien> repository_;
        public NhanVienServices(IRepository<MNhanVien> repository) 
        {
            repository_ = repository;
        }

        public async Task Create(MNhanVien Nhanvien)
        {
            await repository_.Create(Nhanvien);
        }

        public async Task Delete(int id)
        {
            await repository_.Delete(id);
        }

        public Task<IEnumerable<MNhanVien>> GetAll()
        {
            return repository_.GetAll();
        }

        public Task<MNhanVien> GetByID(int id)
        {
            return repository_.GetById(id);
        }

        public Task<IEnumerable<MNhanVien>> GetPageNhanVien(int page, int pageSize)
        {
            return repository_.GetPage(page, pageSize);
        }

        public Task Update(int id, MNhanVien Nhanvien)
        {
            return repository_.Update(id, Nhanvien);
        }
    }
}
