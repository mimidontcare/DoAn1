using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class NhanVienBLL
    {
        private NhanVienDAL _dal;

        public NhanVienBLL()
        {
            _dal = new NhanVienDAL();
        }

        public DataTable GetAllNV()
        {
            try
            {
                return _dal.GetAllNV();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách nhân viên: " + ex.Message);
            }
        }

        public (bool success, string message) AddNhanVien(Entities.NhanVien nv)
        {
            try
            {
                bool result = _dal.AddNhanVien(nv);
                if (result)
                {
                    return (true, "Thêm nhân viên thành công!");
                }
                return (false, "Thêm nhân viên thất bại!");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool success, string message) DeleteNhanVien(string maNV)
        {
            try
            {
                bool result = _dal.DeleteNhanVien(maNV);
                if (result)
                {
                    return (true, "Xóa nhân viên thành công!");
                }
                return (false, "Xóa nhân viên thất bại!");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool success, string message) UpdateNhanVien(Entities.NhanVien nv)
        {
            try
            {
                bool result = _dal.UpdateNhanVien(nv);
                if (result)
                {
                    return (true, "Cập nhật nhân viên thành công!");
                }
                return (false, "Cập nhật nhân viên thất bại!");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public DataTable SearchNhanVienByMa(string maNV)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(maNV))
                {
                    return GetAllNV(); // Nếu không có mã tìm kiếm, trả về tất cả
                }
                return _dal.SearchNhanVienByMa(maNV);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm nhân viên: " + ex.Message);
            }
        }
    }
}
