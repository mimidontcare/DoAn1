using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class KhachHangDAL
    {
        private DataProvider _provider;
        public KhachHangDAL()
        {
            _provider = new DataProvider();
        }

        public DataTable GetAllKH()
        {
            try
            {
                string query = "Select * from KHACHHANG";
                return _provider.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách khách hàng: " + ex.Message);
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

        public bool AddKH(Entities.KhachHang kh)
        {
            try
            {
                string query = "INSERT INTO KHACHHANG (MaKH, TenKH, DiaChiKH, SDT_KH, GioiTinhKH) VALUES (@MaKH, @TenKH, @DiaChiKH, @SDT_KH, @GioiTinhKH)";

                var parameters = new Dictionary<string, object>
                {
                    { "@MaKH", kh.MaKH },
                    { "@TenKH", kh.HoTenKH },
                    { "@DiaChiKH", kh.DiaChi },
                    { "@SDT_KH", kh.Sdt },
                    { "@GioiTinhKH", kh.GioiTinh }
                };

                int rowsAffected = _provider.ExecuteNonQuery(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteKH(string maKH)
        {
            try
            {
                string query = "DELETE FROM KHACHHANG WHERE MaKH = @MaKH";
                var parameters = new Dictionary<string, object>
                {
                    { "@MaKH", maKH }
                };

                int rowsAffected = _provider.ExecuteNonQuery(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateKH(Entities.KhachHang kh)
        {
            try
            {
                string query = "UPDATE KHACHHANG SET TenKH = @TenKH, DiaChiKH = @DiaChiKH, SDT_KH = @SDT_KH, GioiTinhKH = @GioiTinhKH WHERE MaKH = @MaKH";

                var parameters = new Dictionary<string, object>
                {
                    { "@MaKH", kh.MaKH },
                    { "@TenKH", kh.HoTenKH },
                    { "@DiaChiKH", kh.DiaChi },
                    { "@SDT_KH", kh.Sdt },
                    { "@GioiTinhKH", kh.GioiTinh }
                };

                int rowsAffected = _provider.ExecuteNonQuery(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public DataTable SearchKhachHangByMa(string maKH)
        {
            try
            {
                string query = "SELECT * FROM KHACHHANG WHERE MaKH LIKE @MaKH";
                var parameters = new Dictionary<string, object>
                {
                    { "@MaKH", "%" + maKH + "%" }
                };
                return _provider.ExecuteQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

