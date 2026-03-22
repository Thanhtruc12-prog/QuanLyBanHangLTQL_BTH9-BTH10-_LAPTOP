using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLyBanHang.Forms
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }
        private void SetupToolTips()
        {
            // Cấu hình ToolTip
            toolTip.IsBalloon = true;
            toolTip.ShowAlways = true;
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 400;
            toolTip.ReshowDelay = 200;

            // ── Ô nhập liệu ──────────────────────────────────────────
            toolTip.SetToolTip(txtTenDangNhap,
                "Nhập tên tài khoản của bạn.\n" +
                "⚠ Không được để trống.");

            toolTip.SetToolTip(txtMatKhau,
                "Nhập mật khẩu của tài khoản.\n" +
                "Mật khẩu phân biệt chữ hoa và chữ thường.\n" +
                "⚠ Không được để trống.");

            // ── Nút chức năng ─────────────────────────────────────────
            toolTip.SetToolTip(btnDangNhap,
                "Xác nhận đăng nhập vào hệ thống.");

            toolTip.SetToolTip(btnHuyBo, "Hủy và đóng cửa sổ đăng nhập.");
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangNhap_Click(sender, e);
            }
        }

        private void frmDangNhap_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            string helpPath = Path.Combine(Application.StartupPath, "Help", "dangnhap.htm");

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = helpPath,
                UseShellExecute = true  // Mở bằng trình duyệt mặc định
            });

            hlpevent.Handled = true;
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            SetupToolTips();
        }
    }
}
