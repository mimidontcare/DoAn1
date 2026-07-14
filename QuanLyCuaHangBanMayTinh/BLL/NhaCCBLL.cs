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
                // Kiểm tra dữ liệu trống
                if (string.IsNullOrWhiteSpace(ncc.MaNCC1) ||
                    string.IsNullOrWhiteSpace(ncc.TenNCC1) ||
                    string.IsNullOrWhiteSpace(ncc.DiaChiNCC1) ||
                    string.IsNullOrWhiteSpace(ncc.SDTNCC1))
                {
                    return (false, "Vui lòng điền đầy đủ thông tin nhà cung cấp!");
                }

                // Kiểm tra mã nhà cung cấp đã tồn tại
                if (_dal.CheckMaNCCExists(ncc.MaNCC1))
                {
                    return (false, "Mã nhà cung cấp đã tồn tại!");
                }

                // Kiểm tra định dạng số điện thoại
                if (!System.Text.RegularExpressions.Regex.IsMatch(ncc.SDTNCC1, @"^[0-9]{10}$"))
                {
                    return (false, "Số điện thoại không hợp lệ! Vui lòng nhập 10 chữ số.");
                }

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
                // Kiểm tra dữ liệu trống
                if (string.IsNullOrWhiteSpace(ncc.MaNCC1) ||
                    string.IsNullOrWhiteSpace(ncc.TenNCC1) ||
                    string.IsNullOrWhiteSpace(ncc.DiaChiNCC1) ||
                    string.IsNullOrWhiteSpace(ncc.SDTNCC1))
                {
                    return (false, "Vui lòng điền đầy đủ thông tin nhà cung cấp!");
                }

                // Kiểm tra mã nhà cung cấp tồn tại
                if (!_dal.CheckMaNCCExists(ncc.MaNCC1))
                {
                    return (false, "Mã nhà cung cấp không tồn tại!");
                }

                // Kiểm tra định dạng số điện thoại
                if (!System.Text.RegularExpressions.Regex.IsMatch(ncc.SDTNCC1, @"^[0-9]{10}$"))
                {
                    return (false, "Số điện thoại không hợp lệ! Vui lòng nhập 10 chữ số.");
                }

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
                // Kiểm tra mã nhà cung cấp trống
                if (string.IsNullOrWhiteSpace(maNCC))
                {
                    return (false, "Mã nhà cung cấp không được để trống!");
                }

                // Kiểm tra mã nhà cung cấp tồn tại
                if (!_dal.CheckMaNCCExists(maNCC))
                {
                    return (false, "Mã nhà cung cấp không tồn tại!");
                }

                // Kiểm tra xem nhà cung cấp có đang được sử dụng trong bảng sản phẩm không
                if (_dal.CheckNhaCCInUse(maNCC))
                {
                    return (false, "Không thể xóa nhà cung cấp này vì đang có sản phẩm liên quan!");
                }

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
