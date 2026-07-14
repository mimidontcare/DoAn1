using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class KhachHangBLL
    {
        private KhachHangDAL _dal;
        public KhachHangBLL()
        {
            _dal = new KhachHangDAL();
        }

        public DataTable GetAllKH()
        {
            try
            {
                return _dal.GetAllKH();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách khách hàng: " + ex.Message);
            }
        }

        public (bool success, string message) AddKH(Entities.KhachHang kh)
        {
            try
            {
                // Kiểm tra dữ liệu trống
                if (string.IsNullOrWhiteSpace(kh.MaKH) ||
                    string.IsNullOrWhiteSpace(kh.HoTenKH) ||
                    string.IsNullOrWhiteSpace(kh.DiaChi) ||
                    string.IsNullOrWhiteSpace(kh.Sdt) ||
                    string.IsNullOrWhiteSpace(kh.GioiTinh))
                {
                    return (false, "Vui lòng điền đầy đủ thông tin khách hàng!");
                }

                // Kiểm tra mã khách hàng đã tồn tại
                if (_dal.CheckMaKHExists(kh.MaKH))
                {
                    return (false, "Mã khách hàng đã tồn tại!");
                }

                // Kiểm tra định dạng số điện thoại
                if (!System.Text.RegularExpressions.Regex.IsMatch(kh.Sdt, @"^[0-9]{10}$"))
                {
                    return (false, "Số điện thoại không hợp lệ! Vui lòng nhập 10 chữ số.");
                }

                // Kiểm tra giới tính
                if (kh.GioiTinh.ToLower() != "nam" && kh.GioiTinh.ToLower() != "nữ")
                {
                    return (false, "Giới tính không hợp lệ! Chỉ chấp nhận 'Nam' hoặc 'Nữ'.");
                }

                bool result = _dal.AddKH(kh);
                if (result)
                {
                    return (true, "Thêm khách hàng thành công!");
                }
                return (false, "Thêm khách hàng thất bại!");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool success, string message) UpdateKH(Entities.KhachHang kh)
        {
            try
            {
                // Kiểm tra dữ liệu trống
                if (string.IsNullOrWhiteSpace(kh.MaKH) ||
                    string.IsNullOrWhiteSpace(kh.HoTenKH) ||
                    string.IsNullOrWhiteSpace(kh.DiaChi) ||
                    string.IsNullOrWhiteSpace(kh.Sdt) ||
                    string.IsNullOrWhiteSpace(kh.GioiTinh))
                {
                    return (false, "Vui lòng điền đầy đủ thông tin khách hàng!");
                }

                // Kiểm tra mã khách hàng tồn tại
                if (!_dal.CheckMaKHExists(kh.MaKH))
                {
                    return (false, "Mã khách hàng không tồn tại!");
                }

                // Kiểm tra định dạng số điện thoại
                if (!System.Text.RegularExpressions.Regex.IsMatch(kh.Sdt, @"^[0-9]{10}$"))
                {
                    return (false, "Số điện thoại không hợp lệ! Vui lòng nhập 10 chữ số.");
                }

                // Kiểm tra giới tính
                if (kh.GioiTinh.ToLower() != "nam" && kh.GioiTinh.ToLower() != "nữ")
                {
                    return (false, "Giới tính không hợp lệ! Chỉ chấp nhận 'Nam' hoặc 'Nữ'.");
                }

                bool result = _dal.UpdateKH(kh);
                if (result)
                {
                    return (true, "Cập nhật khách hàng thành công!");
                }
                return (false, "Cập nhật khách hàng thất bại!");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool success, string message) DeleteKH(string maKH)
        {
            try
            {
                // Kiểm tra mã khách hàng trống
                if (string.IsNullOrWhiteSpace(maKH))
                {
                    return (false, "Mã khách hàng không được để trống!");
                }

                // Kiểm tra mã khách hàng tồn tại
                if (!_dal.CheckMaKHExists(maKH))
                {
                    return (false, "Mã khách hàng không tồn tại!");
                }

                bool result = _dal.DeleteKH(maKH);
                if (result)
                {
                    return (true, "Xóa khách hàng thành công!");
                }
                return (false, "Xóa khách hàng thất bại!");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public DataTable SearchKhachHangByMa(string maKH)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(maKH))
                {
                    return GetAllKH(); // Nếu không có mã tìm kiếm, trả về tất cả
                }
                return _dal.SearchKhachHangByMa(maKH);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm khách hàng: " + ex.Message);
            }
        }
    }
}
