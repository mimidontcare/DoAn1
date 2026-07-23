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
    public partial class fChiTietDonDH : Form
    {
        private ChiTietDonDHBLL _bll;
        private string _maPhieu = "";

        public fChiTietDonDH()
        {
            InitializeComponent();
            _bll = new ChiTietDonDHBLL();
        }

        public fChiTietDonDH(string maPhieu) : this()
        {
            _maPhieu = maPhieu;
            txtCTDDH_MaDDH.Text = _maPhieu;
            txtCTDDH_MaDDH.ReadOnly = true;
            LoadDGV();
        }
        private void LoadDGV()
        {
            try
            {
                DataTable data = string.IsNullOrEmpty(_maPhieu) ? _bll.GetAllCTDDH() : _bll.GetCTDDHByMaDon(_maPhieu);
                dgvCTDDH.DataSource = data;

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

        private void dgvCTDDH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvCTDDH.Rows[e.RowIndex];
                    txtCTDDH_MaDDH.Text = row.Cells["MaPhieu"].Value?.ToString() ?? string.Empty;
                    txtCTDDH_MaMT.Text = row.Cells["MaMT"].Value?.ToString() ?? string.Empty;
                    txtCTDDH_SLban.Text = row.Cells["SoLuongNhap"].Value?.ToString() ?? string.Empty;
                    txtCTDDH_Giaban.Text = row.Cells["DonGiaNhap"].Value?.ToString() ?? string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCTDDH_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCTDDH_Exit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận thoát", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

      

        private void btnCTDDH_Them_Click(object sender, EventArgs e)
        {
            try
            {
                string maDonDatHang = txtCTDDH_MaDDH.Text.Trim();
                string maMT = txtCTDDH_MaMT.Text.Trim();
                int soLuong = int.TryParse(txtCTDDH_SLban.Text.Trim(), out int sl) ? sl : 0;
                decimal giaBan = decimal.TryParse(txtCTDDH_Giaban.Text.Trim(), out decimal gb) ? gb : 0;
                var (success, message) = _bll.AddCTDDH(maDonDatHang, maMT, soLuong, giaBan);
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

        private void btnCTDDH_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maDonDatHang = txtCTDDH_MaDDH.Text.Trim();
                string maMT = txtCTDDH_MaMT.Text.Trim();
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa chi tiết đơn đặt hàng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    var (success, message) = _bll.DeleteCTDDH(maDonDatHang, maMT);
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

        private void btnCTDDH_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                string maDonDatHang = txtCTDDH_MaDDH.Text.Trim();
                string maMT = txtCTDDH_MaMT.Text.Trim();
                int soLuong = int.TryParse(txtCTDDH_SLban.Text.Trim(), out int sl) ? sl : 0;
                decimal giaBan = decimal.TryParse(txtCTDDH_Giaban.Text.Trim(), out decimal gb) ? gb : 0;
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn cập nhật chi tiết đơn đặt hàng này?", "Xác nhận cập nhật", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    var (success, message) = _bll.UpdateCTDDH(maDonDatHang, maMT, soLuong, giaBan);
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

        private void fChiTietDonDH_Load(object sender, EventArgs e)
        {

        }
    }
}
