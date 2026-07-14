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
    public class SanPhamBLL
    {
        private SanPhamDAL _dal;

        public SanPhamBLL()
        {
            _dal = new SanPhamDAL();
        }

        public DataTable GetAllSP()
        {
            try
            {
                return _dal.GetAllSP();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách sản phẩm: " + ex.Message);
            }
        }

        public (bool success, string message) AddSanPham(Entities.SanPham sp)
        {
            try
            {
                bool result = _dal.AddSanPham(sp);
                if (result)
                {
                    return (true, "Thêm sản phẩm thành công!");
                }
                return (false, "Thêm sản phẩm thất bại!");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool success, string message) DeleteSanPham(string maSP)
        {
            try
            {
                bool result = _dal.DeleteSanPham(maSP);
                if (result)
                {
                    return (true, "Xóa sản phẩm thành công!");
                }
                return (false, "Xóa sản phẩm thất bại!");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool success, string message) UpdateSanPham(Entities.SanPham sp)
        {
            try
            {
                bool result = _dal.UpdateSanPham(sp);
                if (result)
                {
                    return (true, "Cập nhật sản phẩm thành công!");
                }
                return (false, "Cập nhật sản phẩm thất bại!");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public DataTable SearchSanPhamByMa(string maSP)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(maSP))
                {
                    return GetAllSP(); // Nếu không có mã tìm kiếm, trả về tất cả
                }
                return _dal.SearchSanPhamByMa(maSP);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm sản phẩm: " + ex.Message);
            }
        }
    }
}
