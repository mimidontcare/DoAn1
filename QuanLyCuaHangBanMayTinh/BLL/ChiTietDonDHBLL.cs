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
    public class ChiTietDonDHBLL
    {
        private ChiTietDonDHDAL _dal;
        public ChiTietDonDHBLL()
        {
            _dal = new ChiTietDonDHDAL();
        }

        public DataTable GetAllCTDDH()
        {
            try
            {
                return _dal.GetAllCTDDH();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách chi tiết đơn đặt hàng: " + ex.Message);
            }
        }

        public (bool, string) AddCTDDH(string maDonDatHang, string maMT, int soLuong, decimal giaBan)
        {
            try
            {
                bool result = _dal.AddCTDDH(maDonDatHang, maMT, soLuong, giaBan);
                return (result, result ? "Thêm thành công!" : "Thêm thất bại!");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool, string) DeleteCTDDH(string maDonDatHang, string maMT)
        {
            try
            {
                bool result = _dal.DeleteCTDDH(maDonDatHang, maMT);
                return (result, result ? "Xóa thành công!" : "Xóa thất bại!");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool, string) UpdateCTDDH(string maDonDatHang, string maMT, int soLuong, decimal giaBan)
        {
            try
            {
                bool result = _dal.UpdateCTDDH(maDonDatHang, maMT, soLuong, giaBan);
                return (result, result ? "Cập nhật thành công!" : "Cập nhật thất bại!");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public DataTable SearchCTDDH(string keyword)
        {
            try
            {
                return _dal.SearchCTDDH(keyword);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm chi tiết đơn đặt hàng: " + ex.Message);
            }
        }
    }
}
