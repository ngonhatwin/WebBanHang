using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebBanHang.Models;
using WebBanHang.Services;

namespace WebBanHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienController : ControllerBase
    {
        private readonly INhanVienServices nhanVienServices_;
        public NhanVienController(INhanVienServices nhanVienServices) 
        { 
            this.nhanVienServices_ = nhanVienServices;
        }

        [HttpGet("danh-sach-nhan-vien")]
        
        public async Task<IActionResult> GetAllNhanVien()
        {
            var nv = await nhanVienServices_.GetAll();
            return Ok(nv);
        }

        [HttpGet("nhan-vien/{id}")]

        public async Task<IActionResult> GetNhanVienByID(int id)
        {
            var nv = await nhanVienServices_.GetByID(id);
            if (nv == null)
            {
                return BadRequest();
            }
            return Ok(nv);
        }

        [HttpPost("them-nhan-vien")]
        public async Task<IActionResult> CreateNhanVien(MNhanVien nhanVien)
        {
            if(nhanVien == null)
            {
                return BadRequest();
            }    
            await nhanVienServices_.Create(nhanVien);
            return Ok();
            
        }
        [HttpPut("chinh-sua-nhan-vien/{id}")]
        public async Task<IActionResult> EditNhanVien(int id, MNhanVien nhanVien)
        {
            if(nhanVien == null)
            {
                return BadRequest();
            } 
            await nhanVienServices_.Update(id, nhanVien);
            return Ok();
        }

        [HttpDelete("xoa-nhan-vien/{id}")]

        public async Task<IActionResult> DeleteNhanVien(int id)
        {

            await nhanVienServices_.Delete(id);
            return Ok();
        }
    }
}
