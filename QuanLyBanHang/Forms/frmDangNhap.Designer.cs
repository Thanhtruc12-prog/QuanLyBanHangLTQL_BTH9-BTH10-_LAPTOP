namespace QuanLyBanHang.Forms
{
    partial class frmDangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDangNhap));
            picHInhAnh = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtTenDangNhap = new TextBox();
            txtMatKhau = new TextBox();
            btnDangNhap = new Button();
            btnHuyBo = new Button();
            toolTip = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)picHInhAnh).BeginInit();
            SuspendLayout();
            // 
            // picHInhAnh
            // 
            picHInhAnh.Image = (Image)resources.GetObject("picHInhAnh.Image");
            picHInhAnh.Location = new Point(28, 81);
            picHInhAnh.Name = "picHInhAnh";
            picHInhAnh.Size = new Size(146, 163);
            picHInhAnh.SizeMode = PictureBoxSizeMode.StretchImage;
            picHInhAnh.TabIndex = 0;
            picHInhAnh.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(236, 21);
            label1.Name = "label1";
            label1.Size = new Size(222, 38);
            label1.TabIndex = 2;
            label1.Text = "ĐĂNG NHẬP";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(196, 83);
            label2.Name = "label2";
            label2.Size = new Size(130, 22);
            label2.TabIndex = 3;
            label2.Text = "Tên đăng nhập:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(196, 161);
            label3.Name = "label3";
            label3.Size = new Size(82, 22);
            label3.TabIndex = 4;
            label3.Text = "Mật khẩu";
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Location = new Point(196, 108);
            txtTenDangNhap.Multiline = true;
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(292, 39);
            txtTenDangNhap.TabIndex = 5;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Location = new Point(196, 186);
            txtMatKhau.Multiline = true;
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PasswordChar = '⚫';
            txtMatKhau.Size = new Size(292, 38);
            txtMatKhau.TabIndex = 6;
            txtMatKhau.KeyDown += txtMatKhau_KeyDown;
            // 
            // btnDangNhap
            // 
            btnDangNhap.FlatStyle = FlatStyle.Popup;
            btnDangNhap.Location = new Point(196, 259);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(130, 40);
            btnDangNhap.TabIndex = 7;
            btnDangNhap.Text = "Đăng nhập";
            btnDangNhap.UseVisualStyleBackColor = true;
            btnDangNhap.Click += btnDangNhap_Click;
            // 
            // btnHuyBo
            // 
            btnHuyBo.FlatStyle = FlatStyle.Popup;
            btnHuyBo.Location = new Point(354, 259);
            btnHuyBo.Name = "btnHuyBo";
            btnHuyBo.Size = new Size(134, 40);
            btnHuyBo.TabIndex = 8;
            btnHuyBo.Text = "Huỷ bỏ";
            btnHuyBo.UseVisualStyleBackColor = true;
            btnHuyBo.Click += btnHuyBo_Click;
            // 
            // toolTip
            // 
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 100;
            toolTip.IsBalloon = true;
            toolTip.ReshowDelay = 100;
            toolTip.ShowAlways = true;
            // 
            // frmDangNhap
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(517, 316);
            Controls.Add(btnHuyBo);
            Controls.Add(btnDangNhap);
            Controls.Add(txtMatKhau);
            Controls.Add(txtTenDangNhap);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(picHInhAnh);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmDangNhap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập";
            Load += frmDangNhap_Load;
            HelpRequested += frmDangNhap_HelpRequested;
            ((System.ComponentModel.ISupportInitialize)picHInhAnh).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picHInhAnh;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox2;
        private Button btnDangNhap;
        private Button btnHuyBo;
        public TextBox txtTenDangNhap;
        public TextBox txtMatKhau;
        private ToolTip toolTip;
    }
}