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
                // Kiểm tra dữ liệu trống
                if (string.IsNullOrWhiteSpace(sp.MaSP) ||
                    string.IsNullOrWhiteSpace(sp.TenSP) ||
                    string.IsNullOrWhiteSpace(sp.MaNCC))
                {
                    throw new Exception("Vui lòng điền đầy đủ thông tin sản phẩm!");
                }

                // Kiểm tra mã sản phẩm đã tồn tại
                if (CheckMaSPExists(sp.MaSP))
                {
                    throw new Exception("Mã sản phẩm đã tồn tại!");
                }

                // Kiểm tra nhà cung cấp có tồn tại
                if (!CheckNhaCCExists(sp.MaNCC))
                {
                    throw new Exception("Mã nhà cung cấp không tồn tại!");
                }

                // Kiểm tra giá và số lượng
                if (sp.DonGia <= 0)
                {
                    throw new Exception("Đơn giá phải lớn hơn 0!");
                }

                if (sp.SoLuong < 0)
                {
                    throw new Exception("Số lượng không được âm!");
                }

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
                // Kiểm tra mã sản phẩm trống
                if (string.IsNullOrWhiteSpace(maSP))
                {
                    throw new Exception("Mã sản phẩm không được để trống!");
                }

                // Kiểm tra mã sản phẩm tồn tại
                if (!CheckMaSPExists(maSP))
                {
                    throw new Exception("Mã sản phẩm không tồn tại!");
                }

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
                // Kiểm tra dữ liệu trống
                if (string.IsNullOrWhiteSpace(sp.MaSP) ||
                    string.IsNullOrWhiteSpace(sp.TenSP) ||
                    string.IsNullOrWhiteSpace(sp.MaNCC))
                {
                    throw new Exception("Vui lòng điền đầy đủ thông tin sản phẩm!");
                }

                // Kiểm tra mã sản phẩm tồn tại
                if (!CheckMaSPExists(sp.MaSP))
                {
                    throw new Exception("Mã sản phẩm không tồn tại!");
                }

                // Kiểm tra nhà cung cấp có tồn tại
                if (!CheckNhaCCExists(sp.MaNCC))
                {
                    throw new Exception("Mã nhà cung cấp không tồn tại!");
                }

                // Kiểm tra giá và số lượng
                if (sp.DonGia <= 0)
                {
                    throw new Exception("Đơn giá phải lớn hơn 0!");
                }

                if (sp.SoLuong < 0)
                {
                    throw new Exception("Số lượng không được âm!");
                }

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
                string query = "SELECT * FROM MAYTINH WHERE MaMT LIKE N'%" + maSP + "%'";
                return _provider.ExecuteQuery(query);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}