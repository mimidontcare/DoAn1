using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL
{
    public class NhanVienDAL
    {
        private DataProvider _provider;
        public NhanVienDAL()
        {
            _provider = new DataProvider();
        }
        public DataTable GetAllNV()
        {
            string query = "SELECT * FROM NHANVIEN";
            return _provider.ExecuteQuery(query);
        }

        // Kiểm tra sự tồn tại của mã nhân viên
        public bool CheckMaNVExists(string maNV)
        {
            string query = "SELECT COUNT(*) FROM NHANVIEN WHERE MaNV = @MaNV";
            var parameters = new Dictionary<string, object>
            {
                { "@MaNV", maNV }
            };

            int count = Convert.ToInt32(_provider.ExecuteScalar(query, parameters));
            return count > 0;
        }

        // Thêm nhân viên với kiểm tra dữ liệu
        public bool AddNhanVien(NhanVien nv)
        {
            try
            {
                // Kiểm tra dữ liệu trống
                if (string.IsNullOrWhiteSpace(nv.MaNV) ||
                    string.IsNullOrWhiteSpace(nv.TenNV) ||
                    string.IsNullOrWhiteSpace(nv.DiaChi_NV) ||
                    string.IsNullOrWhiteSpace(nv.SDT_NV) ||
                    string.IsNullOrWhiteSpace(nv.GioiTinh))
                {
                    throw new Exception("Vui lòng điền đầy đủ thông tin nhân viên!");
                }

                // Kiểm tra mã nhân viên đã tồn tại
                if (CheckMaNVExists(nv.MaNV))
                {
                    throw new Exception("Mã nhân viên đã tồn tại!");
                }

                // Kiểm tra định dạng số điện thoại
                if (!System.Text.RegularExpressions.Regex.IsMatch(nv.SDT_NV, @"^[0-9]{10}$"))
                {
                    throw new Exception("Số điện thoại không hợp lệ! Vui lòng nhập 10 chữ số.");
                }

                // Kiểm tra giới tính
                if (nv.GioiTinh.ToLower() != "nam" && nv.GioiTinh.ToLower() != "nữ")
                {
                    throw new Exception("Giới tính không hợp lệ! Chỉ chấp nhận 'Nam' hoặc 'Nữ'.");
                }

                string query = "INSERT INTO NHANVIEN (MaNV, TenNV, DiaChiNV, SDT_NV, GioiTinh) VALUES (@MaNV, @TenNV, @DiaChiNV, @SDT_NV, @GioiTinh)";

                var parameters = new Dictionary<string, object>
                {
                    { "@MaNV", nv.MaNV },
                    { "@TenNV", nv.TenNV },
                    { "@DiaChiNV", nv.DiaChi_NV },
                    { "@SDT_NV", nv.SDT_NV },
                    { "@GioiTinh", nv.GioiTinh }
                };

                int rowsAffected = _provider.ExecuteNonQuery(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Cập nhật nhân viên với kiểm tra dữ liệu
        public bool UpdateNhanVien(NhanVien nv)
        {
            try
            {
                // Kiểm tra dữ liệu trống
                if (string.IsNullOrWhiteSpace(nv.MaNV) ||
                    string.IsNullOrWhiteSpace(nv.TenNV) ||
                    string.IsNullOrWhiteSpace(nv.DiaChi_NV) ||
                    string.IsNullOrWhiteSpace(nv.SDT_NV) ||
                    string.IsNullOrWhiteSpace(nv.GioiTinh))
                {
                    throw new Exception("Vui lòng điền đầy đủ thông tin nhân viên!");
                }

                // Kiểm tra mã nhân viên tồn tại
                if (!CheckMaNVExists(nv.MaNV))
                {
                    throw new Exception("Mã nhân viên không tồn tại!");
                }

                // Kiểm tra định dạng số điện thoại
                if (!System.Text.RegularExpressions.Regex.IsMatch(nv.SDT_NV, @"^[0-9]{10}$"))
                {
                    throw new Exception("Số điện thoại không hợp lệ! Vui lòng nhập 10 chữ số.");
                }

                // Kiểm tra giới tính
                if (nv.GioiTinh.ToLower() != "nam" && nv.GioiTinh.ToLower() != "nữ")
                {
                    throw new Exception("Giới tính không hợp lệ! Chỉ chấp nhận 'Nam' hoặc 'Nữ'.");
                }

                string query = "UPDATE NHANVIEN SET TenNV = @TenNV, DiaChiNV = @DiaChiNV, SDT_NV = @SDT_NV, GioiTinh = @GioiTinh WHERE MaNV = @MaNV";

                var parameters = new Dictionary<string, object>
                {
                    { "@MaNV", nv.MaNV },
                    { "@TenNV", nv.TenNV },
                    { "@DiaChiNV", nv.DiaChi_NV },
                    { "@SDT_NV", nv.SDT_NV },
                    { "@GioiTinh", nv.GioiTinh }
                };

                int rowsAffected = _provider.ExecuteNonQuery(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Xóa nhân viên với kiểm tra dữ liệu
        public bool DeleteNhanVien(string maNV)
        {
            try
            {
                // Kiểm tra mã nhân viên trống
                if (string.IsNullOrWhiteSpace(maNV))
                {
                    throw new Exception("Mã nhân viên không được để trống!");
                }

                // Kiểm tra mã nhân viên tồn tại
                if (!CheckMaNVExists(maNV))
                {
                    throw new Exception("Mã nhân viên không tồn tại!");
                }

                string query = "DELETE FROM NHANVIEN WHERE MaNV = @MaNV";
                var parameters = new Dictionary<string, object>
                {
                    { "@MaNV", maNV }
                };

                int rowsAffected = _provider.ExecuteNonQuery(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Tìm kiếm nhân viên theo mã
        public DataTable SearchNhanVienByMa(string maNV)
        {
            try
            {
                string query = "SELECT * FROM NHANVIEN WHERE MaNV LIKE N'%" + maNV + "%'";
                return _provider.ExecuteQuery(query);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
