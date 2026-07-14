namespace GUI
{
    partial class fNhaCC
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
            this.txtNCC_SDT = new System.Windows.Forms.TextBox();
            this.txtNCC_DiaChi = new System.Windows.Forms.TextBox();
            this.txtNCC_Ten = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNCC_Ma = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvNCC = new System.Windows.Forms.DataGridView();
            this.btnNCC_Sua = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnNCC_Xoa = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNCC_Them = new System.Windows.Forms.Button();
            this.txtNCC_TimKiem = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnNCC_TimKiem = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNCC_Back = new System.Windows.Forms.Button();
            this.btnMT_Exit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNCC)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNCC_SDT
            // 
            this.txtNCC_SDT.Location = new System.Drawing.Point(754, 57);
            this.txtNCC_SDT.Multiline = true;
            this.txtNCC_SDT.Name = "txtNCC_SDT";
            this.txtNCC_SDT.Size = new System.Drawing.Size(254, 38);
            this.txtNCC_SDT.TabIndex = 10;
            // 
            // txtNCC_DiaChi
            // 
            this.txtNCC_DiaChi.Location = new System.Drawing.Point(754, 128);
            this.txtNCC_DiaChi.Multiline = true;
            this.txtNCC_DiaChi.Name = "txtNCC_DiaChi";
            this.txtNCC_DiaChi.Size = new System.Drawing.Size(254, 38);
            this.txtNCC_DiaChi.TabIndex = 9;
            // 
            // txtNCC_Ten
            // 
            this.txtNCC_Ten.Location = new System.Drawing.Point(257, 138);
            this.txtNCC_Ten.Multiline = true;
            this.txtNCC_Ten.Name = "txtNCC_Ten";
            this.txtNCC_Ten.Size = new System.Drawing.Size(212, 38);
            this.txtNCC_Ten.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(580, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "SĐT Nhà CC";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(580, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Địa chỉ NHà CC";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên Nhà Cung Cấp";
            // 
            // txtNCC_Ma
            // 
            this.txtNCC_Ma.Location = new System.Drawing.Point(257, 54);
            this.txtNCC_Ma.Multiline = true;
            this.txtNCC_Ma.Name = "txtNCC_Ma";
            this.txtNCC_Ma.Size = new System.Drawing.Size(212, 38);
            this.txtNCC_Ma.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNCC_SDT);
            this.groupBox1.Controls.Add(this.txtNCC_DiaChi);
            this.groupBox1.Controls.Add(this.txtNCC_Ten);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtNCC_Ma);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(31, 218);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1108, 200);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin Nhà Cung Cấp";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã Nhà Cung Cấp";
            // 
            // dgvNCC
            // 
            this.dgvNCC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNCC.ColumnHeadersHeight = 29;
            this.dgvNCC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNCC.Location = new System.Drawing.Point(3, 26);
            this.dgvNCC.Name = "dgvNCC";
            this.dgvNCC.RowHeadersWidth = 51;
            this.dgvNCC.RowTemplate.Height = 24;
            this.dgvNCC.Size = new System.Drawing.Size(1108, 264);
            this.dgvNCC.TabIndex = 0;
            this.dgvNCC.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNCC_CellClick);
            // 
            // btnNCC_Sua
            // 
            this.btnNCC_Sua.Location = new System.Drawing.Point(573, 2);
            this.btnNCC_Sua.Margin = new System.Windows.Forms.Padding(2);
            this.btnNCC_Sua.Name = "btnNCC_Sua";
            this.btnNCC_Sua.Size = new System.Drawing.Size(137, 45);
            this.btnNCC_Sua.TabIndex = 2;
            this.btnNCC_Sua.Text = "SỬA";
            this.btnNCC_Sua.UseVisualStyleBackColor = true;
            this.btnNCC_Sua.Click += new System.EventHandler(this.btnNCC_Sua_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvNCC);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(31, 501);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1114, 293);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin nhà cung cấp";
            // 
            // btnNCC_Xoa
            // 
            this.btnNCC_Xoa.Location = new System.Drawing.Point(279, 2);
            this.btnNCC_Xoa.Margin = new System.Windows.Forms.Padding(2);
            this.btnNCC_Xoa.Name = "btnNCC_Xoa";
            this.btnNCC_Xoa.Size = new System.Drawing.Size(137, 43);
            this.btnNCC_Xoa.TabIndex = 1;
            this.btnNCC_Xoa.Text = "XÓA ";
            this.btnNCC_Xoa.UseVisualStyleBackColor = true;
            this.btnNCC_Xoa.Click += new System.EventHandler(this.btnNCC_Xoa_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnNCC_Sua);
            this.panel2.Controls.Add(this.btnNCC_Xoa);
            this.panel2.Controls.Add(this.btnNCC_Them);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(234, 432);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(710, 47);
            this.panel2.TabIndex = 23;
            // 
            // btnNCC_Them
            // 
            this.btnNCC_Them.BackColor = System.Drawing.Color.Transparent;
            this.btnNCC_Them.Location = new System.Drawing.Point(2, 2);
            this.btnNCC_Them.Margin = new System.Windows.Forms.Padding(2);
            this.btnNCC_Them.Name = "btnNCC_Them";
            this.btnNCC_Them.Size = new System.Drawing.Size(135, 43);
            this.btnNCC_Them.TabIndex = 0;
            this.btnNCC_Them.Text = "THÊM";
            this.btnNCC_Them.UseVisualStyleBackColor = false;
            this.btnNCC_Them.Click += new System.EventHandler(this.btnNCC_Them_Click);
            // 
            // txtNCC_TimKiem
            // 
            this.txtNCC_TimKiem.Location = new System.Drawing.Point(119, 39);
            this.txtNCC_TimKiem.Multiline = true;
            this.txtNCC_TimKiem.Name = "txtNCC_TimKiem";
            this.txtNCC_TimKiem.Size = new System.Drawing.Size(216, 34);
            this.txtNCC_TimKiem.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(174, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 29);
            this.label5.TabIndex = 0;
            this.label5.Text = "Tìm Kiếm";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnNCC_TimKiem);
            this.panel3.Controls.Add(this.txtNCC_TimKiem);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(359, 112);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(442, 91);
            this.panel3.TabIndex = 24;
            // 
            // btnNCC_TimKiem
            // 
            this.btnNCC_TimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNCC_TimKiem.Image = global::GUI.Properties.Resources.search_1102213__1_;
            this.btnNCC_TimKiem.Location = new System.Drawing.Point(355, 39);
            this.btnNCC_TimKiem.Name = "btnNCC_TimKiem";
            this.btnNCC_TimKiem.Size = new System.Drawing.Size(28, 32);
            this.btnNCC_TimKiem.TabIndex = 2;
            this.btnNCC_TimKiem.UseVisualStyleBackColor = true;
            this.btnNCC_TimKiem.Click += new System.EventHandler(this.btnNCC_TimKiem_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(444, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(346, 38);
            this.label7.TabIndex = 1;
            this.label7.Text = "QUẢN LÝ CUNG CẤP";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(104)))));
            this.panel1.Controls.Add(this.btnNCC_Back);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btnMT_Exit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1176, 92);
            this.panel1.TabIndex = 20;
            // 
            // btnNCC_Back
            // 
            this.btnNCC_Back.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNCC_Back.Image = global::GUI.Properties.Resources.back;
            this.btnNCC_Back.Location = new System.Drawing.Point(34, 12);
            this.btnNCC_Back.Name = "btnNCC_Back";
            this.btnNCC_Back.Size = new System.Drawing.Size(69, 59);
            this.btnNCC_Back.TabIndex = 3;
            this.btnNCC_Back.UseVisualStyleBackColor = false;
            this.btnNCC_Back.Click += new System.EventHandler(this.btnNCC_Back_Click);
            // 
            // btnMT_Exit
            // 
            this.btnMT_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMT_Exit.Image = global::GUI.Properties.Resources.Thoat;
            this.btnMT_Exit.Location = new System.Drawing.Point(1077, 3);
            this.btnMT_Exit.Name = "btnMT_Exit";
            this.btnMT_Exit.Size = new System.Drawing.Size(78, 89);
            this.btnMT_Exit.TabIndex = 2;
            this.btnMT_Exit.UseVisualStyleBackColor = false;
            this.btnMT_Exit.Click += new System.EventHandler(this.btnMT_Exit_Click);
            // 
            // fNhaCC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(1176, 811);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "fNhaCC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fNhaCC";
            this.Load += new System.EventHandler(this.fNhaCC_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNCC)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtNCC_SDT;
        private System.Windows.Forms.TextBox txtNCC_DiaChi;
        private System.Windows.Forms.TextBox txtNCC_Ten;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNCC_Ma;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvNCC;
        private System.Windows.Forms.Button btnNCC_Sua;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnNCC_Xoa;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnNCC_Them;
        private System.Windows.Forms.Button btnNCC_TimKiem;
        private System.Windows.Forms.TextBox txtNCC_TimKiem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnNCC_Back;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnMT_Exit;
        private System.Windows.Forms.Panel panel1;
    }
}