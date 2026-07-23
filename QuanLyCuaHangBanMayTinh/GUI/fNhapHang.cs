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
    public partial class fNhapHang : Form
    {
        private NhapHangBLL _bll;
        public fNhapHang()
        {
            InitializeComponent();
            txtNHMa.ReadOnly = true;
            _bll = new NhapHangBLL();
            LoadDGV();
        }

        private void LoadDGV()
        {
            try
            {
                DataTable data = _bll.GetALLNH();
                dgvNH.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputs()
        {
            txtNHMa.Clear();
            txtNHMaNCC.Clear();
            txtNHNgayNhan.Clear();
            txtNHMaNV.Clear();
            nudNHGia.Value = 0;
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtNHMaNCC.Text))
            {
                MessageBox.Show("Vui lòng nhập mã nhà cung cấp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNHMaNCC.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNHMaNV.Text))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNHMaNV.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNHNgayNhan.Text))
            {
                MessageBox.Show("Vui lòng nhập ngày nhận!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNHNgayNhan.Focus();
                return false;
            }

            if (!DateTime.TryParse(txtNHNgayNhan.Text, out DateTime ngayNhan))
            {
                MessageBox.Show("Ngày nhận không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNHNgayNhan.Focus();
                return false;
            }

            if (nudNHGia.Value < 0)
            {
                MessageBox.Show("Tổng tiền không được âm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudNHGia.Focus();
                return false;
            }

            return true;
        }

        private void btnNH_Back_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                if (this.Owner != null)
                {
                    this.Owner.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chuyển form: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dgvNH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < dgvNH.Rows.Count)
                {
                    DataGridViewRow row = dgvNH.Rows[e.RowIndex];

                    // Kiểm tra xem row có tồn tại và có dữ liệu không
                    if (row != null && !row.IsNewRow)
                    {
                        txtNHMa.Text = row.Cells["MaPhieu"].Value?.ToString() ?? string.Empty;
                        txtNHMaNCC.Text = row.Cells["MaNCC"].Value?.ToString() ?? string.Empty;
                        txtNHNgayNhan.Text = row.Cells["NgayNhan"].Value?.ToString() ?? string.Empty;
                        txtNHMaNV.Text = row.Cells["MaNV"].Value?.ToString() ?? string.Empty;

                        // Xử lý giá trị TongTien an toàn
                        var tongTienValue = row.Cells["TongTien"].Value;
                        if (tongTienValue != null && tongTienValue != DBNull.Value)
                        {
                            nudNHGia.Value = Convert.ToDecimal(tongTienValue);
                        }
                        else
                        {
                            nudNHGia.Value = 0;
                        }
                    }
                    else
                    {
                        ClearInputs();
                    }
                }
                else
                {
                    ClearInputs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearInputs();
            }
        }

        private void btnNHThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInputs()) return;

                var newNhanHang = new Entities.NhapHang
                {
                    MaNCC = txtNHMaNCC.Text,
                    NgayNhan = DateTime.Parse(txtNHNgayNhan.Text),
                    MaNV = txtNHMaNV.Text,
                    TongTien = nudNHGia.Value
                };

                var (success, message) = _bll.AddNH(newNhanHang);
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
                MessageBox.Show("Lỗi khi thêm phiếu nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNHXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maPhieu = txtNHMa.Text;
                if (string.IsNullOrWhiteSpace(maPhieu))
                {
                    MessageBox.Show("Vui lòng chọn phiếu nhập cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu nhập này?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    var (success, message) = _bll.DeleteNH(maPhieu);
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
                MessageBox.Show("Lỗi khi xóa phiếu nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNHSua_Click(object sender, EventArgs e)
        {
            try
            {
                string maPhieu = txtNHMa.Text;
                if (string.IsNullOrWhiteSpace(maPhieu))
                {
                    MessageBox.Show("Vui lòng chọn phiếu nhập cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidateInputs()) return;

                var updatedNhanHang = new Entities.NhapHang
                {
                    MaPhieu = maPhieu,
                    MaNCC = txtNHMaNCC.Text,
                    NgayNhan = DateTime.Parse(txtNHNgayNhan.Text),
                    MaNV = txtNHMaNV.Text,
                    TongTien = nudNHGia.Value
                };

                var (success, message) = _bll.UpdateNH(updatedNhanHang);
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
                MessageBox.Show("Lỗi khi cập nhật phiếu nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNH_Exit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận thoát",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnMay_TimKiem_Click(object sender, EventArgs e)
        {

        }

        private void btnNH_CTDNH_Click(object sender, EventArgs e)
        {
            string maPhieu = txtNHMa.Text;
            if (string.IsNullOrWhiteSpace(maPhieu))
            {
                MessageBox.Show("Vui lòng chọn một phiếu nhập trên danh sách để xem chi tiết!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            fChiTietDonDH fChiTietDonDH = new fChiTietDonDH(maPhieu);
            fChiTietDonDH.ShowDialog();
        }

        private void btnNHHuy_Click(object sender, EventArgs e)
        {

        }
    }
}
