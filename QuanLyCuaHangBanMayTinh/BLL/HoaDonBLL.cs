using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class HoaDonBLL
    {
        private HoaDonDAL _dal;

        public HoaDonBLL()
        {
            _dal = new HoaDonDAL();
        }

        public DataTable GetAllHD()
        {
            try
            {
                return _dal.GetAllHD();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách hóa đơn: " + ex.Message);
            }
        }

        public (bool success, string message) AddHoaDon(Entities.HoaDon hd)
        {
            try
            {
                bool result = _dal.AddHoaDon(hd);
                if (result)
                {
                    return (true, "Thêm hóa đơn thành công!");
                }
                return (false, "Thêm hóa đơn thất bại!");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool success, string message) UpdateHoaDon(Entities.HoaDon hd)
        {
            try
            {
                bool result = _dal.UpdateHoaDon(hd);
                if (result)
                {
                    return (true, "Cập nhật hóa đơn thành công!");
                }
                return (false, "Cập nhật hóa đơn thất bại!");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool success, string message) DeleteHoaDon(string maHD)
        {
            try
            {
                bool result = _dal.DeleteHoaDon(maHD);
                if (result)
                {
                    return (true, "Xóa hóa đơn thành công!");
                }
                return (false, "Xóa hóa đơn thất bại!");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public DataTable SearchHoaDonByMa(string maHD)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(maHD))
                    return GetAllHD();
                string query = $"SELECT * FROM HOADONBANHANG WHERE MaHDB LIKE '%{maHD}%'";
                return _dal.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm hóa đơn: " + ex.Message);
            }
        }
    }
}
