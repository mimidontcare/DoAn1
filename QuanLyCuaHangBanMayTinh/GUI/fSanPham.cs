using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Entities;

namespace GUI
{
    public partial class fSanPham : Form
    {
        private SanPhamBLL _bll;
        public fSanPham()
        {
            InitializeComponent();
            _bll = new BLL.SanPhamBLL();
            LoadDGV();
        }

        private void LoadDGV()
        {
            try
            {
                DataTable data = _bll.GetAllSP();
                dgvMay.DataSource = data;

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
            txtMayMa.Clear();
            txtMayTen.Clear();
            txtMayMaNCC.Clear();
            nudMayGia.Value = nudMayGia.Minimum;
            nudMaySoLuong.Value = nudMaySoLuong.Minimum;
        }

        private void btnMT_Back_Click(object sender, EventArgs e)
        {
            fTrangChu trangChuForm = new fTrangChu();
            trangChuForm.Show();
            this.Close();
        }

        private void btnMayThem_Click(object sender, EventArgs e)
        {
            try
            {
                var newSanPham = new SanPham
                {
                    MaSP = txtMayMa.Text.Trim(),
                    TenSP = txtMayTen.Text.Trim(),
                    DonGia = (int)nudMayGia.Value,
                    SoLuong = (int)nudMaySoLuong.Value,
                    MaNCC = txtMayMaNCC.Text.Trim(),
                };

                var (success, message) = _bll.AddSanPham(newSanPham);

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

        private void btnMayXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maSP = txtMayMa.Text.Trim();

                // Xác nhận xóa
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var (success, message) = _bll.DeleteSanPham(maSP);

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

        private void btnMaySua_Click(object sender, EventArgs e)
        {
            try
            {
                var updatedSP = new SanPham
                {
                    MaSP = txtMayMa.Text.Trim(),
                    TenSP = txtMayTen.Text.Trim(),
                    DonGia = (int)nudMayGia.Value,
                    SoLuong = (int)nudMaySoLuong.Value,
                    MaNCC = txtMayMaNCC.Text.Trim()
                };

                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn cập nhật thông tin sản phẩm này?",
                    "Xác nhận cập nhật", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var (success, message) = _bll.UpdateSanPham(updatedSP);

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

        private void dgvMay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvMay.Rows[e.RowIndex];

                    txtMayMa.Text = row.Cells["MaMT"].Value?.ToString() ?? string.Empty;
                    txtMayMaNCC.Text = row.Cells["MaNCC"].Value?.ToString() ?? string.Empty;
                    txtMayTen.Text = row.Cells["TenMT"].Value?.ToString() ?? string.Empty;

                    if (decimal.TryParse(row.Cells["SoLuongMT"].Value?.ToString(), out decimal soLuong))
                    {
                        nudMaySoLuong.Value = soLuong;
                    }

                    if (decimal.TryParse(row.Cells["GiaMT"].Value?.ToString(), out decimal gia))
                    {
                        nudMayGia.Value = gia;
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

        private void btnMay_TimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string searchMaSP = txtMay_TimKiem.Text.Trim();
                DataTable searchResult = _bll.SearchSanPhamByMa(searchMaSP);

                dgvMay.DataSource = searchResult;

                if (searchResult.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy sản phẩm nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


        private void btnMayHuy_Click_1(object sender, EventArgs e)
        {
            ClearInputs();
        }
    }
}
