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
                // Kiểm tra dữ liệu trống
                if (string.IsNullOrWhiteSpace(sp.MaSP) ||
                    string.IsNullOrWhiteSpace(sp.TenSP) ||
                    string.IsNullOrWhiteSpace(sp.MaNCC))
                {
                    return (false, "Vui lòng điền đầy đủ thông tin sản phẩm!");
                }

                // Kiểm tra mã sản phẩm đã tồn tại
                if (_dal.CheckMaSPExists(sp.MaSP))
                {
                    return (false, "Mã sản phẩm đã tồn tại!");
                }

                // Kiểm tra nhà cung cấp có tồn tại
                if (!_dal.CheckNhaCCExists(sp.MaNCC))
                {
                    return (false, "Mã nhà cung cấp không tồn tại!");
                }

                // Kiểm tra giá và số lượng
                if (sp.DonGia <= 0)
                {
                    return (false, "Đơn giá phải lớn hơn 0!");
                }

                if (sp.SoLuong < 0)
                {
                    return (false, "Số lượng không được âm!");
                }

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
                // Kiểm tra mã sản phẩm trống
                if (string.IsNullOrWhiteSpace(maSP))
                {
                    return (false, "Mã sản phẩm không được để trống!");
                }

                // Kiểm tra mã sản phẩm tồn tại
                if (!_dal.CheckMaSPExists(maSP))
                {
                    return (false, "Mã sản phẩm không tồn tại!");
                }

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
                // Kiểm tra dữ liệu trống
                if (string.IsNullOrWhiteSpace(sp.MaSP) ||
                    string.IsNullOrWhiteSpace(sp.TenSP) ||
                    string.IsNullOrWhiteSpace(sp.MaNCC))
                {
                    return (false, "Vui lòng điền đầy đủ thông tin sản phẩm!");
                }

                // Kiểm tra mã sản phẩm tồn tại
                if (!_dal.CheckMaSPExists(sp.MaSP))
                {
                    return (false, "Mã sản phẩm không tồn tại!");
                }

                // Kiểm tra nhà cung cấp có tồn tại
                if (!_dal.CheckNhaCCExists(sp.MaNCC))
                {
                    return (false, "Mã nhà cung cấp không tồn tại!");
                }

                // Kiểm tra giá và số lượng
                if (sp.DonGia <= 0)
                {
                    return (false, "Đơn giá phải lớn hơn 0!");
                }

                if (sp.SoLuong < 0)
                {
                    return (false, "Số lượng không được âm!");
                }

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
