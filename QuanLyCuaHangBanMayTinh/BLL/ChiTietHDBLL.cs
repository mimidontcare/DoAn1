using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class ChiTietHDBLL
    {
        private ChiTietHDDAL _dal;
        public ChiTietHDBLL()
        {
            _dal = new ChiTietHDDAL();
        }

        public DataTable GetAllCTHD()
        {
            try
            {
                return _dal.GetAllCTHD();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách chi tiết hóa đơn: " + ex.Message);
            }
        }

        public DataTable GetCTHDByID(string id)
        {
            try
            {
                return _dal.GetCTHDByID(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy chi tiết hóa đơn: " + ex.Message);
            }
        }

        public (bool, string) AddCTHD(string maHDB, string maMT, int slBan, decimal giaBan)
        {
            try
            {
                bool result = _dal.AddCTHD(maHDB, maMT, slBan, giaBan);
                if (result)
                    return (true, "Thêm chi tiết hóa đơn thành công!");
                return (false, "Thêm chi tiết hóa đơn thất bại!");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool, string) DeleteCTHD(string maHDB, string maMT)
        {
            try
            {
                bool result = _dal.DeleteCTHD(maHDB, maMT);
                if (result)
                    return (true, "Xóa chi tiết hóa đơn thành công!");
                return (false, "Xóa chi tiết hóa đơn thất bại!");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool, string) UpdateCTHD(string maHDB, string maMT, int slBan, decimal giaBan)
        {
            try
            {
                bool result = _dal.UpdateCTHD(maHDB, maMT, slBan, giaBan);
                if (result)
                    return (true, "Cập nhật chi tiết hóa đơn thành công!");
                return (false, "Cập nhật chi tiết hóa đơn thất bại!");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public DataTable SearchCTHDByMa(string maHDB)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(maHDB))
                    return GetAllCTHD();
                string query = $"SELECT * FROM ChiTietHDB WHERE MaHDB LIKE '%{maHDB}%'";
                return _dal.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm chi tiết hóa đơn: " + ex.Message);
            }
        }
    }
}
