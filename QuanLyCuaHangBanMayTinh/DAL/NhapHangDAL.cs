using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NhapHangDAL
    {
        private DataProvider _provider;

        public NhapHangDAL()
        {
            _provider = new DataProvider();
        }

        public DataTable GetALLNH()
        {
            try
            {
                string query = "SELECT * FROM NHAPHANG";
                return _provider.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách phiếu nhập: " + ex.Message);
            }
        }

        // Kiểm tra sự tồn tại của mã phiếu
        public bool CheckMaPhieuExists(string maPhieu)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM NHAPHANG WHERE MaPhieu = @MaPhieu";
                var parameters = new Dictionary<string, object>
                {
                    { "@MaPhieu", maPhieu }
                };

                int count = Convert.ToInt32(_provider.ExecuteScalar(query, parameters));
                return count > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi kiểm tra mã phiếu: " + ex.Message);
            }
        }

        // Kiểm tra sự tồn tại của nhà cung cấp
        public bool CheckNhaCCExists(string maNCC)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM NHACUNGCAP WHERE MaNCC = @MaNCC";
                var parameters = new Dictionary<string, object>
                {
                    { "@MaNCC", maNCC }
                };

                int count = Convert.ToInt32(_provider.ExecuteScalar(query, parameters));
                return count > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi kiểm tra mã nhà cung cấp: " + ex.Message);
            }
        }

        // Kiểm tra sự tồn tại của nhân viên
        public bool CheckNhanVienExists(string maNV)
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

        // Kiểm tra xem phiếu nhập có đang có chi tiết không
        public bool CheckNhapHangInUse(string maPhieu)
        {
            try
            {
                string checkQuery = "SELECT COUNT(*) FROM CHITIETDONDATHANG WHERE MaDonDatHang = @MaPhieu";
                var checkParams = new Dictionary<string, object>
                {
                    { "@MaPhieu", maPhieu }
                };
                int usageCount = Convert.ToInt32(_provider.ExecuteScalar(checkQuery, checkParams));
                return usageCount > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi kiểm tra sử dụng phiếu nhập: " + ex.Message);
            }
        }

        public bool AddNH(Entities.NhapHang nh)
        {
            try
            {
                string query = "INSERT INTO NHAPHANG (MaNCC, NgayNhan, MaNV, TongTien) VALUES (@MaNCC, @NgayNhan, @MaNV, @TongTien)";

                var parameters = new Dictionary<string, object>
                {
                    { "@MaNCC", nh.MaNCC },
                    { "@NgayNhan", nh.NgayNhan },
                    { "@MaNV", nh.MaNV },
                    { "@TongTien", nh.TongTien }
                };

                int rowsAffected = _provider.ExecuteNonQuery(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteNH(string maPhieu)
        {
            try
            {
                string query = "DELETE FROM NHAPHANG WHERE MaPhieu = @MaPhieu";
                var parameters = new Dictionary<string, object>
                {
                    { "@MaPhieu", maPhieu }
                };

                int rowsAffected = _provider.ExecuteNonQuery(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateNH(Entities.NhapHang nh)
        {
            try
            {
                string query = "UPDATE NHAPHANG SET MaNCC = @MaNCC, NgayNhan = @NgayNhan, MaNV = @MaNV, TongTien = @TongTien WHERE MaPhieu = @MaPhieu";

                var parameters = new Dictionary<string, object>
                {
                    { "@MaPhieu", nh.MaPhieu },
                    { "@MaNCC", nh.MaNCC },
                    { "@NgayNhan", nh.NgayNhan },
                    { "@MaNV", nh.MaNV },
                    { "@TongTien", nh.TongTien }
                };

                int rowsAffected = _provider.ExecuteNonQuery(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
