using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Entities;

namespace GUI
{
    public partial class fNhanVien : Form
    {
        private NhanVienBLL _bll;
        public fNhanVien()
        {
            InitializeComponent();
            _bll = new BLL.NhanVienBLL();
            LoadDGV();
        }

        private void LoadDGV()
        {
            try
            {
                DataTable data = _bll.GetAllNV();
                dgvNV.DataSource = data;

                if (data.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để hiển thị!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputs()
        {
            txtNV_Ma.Clear();
            txtNV_Ten.Clear();
            txtNV_DiaChi.Clear();
            txtNV_SDT.Clear();
            txtNV_GioiTinh.Clear();
        }

        private void btnNV_Back_Click(object sender, EventArgs e)
        {
            fTrangChu fTrangChu = new fTrangChu();
            fTrangChu.Show();
            this.Hide();
        }

        private void btnNV_Them_Click(object sender, EventArgs e)
        {
            try
            {
                // Khởi tạo đối tượng NhanVien mới
                var newNhanVien = new NhanVien
                {
                    MaNV = txtNV_Ma.Text.Trim(),
                    TenNV = txtNV_Ten.Text.Trim(),
                    DiaChi_NV = txtNV_DiaChi.Text.Trim(),
                    SDT_NV = txtNV_SDT.Text.Trim(),
                    GioiTinh = txtNV_GioiTinh.Text.Trim()
                };


                // Thêm nhân viên thông qua BLL
                var (success, message) = _bll.AddNhanVien(newNhanVien);

                // Hiển thị thông báo kết quả
                if (success)
                {
                    MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDGV();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        private void btnNV_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy mã nhân viên từ textbox
                string maNV = txtNV_Ma.Text.Trim();

                // Xác nhận xóa
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Gọi phương thức xóa nhân viên từ BLL
                    var (success, message) = _bll.DeleteNhanVien(maNV);

                    // Hiển thị thông báo kết quả
                    if (success)
                    {
                        MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDGV();
                        ClearInputs();
                    }
                    else
                    {
                        MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNV_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                // Khởi tạo đối tượng NhanVien với thông tin mới
                var updatedNhanVien = new NhanVien
                {
                    MaNV = txtNV_Ma.Text.Trim(),
                    TenNV = txtNV_Ten.Text.Trim(),
                    DiaChi_NV = txtNV_DiaChi.Text.Trim(),
                    SDT_NV = txtNV_SDT.Text.Trim(),
                    GioiTinh = txtNV_GioiTinh.Text.Trim()
                };

                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn cập nhật thông tin nhân viên này?",
                    "Xác nhận cập nhật", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Gọi phương thức sửa nhân viên từ BLL
                    var (success, message) = _bll.UpdateNhanVien(updatedNhanVien);

                    // Hiển thị thông báo kết quả
                    if (success)
                    {
                        MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDGV();
                        ClearInputs();
                    }
                    else
                    {
                        MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Kiểm tra nếu có dòng nào được chọn trong DataGridView
                if (dgvNV.CurrentRow != null)
                {
                    DataGridViewRow row = dgvNV.CurrentRow;

                    // Kiểm tra giá trị của mỗi ô trước khi gán vào textbox
                    txtNV_Ma.Text = row.Cells["MaNV"].Value?.ToString() ?? string.Empty;
                    txtNV_Ten.Text = row.Cells["TenNV"].Value?.ToString() ?? string.Empty;
                    txtNV_DiaChi.Text = row.Cells["DiaChiNV"].Value?.ToString() ?? string.Empty;
                    txtNV_SDT.Text = row.Cells["SDT_NV"].Value?.ToString() ?? string.Empty;
                    txtNV_GioiTinh.Text = row.Cells["GioiTinh"].Value?.ToString() ?? string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNV_Exit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?",
                "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnNV_TimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string searchMaNV = txtNV_TimKiem.Text.Trim();
                DataTable searchResult = _bll.SearchNhanVienByMa(searchMaNV);

                dgvNV.DataSource = searchResult;

                if (searchResult.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy nhân viên nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Nếu không tìm thấy, hiển thị lại toàn bộ danh sách
                    LoadDGV();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadDGV();
            }
        }

  
    }
}
