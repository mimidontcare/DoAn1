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

        public bool AddNCC(NhaCC ncc)
        {
            try
            {
                // Kiểm tra dữ liệu trống
                if (string.IsNullOrWhiteSpace(ncc.MaNCC1) ||
                    string.IsNullOrWhiteSpace(ncc.TenNCC1) ||
                    string.IsNullOrWhiteSpace(ncc.DiaChiNCC1) ||
                    string.IsNullOrWhiteSpace(ncc.SDTNCC1))
                {
                    throw new Exception("Vui lòng điền đầy đủ thông tin nhà cung cấp!");
                }

                // Kiểm tra mã nhà cung cấp đã tồn tại
                if (CheckMaNCCExists(ncc.MaNCC1))
                {
                    throw new Exception("Mã nhà cung cấp đã tồn tại!");
                }

                // Kiểm tra định dạng số điện thoại
                if (!System.Text.RegularExpressions.Regex.IsMatch(ncc.SDTNCC1, @"^[0-9]{10}$"))
                {
                    throw new Exception("Số điện thoại không hợp lệ! Vui lòng nhập 10 chữ số.");
                }

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
                // Kiểm tra mã nhà cung cấp trống
                if (string.IsNullOrWhiteSpace(maNCC))
                {
                    throw new Exception("Mã nhà cung cấp không được để trống!");
                }

                // Kiểm tra mã nhà cung cấp tồn tại
                if (!CheckMaNCCExists(maNCC))
                {
                    throw new Exception("Mã nhà cung cấp không tồn tại!");
                }

                // Kiểm tra xem nhà cung cấp có đang được sử dụng trong bảng sản phẩm không
                string checkQuery = "SELECT COUNT(*) FROM MAYTINH WHERE MaNCC = @MaNCC";
                var checkParams = new Dictionary<string, object>
                {
                    { "@MaNCC", maNCC }
                };
                int usageCount = Convert.ToInt32(_provider.ExecuteScalar(checkQuery, checkParams));
                if (usageCount > 0)
                {
                    throw new Exception("Không thể xóa nhà cung cấp này vì đang có sản phẩm liên quan!");
                }

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
                // Kiểm tra dữ liệu trống
                if (string.IsNullOrWhiteSpace(ncc.MaNCC1) ||
                    string.IsNullOrWhiteSpace(ncc.TenNCC1) ||
                    string.IsNullOrWhiteSpace(ncc.DiaChiNCC1) ||
                    string.IsNullOrWhiteSpace(ncc.SDTNCC1))
                {
                    throw new Exception("Vui lòng điền đầy đủ thông tin nhà cung cấp!");
                }

                // Kiểm tra mã nhà cung cấp tồn tại
                if (!CheckMaNCCExists(ncc.MaNCC1))
                {
                    throw new Exception("Mã nhà cung cấp không tồn tại!");
                }

                // Kiểm tra định dạng số điện thoại
                if (!System.Text.RegularExpressions.Regex.IsMatch(ncc.SDTNCC1, @"^[0-9]{10}$"))
                {
                    throw new Exception("Số điện thoại không hợp lệ! Vui lòng nhập 10 chữ số.");
                }

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
                if (string.IsNullOrWhiteSpace(maNCC))
                {
                    throw new Exception("Vui lòng nhập mã nhà cung cấp để tìm kiếm!");
                }

                string query = $"SELECT * FROM NHACUNGCAP WHERE MaNCC LIKE N'%{maNCC}%'";
                return _provider.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm nhà cung cấp: " + ex.Message);
            }
        }
    }
}
