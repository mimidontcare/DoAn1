namespace GUI
{
    partial class fKhachHang
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
            this.btnKH_TimKiem = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtKH_TimKiem = new System.Windows.Forms.TextBox();
            this.btnKH_Back = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnKH_Exit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvKH = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnKH_Sua = new System.Windows.Forms.Button();
            this.btnKH_Xoa = new System.Windows.Forms.Button();
            this.btnKH_Them = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKH_GioiTinh = new System.Windows.Forms.TextBox();
            this.txtKH_SDT = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtKH_DiaChi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKH_Ten = new System.Windows.Forms.TextBox();
            this.txtKH_Ma = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKH)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnKH_TimKiem
            // 
            this.btnKH_TimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnKH_TimKiem.Image = global::GUI.Properties.Resources.search_1102213__1_;
            this.btnKH_TimKiem.Location = new System.Drawing.Point(355, 39);
            this.btnKH_TimKiem.Name = "btnKH_TimKiem";
            this.btnKH_TimKiem.Size = new System.Drawing.Size(28, 32);
            this.btnKH_TimKiem.TabIndex = 2;
            this.btnKH_TimKiem.UseVisualStyleBackColor = true;
            this.btnKH_TimKiem.Click += new System.EventHandler(this.btnKH_TimKiem_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(175, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 29);
            this.label5.TabIndex = 0;
            this.label5.Text = "Tìm Kiếm";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnKH_TimKiem);
            this.panel3.Controls.Add(this.txtKH_TimKiem);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(394, 97);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(442, 91);
            this.panel3.TabIndex = 15;
            // 
            // txtKH_TimKiem
            // 
            this.txtKH_TimKiem.Location = new System.Drawing.Point(119, 39);
            this.txtKH_TimKiem.Multiline = true;
            this.txtKH_TimKiem.Name = "txtKH_TimKiem";
            this.txtKH_TimKiem.Size = new System.Drawing.Size(216, 34);
            this.txtKH_TimKiem.TabIndex = 1;
            // 
            // btnKH_Back
            // 
            this.btnKH_Back.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnKH_Back.Image = global::GUI.Properties.Resources.back;
            this.btnKH_Back.Location = new System.Drawing.Point(34, 12);
            this.btnKH_Back.Name = "btnKH_Back";
            this.btnKH_Back.Size = new System.Drawing.Size(69, 59);
            this.btnKH_Back.TabIndex = 3;
            this.btnKH_Back.UseVisualStyleBackColor = false;
            this.btnKH_Back.Click += new System.EventHandler(this.btnKH_Back_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(444, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(392, 38);
            this.label7.TabIndex = 1;
            this.label7.Text = "QUẢN LÝ KHÁCH HÀNG";
            // 
            // btnKH_Exit
            // 
            this.btnKH_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnKH_Exit.Image = global::GUI.Properties.Resources.Thoat;
            this.btnKH_Exit.Location = new System.Drawing.Point(1072, -3);
            this.btnKH_Exit.Name = "btnKH_Exit";
            this.btnKH_Exit.Size = new System.Drawing.Size(78, 89);
            this.btnKH_Exit.TabIndex = 2;
            this.btnKH_Exit.UseVisualStyleBackColor = false;
            this.btnKH_Exit.Click += new System.EventHandler(this.btnKH_Exit_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(104)))));
            this.panel1.Controls.Add(this.btnKH_Back);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btnKH_Exit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1176, 92);
            this.panel1.TabIndex = 14;
            // 
            // dgvKH
            // 
            this.dgvKH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKH.Location = new System.Drawing.Point(3, 26);
            this.dgvKH.Name = "dgvKH";
            this.dgvKH.RowHeadersWidth = 51;
            this.dgvKH.RowTemplate.Height = 24;
            this.dgvKH.Size = new System.Drawing.Size(1080, 249);
            this.dgvKH.TabIndex = 0;
            this.dgvKH.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKH_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvKH);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(54, 515);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1086, 278);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh Sách Khách Hàng";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnKH_Sua);
            this.panel2.Controls.Add(this.btnKH_Xoa);
            this.panel2.Controls.Add(this.btnKH_Them);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(245, 463);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(710, 47);
            this.panel2.TabIndex = 12;
            // 
            // btnKH_Sua
            // 
            this.btnKH_Sua.Location = new System.Drawing.Point(573, 0);
            this.btnKH_Sua.Margin = new System.Windows.Forms.Padding(2);
            this.btnKH_Sua.Name = "btnKH_Sua";
            this.btnKH_Sua.Size = new System.Drawing.Size(137, 45);
            this.btnKH_Sua.TabIndex = 2;
            this.btnKH_Sua.Text = "SỬA";
            this.btnKH_Sua.UseVisualStyleBackColor = true;
            this.btnKH_Sua.Click += new System.EventHandler(this.btnKH_Sua_Click);
            // 
            // btnKH_Xoa
            // 
            this.btnKH_Xoa.Location = new System.Drawing.Point(289, 2);
            this.btnKH_Xoa.Margin = new System.Windows.Forms.Padding(2);
            this.btnKH_Xoa.Name = "btnKH_Xoa";
            this.btnKH_Xoa.Size = new System.Drawing.Size(137, 43);
            this.btnKH_Xoa.TabIndex = 1;
            this.btnKH_Xoa.Text = "XÓA ";
            this.btnKH_Xoa.UseVisualStyleBackColor = true;
            this.btnKH_Xoa.Click += new System.EventHandler(this.btnKH_Xoa_Click);
            // 
            // btnKH_Them
            // 
            this.btnKH_Them.Location = new System.Drawing.Point(2, 2);
            this.btnKH_Them.Margin = new System.Windows.Forms.Padding(2);
            this.btnKH_Them.Name = "btnKH_Them";
            this.btnKH_Them.Size = new System.Drawing.Size(135, 43);
            this.btnKH_Them.TabIndex = 0;
            this.btnKH_Them.Text = "THÊM";
            this.btnKH_Them.UseVisualStyleBackColor = true;
            this.btnKH_Them.Click += new System.EventHandler(this.btnKH_Them_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã Khách Hàng";
            // 
            // txtKH_GioiTinh
            // 
            this.txtKH_GioiTinh.Location = new System.Drawing.Point(726, 104);
            this.txtKH_GioiTinh.Margin = new System.Windows.Forms.Padding(2);
            this.txtKH_GioiTinh.Multiline = true;
            this.txtKH_GioiTinh.Name = "txtKH_GioiTinh";
            this.txtKH_GioiTinh.Size = new System.Drawing.Size(262, 35);
            this.txtKH_GioiTinh.TabIndex = 13;
            // 
            // txtKH_SDT
            // 
            this.txtKH_SDT.Location = new System.Drawing.Point(726, 41);
            this.txtKH_SDT.Margin = new System.Windows.Forms.Padding(2);
            this.txtKH_SDT.Multiline = true;
            this.txtKH_SDT.Name = "txtKH_SDT";
            this.txtKH_SDT.Size = new System.Drawing.Size(262, 35);
            this.txtKH_SDT.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(527, 124);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 25);
            this.label6.TabIndex = 10;
            this.label6.Text = "Giới Tính";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(527, 41);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Số Điện Thoại";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 178);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Địa Chỉ";
            // 
            // txtKH_DiaChi
            // 
            this.txtKH_DiaChi.Location = new System.Drawing.Point(191, 164);
            this.txtKH_DiaChi.Margin = new System.Windows.Forms.Padding(2);
            this.txtKH_DiaChi.Multiline = true;
            this.txtKH_DiaChi.Name = "txtKH_DiaChi";
            this.txtKH_DiaChi.Size = new System.Drawing.Size(287, 49);
            this.txtKH_DiaChi.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 107);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tên Khách Hàng";
            // 
            // txtKH_Ten
            // 
            this.txtKH_Ten.Location = new System.Drawing.Point(191, 104);
            this.txtKH_Ten.Margin = new System.Windows.Forms.Padding(2);
            this.txtKH_Ten.Multiline = true;
            this.txtKH_Ten.Name = "txtKH_Ten";
            this.txtKH_Ten.Size = new System.Drawing.Size(287, 35);
            this.txtKH_Ten.TabIndex = 2;
            // 
            // txtKH_Ma
            // 
            this.txtKH_Ma.Location = new System.Drawing.Point(191, 41);
            this.txtKH_Ma.Margin = new System.Windows.Forms.Padding(2);
            this.txtKH_Ma.Multiline = true;
            this.txtKH_Ma.Name = "txtKH_Ma";
            this.txtKH_Ma.Size = new System.Drawing.Size(287, 35);
            this.txtKH_Ma.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtKH_GioiTinh);
            this.groupBox2.Controls.Add(this.txtKH_SDT);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtKH_DiaChi);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtKH_Ten);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtKH_Ma);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(54, 203);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1114, 228);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin Khách Hàng";
            // 
            // fKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(1176, 811);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox2);
            this.Name = "fKhachHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fKhachHang";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKH)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnKH_TimKiem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtKH_TimKiem;
        private System.Windows.Forms.Button btnKH_Back;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnKH_Exit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvKH;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnKH_Sua;
        private System.Windows.Forms.Button btnKH_Xoa;
        private System.Windows.Forms.Button btnKH_Them;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKH_GioiTinh;
        private System.Windows.Forms.TextBox txtKH_SDT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtKH_DiaChi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKH_Ten;
        private System.Windows.Forms.TextBox txtKH_Ma;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}