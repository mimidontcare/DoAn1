namespace GUI
{
    partial class fNhapHang
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtNHMa = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnMay_TimKiem = new System.Windows.Forms.Button();
            this.txtNH_TimKiem = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNHMaNCC = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNHMaNV = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNH_Back = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnNH_Exit = new System.Windows.Forms.Button();
            this.dgvNH = new System.Windows.Forms.DataGridView();
            this.nudNHGia = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNHSua = new System.Windows.Forms.Button();
            this.btnNHXoa = new System.Windows.Forms.Button();
            this.btnNHThem = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtNHNgayNhan = new System.Windows.Forms.TextBox();
            this.btnNH_CTDNH = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNHGia)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNHMa
            // 
            this.txtNHMa.Location = new System.Drawing.Point(209, 41);
            this.txtNHMa.Margin = new System.Windows.Forms.Padding(2);
            this.txtNHMa.Name = "txtNHMa";
            this.txtNHMa.Size = new System.Drawing.Size(241, 30);
            this.txtNHMa.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnMay_TimKiem);
            this.panel3.Controls.Add(this.txtNH_TimKiem);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(388, 98);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(442, 91);
            this.panel3.TabIndex = 24;
            // 
            // btnMay_TimKiem
            // 
            this.btnMay_TimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMay_TimKiem.Image = global::GUI.Properties.Resources.search_1102213__1_;
            this.btnMay_TimKiem.Location = new System.Drawing.Point(355, 39);
            this.btnMay_TimKiem.Name = "btnMay_TimKiem";
            this.btnMay_TimKiem.Size = new System.Drawing.Size(28, 32);
            this.btnMay_TimKiem.TabIndex = 2;
            this.btnMay_TimKiem.UseVisualStyleBackColor = true;
            this.btnMay_TimKiem.Click += new System.EventHandler(this.btnMay_TimKiem_Click);
            // 
            // txtNH_TimKiem
            // 
            this.txtNH_TimKiem.Location = new System.Drawing.Point(119, 39);
            this.txtNH_TimKiem.Multiline = true;
            this.txtNH_TimKiem.Name = "txtNH_TimKiem";
            this.txtNH_TimKiem.Size = new System.Drawing.Size(216, 34);
            this.txtNH_TimKiem.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(162, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 29);
            this.label6.TabIndex = 0;
            this.label6.Text = "Tìm Kiếm";
            // 
            // txtNHMaNCC
            // 
            this.txtNHMaNCC.Location = new System.Drawing.Point(209, 186);
            this.txtNHMaNCC.Margin = new System.Windows.Forms.Padding(2);
            this.txtNHMaNCC.Name = "txtNHMaNCC";
            this.txtNHMaNCC.Size = new System.Drawing.Size(241, 30);
            this.txtNHMaNCC.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 122);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mã Nhân viên";
            // 
            // txtNHMaNV
            // 
            this.txtNHMaNV.Location = new System.Drawing.Point(209, 119);
            this.txtNHMaNV.Margin = new System.Windows.Forms.Padding(2);
            this.txtNHMaNV.Name = "txtNHMaNV";
            this.txtNHMaNV.Size = new System.Drawing.Size(241, 30);
            this.txtNHMaNV.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã Phiếu";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(104)))));
            this.panel1.Controls.Add(this.btnNH_Back);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btnNH_Exit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1176, 92);
            this.panel1.TabIndex = 23;
            // 
            // btnNH_Back
            // 
            this.btnNH_Back.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNH_Back.Image = global::GUI.Properties.Resources.back;
            this.btnNH_Back.Location = new System.Drawing.Point(34, 12);
            this.btnNH_Back.Name = "btnNH_Back";
            this.btnNH_Back.Size = new System.Drawing.Size(69, 59);
            this.btnNH_Back.TabIndex = 3;
            this.btnNH_Back.UseVisualStyleBackColor = false;
            this.btnNH_Back.Click += new System.EventHandler(this.btnNH_Back_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(444, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(368, 38);
            this.label7.TabIndex = 1;
            this.label7.Text = "QUẢN LÝ NHẬP HÀNG";
            // 
            // btnNH_Exit
            // 
            this.btnNH_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNH_Exit.Image = global::GUI.Properties.Resources.Thoat;
            this.btnNH_Exit.Location = new System.Drawing.Point(1067, 0);
            this.btnNH_Exit.Name = "btnNH_Exit";
            this.btnNH_Exit.Size = new System.Drawing.Size(78, 92);
            this.btnNH_Exit.TabIndex = 2;
            this.btnNH_Exit.UseVisualStyleBackColor = false;
            this.btnNH_Exit.Click += new System.EventHandler(this.btnNH_Exit_Click);
            // 
            // dgvNH
            // 
            this.dgvNH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNH.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvNH.ColumnHeadersHeight = 29;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNH.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvNH.Location = new System.Drawing.Point(32, 535);
            this.dgvNH.Margin = new System.Windows.Forms.Padding(2);
            this.dgvNH.Name = "dgvNH";
            this.dgvNH.RowHeadersWidth = 51;
            this.dgvNH.RowTemplate.Height = 24;
            this.dgvNH.Size = new System.Drawing.Size(1133, 254);
            this.dgvNH.TabIndex = 22;
            this.dgvNH.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNH_CellClick);
            // 
            // nudNHGia
            // 
            this.nudNHGia.Location = new System.Drawing.Point(768, 130);
            this.nudNHGia.Margin = new System.Windows.Forms.Padding(2);
            this.nudNHGia.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudNHGia.Name = "nudNHGia";
            this.nudNHGia.Size = new System.Drawing.Size(189, 30);
            this.nudNHGia.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(593, 135);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "Tổng tiền";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(593, 44);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Ngày Nhận";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 186);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Mã Nhà CC";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnNHSua);
            this.panel2.Controls.Add(this.btnNHXoa);
            this.panel2.Controls.Add(this.btnNHThem);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(230, 463);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(710, 47);
            this.panel2.TabIndex = 21;
            // 
            // btnNHSua
            // 
            this.btnNHSua.Location = new System.Drawing.Point(572, 2);
            this.btnNHSua.Margin = new System.Windows.Forms.Padding(2);
            this.btnNHSua.Name = "btnNHSua";
            this.btnNHSua.Size = new System.Drawing.Size(137, 45);
            this.btnNHSua.TabIndex = 2;
            this.btnNHSua.Text = "SỬA";
            this.btnNHSua.UseVisualStyleBackColor = true;
            this.btnNHSua.Click += new System.EventHandler(this.btnNHSua_Click);
            // 
            // btnNHXoa
            // 
            this.btnNHXoa.Location = new System.Drawing.Point(288, 2);
            this.btnNHXoa.Margin = new System.Windows.Forms.Padding(2);
            this.btnNHXoa.Name = "btnNHXoa";
            this.btnNHXoa.Size = new System.Drawing.Size(137, 43);
            this.btnNHXoa.TabIndex = 1;
            this.btnNHXoa.Text = "XÓA ";
            this.btnNHXoa.UseVisualStyleBackColor = true;
            this.btnNHXoa.Click += new System.EventHandler(this.btnNHXoa_Click);
            // 
            // btnNHThem
            // 
            this.btnNHThem.Location = new System.Drawing.Point(2, 2);
            this.btnNHThem.Margin = new System.Windows.Forms.Padding(2);
            this.btnNHThem.Name = "btnNHThem";
            this.btnNHThem.Size = new System.Drawing.Size(135, 43);
            this.btnNHThem.TabIndex = 0;
            this.btnNHThem.Text = "THÊM";
            this.btnNHThem.UseVisualStyleBackColor = true;
            this.btnNHThem.Click += new System.EventHandler(this.btnNHThem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtNHNgayNhan);
            this.groupBox2.Controls.Add(this.nudNHGia);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtNHMaNCC);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtNHMaNV);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtNHMa);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(34, 204);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1111, 239);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chi tiết quản lý nhập hàng";
            // 
            // txtNHNgayNhan
            // 
            this.txtNHNgayNhan.Location = new System.Drawing.Point(768, 41);
            this.txtNHNgayNhan.Margin = new System.Windows.Forms.Padding(2);
            this.txtNHNgayNhan.Name = "txtNHNgayNhan";
            this.txtNHNgayNhan.Size = new System.Drawing.Size(190, 30);
            this.txtNHNgayNhan.TabIndex = 14;
            // 
            // btnNH_CTDNH
            // 
            this.btnNH_CTDNH.Location = new System.Drawing.Point(941, 126);
            this.btnNH_CTDNH.Margin = new System.Windows.Forms.Padding(2);
            this.btnNH_CTDNH.Name = "btnNH_CTDNH";
            this.btnNH_CTDNH.Size = new System.Drawing.Size(176, 43);
            this.btnNH_CTDNH.TabIndex = 25;
            this.btnNH_CTDNH.Text = "Chi Tiết Đơn Nhập Hàng";
            this.btnNH_CTDNH.UseVisualStyleBackColor = true;
            this.btnNH_CTDNH.Click += new System.EventHandler(this.btnNH_CTDNH_Click);
            // 
            // fNhapHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(1176, 811);
            this.Controls.Add(this.btnNH_CTDNH);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvNH);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox2);
            this.Name = "fNhapHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fNhapHang";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNHGia)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtNHMa;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnMay_TimKiem;
        private System.Windows.Forms.TextBox txtNH_TimKiem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNHMaNCC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNHMaNV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnNH_Back;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnNH_Exit;
        private System.Windows.Forms.DataGridView dgvNH;
        private System.Windows.Forms.NumericUpDown nudNHGia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnNHSua;
        private System.Windows.Forms.Button btnNHXoa;
        private System.Windows.Forms.Button btnNHThem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtNHNgayNhan;
        private System.Windows.Forms.Button btnNH_CTDNH;
    }
}