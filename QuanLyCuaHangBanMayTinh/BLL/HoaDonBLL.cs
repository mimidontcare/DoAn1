using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class HoaDonBLL
    {
        private HoaDonDAL _dal;

        public HoaDonBLL()
        {
            _dal = new HoaDonDAL();
        }

        public DataTable GetAllHD()
        {
            try
            {
                return _dal.GetAllHD();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách hóa đơn: " + ex.Message);
            }
        }

        public (bool success, string message) AddHoaDon(Entities.HoaDon hd)
        {
            try
            {
                // Kiểm tra dữ liệu trống
                if (string.IsNullOrWhiteSpace(hd.MaHDB) ||
                    string.IsNullOrWhiteSpace(hd.MaNV) ||
                    string.IsNullOrWhiteSpace(hd.MaKH))
                {
                    return (false, "Vui lòng điền đầy đủ thông tin hóa đơn!");
                }

                // Kiểm tra mã hóa đơn đã tồn tại
                if (_dal.CheckMaHDExists(hd.MaHDB))
                {
                    return (false, "Mã hóa đơn đã tồn tại!");
                }

                // Kiểm tra mã nhân viên tồn tại
                if (!_dal.CheckMaNVExists(hd.MaNV))
                {
                    return (false, "Mã nhân viên không tồn tại!");
                }

                // Kiểm tra mã khách hàng tồn tại
                if (!_dal.CheckMaKHExists(hd.MaKH))
                {
                    return (false, "Mã khách hàng không tồn tại!");
                }

                // Kiểm tra ngày lập hóa đơn
                if (!DateTime.TryParse(hd.NgayLapHD, out DateTime ngayLap))
                {
                    return (false, "Ngày lập hóa đơn không hợp lệ!");
                }

                if (ngayLap > DateTime.Now)
                {
                    return (false, "Ngày lập hóa đơn không thể lớn hơn ngày hiện tại!");
                }

                // Kiểm tra tổng tiền
                if (hd.TongTien < 0)
                {
                    return (false, "Tổng tiền không thể âm!");
                }

                bool result = _dal.AddHoaDon(hd);
                if (result)
                {
                    return (true, "Thêm hóa đơn thành công!");
                }
                return (false, "Thêm hóa đơn thất bại!");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool success, string message) UpdateHoaDon(Entities.HoaDon hd)
        {
            try
            {
                // Kiểm tra dữ liệu trống
                if (string.IsNullOrWhiteSpace(hd.MaHDB) ||
                    string.IsNullOrWhiteSpace(hd.MaNV) ||
                    string.IsNullOrWhiteSpace(hd.MaKH))
                {
                    return (false, "Vui lòng điền đầy đủ thông tin hóa đơn!");
                }

                // Kiểm tra mã hóa đơn tồn tại
                if (!_dal.CheckMaHDExists(hd.MaHDB))
                {
                    return (false, "Mã hóa đơn không tồn tại!");
                }

                // Kiểm tra mã nhân viên tồn tại
                if (!_dal.CheckMaNVExists(hd.MaNV))
                {
                    return (false, "Mã nhân viên không tồn tại!");
                }

                // Kiểm tra mã khách hàng tồn tại
                if (!_dal.CheckMaKHExists(hd.MaKH))
                {
                    return (false, "Mã khách hàng không tồn tại!");
                }

                // Kiểm tra ngày lập hóa đơn
                if (!DateTime.TryParse(hd.NgayLapHD, out DateTime ngayLap))
                {
                    return (false, "Ngày lập hóa đơn không hợp lệ!");
                }

                if (ngayLap > DateTime.Now)
                {
                    return (false, "Ngày lập hóa đơn không thể lớn hơn ngày hiện tại!");
                }

                // Kiểm tra tổng tiền
                if (hd.TongTien < 0)
                {
                    return (false, "Tổng tiền không thể âm!");
                }

                bool result = _dal.UpdateHoaDon(hd);
                if (result)
                {
                    return (true, "Cập nhật hóa đơn thành công!");
                }
                return (false, "Cập nhật hóa đơn thất bại!");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool success, string message) DeleteHoaDon(string maHD)
        {
            try
            {
                // Kiểm tra mã hóa đơn trống
                if (string.IsNullOrWhiteSpace(maHD))
                {
                    return (false, "Mã hóa đơn không được để trống!");
                }

                // Kiểm tra mã hóa đơn tồn tại
                if (!_dal.CheckMaHDExists(maHD))
                {
                    return (false, "Mã hóa đơn không tồn tại!");
                }

                bool result = _dal.DeleteHoaDon(maHD);
                if (result)
                {
                    return (true, "Xóa hóa đơn thành công!");
                }
                return (false, "Xóa hóa đơn thất bại!");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public DataTable SearchHoaDonByMa(string maHD)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(maHD))
                    return GetAllHD();
                string query = "SELECT * FROM HOADONBANHANG WHERE MaHDB LIKE @MaHDB";
                var parameters = new Dictionary<string, object>
                {
                    { "@MaHDB", "%" + maHD + "%" }
                };
                return _dal.ExecuteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm hóa đơn: " + ex.Message);
            }
        }
    }
}
