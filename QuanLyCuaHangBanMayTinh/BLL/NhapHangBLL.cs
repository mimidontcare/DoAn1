using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using Entities;

namespace BLL
{
    public class NhapHangBLL
    {
        private NhapHangDAL _dal;
        public NhapHangBLL()
        {
            _dal = new NhapHangDAL();
        }

        public DataTable GetALLNH()
        {
            try
            {
                return _dal.GetALLNH();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách phiếu nhập: " + ex.Message);
            }
        }

        public (bool success, string message) AddNH(Entities.NhapHang nh)
        {
            try
            {
                bool result = _dal.AddNH(nh);
                return (result, result ? "Thêm phiếu nhập thành công!" : "Thêm phiếu nhập thất bại!");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi khi thêm phiếu nhập: " + ex.Message);
            }
        }

        public (bool success, string message) DeleteNH(string maPhieu)
        {
            try
            {
                bool result = _dal.DeleteNH(maPhieu);
                return (result, result ? "Xóa phiếu nhập thành công!" : "Xóa phiếu nhập thất bại!");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi khi xóa phiếu nhập: " + ex.Message);
            }
        }

        public (bool success, string message) UpdateNH(Entities.NhapHang nh)
        {
            try
            {
                bool result = _dal.UpdateNH(nh);
                return (result, result ? "Cập nhật phiếu nhập thành công!" : "Cập nhật phiếu nhập thất bại!");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi khi cập nhật phiếu nhập: " + ex.Message);
            }
        }
    }
}
