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
                // Phân tích ngày lập hóa đơn ở tầng BLL trước
                DateTime.TryParse(hd.NgayLapHD, out DateTime ngayLap);

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
                DateTime.TryParse(hd.NgayLapHD, out DateTime ngayLap);

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

        public DataTable ExecuteQuery(string query, Dictionary<string, object> parameters = null)
        {
            return _provider.ExecuteQuery(query, parameters);
        }
    }
}

