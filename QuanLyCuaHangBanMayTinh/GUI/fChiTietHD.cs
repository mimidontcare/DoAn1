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
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

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
                try
                {
                    QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;
                    string maHD = txtCTHD_MaHD.Text;
                    DataTable reportData = _bll.GetCTHDByID(maHD);

                    if (reportData == null || reportData.Rows.Count == 0)
                    {
                        MessageBox.Show("Không có dữ liệu cho hóa đơn này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    string filePath = $"HoaDon_{maHD}_{DateTime.Now:yyyyMMddHHmmss}.pdf";

                    QuestPDF.Fluent.Document.Create(container =>
                    {
                        container.Page(page =>
                        {
                            page.Size(QuestPDF.Helpers.PageSizes.A4);
                            page.Margin(2, QuestPDF.Infrastructure.Unit.Centimetre);
                            page.PageColor(QuestPDF.Helpers.Colors.White);
                            page.DefaultTextStyle(x => x.FontSize(12));

                            page.Header().Element(compose => 
                            {
                                compose.Column(col => 
                                {
                                    col.Item().Text("CỬA HÀNG BÁN MÁY TÍNH").FontSize(20).SemiBold().FontColor(QuestPDF.Helpers.Colors.Blue.Darken2);
                                    col.Item().Text($"HÓA ĐƠN BÁN HÀNG - {maHD}").FontSize(16).SemiBold();
                                    col.Item().Text($"Ngày in: {DateTime.Now:dd/MM/yyyy HH:mm}");
                                });
                            });

                            page.Content().PaddingVertical(1, QuestPDF.Infrastructure.Unit.Centimetre).Column(col =>
                            {
                                col.Item().Table(table =>
                                {
                                    table.ColumnsDefinition(columns =>
                                    {
                                        columns.ConstantColumn(50); // STT
                                        columns.RelativeColumn();   // MaMT
                                        columns.RelativeColumn();   // SL
                                        columns.RelativeColumn();   // Gia
                                        columns.RelativeColumn();   // ThanhTien
                                    });

                                    table.Header(header =>
                                    {
                                        header.Cell().Text("STT").SemiBold();
                                        header.Cell().Text("Mã Máy Tính").SemiBold();
                                        header.Cell().Text("Số Lượng").SemiBold();
                                        header.Cell().Text("Giá Bán").SemiBold();
                                        header.Cell().Text("Thành Tiền").SemiBold();
                                    });

                                    decimal total = 0;
                                    for (int i = 0; i < reportData.Rows.Count; i++)
                                    {
                                        var row = reportData.Rows[i];
                                        string maMT = row["MaMT"].ToString();
                                        int sl = Convert.ToInt32(row["SLBan"]);
                                        decimal gia = Convert.ToDecimal(row["GiaBan"]);
                                        decimal thanhTien = sl * gia;
                                        total += thanhTien;

                                        table.Cell().Text((i + 1).ToString());
                                        table.Cell().Text(maMT);
                                        table.Cell().Text(sl.ToString());
                                        table.Cell().Text(gia.ToString("N0"));
                                        table.Cell().Text(thanhTien.ToString("N0"));
                                    }

                                    col.Item().PaddingTop(10).AlignRight().Text($"Tổng Cộng: {total:N0} VND").FontSize(14).SemiBold();
                                });
                            });

                            page.Footer().AlignCenter().Text(x =>
                            {
                                x.Span("Trang ");
                                x.CurrentPageNumber();
                                x.Span(" / ");
                                x.TotalPages();
                            });
                        });
                    })
                    .GeneratePdf(filePath);

                    System.Diagnostics.Process.Start(filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tạo PDF: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
