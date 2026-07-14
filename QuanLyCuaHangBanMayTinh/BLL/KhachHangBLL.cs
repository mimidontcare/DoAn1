using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class KhachHangBLL
    {
        private KhachHangDAL _dal;
        public KhachHangBLL()
        {
            _dal = new KhachHangDAL();
        }

        public DataTable GetAllKH()
        {
            try
            {
                return _dal.GetAllKH();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách khách hàng: " + ex.Message);
            }
        }

        public (bool success, string message) AddKH(Entities.KhachHang kh)
        {
            try
            {
                bool result = _dal.AddKH(kh);
                if (result)
                {
                    return (true, "Thêm khách hàng thành công!");
                }
                return (false, "Thêm khách hàng thất bại!");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool success, string message) UpdateKH(Entities.KhachHang kh)
        {
            try
            {
                bool result = _dal.UpdateKH(kh);
                if (result)
                {
                    return (true, "Cập nhật khách hàng thành công!");
                }
                return (false, "Cập nhật khách hàng thất bại!");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool success, string message) DeleteKH(string maKH)
        {
            try
            {
                bool result = _dal.DeleteKH(maKH);
                if (result)
                {
                    return (true, "Xóa khách hàng thành công!");
                }
                return (false, "Xóa khách hàng thất bại!");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public DataTable SearchKhachHangByMa(string maKH)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(maKH))
                {
                    return GetAllKH(); // Nếu không có mã tìm kiếm, trả về tất cả
                }
                return _dal.SearchKhachHangByMa(maKH);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm khách hàng: " + ex.Message);
            }
        }
    }
}
