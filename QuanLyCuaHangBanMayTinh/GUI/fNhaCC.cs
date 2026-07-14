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
    public partial class fNhaCC : Form
    {
        private NhaCCBLL _bll;
        public fNhaCC()
        {
            InitializeComponent();
            _bll = new BLL.NhaCCBLL();
            LoadDGV();
        }

        private void LoadDGV()
        {
            try
            {
                DataTable data = _bll.GetAllNCC();
                dgvNCC.DataSource = data;

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
            txtNCC_Ma.Clear();
            txtNCC_Ten.Clear();
            txtNCC_DiaChi.Clear();
            txtNCC_SDT.Clear();
        }

        private void fNhaCC_Load(object sender, EventArgs e)
        {
            // Không cần làm gì vì đã gọi LoadDGV trong constructor
        }

        private void btnNCC_Back_Click(object sender, EventArgs e)
        {
            fTrangChu trangChuForm = new fTrangChu();
            trangChuForm.Show();
            this.Close();
        }

        private void dgvNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvNCC.Rows[e.RowIndex];

                    txtNCC_Ma.Text = row.Cells["MaNCC"].Value?.ToString() ?? string.Empty;
                    txtNCC_Ten.Text = row.Cells["TenNCC"].Value?.ToString() ?? string.Empty;
                    txtNCC_DiaChi.Text = row.Cells["DiaChiNCC"].Value?.ToString() ?? string.Empty;
                    txtNCC_SDT.Text = row.Cells["SDTNCC"].Value?.ToString() ?? string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNCC_Them_Click(object sender, EventArgs e)
        {
            try
            {
                var newNhaCungCap = new NhaCC
                {
                    MaNCC1 = txtNCC_Ma.Text.Trim(),
                    TenNCC1 = txtNCC_Ten.Text.Trim(),
                    DiaChiNCC1 = txtNCC_DiaChi.Text.Trim(),
                    SDTNCC1 = txtNCC_SDT.Text.Trim()
                };

                var (success, message) = _bll.AddNCC(newNhaCungCap);

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

        private void btnNCC_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maNCC = txtNCC_Ma.Text.Trim();

                // Xác nhận xóa
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhà cung cấp này?",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var (success, message) = _bll.DeleteNCC(maNCC);

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

        private void btnNCC_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                var updatedNhaCungCap = new NhaCC
                {
                    MaNCC1 = txtNCC_Ma.Text.Trim(),
                    TenNCC1 = txtNCC_Ten.Text.Trim(),
                    DiaChiNCC1 = txtNCC_DiaChi.Text.Trim(),
                    SDTNCC1 = txtNCC_SDT.Text.Trim()
                };

                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn cập nhật thông tin nhà cung cấp này?",
                    "Xác nhận cập nhật", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var (success, message) = _bll.UpdateNCC(updatedNhaCungCap);

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

        private void btnMT_Exit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?",
                "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnNCC_TimKiem_Click(object sender, EventArgs e)
        {
            string maNCC = txtNCC_Ma.Text.Trim();
            var (result, message) = _bll.SearchNhaCCByMa(maNCC);

            if (result != null)
            {
                dgvNCC.DataSource = result;
            }
            MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK,
                result == null ? MessageBoxIcon.Error : MessageBoxIcon.Information);
        }

        private void btnNCC_Huy_Click(object sender, EventArgs e)
        {

        }
    }
}
