using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;
using BLL;

namespace GUI
{
    public partial class fChiTietHD : Form
    {
        private ChiTietHDBLL _bll;
        public fChiTietHD()
        {
            InitializeComponent();
            _bll = new ChiTietHDBLL();
            LoadDGV();
        }

        private void LoadDGV()
        {
            try
            {
                DataTable data = _bll.GetAllCTHD();
                dgvCTHD.DataSource = data;

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

        private void btnCTHD_Back_Click(object sender, EventArgs e)
        {
            fHoaDon f = new fHoaDon();
            f.Show();
            this.Hide();
        }

        private void btnCTHD_Exit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận thoát", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnCTHD_Them_Click(object sender, EventArgs e)
        {
            try
            {
                string maHDB = txtCTHD_MaHD.Text.Trim();
                string maMT = txtCTHD_MaMT.Text.Trim();
                int slBan = int.TryParse(txtCTHD_SLban.Text.Trim(), out int sl) ? sl : 0;
                decimal giaBan = decimal.TryParse(txtCTHD_Giaban.Text.Trim(), out decimal gb) ? gb : 0;

                var (success, message) = _bll.AddCTHD(maHDB, maMT, slBan, giaBan);
                MessageBox.Show(message, success ? "Thông báo" : "Lỗi", MessageBoxButtons.OK, success ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                if (success)
                {
                    LoadDGV();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCTHD_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maHDB = txtCTHD_MaHD.Text.Trim();
                string maMT = txtCTHD_MaMT.Text.Trim();
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa chi tiết hóa đơn này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    var (success, message) = _bll.DeleteCTHD(maHDB, maMT);
                    MessageBox.Show(message, success ? "Thông báo" : "Lỗi", MessageBoxButtons.OK, success ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                    if (success)
                    {
                        LoadDGV();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCTHD_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                string maHDB = txtCTHD_MaHD.Text.Trim();
                string maMT = txtCTHD_MaMT.Text.Trim();
                int slBan = int.TryParse(txtCTHD_SLban.Text.Trim(), out int sl) ? sl : 0;
                decimal giaBan = decimal.TryParse(txtCTHD_Giaban.Text.Trim(), out decimal gb) ? gb : 0;
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn cập nhật chi tiết hóa đơn này?", "Xác nhận cập nhật", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    var (success, message) = _bll.UpdateCTHD(maHDB, maMT, slBan, giaBan);
                    MessageBox.Show(message, success ? "Thông báo" : "Lỗi", MessageBoxButtons.OK, success ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                    if (success)
                    {
                        LoadDGV();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCTHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvCTHD.Rows[e.RowIndex];
                    txtCTHD_MaHD.Text = row.Cells["MaHDB"].Value?.ToString() ?? string.Empty;
                    txtCTHD_MaMT.Text = row.Cells["MaMT"].Value?.ToString() ?? string.Empty;
                    txtCTHD_SLban.Text = row.Cells["SLBan"].Value?.ToString() ?? string.Empty;
                    txtCTHD_Giaban.Text = row.Cells["GiaBan"].Value?.ToString() ?? string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCTHD_inhoadon_Click(object sender, EventArgs e)
        {
            if (txtCTHD_MaHD.Text != string.Empty)
            {
                InHoaDon report = new InHoaDon();

                DataTable reportData = _bll.GetCTHDByID(txtCTHD_MaHD.Text);

                report.SetDataSource(reportData);

                fXuatHoaDon reportViewer = new fXuatHoaDon();
                reportViewer.crystalReportViewer1.ReportSource = report;

                reportViewer.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn chi tiết hóa đơn để in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCTHD_TimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string maHDB = txtCTHD_MaHD.Text.Trim();
                DataTable data = _bll.SearchCTHDByMa(maHDB);
                dgvCTHD.DataSource = data;
                if (data.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy chi tiết hóa đơn phù hợp!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
