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
                string query = "SELECT * FROM CHITIETDONDATHANG";
                return _provider.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách chi tiết đơn đặt hàng: " + ex.Message);
            }
        }

        public bool AddCTDDH(string maDonDatHang, string maMT, int soLuong, decimal giaBan)
        {
            try
            {
                string query = "INSERT INTO CHITIETDONDATHANG (MaDonDatHang, MaMT, SoLuong, GiaBan) VALUES (@MaDonDatHang, @MaMT, @SoLuong, @GiaBan)";
                var parameters = new Dictionary<string, object>
                {
                    { "@MaDonDatHang", maDonDatHang },
                    { "@MaMT", maMT },
                    { "@SoLuong", soLuong },
                    { "@GiaBan", giaBan }
                };
                return _provider.ExecuteNonQuery(query, parameters) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm chi tiết đơn đặt hàng: " + ex.Message);
            }
        }

        public bool DeleteCTDDH(string maDonDatHang, string maMT)
        {
            try
            {
                string query = "DELETE FROM CHITIETDONDATHANG WHERE MaDonDatHang = @MaDonDatHang AND MaMT = @MaMT";
                var parameters = new Dictionary<string, object>
                {
                    { "@MaDonDatHang", maDonDatHang },
                    { "@MaMT", maMT }
                };
                return _provider.ExecuteNonQuery(query, parameters) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa chi tiết đơn đặt hàng: " + ex.Message);
            }
        }

        public bool UpdateCTDDH(string maDonDatHang, string maMT, int soLuong, decimal giaBan)
        {
            try
            {
                string query = "UPDATE CHITIETDONDATHANG SET SoLuong = @SoLuong, GiaBan = @GiaBan WHERE MaDonDatHang = @MaDonDatHang AND MaMT = @MaMT";
                var parameters = new Dictionary<string, object>
                {
                    { "@MaDonDatHang", maDonDatHang },
                    { "@MaMT", maMT },
                    { "@SoLuong", soLuong },
                    { "@GiaBan", giaBan }
                };
                return _provider.ExecuteNonQuery(query, parameters) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật chi tiết đơn đặt hàng: " + ex.Message);
            }
        }

        public DataTable SearchCTDDH(string keyword)
        {
            try
            {
                string query = "SELECT * FROM CHITIETDONDATHANG WHERE MaDonDatHang LIKE @Keyword OR MaMT LIKE @Keyword";
                var parameters = new Dictionary<string, object>
                {
                    { "@Keyword", "%" + keyword + "%" }
                };
                return _provider.ExecuteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm chi tiết đơn đặt hàng: " + ex.Message);
            }
        }

        public DataTable ExecuteQuery(string query, Dictionary<string, object> parameters = null)
        {
            return _provider.ExecuteQuery(query, parameters);
        }
    }
}
