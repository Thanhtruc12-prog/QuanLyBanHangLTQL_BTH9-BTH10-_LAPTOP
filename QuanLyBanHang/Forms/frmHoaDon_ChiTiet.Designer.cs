namespace QuanLyBanHang.Forms
{
    partial class frmHoaDon_ChiTiet
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            grbThongTinHoaDon = new GroupBox();
            txtGhiChuHoaDon = new TextBox();
            cboKhachHang = new ComboBox();
            cboNhanVien = new ComboBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            grbThongtinCTHD = new GroupBox();
            btnInHoaDon = new Button();
            btnLuuHoaDon = new Button();
            btnThoat = new Button();
            dataGridView = new DataGridView();
            SanPhamID = new DataGridViewTextBoxColumn();
            TenSanPham = new DataGridViewTextBoxColumn();
            DonGiaBan = new DataGridViewTextBoxColumn();
            SoLuongBan = new DataGridViewTextBoxColumn();
            ThanhTien = new DataGridViewTextBoxColumn();
            btnXoa = new Button();
            btnXacNhanBan = new Button();
            numSoLuongBan = new NumericUpDown();
            numDonGiaBan = new NumericUpDown();
            label6 = new Label();
            label5 = new Label();
            cboSanPham = new ComboBox();
            label4 = new Label();
            toolTip = new ToolTip(components);
            grbThongTinHoaDon.SuspendLayout();
            grbThongtinCTHD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSoLuongBan).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDonGiaBan).BeginInit();
            SuspendLayout();
            // 
            // grbThongTinHoaDon
            // 
            grbThongTinHoaDon.Controls.Add(txtGhiChuHoaDon);
            grbThongTinHoaDon.Controls.Add(cboKhachHang);
            grbThongTinHoaDon.Controls.Add(cboNhanVien);
            grbThongTinHoaDon.Controls.Add(label3);
            grbThongTinHoaDon.Controls.Add(label2);
            grbThongTinHoaDon.Controls.Add(label1);
            grbThongTinHoaDon.Location = new Point(12, 12);
            grbThongTinHoaDon.Name = "grbThongTinHoaDon";
            grbThongTinHoaDon.Size = new Size(1112, 140);
            grbThongTinHoaDon.TabIndex = 0;
            grbThongTinHoaDon.TabStop = false;
            grbThongTinHoaDon.Text = "Thông tin hoá đơn";
            // 
            // txtGhiChuHoaDon
            // 
            txtGhiChuHoaDon.Location = new Point(181, 84);
            txtGhiChuHoaDon.Multiline = true;
            txtGhiChuHoaDon.Name = "txtGhiChuHoaDon";
            txtGhiChuHoaDon.Size = new Size(916, 39);
            txtGhiChuHoaDon.TabIndex = 5;
            // 
            // cboKhachHang
            // 
            cboKhachHang.FormattingEnabled = true;
            cboKhachHang.Location = new Point(745, 32);
            cboKhachHang.Name = "cboKhachHang";
            cboKhachHang.Size = new Size(352, 30);
            cboKhachHang.TabIndex = 4;
            // 
            // cboNhanVien
            // 
            cboNhanVien.FormattingEnabled = true;
            cboNhanVien.Location = new Point(181, 32);
            cboNhanVien.Name = "cboNhanVien";
            cboNhanVien.Size = new Size(375, 30);
            cboNhanVien.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 95);
            label3.Name = "label3";
            label3.Size = new Size(146, 22);
            label3.TabIndex = 2;
            label3.Text = "Ghi chú hoá đơn:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(594, 40);
            label2.Name = "label2";
            label2.Size = new Size(135, 22);
            label2.TabIndex = 1;
            label2.Text = "Khách hàng (*):";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 40);
            label1.Name = "label1";
            label1.Size = new Size(154, 22);
            label1.TabIndex = 0;
            label1.Text = "Nhân viên lập (*):";
            // 
            // grbThongtinCTHD
            // 
            grbThongtinCTHD.Controls.Add(btnInHoaDon);
            grbThongtinCTHD.Controls.Add(btnLuuHoaDon);
            grbThongtinCTHD.Controls.Add(btnThoat);
            grbThongtinCTHD.Controls.Add(dataGridView);
            grbThongtinCTHD.Controls.Add(btnXoa);
            grbThongtinCTHD.Controls.Add(btnXacNhanBan);
            grbThongtinCTHD.Controls.Add(numSoLuongBan);
            grbThongtinCTHD.Controls.Add(numDonGiaBan);
            grbThongtinCTHD.Controls.Add(label6);
            grbThongtinCTHD.Controls.Add(label5);
            grbThongtinCTHD.Controls.Add(cboSanPham);
            grbThongtinCTHD.Controls.Add(label4);
            grbThongtinCTHD.Location = new Point(12, 158);
            grbThongtinCTHD.Name = "grbThongtinCTHD";
            grbThongtinCTHD.Size = new Size(1112, 430);
            grbThongtinCTHD.TabIndex = 1;
            grbThongtinCTHD.TabStop = false;
            grbThongtinCTHD.Text = "Thông tin chi tiết hoá đơn";
            // 
            // btnInHoaDon
            // 
            btnInHoaDon.FlatStyle = FlatStyle.Popup;
            btnInHoaDon.ForeColor = Color.Black;
            btnInHoaDon.Location = new Point(523, 388);
            btnInHoaDon.Name = "btnInHoaDon";
            btnInHoaDon.Size = new Size(135, 30);
            btnInHoaDon.TabIndex = 27;
            btnInHoaDon.Text = "In hoá đơn...";
            btnInHoaDon.UseVisualStyleBackColor = true;
            // 
            // btnLuuHoaDon
            // 
            btnLuuHoaDon.FlatStyle = FlatStyle.Popup;
            btnLuuHoaDon.ForeColor = Color.Blue;
            btnLuuHoaDon.Location = new Point(270, 388);
            btnLuuHoaDon.Name = "btnLuuHoaDon";
            btnLuuHoaDon.Size = new Size(170, 30);
            btnLuuHoaDon.TabIndex = 26;
            btnLuuHoaDon.Text = "Lưu hoá đơn...";
            btnLuuHoaDon.UseVisualStyleBackColor = true;
            btnLuuHoaDon.Click += btnLuuHoaDon_Click;
            // 
            // btnThoat
            // 
            btnThoat.FlatStyle = FlatStyle.Popup;
            btnThoat.ForeColor = Color.Red;
            btnThoat.Location = new Point(745, 388);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(115, 30);
            btnThoat.TabIndex = 25;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { SanPhamID, TenSanPham, DonGiaBan, SoLuongBan, ThanhTien });
            dataGridView.Location = new Point(6, 125);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(1100, 253);
            dataGridView.TabIndex = 13;
            // 
            // SanPhamID
            // 
            SanPhamID.DataPropertyName = "SanPhamID";
            SanPhamID.HeaderText = "ID";
            SanPhamID.MinimumWidth = 6;
            SanPhamID.Name = "SanPhamID";
            // 
            // TenSanPham
            // 
            TenSanPham.DataPropertyName = "TenSanPham";
            TenSanPham.HeaderText = "Tên sản phẩm";
            TenSanPham.MinimumWidth = 6;
            TenSanPham.Name = "TenSanPham";
            // 
            // DonGiaBan
            // 
            DonGiaBan.DataPropertyName = "DonGiaBan";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            DonGiaBan.DefaultCellStyle = dataGridViewCellStyle2;
            DonGiaBan.HeaderText = "Đơn giá bán";
            DonGiaBan.MinimumWidth = 6;
            DonGiaBan.Name = "DonGiaBan";
            // 
            // SoLuongBan
            // 
            SoLuongBan.DataPropertyName = "SoLuongBan";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            SoLuongBan.DefaultCellStyle = dataGridViewCellStyle3;
            SoLuongBan.HeaderText = "Số lượng bán";
            SoLuongBan.MinimumWidth = 6;
            SoLuongBan.Name = "SoLuongBan";
            // 
            // ThanhTien
            // 
            ThanhTien.DataPropertyName = "ThanhTien";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.Blue;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            ThanhTien.DefaultCellStyle = dataGridViewCellStyle4;
            ThanhTien.HeaderText = "Thành tiền";
            ThanhTien.MinimumWidth = 6;
            ThanhTien.Name = "ThanhTien";
            // 
            // btnXoa
            // 
            btnXoa.FlatStyle = FlatStyle.Popup;
            btnXoa.ForeColor = Color.Red;
            btnXoa.Location = new Point(1007, 80);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(90, 29);
            btnXoa.TabIndex = 12;
            btnXoa.Text = "Xoá";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnXacNhanBan
            // 
            btnXacNhanBan.FlatStyle = FlatStyle.Popup;
            btnXacNhanBan.Location = new Point(853, 80);
            btnXacNhanBan.Name = "btnXacNhanBan";
            btnXacNhanBan.Size = new Size(135, 29);
            btnXacNhanBan.TabIndex = 11;
            btnXacNhanBan.Text = "Xác nhận bán";
            btnXacNhanBan.UseVisualStyleBackColor = true;
            btnXacNhanBan.Click += btnXacNhanBan_Click;
            // 
            // numSoLuongBan
            // 
            numSoLuongBan.Location = new Point(563, 76);
            numSoLuongBan.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numSoLuongBan.Name = "numSoLuongBan";
            numSoLuongBan.Size = new Size(225, 30);
            numSoLuongBan.TabIndex = 10;
            numSoLuongBan.ThousandsSeparator = true;
            // 
            // numDonGiaBan
            // 
            numDonGiaBan.Location = new Point(296, 79);
            numDonGiaBan.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            numDonGiaBan.Name = "numDonGiaBan";
            numDonGiaBan.Size = new Size(225, 30);
            numDonGiaBan.TabIndex = 9;
            numDonGiaBan.ThousandsSeparator = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(563, 41);
            label6.Name = "label6";
            label6.Size = new Size(149, 22);
            label6.TabIndex = 8;
            label6.Text = "Số lượng bán (*):";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(296, 44);
            label5.Name = "label5";
            label5.Size = new Size(140, 22);
            label5.TabIndex = 7;
            label5.Text = "Đơn giá bán (*):";
            // 
            // cboSanPham
            // 
            cboSanPham.FormattingEnabled = true;
            cboSanPham.Location = new Point(21, 78);
            cboSanPham.Name = "cboSanPham";
            cboSanPham.Size = new Size(234, 30);
            cboSanPham.TabIndex = 6;
            cboSanPham.SelectionChangeCommitted += cboSanPham_SelectionChangeCommitted;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 43);
            label4.Name = "label4";
            label4.Size = new Size(120, 22);
            label4.TabIndex = 6;
            label4.Text = "Sản phẩm (*):";
            // 
            // frmHoaDon_ChiTiet
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1140, 600);
            Controls.Add(grbThongtinCTHD);
            Controls.Add(grbThongTinHoaDon);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmHoaDon_ChiTiet";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hoá đơn chi tiết";
            Load += frmHoaDon_ChiTiet_Load;
            HelpRequested += frmHoaDon_ChiTiet_HelpRequested;
            grbThongTinHoaDon.ResumeLayout(false);
            grbThongTinHoaDon.PerformLayout();
            grbThongtinCTHD.ResumeLayout(false);
            grbThongtinCTHD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSoLuongBan).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDonGiaBan).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grbThongTinHoaDon;
        private TextBox txtGhiChuHoaDon;
        private ComboBox cboKhachHang;
        private ComboBox cboNhanVien;
        private Label label3;
        private Label label2;
        private Label label1;
        private GroupBox grbThongtinCTHD;
        private Button btnXoa;
        private Button btnXacNhanBan;
        private NumericUpDown numSoLuongBan;
        private NumericUpDown numDonGiaBan;
        private Label label6;
        private Label label5;
        private ComboBox cboSanPham;
        private Label label4;
        private DataGridView dataGridView;
        private Button btnInHoaDon;
        private Button btnLuuHoaDon;
        private Button btnThoat;
        private DataGridViewTextBoxColumn SanPhamID;
        private DataGridViewTextBoxColumn TenSanPham;
        private DataGridViewTextBoxColumn DonGiaBan;
        private DataGridViewTextBoxColumn SoLuongBan;
        private DataGridViewTextBoxColumn ThanhTien;
        private ToolTip toolTip;
    }
}