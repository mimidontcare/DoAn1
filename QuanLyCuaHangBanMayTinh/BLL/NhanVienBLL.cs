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
                // Kiểm tra dữ liệu trống
                if (string.IsNullOrWhiteSpace(nv.MaNV) ||
                    string.IsNullOrWhiteSpace(nv.TenNV) ||
                    string.IsNullOrWhiteSpace(nv.DiaChi_NV) ||
                    string.IsNullOrWhiteSpace(nv.SDT_NV) ||
                    string.IsNullOrWhiteSpace(nv.GioiTinh))
                {
                    return (false, "Vui lòng điền đầy đủ thông tin nhân viên!");
                }

                // Kiểm tra mã nhân viên đã tồn tại
                if (_dal.CheckMaNVExists(nv.MaNV))
                {
                    return (false, "Mã nhân viên đã tồn tại!");
                }

                // Kiểm tra định dạng số điện thoại
                if (!System.Text.RegularExpressions.Regex.IsMatch(nv.SDT_NV, @"^[0-9]{10}$"))
                {
                    return (false, "Số điện thoại không hợp lệ! Vui lòng nhập 10 chữ số.");
                }

                // Kiểm tra giới tính
                if (nv.GioiTinh.ToLower() != "nam" && nv.GioiTinh.ToLower() != "nữ")
                {
                    return (false, "Giới tính không hợp lệ! Chỉ chấp nhận 'Nam' hoặc 'Nữ'.");
                }

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
                // Kiểm tra mã nhân viên trống
                if (string.IsNullOrWhiteSpace(maNV))
                {
                    return (false, "Mã nhân viên không được để trống!");
                }

                // Kiểm tra mã nhân viên tồn tại
                if (!_dal.CheckMaNVExists(maNV))
                {
                    return (false, "Mã nhân viên không tồn tại!");
                }

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
                // Kiểm tra dữ liệu trống
                if (string.IsNullOrWhiteSpace(nv.MaNV) ||
                    string.IsNullOrWhiteSpace(nv.TenNV) ||
                    string.IsNullOrWhiteSpace(nv.DiaChi_NV) ||
                    string.IsNullOrWhiteSpace(nv.SDT_NV) ||
                    string.IsNullOrWhiteSpace(nv.GioiTinh))
                {
                    return (false, "Vui lòng điền đầy đủ thông tin nhân viên!");
                }

                // Kiểm tra mã nhân viên tồn tại
                if (!_dal.CheckMaNVExists(nv.MaNV))
                {
                    return (false, "Mã nhân viên không tồn tại!");
                }

                // Kiểm tra định dạng số điện thoại
                if (!System.Text.RegularExpressions.Regex.IsMatch(nv.SDT_NV, @"^[0-9]{10}$"))
                {
                    return (false, "Số điện thoại không hợp lệ! Vui lòng nhập 10 chữ số.");
                }

                // Kiểm tra giới tính
                if (nv.GioiTinh.ToLower() != "nam" && nv.GioiTinh.ToLower() != "nữ")
                {
                    return (false, "Giới tính không hợp lệ! Chỉ chấp nhận 'Nam' hoặc 'Nữ'.");
                }

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
