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
                if (slBan <= 0)
                {
                    return (false, "Số lượng bán phải lớn hơn 0!");
                }

                // Kiểm tra hàng tồn kho
                SanPhamDAL spDal = new SanPhamDAL();
                int currentStock = spDal.GetProductStock(maMT);
                if (currentStock < slBan)
                {
                    return (false, $"Không đủ số lượng tồn kho! Hiện tại chỉ còn {currentStock} sản phẩm.");
                }

                bool result = _dal.AddCTHD(maHDB, maMT, slBan, giaBan);
                if (result)
                {
                    // Trừ kho
                    spDal.UpdateStock(maMT, -slBan);
                    return (true, "Thêm chi tiết hóa đơn thành công!");
                }
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
                // Lấy số lượng cũ để cộng lại vào kho
                int qty = 0;
                DataTable dt = _dal.GetCTHDByID(maHDB);
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["MaMT"].ToString() == maMT)
                        {
                            qty = Convert.ToInt32(row["SLBan"]);
                            break;
                        }
                    }
                }

                bool result = _dal.DeleteCTHD(maHDB, maMT);
                if (result)
                {
                    // Cộng lại kho
                    if (qty > 0)
                    {
                        SanPhamDAL spDal = new SanPhamDAL();
                        spDal.UpdateStock(maMT, qty);
                    }
                    return (true, "Xóa chi tiết hóa đơn thành công!");
                }
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
                if (slBan <= 0)
                {
                    return (false, "Số lượng bán phải lớn hơn 0!");
                }

                // Lấy số lượng cũ để tính toán lượng chênh lệch
                int oldQty = 0;
                DataTable dt = _dal.GetCTHDByID(maHDB);
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["MaMT"].ToString() == maMT)
                        {
                            oldQty = Convert.ToInt32(row["SLBan"]);
                            break;
                        }
                    }
                }

                int diff = slBan - oldQty; // Độ lệch số lượng
                SanPhamDAL spDal = new SanPhamDAL();

                // Nếu bán thêm, kiểm tra xem kho có đủ không
                if (diff > 0)
                {
                    int currentStock = spDal.GetProductStock(maMT);
                    if (currentStock < diff)
                    {
                        return (false, $"Không đủ hàng trong kho để tăng số lượng bán! Hiện tại chỉ còn {currentStock} sản phẩm.");
                    }
                }

                bool result = _dal.UpdateCTHD(maHDB, maMT, slBan, giaBan);
                if (result)
                {
                    // Cập nhật lượng tồn kho chênh lệch
                    if (diff != 0)
                    {
                        spDal.UpdateStock(maMT, -diff);
                    }
                    return (true, "Cập nhật chi tiết hóa đơn thành công!");
                }
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
                string query = "SELECT * FROM ChiTietHDB WHERE MaHDB LIKE @MaHDB";
                var parameters = new Dictionary<string, object>
                {
                    { "@MaHDB", "%" + maHDB + "%" }
                };
                return _dal.ExecuteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm chi tiết hóa đơn: " + ex.Message);
            }
        }
    }
}
