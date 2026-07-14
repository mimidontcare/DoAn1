using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class NhaCCBLL
    {
        private DAL.NhaCCDAL _dal;
        public NhaCCBLL()
        {
            _dal = new NhaCCDAL();
        }

        public DataTable GetAllNCC()
        {
            try
            {
                return _dal.GetAllNCC();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách nhà cung cấp: " + ex.Message);
            }
        }

        public (bool success, string message) AddNCC(Entities.NhaCC ncc)
        {
            try
            {
                bool result = _dal.AddNCC(ncc);
                if (result)
                {
                    return (true, "Thêm nhà cung cấp thành công!");
                }
                return (false, "Thêm nhà cung cấp thất bại!");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool success, string message) UpdateNCC(Entities.NhaCC ncc)
        {
            try
            {
                bool result = _dal.UpdateNCC(ncc);
                if (result)
                {
                    return (true, "Cập nhật nhà cung cấp thành công!");
                }
                return (false, "Cập nhật nhà cung cấp thất bại!");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool success, string message) DeleteNCC(string maNCC)
        {
            try
            {
                bool result = _dal.DeleteNCC(maNCC);
                if (result)
                {
                    return (true, "Xóa nhà cung cấp thành công!");
                }
                return (false, "Xóa nhà cung cấp thất bại!");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (DataTable, string) SearchNhaCCByMa(string maNCC)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(maNCC))
                {
                    return (null, "Vui lòng nhập mã nhà cung cấp cần tìm");
                }

                DataTable result = _dal.SearchNhaCCByMa(maNCC);
                if (result.Rows.Count == 0)
                {
                    return (result, "Không tìm thấy nhà cung cấp nào phù hợp");
                }
                return (result, "Tìm thấy " + result.Rows.Count + " kết quả");
            }
            catch (Exception ex)
            {
                return (null, "Lỗi khi tìm kiếm nhà cung cấp: " + ex.Message);
            }
        }
    }
}
