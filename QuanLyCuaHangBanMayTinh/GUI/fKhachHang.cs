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

namespace GUI
{
    public partial class fKhachHang : Form
    {
        private BLL.KhachHangBLL _bll;
        public fKhachHang()
        {
            InitializeComponent();
            _bll = new BLL.KhachHangBLL();
            LoadDGV();
        }

        private void LoadDGV()
        {
            try
            {
                DataTable data = _bll.GetAllKH();
                dgvKH.DataSource = data;

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
            txtKH_Ma.Clear();
            txtKH_Ten.Clear();
            txtKH_DiaChi.Clear();
            txtKH_SDT.Clear();
            txtKH_GioiTinh.Clear();
        }

        private void btnKH_Exit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?",
                "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnKH_Back_Click(object sender, EventArgs e)
        {
            fTrangChu fTrangChu = new fTrangChu();
            fTrangChu.Show();
            this.Hide();
        }

        private void btnKH_Them_Click(object sender, EventArgs e)
        {
            try
            {
                var newKhachHang = new Entities.KhachHang
                {
                    MaKH = txtKH_Ma.Text.Trim(),
                    HoTenKH = txtKH_Ten.Text.Trim(),
                    DiaChi = txtKH_DiaChi.Text.Trim(),
                    Sdt = txtKH_SDT.Text.Trim(),
                    GioiTinh = txtKH_GioiTinh.Text.Trim()
                };

                var (success, message) = _bll.AddKH(newKhachHang);

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

        private void btnKH_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maKH = txtKH_Ma.Text.Trim();

                // Xác nhận xóa
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var (success, message) = _bll.DeleteKH(maKH);

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

        private void btnKH_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                var updatedKhachHang = new Entities.KhachHang
                {
                    MaKH = txtKH_Ma.Text.Trim(),
                    HoTenKH = txtKH_Ten.Text.Trim(),
                    DiaChi = txtKH_DiaChi.Text.Trim(),
                    Sdt = txtKH_SDT.Text.Trim(),
                    GioiTinh = txtKH_GioiTinh.Text.Trim()
                };

                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn cập nhật thông tin khách hàng này?",
                    "Xác nhận cập nhật", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var (success, message) = _bll.UpdateKH(updatedKhachHang);

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

        private void dgvKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvKH.Rows[e.RowIndex];

                    txtKH_Ma.Text = row.Cells["MaKH"].Value?.ToString() ?? string.Empty;
                    txtKH_Ten.Text = row.Cells["TenKH"].Value?.ToString() ?? string.Empty;
                    txtKH_DiaChi.Text = row.Cells["DiaChiKH"].Value?.ToString() ?? string.Empty;
                    txtKH_SDT.Text = row.Cells["SDT_KH"].Value?.ToString() ?? string.Empty;
                    txtKH_GioiTinh.Text = row.Cells["GioiTinhKH"].Value?.ToString() ?? string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKH_TimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string maKH = txtKH_TimKiem.Text.Trim();
                DataTable data = _bll.SearchKhachHangByMa(maKH);
                dgvKH.DataSource = data;
                if (data.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy khách hàng phù hợp!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKH_Huy_Click(object sender, EventArgs e)
        {
            txtKH_Ma.Clear();
            txtKH_Ten.Clear();
            txtKH_DiaChi.Clear();
            txtKH_SDT.Clear();
            txtKH_GioiTinh.Clear();
            txtKH_TimKiem.Clear();
        }
    }
}
