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

        // Thêm nhân viên
        public bool AddNhanVien(NhanVien nv)
        {
            try
            {
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

        // Cập nhật nhân viên
        public bool UpdateNhanVien(NhanVien nv)
        {
            try
            {
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

        // Xóa nhân viên
        public bool DeleteNhanVien(string maNV)
        {
            try
            {
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
                string query = "SELECT * FROM NHANVIEN WHERE MaNV LIKE @MaNV";
                var parameters = new Dictionary<string, object>
                {
                    { "@MaNV", "%" + maNV + "%" }
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
