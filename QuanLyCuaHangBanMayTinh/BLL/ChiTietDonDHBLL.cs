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
                throw new Exception("Lỗi khi lấy danh sách chi tiết đơn đặt hàng: " + ex.Message);
            }
        }

        // Lấy chi tiết đơn đặt hàng theo mã đơn
        public DataTable GetCTDDHByMaDon(string maDon)
        {
            try
            {
                string query = "SELECT * FROM CHITIETDONDATHANG WHERE MaDonDatHang = @MaDon";
                var parameters = new Dictionary<string, object>
                {
                    { "@MaDon", maDon }
                };
                return _dal.ExecuteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy chi tiết đơn đặt hàng: " + ex.Message);
            }
        }

        public (bool, string) AddCTDDH(string maDonDatHang, string maMT, int soLuong, decimal giaBan)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(maDonDatHang))
                    return (false, "Mã đơn đặt hàng không được để trống!");

                if (string.IsNullOrWhiteSpace(maMT))
                    return (false, "Mã máy tính không được để trống!");

                if (soLuong <= 0)
                    return (false, "Số lượng phải lớn hơn 0!");

                if (giaBan < 0)
                    return (false, "Giá bán không được âm!");

                bool result = _dal.AddCTDDH(maDonDatHang, maMT, soLuong, giaBan);
                if (result)
                {
                    // Nhập hàng => cộng vào kho
                    SanPhamDAL spDal = new SanPhamDAL();
                    spDal.UpdateStock(maMT, soLuong);
                    return (true, "Thêm thành công!");
                }
                return (false, "Thêm thất bại!");
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
                if (string.IsNullOrWhiteSpace(maDonDatHang) || string.IsNullOrWhiteSpace(maMT))
                    return (false, "Mã đơn đặt hàng và mã máy tính không được để trống!");

                // Lấy số lượng cũ để trừ lại kho
                int qty = 0;
                DataTable dt = GetCTDDHByMaDon(maDonDatHang);
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["MaMT"].ToString() == maMT)
                        {
                            qty = Convert.ToInt32(row["SoLuong"]);
                            break;
                        }
                    }
                }

                bool result = _dal.DeleteCTDDH(maDonDatHang, maMT);
                if (result)
                {
                    // Xóa chi tiết nhập hàng => trừ kho
                    if (qty > 0)
                    {
                        SanPhamDAL spDal = new SanPhamDAL();
                        spDal.UpdateStock(maMT, -qty);
                    }
                    return (true, "Xóa thành công!");
                }
                return (false, "Xóa thất bại!");
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
                if (string.IsNullOrWhiteSpace(maDonDatHang) || string.IsNullOrWhiteSpace(maMT))
                    return (false, "Mã đơn đặt hàng và mã máy tính không được để trống!");

                if (soLuong <= 0)
                    return (false, "Số lượng phải lớn hơn 0!");

                // Lấy số lượng cũ để tính chênh lệch
                int oldQty = 0;
                DataTable dt = GetCTDDHByMaDon(maDonDatHang);
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["MaMT"].ToString() == maMT)
                        {
                            oldQty = Convert.ToInt32(row["SoLuong"]);
                            break;
                        }
                    }
                }

                int diff = soLuong - oldQty; // Chênh lệch số lượng nhập

                bool result = _dal.UpdateCTDDH(maDonDatHang, maMT, soLuong, giaBan);
                if (result)
                {
                    // Điều chỉnh kho theo chênh lệch
                    if (diff != 0)
                    {
                        SanPhamDAL spDal = new SanPhamDAL();
                        spDal.UpdateStock(maMT, diff);
                    }
                    return (true, "Cập nhật thành công!");
                }
                return (false, "Cập nhật thất bại!");
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
