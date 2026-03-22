namespace QuanLyBanHang.Forms
{
    partial class frmSanPham
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            grbDSSP = new GroupBox();
            dataGridView = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            TenLoai = new DataGridViewTextBoxColumn();
            TenHangSanXuat = new DataGridViewTextBoxColumn();
            TenSanPham = new DataGridViewTextBoxColumn();
            SoLuong = new DataGridViewTextBoxColumn();
            DonGia = new DataGridViewTextBoxColumn();
            HinhAnh = new DataGridViewImageColumn();
            grbSP = new GroupBox();
            panelPic = new Panel();
            picHinhAnh = new PictureBox();
            btnXoayAnh = new Button();
            lblTenSanPham = new Label();
            lblTenHangSanXuat = new Label();
            btnDoiAnh = new Button();
            numDonGia = new NumericUpDown();
            numSoLuong = new NumericUpDown();
            txtMoTa = new TextBox();
            txtTenSanPham = new TextBox();
            cboHangSanXuat = new ComboBox();
            cboLoaiSanPham = new ComboBox();
            lblDonGia = new Label();
            lblMoTa = new Label();
            lblSoLuong = new Label();
            btnTimKiem = new Button();
            btnXuat = new Button();
            btnXoa = new Button();
            btnNhap = new Button();
            btnThoat = new Button();
            btnHuyBo = new Button();
            btnLuu = new Button();
            btnSua = new Button();
            btnThem = new Button();
            lblTenLoai = new Label();
            toolTip = new ToolTip(components);
            grbDSSP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            grbSP.SuspendLayout();
            panelPic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDonGia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).BeginInit();
            SuspendLayout();
            // 
            // grbDSSP
            // 
            grbDSSP.Controls.Add(dataGridView);
            grbDSSP.Location = new Point(15, 316);
            grbDSSP.Margin = new Padding(4, 3, 4, 3);
            grbDSSP.Name = "grbDSSP";
            grbDSSP.Padding = new Padding(4, 3, 4, 3);
            grbDSSP.Size = new Size(1184, 307);
            grbDSSP.TabIndex = 11;
            grbDSSP.TabStop = false;
            grbDSSP.Text = "Danh sách sản phẩm";
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToOrderColumns = true;
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
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { ID, TenLoai, TenHangSanXuat, TenSanPham, SoLuong, DonGia, HinhAnh });
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(4, 26);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView.Size = new Size(1176, 278);
            dataGridView.TabIndex = 0;
            dataGridView.CellFormatting += dataGridView_CellFormatting;
            // 
            // ID
            // 
            ID.DataPropertyName = "ID";
            ID.FillWeight = 170F;
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            // 
            // TenLoai
            // 
            TenLoai.DataPropertyName = "TenLoai";
            TenLoai.FillWeight = 170F;
            TenLoai.HeaderText = "Phân loại";
            TenLoai.MinimumWidth = 6;
            TenLoai.Name = "TenLoai";
            // 
            // TenHangSanXuat
            // 
            TenHangSanXuat.DataPropertyName = "TenHangSanXuat";
            TenHangSanXuat.FillWeight = 170F;
            TenHangSanXuat.HeaderText = "Hãng sản xuất";
            TenHangSanXuat.MinimumWidth = 6;
            TenHangSanXuat.Name = "TenHangSanXuat";
            // 
            // TenSanPham
            // 
            TenSanPham.DataPropertyName = "TenSanPham";
            TenSanPham.FillWeight = 170F;
            TenSanPham.HeaderText = "Tên sản phẩm";
            TenSanPham.MinimumWidth = 6;
            TenSanPham.Name = "TenSanPham";
            // 
            // SoLuong
            // 
            SoLuong.DataPropertyName = "SoLuong";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            SoLuong.DefaultCellStyle = dataGridViewCellStyle2;
            SoLuong.FillWeight = 170F;
            SoLuong.HeaderText = "Số lượng";
            SoLuong.MinimumWidth = 6;
            SoLuong.Name = "SoLuong";
            // 
            // DonGia
            // 
            DonGia.DataPropertyName = "DonGia";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            DonGia.DefaultCellStyle = dataGridViewCellStyle3;
            DonGia.FillWeight = 170F;
            DonGia.HeaderText = "Đơn giá";
            DonGia.MinimumWidth = 6;
            DonGia.Name = "DonGia";
            // 
            // HinhAnh
            // 
            HinhAnh.DataPropertyName = "HinhAnh";
            HinhAnh.FillWeight = 170F;
            HinhAnh.HeaderText = "Hình ảnh";
            HinhAnh.MinimumWidth = 6;
            HinhAnh.Name = "HinhAnh";
            // 
            // grbSP
            // 
            grbSP.Controls.Add(panelPic);
            grbSP.Controls.Add(btnXoayAnh);
            grbSP.Controls.Add(lblTenSanPham);
            grbSP.Controls.Add(lblTenHangSanXuat);
            grbSP.Controls.Add(btnDoiAnh);
            grbSP.Controls.Add(numDonGia);
            grbSP.Controls.Add(numSoLuong);
            grbSP.Controls.Add(txtMoTa);
            grbSP.Controls.Add(txtTenSanPham);
            grbSP.Controls.Add(cboHangSanXuat);
            grbSP.Controls.Add(cboLoaiSanPham);
            grbSP.Controls.Add(lblDonGia);
            grbSP.Controls.Add(lblMoTa);
            grbSP.Controls.Add(lblSoLuong);
            grbSP.Controls.Add(btnTimKiem);
            grbSP.Controls.Add(btnXuat);
            grbSP.Controls.Add(btnXoa);
            grbSP.Controls.Add(btnNhap);
            grbSP.Controls.Add(btnThoat);
            grbSP.Controls.Add(btnHuyBo);
            grbSP.Controls.Add(btnLuu);
            grbSP.Controls.Add(btnSua);
            grbSP.Controls.Add(btnThem);
            grbSP.Controls.Add(lblTenLoai);
            grbSP.Location = new Point(14, 12);
            grbSP.Margin = new Padding(4, 3, 4, 3);
            grbSP.Name = "grbSP";
            grbSP.Padding = new Padding(4, 3, 4, 3);
            grbSP.Size = new Size(1184, 288);
            grbSP.TabIndex = 10;
            grbSP.TabStop = false;
            grbSP.Text = "Thông tin sản phẩm";
            // 
            // panelPic
            // 
            panelPic.Controls.Add(picHinhAnh);
            panelPic.Location = new Point(785, 18);
            panelPic.Name = "panelPic";
            panelPic.Size = new Size(250, 204);
            panelPic.TabIndex = 28;
            //panelPic.Paint += panelPic_Paint;
            // 
            // picHinhAnh
            // 
            picHinhAnh.Location = new Point(39, 8);
            picHinhAnh.Name = "picHinhAnh";
            picHinhAnh.Size = new Size(161, 186);
            picHinhAnh.SizeMode = PictureBoxSizeMode.StretchImage;
            picHinhAnh.TabIndex = 27;
            picHinhAnh.TabStop = false;
            //picHinhAnh.Click += picHinhAnh_Click_1;
            // 
            // btnXoayAnh
            // 
            btnXoayAnh.FlatStyle = FlatStyle.Popup;
            btnXoayAnh.ForeColor = Color.Black;
            btnXoayAnh.Location = new Point(1055, 71);
            btnXoayAnh.Name = "btnXoayAnh";
            btnXoayAnh.Size = new Size(101, 30);
            btnXoayAnh.TabIndex = 31;
            btnXoayAnh.Text = "Xoay ảnh";
            btnXoayAnh.UseVisualStyleBackColor = true;
            btnXoayAnh.Click += btnXoayAnh_Click;
            // 
            // lblTenSanPham
            // 
            lblTenSanPham.AutoSize = true;
            lblTenSanPham.Location = new Point(13, 132);
            lblTenSanPham.Name = "lblTenSanPham";
            lblTenSanPham.Size = new Size(152, 22);
            lblTenSanPham.TabIndex = 30;
            lblTenSanPham.Text = "Tên sản phẩm (*):";
            // 
            // lblTenHangSanXuat
            // 
            lblTenHangSanXuat.AutoSize = true;
            lblTenHangSanXuat.Location = new Point(13, 77);
            lblTenHangSanXuat.Name = "lblTenHangSanXuat";
            lblTenHangSanXuat.Size = new Size(153, 22);
            lblTenHangSanXuat.TabIndex = 29;
            lblTenHangSanXuat.Text = "Hãng sản xuất (*):";
            // 
            // btnDoiAnh
            // 
            btnDoiAnh.FlatStyle = FlatStyle.Popup;
            btnDoiAnh.ForeColor = Color.Black;
            btnDoiAnh.Location = new Point(1055, 26);
            btnDoiAnh.Name = "btnDoiAnh";
            btnDoiAnh.Size = new Size(101, 30);
            btnDoiAnh.TabIndex = 28;
            btnDoiAnh.Text = "Đổi ảnh...";
            btnDoiAnh.UseVisualStyleBackColor = true;
            btnDoiAnh.Click += btnDoiAnh_Click;
            // 
            // numDonGia
            // 
            numDonGia.Location = new Point(570, 75);
            numDonGia.Name = "numDonGia";
            numDonGia.Size = new Size(188, 30);
            numDonGia.TabIndex = 26;
            // 
            // numSoLuong
            // 
            numSoLuong.Location = new Point(570, 26);
            numSoLuong.Name = "numSoLuong";
            numSoLuong.Size = new Size(188, 30);
            numSoLuong.TabIndex = 25;
            // 
            // txtMoTa
            // 
            txtMoTa.Location = new Point(175, 181);
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Size = new Size(583, 30);
            txtMoTa.TabIndex = 24;
            // 
            // txtTenSanPham
            // 
            txtTenSanPham.Location = new Point(175, 124);
            txtTenSanPham.Name = "txtTenSanPham";
            txtTenSanPham.Size = new Size(583, 30);
            txtTenSanPham.TabIndex = 23;
            // 
            // cboHangSanXuat
            // 
            cboHangSanXuat.FormattingEnabled = true;
            cboHangSanXuat.Location = new Point(175, 74);
            cboHangSanXuat.Name = "cboHangSanXuat";
            cboHangSanXuat.Size = new Size(222, 30);
            cboHangSanXuat.TabIndex = 22;
            // 
            // cboLoaiSanPham
            // 
            cboLoaiSanPham.FormattingEnabled = true;
            cboLoaiSanPham.Location = new Point(175, 25);
            cboLoaiSanPham.Name = "cboLoaiSanPham";
            cboLoaiSanPham.Size = new Size(222, 30);
            cboLoaiSanPham.TabIndex = 21;
            // 
            // lblDonGia
            // 
            lblDonGia.AutoSize = true;
            lblDonGia.Location = new Point(430, 82);
            lblDonGia.Margin = new Padding(4, 0, 4, 0);
            lblDonGia.Name = "lblDonGia";
            lblDonGia.Size = new Size(107, 22);
            lblDonGia.TabIndex = 18;
            lblDonGia.Text = "Đơn giá (*):";
            // 
            // lblMoTa
            // 
            lblMoTa.AutoSize = true;
            lblMoTa.Location = new Point(13, 184);
            lblMoTa.Margin = new Padding(4, 0, 4, 0);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.Size = new Size(140, 22);
            lblMoTa.TabIndex = 16;
            lblMoTa.Text = "Mô tả sản phẩm:";
            // 
            // lblSoLuong
            // 
            lblSoLuong.AutoSize = true;
            lblSoLuong.Location = new Point(430, 37);
            lblSoLuong.Margin = new Padding(4, 0, 4, 0);
            lblSoLuong.Name = "lblSoLuong";
            lblSoLuong.Size = new Size(116, 22);
            lblSoLuong.TabIndex = 14;
            lblSoLuong.Text = "Số lượng (*):";
            // 
            // btnTimKiem
            // 
            btnTimKiem.FlatStyle = FlatStyle.Popup;
            btnTimKiem.ForeColor = Color.Black;
            btnTimKiem.Location = new Point(835, 228);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(101, 30);
            btnTimKiem.TabIndex = 13;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // btnXuat
            // 
            btnXuat.FlatStyle = FlatStyle.Popup;
            btnXuat.ForeColor = Color.Black;
            btnXuat.Location = new Point(1055, 228);
            btnXuat.Name = "btnXuat";
            btnXuat.Size = new Size(101, 30);
            btnXuat.TabIndex = 12;
            btnXuat.Text = "Xuất...";
            btnXuat.UseVisualStyleBackColor = true;
            btnXuat.Click += btnXuat_Click;
            // 
            // btnXoa
            // 
            btnXoa.FlatStyle = FlatStyle.Popup;
            btnXoa.ForeColor = Color.Red;
            btnXoa.Location = new Point(395, 228);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(101, 30);
            btnXoa.TabIndex = 4;
            btnXoa.Text = "Xoá";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnNhap
            // 
            btnNhap.FlatStyle = FlatStyle.Popup;
            btnNhap.ForeColor = Color.Black;
            btnNhap.Location = new Point(945, 228);
            btnNhap.Name = "btnNhap";
            btnNhap.Size = new Size(101, 30);
            btnNhap.TabIndex = 11;
            btnNhap.Text = "Nhập...";
            btnNhap.UseVisualStyleBackColor = true;
            btnNhap.Click += btnNhap_Click;
            // 
            // btnThoat
            // 
            btnThoat.FlatStyle = FlatStyle.Popup;
            btnThoat.Location = new Point(725, 228);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(101, 30);
            btnThoat.TabIndex = 3;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnHuyBo
            // 
            btnHuyBo.FlatStyle = FlatStyle.Popup;
            btnHuyBo.Location = new Point(615, 228);
            btnHuyBo.Name = "btnHuyBo";
            btnHuyBo.Size = new Size(101, 30);
            btnHuyBo.TabIndex = 6;
            btnHuyBo.Text = "Huỷ Bỏ";
            btnHuyBo.UseVisualStyleBackColor = true;
            btnHuyBo.Click += btnHuyBo_Click;
            // 
            // btnLuu
            // 
            btnLuu.FlatStyle = FlatStyle.Popup;
            btnLuu.ForeColor = Color.Blue;
            btnLuu.Location = new Point(505, 228);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(101, 30);
            btnLuu.TabIndex = 5;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnSua
            // 
            btnSua.FlatStyle = FlatStyle.Popup;
            btnSua.Location = new Point(285, 228);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(101, 30);
            btnSua.TabIndex = 3;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.FlatStyle = FlatStyle.Popup;
            btnThem.Location = new Point(175, 228);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(101, 30);
            btnThem.TabIndex = 2;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // lblTenLoai
            // 
            lblTenLoai.AutoSize = true;
            lblTenLoai.Location = new Point(13, 33);
            lblTenLoai.Margin = new Padding(4, 0, 4, 0);
            lblTenLoai.Name = "lblTenLoai";
            lblTenLoai.Size = new Size(118, 22);
            lblTenLoai.TabIndex = 0;
            lblTenLoai.Text = "Phân loại (*):";
            // 
            // toolTip
            // 
            toolTip.IsBalloon = true;
            toolTip.ShowAlways = true;
            // 
            // frmSanPham
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1208, 627);
            Controls.Add(grbDSSP);
            Controls.Add(grbSP);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmSanPham";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmSanPham";
            Load += frmSanPham_Load;
            HelpRequested += frmSanPham_HelpRequested;
            grbDSSP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            grbSP.ResumeLayout(false);
            grbSP.PerformLayout();
            panelPic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDonGia).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grbDSSP;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn TenLoai;
        private DataGridViewTextBoxColumn TenHangSanXuat;
        private DataGridViewTextBoxColumn TenSanPham;
        private DataGridViewTextBoxColumn SoLuong;
        private DataGridViewTextBoxColumn DonGia;
        private DataGridViewImageColumn HinhAnh;
        private GroupBox grbSP;
        private Label lblTenSanPham;
        private Label lblTenHangSanXuat;
        private Button btnDoiAnh;
        private PictureBox picHinhAnh;
        private NumericUpDown numDonGia;
        private NumericUpDown numSoLuong;
        private TextBox txtMoTa;
        private TextBox txtTenSanPham;
        private ComboBox cboHangSanXuat;
        private ComboBox cboLoaiSanPham;
        private Label lblDonGia;
        private Label lblMoTa;
        private Label lblSoLuong;
        private Button btnTimKiem;
        private Button btnXuat;
        private Button btnXoa;
        private Button btnNhap;
        private Button btnThoat;
        private Button btnHuyBo;
        private Button btnLuu;
        private Button btnSua;
        private Button btnThem;
        private Label lblTenLoai;
        private Button btnXoayAnh;
        private Panel panelPic;
        private ToolTip toolTip;
    }
}