using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class fHoaDon : Form
    {
        private HoaDonBLL _bll;
        public fHoaDon()
        {
            InitializeComponent();
            _bll = new BLL.HoaDonBLL();
            LoadDGV();
        }

        private void LoadDGV()
        {
            try
            {
                DataTable data = _bll.GetAllHD();
                dgvHD.DataSource = data;

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
            txtHD_MaHDB.Clear();
            txtHD_MaNV.Clear();
            txtHD_MaKH.Clear();
            txtHD_NgayXuat.Clear();
            txtHD_TongTienBan.Clear();
            txtHD_ChiPhiKhac.Clear();
        }

        private void btnHD_Back_Click(object sender, EventArgs e)
        {
            fTrangChu fTrangChu = new fTrangChu();
            fTrangChu.Show();
            this.Hide();
        }

        private void btnHD_Them_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra và chuyển đổi dữ liệu
                if (!double.TryParse(txtHD_TongTienBan.Text, out double tongTien))
                {
                    MessageBox.Show("Vui lòng nhập tổng tiền hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!DateTime.TryParse(txtHD_NgayXuat.Text, out DateTime ngayXuat))
                {
                    MessageBox.Show("Vui lòng nhập ngày xuất hợp lệ (yyyy-MM-dd)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var newHoaDon = new Entities.HoaDon
                {
                    MaHDB = txtHD_MaHDB.Text.Trim(),
                    MaNV = txtHD_MaNV.Text.Trim(),
                    MaKH = txtHD_MaKH.Text.Trim(),
                    NgayLapHD = txtHD_NgayXuat.Text.Trim(),
                    TongTien = tongTien
                };

                var (success, message) = _bll.AddHoaDon(newHoaDon);

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

        private void btnHD_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maHD = txtHD_MaHDB.Text.Trim();

                // Xác nhận xóa
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn này?",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var (success, message) = _bll.DeleteHoaDon(maHD);

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

        private void btnHD_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra và chuyển đổi dữ liệu
                if (!double.TryParse(txtHD_TongTienBan.Text, out double tongTien))
                {
                    MessageBox.Show("Vui lòng nhập tổng tiền hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!DateTime.TryParse(txtHD_NgayXuat.Text, out DateTime ngayXuat))
                {
                    MessageBox.Show("Vui lòng nhập ngày xuất hợp lệ (yyyy-MM-dd)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var updatedHoaDon = new Entities.HoaDon
                {
                    MaHDB = txtHD_MaHDB.Text.Trim(),
                    MaNV = txtHD_MaNV.Text.Trim(),
                    MaKH = txtHD_MaKH.Text.Trim(),
                    NgayLapHD = txtHD_NgayXuat.Text.Trim(),
                    TongTien = tongTien
                };

                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn cập nhật thông tin hóa đơn này?",
                    "Xác nhận cập nhật", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var (success, message) = _bll.UpdateHoaDon(updatedHoaDon);

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

        private void dgvHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvHD.Rows[e.RowIndex];

                    txtHD_MaHDB.Text = row.Cells["MaHDB"].Value?.ToString() ?? string.Empty;
                    txtHD_MaNV.Text = row.Cells["MaNV"].Value?.ToString() ?? string.Empty;
                    txtHD_MaKH.Text = row.Cells["MaKH"].Value?.ToString() ?? string.Empty;

                    // Xử lý ngày xuất
                    if (row.Cells["NgayXuatHDB"].Value != null &&
                        DateTime.TryParse(row.Cells["NgayXuatHDB"].Value.ToString(), out DateTime ngayXuat))
                    {
                        txtHD_NgayXuat.Text = ngayXuat.ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        txtHD_NgayXuat.Clear();
                    }

                    // Xử lý số tiền
                    txtHD_TongTienBan.Text = row.Cells["TongTienBan"].Value?.ToString() ?? "0";
                    txtHD_ChiPhiKhac.Text = row.Cells["ChiPhiKhac"].Value?.ToString() ?? "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHD_Exit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?",
                "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnHD_TimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string maHD = txtHD_MaHDB.Text.Trim();
                DataTable data = _bll.SearchHoaDonByMa(maHD);
                dgvHD.DataSource = data;
                if (data.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn phù hợp!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fChiTietHD fChiTietHD = new fChiTietHD();
            fChiTietHD.ShowDialog();
            this.Close();
        }

        private void btnHD__Huy_Click(object sender, EventArgs e)
        {

        }
    }
}

