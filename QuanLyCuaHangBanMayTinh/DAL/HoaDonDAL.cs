using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HoaDonDAL
    {
        private DataProvider _provider;

        public HoaDonDAL()
        {
            _provider = new DataProvider();
        }

        public DataTable GetAllHD()
        {
            try
            {
                string query = "SELECT * FROM HOADONBANHANG";
                return _provider.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách hóa đơn: " + ex.Message);
            }
        }

        // Kiểm tra sự tồn tại của mã hóa đơn
        public bool CheckMaHDExists(string maHD)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM HOADONBANHANG WHERE MaHDB = @MaHDB";
                var parameters = new Dictionary<string, object>
                {
                    { "@MaHDB", maHD }
                };

                int count = Convert.ToInt32(_provider.ExecuteScalar(query, parameters));
                return count > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi kiểm tra mã hóa đơn: " + ex.Message);
            }
        }

        // Kiểm tra sự tồn tại của mã nhân viên
        public bool CheckMaNVExists(string maNV)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM NHANVIEN WHERE MaNV = @MaNV";
                var parameters = new Dictionary<string, object>
                {
                    { "@MaNV", maNV }
                };

                int count = Convert.ToInt32(_provider.ExecuteScalar(query, parameters));
                return count > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi kiểm tra mã nhân viên: " + ex.Message);
            }
        }

        // Kiểm tra sự tồn tại của mã khách hàng
        public bool CheckMaKHExists(string maKH)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM KHACHHANG WHERE MaKH = @MaKH";
                var parameters = new Dictionary<string, object>
                {
                    { "@MaKH", maKH }
                };

                int count = Convert.ToInt32(_provider.ExecuteScalar(query, parameters));
                return count > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi kiểm tra mã khách hàng: " + ex.Message);
            }
        }

        public bool AddHoaDon(Entities.HoaDon hd)
        {
            try
            {
                // Kiểm tra dữ liệu trống
                if (string.IsNullOrWhiteSpace(hd.MaHDB) ||
                    string.IsNullOrWhiteSpace(hd.MaNV) ||
                    string.IsNullOrWhiteSpace(hd.MaKH))
                {
                    throw new Exception("Vui lòng điền đầy đủ thông tin hóa đơn!");
                }

                // Kiểm tra mã hóa đơn đã tồn tại
                if (CheckMaHDExists(hd.MaHDB))
                {
                    throw new Exception("Mã hóa đơn đã tồn tại!");
                }

                // Kiểm tra mã nhân viên tồn tại
                if (!CheckMaNVExists(hd.MaNV))
                {
                    throw new Exception("Mã nhân viên không tồn tại!");
                }

                // Kiểm tra mã khách hàng tồn tại
                if (!CheckMaKHExists(hd.MaKH))
                {
                    throw new Exception("Mã khách hàng không tồn tại!");
                }

                // Kiểm tra ngày lập hóa đơn
                if (!DateTime.TryParse(hd.NgayLapHD, out DateTime ngayLap))
                {
                    throw new Exception("Ngày lập hóa đơn không hợp lệ!");
                }

                if (ngayLap > DateTime.Now)
                {
                    throw new Exception("Ngày lập hóa đơn không thể lớn hơn ngày hiện tại!");
                }

                // Kiểm tra tổng tiền
                if (hd.TongTien < 0)
                {
                    throw new Exception("Tổng tiền không thể âm!");
                }

                string query = "INSERT INTO HOADONBANHANG (MaHDB, MaNV, MaKH, NgayXuatHDB, TongTienBan) " +
                             "VALUES (@MaHDB, @MaNV, @MaKH, @NgayXuatHDB, @TongTienBan)";

                var parameters = new Dictionary<string, object>
                {
                    { "@MaHDB", hd.MaHDB },
                    { "@MaNV", hd.MaNV },
                    { "@MaKH", hd.MaKH },
                    { "@NgayXuatHDB", ngayLap },
                    { "@TongTienBan", hd.TongTien }
                };

                int rowsAffected = _provider.ExecuteNonQuery(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteHoaDon(string maHD)
        {
            try
            {
                // Kiểm tra mã hóa đơn trống
                if (string.IsNullOrWhiteSpace(maHD))
                {
                    throw new Exception("Mã hóa đơn không được để trống!");
                }

                // Kiểm tra mã hóa đơn tồn tại
                if (!CheckMaHDExists(maHD))
                {
                    throw new Exception("Mã hóa đơn không tồn tại!");
                }

                string query = "DELETE FROM HOADONBANHANG WHERE MaHDB = @MaHDB";
                var parameters = new Dictionary<string, object>
                {
                    { "@MaHDB", maHD }
                };

                int rowsAffected = _provider.ExecuteNonQuery(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateHoaDon(Entities.HoaDon hd)
        {
            try
            {
                // Kiểm tra dữ liệu trống
                if (string.IsNullOrWhiteSpace(hd.MaHDB) ||
                    string.IsNullOrWhiteSpace(hd.MaNV) ||
                    string.IsNullOrWhiteSpace(hd.MaKH))
                {
                    throw new Exception("Vui lòng điền đầy đủ thông tin hóa đơn!");
                }

                // Kiểm tra mã hóa đơn tồn tại
                if (!CheckMaHDExists(hd.MaHDB))
                {
                    throw new Exception("Mã hóa đơn không tồn tại!");
                }

                // Kiểm tra mã nhân viên tồn tại
                if (!CheckMaNVExists(hd.MaNV))
                {
                    throw new Exception("Mã nhân viên không tồn tại!");
                }

                // Kiểm tra mã khách hàng tồn tại
                if (!CheckMaKHExists(hd.MaKH))
                {
                    throw new Exception("Mã khách hàng không tồn tại!");
                }

                // Kiểm tra ngày lập hóa đơn
                if (!DateTime.TryParse(hd.NgayLapHD, out DateTime ngayLap))
                {
                    throw new Exception("Ngày lập hóa đơn không hợp lệ!");
                }

                if (ngayLap > DateTime.Now)
                {
                    throw new Exception("Ngày lập hóa đơn không thể lớn hơn ngày hiện tại!");
                }

                // Kiểm tra tổng tiền
                if (hd.TongTien < 0)
                {
                    throw new Exception("Tổng tiền không thể âm!");
                }

                string query = "UPDATE HOADONBANHANG SET MaNV = @MaNV, MaKH = @MaKH, NgayXuatHDB = @NgayXuatHDB, TongTienBan = @TongTienBan WHERE MaHDB = @MaHDB";
                var parameters = new Dictionary<string, object>
                {
                    { "@MaHDB", hd.MaHDB },
                    { "@MaNV", hd.MaNV },
                    { "@MaKH", hd.MaKH },
                    { "@NgayXuatHDB", ngayLap },
                    { "@TongTienBan", hd.TongTien }
                };

                int rowsAffected = _provider.ExecuteNonQuery(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable ExecuteQuery(string query)
        {
            return _provider.ExecuteQuery(query);
        }
    }
}

