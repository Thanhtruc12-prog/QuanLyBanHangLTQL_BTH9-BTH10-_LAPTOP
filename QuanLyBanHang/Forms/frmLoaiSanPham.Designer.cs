namespace QuanLyBanHang.Forms
{
    partial class frmLoaiSanPham
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
            grbDsLSP = new GroupBox();
            dataGridView = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            TenLoai = new DataGridViewTextBoxColumn();
            lblTenLSP = new Label();
            txtTenLoai = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLuu = new Button();
            btnHuyBo = new Button();
            btnThoat = new Button();
            btnNhap = new Button();
            btnXuat = new Button();
            grbLSP = new GroupBox();
            toolTip = new ToolTip(components);
            grbDsLSP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            grbLSP.SuspendLayout();
            SuspendLayout();
            // 
            // grbDsLSP
            // 
            grbDsLSP.Controls.Add(dataGridView);
            grbDsLSP.Location = new Point(13, 168);
            grbDsLSP.Margin = new Padding(4, 3, 4, 3);
            grbDsLSP.Name = "grbDsLSP";
            grbDsLSP.Padding = new Padding(4, 3, 4, 3);
            grbDsLSP.Size = new Size(980, 407);
            grbDsLSP.TabIndex = 2;
            grbDsLSP.TabStop = false;
            grbDsLSP.Text = "Danh sách loại sản phẩm";
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
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { ID, TenLoai });
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(4, 26);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(972, 378);
            dataGridView.TabIndex = 0;
            // 
            // ID
            // 
            ID.DataPropertyName = "ID";
            ID.FillWeight = 10F;
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            // 
            // TenLoai
            // 
            TenLoai.DataPropertyName = "TenLoai";
            TenLoai.HeaderText = "Tên loại sản phẩm";
            TenLoai.MinimumWidth = 6;
            TenLoai.Name = "TenLoai";
            // 
            // lblTenLSP
            // 
            lblTenLSP.AutoSize = true;
            lblTenLSP.Location = new Point(19, 47);
            lblTenLSP.Margin = new Padding(4, 0, 4, 0);
            lblTenLSP.Name = "lblTenLSP";
            lblTenLSP.Size = new Size(188, 22);
            lblTenLSP.TabIndex = 0;
            lblTenLSP.Text = "Tên loại sản phẩm (*):";
            // 
            // txtTenLoai
            // 
            txtTenLoai.Location = new Point(214, 44);
            txtTenLoai.Name = "txtTenLoai";
            txtTenLoai.Size = new Size(701, 30);
            txtTenLoai.TabIndex = 1;
            // 
            // btnThem
            // 
            btnThem.FlatStyle = FlatStyle.Popup;
            btnThem.Location = new Point(14, 90);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(101, 30);
            btnThem.TabIndex = 2;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.FlatStyle = FlatStyle.Popup;
            btnSua.Location = new Point(132, 90);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(101, 30);
            btnSua.TabIndex = 3;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.FlatStyle = FlatStyle.Popup;
            btnXoa.ForeColor = Color.Red;
            btnXoa.Location = new Point(249, 90);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(101, 30);
            btnXoa.TabIndex = 4;
            btnXoa.Text = "Xoá";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLuu
            // 
            btnLuu.FlatStyle = FlatStyle.Popup;
            btnLuu.ForeColor = Color.Blue;
            btnLuu.Location = new Point(371, 90);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(101, 30);
            btnLuu.TabIndex = 5;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnHuyBo
            // 
            btnHuyBo.FlatStyle = FlatStyle.Popup;
            btnHuyBo.Location = new Point(493, 90);
            btnHuyBo.Name = "btnHuyBo";
            btnHuyBo.Size = new Size(101, 30);
            btnHuyBo.TabIndex = 6;
            btnHuyBo.Text = "Huỷ Bỏ";
            btnHuyBo.UseVisualStyleBackColor = true;
            btnHuyBo.Click += btnHuyBo_Click;
            // 
            // btnThoat
            // 
            btnThoat.FlatStyle = FlatStyle.Popup;
            btnThoat.Location = new Point(863, 90);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(101, 30);
            btnThoat.TabIndex = 3;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnNhap
            // 
            btnNhap.FlatStyle = FlatStyle.Popup;
            btnNhap.Location = new Point(614, 90);
            btnNhap.Name = "btnNhap";
            btnNhap.Size = new Size(101, 30);
            btnNhap.TabIndex = 7;
            btnNhap.Text = "Nhập";
            btnNhap.UseVisualStyleBackColor = true;
            btnNhap.Click += btnNhap_Click;
            // 
            // btnXuat
            // 
            btnXuat.FlatStyle = FlatStyle.Popup;
            btnXuat.Location = new Point(738, 90);
            btnXuat.Name = "btnXuat";
            btnXuat.Size = new Size(101, 30);
            btnXuat.TabIndex = 8;
            btnXuat.Text = "Xuất";
            btnXuat.UseVisualStyleBackColor = true;
            btnXuat.Click += btnXuat_Click;
            // 
            // grbLSP
            // 
            grbLSP.Controls.Add(btnXuat);
            grbLSP.Controls.Add(btnNhap);
            grbLSP.Controls.Add(btnThoat);
            grbLSP.Controls.Add(btnHuyBo);
            grbLSP.Controls.Add(btnLuu);
            grbLSP.Controls.Add(btnXoa);
            grbLSP.Controls.Add(btnSua);
            grbLSP.Controls.Add(btnThem);
            grbLSP.Controls.Add(txtTenLoai);
            grbLSP.Controls.Add(lblTenLSP);
            grbLSP.Location = new Point(13, 12);
            grbLSP.Margin = new Padding(4, 3, 4, 3);
            grbLSP.Name = "grbLSP";
            grbLSP.Padding = new Padding(4, 3, 4, 3);
            grbLSP.Size = new Size(980, 138);
            grbLSP.TabIndex = 1;
            grbLSP.TabStop = false;
            grbLSP.Text = "Thông tin loại sản phẩm";
            // 
            // toolTip
            // 
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 100;
            toolTip.IsBalloon = true;
            toolTip.ReshowDelay = 100;
            toolTip.ShowAlways = true;
            // 
            // frmLoaiSanPham
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1006, 587);
            Controls.Add(grbDsLSP);
            Controls.Add(grbLSP);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmLoaiSanPham";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Loại sản phẩm";
            Load += frmLoaiSanPham_Load;
            HelpRequested += frmLoaiSanPham_HelpRequested;
            grbDsLSP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            grbLSP.ResumeLayout(false);
            grbLSP.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grbDsLSP;
        private DataGridView dataGridView;
        private Label lblTenLSP;
        private TextBox txtTenLoai;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLuu;
        private Button btnHuyBo;
        private Button btnThoat;
        private Button btnNhap;
        private Button btnXuat;
        private GroupBox grbLSP;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn TenLoai;
        private ToolTip toolTip;
    }
}