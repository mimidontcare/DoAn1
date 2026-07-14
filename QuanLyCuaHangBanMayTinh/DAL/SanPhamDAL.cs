using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL
{
    public class SanPhamDAL
    {
        private DataProvider _provider;
        public SanPhamDAL()
        {
            _provider = new DataProvider();
        }

        public DataTable GetAllSP()
        {
            try
            {
                string query = "Select * from MAYTINH";
                return _provider.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách sản phẩm: " + ex.Message);
            }
        }

        // Kiểm tra sự tồn tại của mã sản phẩm
        public bool CheckMaSPExists(string maSP)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM MAYTINH WHERE MaMT = @MaMT";
                var parameters = new Dictionary<string, object>
                {
                    { "@MaMT", maSP }
                };

                int count = Convert.ToInt32(_provider.ExecuteScalar(query, parameters));
                return count > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi kiểm tra mã sản phẩm: " + ex.Message);
            }
        }

        // Lấy số lượng tồn kho hiện tại
        public int GetProductStock(string maSP)
        {
            try
            {
                string query = "SELECT SoLuongMT FROM MAYTINH WHERE MaMT = @MaMT";
                var parameters = new Dictionary<string, object>
                {
                    { "@MaMT", maSP }
                };
                object result = _provider.ExecuteScalar(query, parameters);
                return result != null && result != DBNull.Value ? Convert.ToInt32(result) : 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy số lượng tồn kho: " + ex.Message);
            }
        }

        // Cập nhật tồn kho (cộng hoặc trừ)
        public bool UpdateStock(string maSP, int changeAmount)
        {
            try
            {
                string query = "UPDATE MAYTINH SET SoLuongMT = SoLuongMT + @ChangeAmount WHERE MaMT = @MaMT";
                var parameters = new Dictionary<string, object>
                {
                    { "@MaMT", maSP },
                    { "@ChangeAmount", changeAmount }
                };
                return _provider.ExecuteNonQuery(query, parameters) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật tồn kho: " + ex.Message);
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

        public bool AddSanPham(SanPham sp)
        {
            try
            {
                string query = "INSERT INTO MAYTINH (MaMT, TenMT, GiaMT, MaNCC, SoLuongMT) VALUES (@MaMT, @TenMT, @GiaMT, @MaNCC, @SoLuongMT)";

                var parameters = new Dictionary<string, object>
                {
                    { "@MaMT", sp.MaSP },
                    { "@TenMT", sp.TenSP },
                    { "@GiaMT", sp.DonGia },
                    { "@MaNCC", sp.MaNCC },
                    { "@SoLuongMT", sp.SoLuong }
                };

                int rowsAffected = _provider.ExecuteNonQuery(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteSanPham(string maSP)
        {
            try
            {
                string query = "DELETE FROM MAYTINH WHERE MaMT = @MaMT";
                var parameters = new Dictionary<string, object>
                {
                    { "@MaMT", maSP }
                };

                int rowsAffected = _provider.ExecuteNonQuery(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateSanPham(SanPham sp)
        {
            try
            {
                string query = "UPDATE MAYTINH SET TenMT = @TenMT, GiaMT = @GiaMT, MaNCC = @MaNCC, SoLuongMT = @SoLuongMT WHERE MaMT = @MaMT";

                var parameters = new Dictionary<string, object>
                {
                    { "@MaMT", sp.MaSP },
                    { "@TenMT", sp.TenSP },
                    { "@GiaMT", sp.DonGia },
                    { "@MaNCC", sp.MaNCC },
                    { "@SoLuongMT", sp.SoLuong }
                };

                int rowsAffected = _provider.ExecuteNonQuery(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Tìm kiếm sản phẩm theo mã
        public DataTable SearchSanPhamByMa(string maSP)
        {
            try
            {
                string query = "SELECT * FROM MAYTINH WHERE MaMT LIKE @MaMT";
                var parameters = new Dictionary<string, object>
                {
                    { "@MaMT", "%" + maSP + "%" }
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