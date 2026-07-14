using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ChiTietHDDAL
    {
        private DataProvider _provider;

        public ChiTietHDDAL()
        {
            _provider = new DataProvider();
        }

        public DataTable GetAllCTHD()
        {
            try
            {
                string query = "SELECT * FROM ChiTietHDB";
                return _provider.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách chi tiết hóa đơn: " + ex.Message);
            }
        }

        public DataTable GetCTHDByID(string id)
        {
            try
            {
                string query = "SELECT * FROM ChiTietHDB WHERE MaHDB = @MaHDB";
                var parameters = new Dictionary<string, object>
                {
                    { "@MaHDB", id }
                };
                return _provider.ExecuteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách chi tiết hóa đơn: " + ex.Message);
            }
        }

        public bool CheckMaCTHDExists(string maHDB)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM ChiTietHDB WHERE MaHDB = @MaHDB";
                var parameters = new Dictionary<string, object>
                {
                    { "@MaHDB", maHDB }
                };

                int count = Convert.ToInt32(_provider.ExecuteScalar(query, parameters));
                return count > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi kiểm tra mã chi tiết hóa đơn: " + ex.Message);
            }
        }

        public bool AddCTHD(string maHDB, string maMT, int slBan, decimal giaBan)
        {
            string query = "INSERT INTO ChiTietHDB (MaHDB, MaMT, SLBan, GiaBan) VALUES (@MaHDB, @MaMT, @SLBan, @GiaBan)";
            var parameters = new Dictionary<string, object>
            {
                {"@MaHDB", maHDB},
                {"@MaMT", maMT},
                {"@SLBan", slBan},
                {"@GiaBan", giaBan}
            };
            return _provider.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool DeleteCTHD(string maHDB, string maMT)
        {
            string query = "DELETE FROM ChiTietHDB WHERE MaHDB = @MaHDB AND MaMT = @MaMT";
            var parameters = new Dictionary<string, object>
            {
                {"@MaHDB", maHDB},
                {"@MaMT", maMT}
            };
            return _provider.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool UpdateCTHD(string maHDB, string maMT, int slBan, decimal giaBan)
        {
            string query = "UPDATE ChiTietHDB SET SLBan = @SLBan, GiaBan = @GiaBan WHERE MaHDB = @MaHDB AND MaMT = @MaMT";
            var parameters = new Dictionary<string, object>
            {
                {"@MaHDB", maHDB},
                {"@MaMT", maMT},
                {"@SLBan", slBan},
                {"@GiaBan", giaBan}
            };
            return _provider.ExecuteNonQuery(query, parameters) > 0;
        }

        public DataTable ExecuteQuery(string query, Dictionary<string, object> parameters = null)
        {
            return _provider.ExecuteQuery(query, parameters);
        }
    }
}
