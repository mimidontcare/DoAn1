using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using Entities;

namespace BLL
{
    public class NhapHangBLL
    {
        private NhapHangDAL _dal;
        public NhapHangBLL()
        {
            _dal = new NhapHangDAL();
        }

        public DataTable GetALLNH()
        {
            try
            {
                return _dal.GetALLNH();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách phiếu nhập: " + ex.Message);
            }
        }

        public (bool success, string message) AddNH(Entities.NhapHang nh)
        {
            try
            {
                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrWhiteSpace(nh.MaNCC))
                    return (false, "Mã nhà cung cấp không được để trống!");

                if (string.IsNullOrWhiteSpace(nh.MaNV))
                    return (false, "Mã nhân viên không được để trống!");

                if (nh.NgayNhan == DateTime.MinValue)
                    return (false, "Ngày nhận không hợp lệ!");

                if (nh.TongTien < 0)
                    return (false, "Tổng tiền không được âm!");

                // Kiểm tra sự tồn tại của nhà cung cấp và nhân viên
                if (!_dal.CheckNhaCCExists(nh.MaNCC))
                    return (false, "Nhà cung cấp không tồn tại trong hệ thống!");

                if (!_dal.CheckNhanVienExists(nh.MaNV))
                    return (false, "Nhân viên không tồn tại trong hệ thống!");

                bool result = _dal.AddNH(nh);
                return (result, result ? "Thêm phiếu nhập thành công!" : "Thêm phiếu nhập thất bại!");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi khi thêm phiếu nhập: " + ex.Message);
            }
        }

        public (bool success, string message) DeleteNH(string maPhieu)
        {
            try
            {
                // Kiểm tra mã phiếu trống
                if (string.IsNullOrWhiteSpace(maPhieu))
                    return (false, "Mã phiếu không được để trống!");

                // Kiểm tra sự tồn tại của phiếu nhập
                if (!_dal.CheckMaPhieuExists(maPhieu))
                    return (false, "Phiếu nhập không tồn tại trong hệ thống!");

                // Kiểm tra xem phiếu nhập có đang có chi tiết không
                if (_dal.CheckNhapHangInUse(maPhieu))
                    return (false, "Không thể xóa phiếu nhập này vì đang có các dòng chi tiết liên quan!");

                bool result = _dal.DeleteNH(maPhieu);
                return (result, result ? "Xóa phiếu nhập thành công!" : "Xóa phiếu nhập thất bại!");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi khi xóa phiếu nhập: " + ex.Message);
            }
        }

        public (bool success, string message) UpdateNH(Entities.NhapHang nh)
        {
            try
            {
                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrWhiteSpace(nh.MaPhieu))
                    return (false, "Mã phiếu không được để trống!");

                if (string.IsNullOrWhiteSpace(nh.MaNCC))
                    return (false, "Mã nhà cung cấp không được để trống!");

                if (string.IsNullOrWhiteSpace(nh.MaNV))
                    return (false, "Mã nhân viên không được để trống!");

                if (nh.NgayNhan == DateTime.MinValue)
                    return (false, "Ngày nhận không hợp lệ!");

                if (nh.TongTien < 0)
                    return (false, "Tổng tiền không được âm!");

                // Kiểm tra sự tồn tại của phiếu nhập
                if (!_dal.CheckMaPhieuExists(nh.MaPhieu))
                    return (false, "Phiếu nhập không tồn tại trong hệ thống!");

                // Kiểm tra sự tồn tại của nhà cung cấp và nhân viên
                if (!_dal.CheckNhaCCExists(nh.MaNCC))
                    return (false, "Nhà cung cấp không tồn tại trong hệ thống!");

                if (!_dal.CheckNhanVienExists(nh.MaNV))
                    return (false, "Nhân viên không tồn tại trong hệ thống!");

                bool result = _dal.UpdateNH(nh);
                return (result, result ? "Cập nhật phiếu nhập thành công!" : "Cập nhật phiếu nhập thất bại!");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi khi cập nhật phiếu nhập: " + ex.Message);
            }
        }
    }
}
