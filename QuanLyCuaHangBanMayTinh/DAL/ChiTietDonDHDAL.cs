using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ChiTietDonDHDAL
    {
        private DataProvider _provider;

        public ChiTietDonDHDAL()
        {
            _provider = new DataProvider();
        }

        public DataTable GetAllCTDDH()
        {
            try
            {
                string query = "SELECT * FROM CHITIETNHAPHANG";
                return _provider.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách chi tiết: " + ex.Message);
            }
        }

        public bool AddCTDDH(string maDonDatHang, string maMT, int soLuong, decimal giaBan)
        {
            try
            {
                string query = "INSERT INTO CHITIETNHAPHANG (MaPhieu, MaMT, SoLuongNhap, DonGiaNhap) VALUES (@MaPhieu, @MaMT, @SoLuongNhap, @DonGiaNhap)";
                var parameters = new Dictionary<string, object>
                {
                    { "@MaPhieu", maDonDatHang },
                    { "@MaMT", maMT },
                    { "@SoLuongNhap", soLuong },
                    { "@DonGiaNhap", giaBan }
                };
                return _provider.ExecuteNonQuery(query, parameters) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm chi tiết: " + ex.Message);
            }
        }

        public bool DeleteCTDDH(string maDonDatHang, string maMT)
        {
            try
            {
                string query = "DELETE FROM CHITIETNHAPHANG WHERE MaPhieu = @MaPhieu AND MaMT = @MaMT";
                var parameters = new Dictionary<string, object>
                {
                    { "@MaPhieu", maDonDatHang },
                    { "@MaMT", maMT }
                };
                return _provider.ExecuteNonQuery(query, parameters) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa chi tiết: " + ex.Message);
            }
        }

        public bool UpdateCTDDH(string maDonDatHang, string maMT, int soLuong, decimal giaBan)
        {
            try
            {
                string query = "UPDATE CHITIETNHAPHANG SET SoLuongNhap = @SoLuongNhap, DonGiaNhap = @DonGiaNhap WHERE MaPhieu = @MaPhieu AND MaMT = @MaMT";
                var parameters = new Dictionary<string, object>
                {
                    { "@MaPhieu", maDonDatHang },
                    { "@MaMT", maMT },
                    { "@SoLuongNhap", soLuong },
                    { "@DonGiaNhap", giaBan }
                };
                return _provider.ExecuteNonQuery(query, parameters) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật chi tiết: " + ex.Message);
            }
        }

        public DataTable SearchCTDDH(string keyword)
        {
            try
            {
                string query = "SELECT * FROM CHITIETNHAPHANG WHERE MaPhieu LIKE @Keyword OR MaMT LIKE @Keyword";
                var parameters = new Dictionary<string, object>
                {
                    { "@Keyword", "%" + keyword + "%" }
                };
                return _provider.ExecuteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm: " + ex.Message);
            }
        }

        public DataTable ExecuteQuery(string query, Dictionary<string, object> parameters = null)
        {
            return _provider.ExecuteQuery(query, parameters);
        }
    }
}
