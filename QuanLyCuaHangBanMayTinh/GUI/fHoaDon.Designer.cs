namespace GUI
{
    partial class fHoaDon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvHD = new System.Windows.Forms.DataGridView();
            this.txtHD_MaNV = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHD_MaHDB = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnHD_TimKiem = new System.Windows.Forms.Button();
            this.txtHD_TimKiem = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHD_TongTienBan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnHD_Sua = new System.Windows.Forms.Button();
            this.btnHD_Xoa = new System.Windows.Forms.Button();
            this.btnHD_Them = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtHD_ChiPhiKhac = new System.Windows.Forms.TextBox();
            this.txtHD_MaKH = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtHD_NgayXuat = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnHD_Back = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnHD_Exit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHD)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvHD
            // 
            this.dgvHD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHD.ColumnHeadersHeight = 29;
            this.dgvHD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHD.Location = new System.Drawing.Point(3, 26);
            this.dgvHD.Margin = new System.Windows.Forms.Padding(2);
            this.dgvHD.Name = "dgvHD";
            this.dgvHD.RowHeadersWidth = 51;
            this.dgvHD.RowTemplate.Height = 24;
            this.dgvHD.Size = new System.Drawing.Size(1099, 270);
            this.dgvHD.TabIndex = 0;
            this.dgvHD.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHD_CellClick);
            // 
            // txtHD_MaNV
            // 
            this.txtHD_MaNV.Location = new System.Drawing.Point(183, 103);
            this.txtHD_MaNV.Margin = new System.Windows.Forms.Padding(2);
            this.txtHD_MaNV.Multiline = true;
            this.txtHD_MaNV.Name = "txtHD_MaNV";
            this.txtHD_MaNV.Size = new System.Drawing.Size(287, 35);
            this.txtHD_MaNV.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã Hóa Đơn";
            // 
            // txtHD_MaHDB
            // 
            this.txtHD_MaHDB.Location = new System.Drawing.Point(183, 41);
            this.txtHD_MaHDB.Margin = new System.Windows.Forms.Padding(2);
            this.txtHD_MaHDB.Multiline = true;
            this.txtHD_MaHDB.Name = "txtHD_MaHDB";
            this.txtHD_MaHDB.Size = new System.Drawing.Size(287, 33);
            this.txtHD_MaHDB.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnHD_TimKiem);
            this.panel3.Controls.Add(this.txtHD_TimKiem);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(368, 106);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(442, 91);
            this.panel3.TabIndex = 19;
            // 
            // btnHD_TimKiem
            // 
            this.btnHD_TimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHD_TimKiem.Image = global::GUI.Properties.Resources.search_1102213__1_;
            this.btnHD_TimKiem.Location = new System.Drawing.Point(355, 39);
            this.btnHD_TimKiem.Name = "btnHD_TimKiem";
            this.btnHD_TimKiem.Size = new System.Drawing.Size(28, 32);
            this.btnHD_TimKiem.TabIndex = 2;
            this.btnHD_TimKiem.UseVisualStyleBackColor = true;
            this.btnHD_TimKiem.Click += new System.EventHandler(this.btnHD_TimKiem_Click);
            // 
            // txtHD_TimKiem
            // 
            this.txtHD_TimKiem.Location = new System.Drawing.Point(119, 39);
            this.txtHD_TimKiem.Multiline = true;
            this.txtHD_TimKiem.Name = "txtHD_TimKiem";
            this.txtHD_TimKiem.Size = new System.Drawing.Size(216, 34);
            this.txtHD_TimKiem.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(169, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 29);
            this.label8.TabIndex = 0;
            this.label8.Text = "Tìm Kiếm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 174);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tổng Tiền Bán";
            // 
            // txtHD_TongTienBan
            // 
            this.txtHD_TongTienBan.Location = new System.Drawing.Point(183, 174);
            this.txtHD_TongTienBan.Margin = new System.Windows.Forms.Padding(2);
            this.txtHD_TongTienBan.Multiline = true;
            this.txtHD_TongTienBan.Name = "txtHD_TongTienBan";
            this.txtHD_TongTienBan.Size = new System.Drawing.Size(287, 33);
            this.txtHD_TongTienBan.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 106);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mã Nhân Viên";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnHD_Sua);
            this.panel2.Controls.Add(this.btnHD_Xoa);
            this.panel2.Controls.Add(this.btnHD_Them);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(218, 446);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(710, 47);
            this.panel2.TabIndex = 18;
            // 
            // btnHD_Sua
            // 
            this.btnHD_Sua.Location = new System.Drawing.Point(571, 1);
            this.btnHD_Sua.Margin = new System.Windows.Forms.Padding(2);
            this.btnHD_Sua.Name = "btnHD_Sua";
            this.btnHD_Sua.Size = new System.Drawing.Size(137, 45);
            this.btnHD_Sua.TabIndex = 2;
            this.btnHD_Sua.Text = "SỬA";
            this.btnHD_Sua.UseVisualStyleBackColor = true;
            this.btnHD_Sua.Click += new System.EventHandler(this.btnHD_Sua_Click);
            // 
            // btnHD_Xoa
            // 
            this.btnHD_Xoa.Location = new System.Drawing.Point(287, 2);
            this.btnHD_Xoa.Margin = new System.Windows.Forms.Padding(2);
            this.btnHD_Xoa.Name = "btnHD_Xoa";
            this.btnHD_Xoa.Size = new System.Drawing.Size(137, 43);
            this.btnHD_Xoa.TabIndex = 1;
            this.btnHD_Xoa.Text = "XÓA ";
            this.btnHD_Xoa.UseVisualStyleBackColor = true;
            this.btnHD_Xoa.Click += new System.EventHandler(this.btnHD_Xoa_Click);
            // 
            // btnHD_Them
            // 
            this.btnHD_Them.Location = new System.Drawing.Point(2, 2);
            this.btnHD_Them.Margin = new System.Windows.Forms.Padding(2);
            this.btnHD_Them.Name = "btnHD_Them";
            this.btnHD_Them.Size = new System.Drawing.Size(135, 43);
            this.btnHD_Them.TabIndex = 0;
            this.btnHD_Them.Text = "THÊM";
            this.btnHD_Them.UseVisualStyleBackColor = true;
            this.btnHD_Them.Click += new System.EventHandler(this.btnHD_Them_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(527, 174);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 25);
            this.label5.TabIndex = 16;
            this.label5.Text = "Chi Phí Khác";
            // 
            // txtHD_ChiPhiKhac
            // 
            this.txtHD_ChiPhiKhac.Location = new System.Drawing.Point(726, 174);
            this.txtHD_ChiPhiKhac.Margin = new System.Windows.Forms.Padding(2);
            this.txtHD_ChiPhiKhac.Multiline = true;
            this.txtHD_ChiPhiKhac.Name = "txtHD_ChiPhiKhac";
            this.txtHD_ChiPhiKhac.Size = new System.Drawing.Size(262, 33);
            this.txtHD_ChiPhiKhac.TabIndex = 15;
            // 
            // txtHD_MaKH
            // 
            this.txtHD_MaKH.Location = new System.Drawing.Point(726, 41);
            this.txtHD_MaKH.Margin = new System.Windows.Forms.Padding(2);
            this.txtHD_MaKH.Multiline = true;
            this.txtHD_MaKH.Name = "txtHD_MaKH";
            this.txtHD_MaKH.Size = new System.Drawing.Size(262, 33);
            this.txtHD_MaKH.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(527, 113);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 25);
            this.label6.TabIndex = 10;
            this.label6.Text = "Ngày Xuất HD";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(527, 41);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Mã Khách Hàng";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtHD_NgayXuat);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtHD_ChiPhiKhac);
            this.groupBox2.Controls.Add(this.txtHD_MaKH);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtHD_TongTienBan);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtHD_MaNV);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtHD_MaHDB);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(35, 203);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1105, 228);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin chung";
            // 
            // txtHD_NgayXuat
            // 
            this.txtHD_NgayXuat.Location = new System.Drawing.Point(726, 103);
            this.txtHD_NgayXuat.Margin = new System.Windows.Forms.Padding(2);
            this.txtHD_NgayXuat.Multiline = true;
            this.txtHD_NgayXuat.Name = "txtHD_NgayXuat";
            this.txtHD_NgayXuat.Size = new System.Drawing.Size(262, 35);
            this.txtHD_NgayXuat.TabIndex = 17;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvHD);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(35, 498);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1105, 299);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Hóa Đơn";
            // 
            // btnHD_Back
            // 
            this.btnHD_Back.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHD_Back.Image = global::GUI.Properties.Resources.back;
            this.btnHD_Back.Location = new System.Drawing.Point(34, 12);
            this.btnHD_Back.Name = "btnHD_Back";
            this.btnHD_Back.Size = new System.Drawing.Size(69, 59);
            this.btnHD_Back.TabIndex = 3;
            this.btnHD_Back.UseVisualStyleBackColor = false;
            this.btnHD_Back.Click += new System.EventHandler(this.btnHD_Back_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(444, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(326, 38);
            this.label7.TabIndex = 1;
            this.label7.Text = "QUẢN LÝ HÓA ĐƠN";
            // 
            // btnHD_Exit
            // 
            this.btnHD_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHD_Exit.Image = global::GUI.Properties.Resources.Thoat;
            this.btnHD_Exit.Location = new System.Drawing.Point(1076, 0);
            this.btnHD_Exit.Name = "btnHD_Exit";
            this.btnHD_Exit.Size = new System.Drawing.Size(78, 89);
            this.btnHD_Exit.TabIndex = 2;
            this.btnHD_Exit.UseVisualStyleBackColor = false;
            this.btnHD_Exit.Click += new System.EventHandler(this.btnHD_Exit_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(104)))));
            this.panel1.Controls.Add(this.btnHD_Back);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btnHD_Exit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1176, 92);
            this.panel1.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(936, 141);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 38);
            this.button1.TabIndex = 20;
            this.button1.Text = "Chi tiết hóa đơn";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // fHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(1176, 811);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "fHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fHoaDon";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHD)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHD;
        private System.Windows.Forms.TextBox txtHD_MaNV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHD_MaHDB;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnHD_TimKiem;
        private System.Windows.Forms.TextBox txtHD_TimKiem;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHD_TongTienBan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnHD_Sua;
        private System.Windows.Forms.Button btnHD_Xoa;
        private System.Windows.Forms.Button btnHD_Them;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtHD_ChiPhiKhac;
        private System.Windows.Forms.TextBox txtHD_MaKH;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtHD_NgayXuat;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnHD_Back;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnHD_Exit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
    }
}