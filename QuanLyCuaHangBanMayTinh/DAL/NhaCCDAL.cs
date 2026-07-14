using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NhaCCDAL
    {
        private DataProvider _provider;
        public NhaCCDAL()
        {
            _provider = new DataProvider();
        }

        public DataTable GetAllNCC()
        {
            try
            {
                string query = "SELECT * FROM NHACUNGCAP";
                return _provider.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách nhà cung cấp: " + ex.Message);
            }
        }

        // Kiểm tra sự tồn tại của mã nhà cung cấp
        public bool CheckMaNCCExists(string maNCC)
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

        // Kiểm tra xem nhà cung cấp có đang được sử dụng trong bảng sản phẩm không
        public bool CheckNhaCCInUse(string maNCC)
        {
            try
            {
                string checkQuery = "SELECT COUNT(*) FROM MAYTINH WHERE MaNCC = @MaNCC";
                var checkParams = new Dictionary<string, object>
                {
                    { "@MaNCC", maNCC }
                };
                int usageCount = Convert.ToInt32(_provider.ExecuteScalar(checkQuery, checkParams));
                return usageCount > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi kiểm tra sử dụng nhà cung cấp: " + ex.Message);
            }
        }

        public bool AddNCC(NhaCC ncc)
        {
            try
            {
                string query = "INSERT INTO NHACUNGCAP (MaNCC, TenNCC, DiaChiNCC, SDTNCC) " +
                             "VALUES (@MaNCC, @TenNCC, @DiaChiNCC, @SDTNCC)";

                var parameters = new Dictionary<string, object>
                {
                    { "@MaNCC", ncc.MaNCC1 },
                    { "@TenNCC", ncc.TenNCC1 },
                    { "@DiaChiNCC", ncc.DiaChiNCC1 },
                    { "@SDTNCC", ncc.SDTNCC1 }
                };

                int rowsAffected = _provider.ExecuteNonQuery(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteNCC(string maNCC)
        {
            try
            {
                string query = "DELETE FROM NHACUNGCAP WHERE MaNCC = @MaNCC";
                var parameters = new Dictionary<string, object>
                {
                    { "@MaNCC", maNCC }
                };

                int rowsAffected = _provider.ExecuteNonQuery(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateNCC(NhaCC ncc)
        {
            try
            {
                string query = "UPDATE NHACUNGCAP SET TenNCC = @TenNCC, DiaChiNCC = @DiaChiNCC, SDTNCC = @SDTNCC " +
                             "WHERE MaNCC = @MaNCC";

                var parameters = new Dictionary<string, object>
                {
                    { "@MaNCC", ncc.MaNCC1 },
                    { "@TenNCC", ncc.TenNCC1 },
                    { "@DiaChiNCC", ncc.DiaChiNCC1 },
                    { "@SDTNCC", ncc.SDTNCC1 }
                };

                int rowsAffected = _provider.ExecuteNonQuery(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable SearchNhaCCByMa(string maNCC)
        {
            try
            {
                string query = "SELECT * FROM NHACUNGCAP WHERE MaNCC LIKE @MaNCC";
                var parameters = new Dictionary<string, object>
                {
                    { "@MaNCC", "%" + maNCC + "%" }
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
