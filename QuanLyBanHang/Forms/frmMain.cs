using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyBanHang.Forms
{
    public partial class frmMain : Form
    {
        QLBHDbContext context = new QLBHDbContext();
        frmHangSanXuat hangSanXuat = null;
        frmHoaDon hoaDon = null;
        frmKhachHang khachHang = null;
        frmLoaiSanPham loaiSanPham = null;
        frmSanPham sanPham = null;
        frmNhanVien nhanVien = null;
        frmDangNhap dangNhap = null;
        string hoVaTenNhanVien = ""; //Lấy tên người dùng hiển thị vào thanh Status.
        public frmMain()
        {
            InitializeComponent();
        }
        private void SetupToolTips()
        {
            toolTip.IsBalloon = true;
            toolTip.ShowAlways = true;
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 400;
            toolTip.ReshowDelay = 200;

            // ── Bật tooltip cho MenuStrip ─────────────────────────────
            menuStrip1.ShowItemToolTips = true;

            // ── Menu Hệ thống ─────────────────────────────────────────
            mnuDangNhap.ToolTipText = "Đăng nhập vào hệ thống bằng tài khoản nhân viên.";
            mnuDangXuat.ToolTipText = "Đăng xuất khỏi hệ thống và đóng tất cả cửa sổ con.";
            mnuDoiMatKhau.ToolTipText = "Thay đổi mật khẩu tài khoản đang đăng nhập.";
            mnuThoat.ToolTipText = "Thoát khỏi chương trình quản lý bán hàng.";

            // ── Menu Quản lý ──────────────────────────────────────────
            mnuLoaiSanPham.ToolTipText = "Quản lý danh mục loại sản phẩm (thêm, sửa, xóa).\n⚠ Chỉ dành cho Quản lý.";
            mnuHangSanXuat.ToolTipText = "Quản lý danh sách hãng sản xuất thiết bị.\n⚠ Chỉ dành cho Quản lý.";
            mnuSanPham.ToolTipText = "Quản lý danh mục sản phẩm, giá bán và tồn kho.\n⚠ Chỉ dành cho Quản lý.";
            mnuKhachHang.ToolTipText = "Quản lý thông tin khách hàng trong hệ thống.";
            mnuNhanVien.ToolTipText = "Quản lý tài khoản và phân quyền nhân viên.\n⚠ Chỉ dành cho Quản lý.";
            mnuHoaDon.ToolTipText = "Lập và quản lý hoá đơn bán hàng.";

            // ── Menu Báo cáo – Thống kê ───────────────────────────────
            mnuThongKeSanPham.ToolTipText = "Xem thống kê số lượng tồn kho và doanh số theo sản phẩm.";
            mnuThongKeDoanhThu.ToolTipText = "Xem báo cáo tổng doanh thu theo khoảng thời gian.";

            // ── Menu Trợ giúp ─────────────────────────────────────────
            mnuTroGiup.ToolTipText = "Mở tài liệu hướng dẫn sử dụng phần mềm.";
            

            // ── Hiển thị mô tả lên StatusBar khi hover menu ───────────
            mnuDangNhap.MouseEnter += (s, e) => lblTrangThai.Text = "Đăng nhập vào hệ thống.";
            mnuDangXuat.MouseEnter += (s, e) => lblTrangThai.Text = "Đăng xuất và đóng tất cả cửa sổ.";
            mnuDoiMatKhau.MouseEnter += (s, e) => lblTrangThai.Text = "Đổi mật khẩu tài khoản hiện tại.";
            mnuThoat.MouseEnter += (s, e) => lblTrangThai.Text = "Thoát khỏi chương trình.";

            mnuLoaiSanPham.MouseEnter += (s, e) => lblTrangThai.Text = "Quản lý loại sản phẩm.";
            mnuHangSanXuat.MouseEnter += (s, e) => lblTrangThai.Text = "Quản lý hãng sản xuất.";
            mnuSanPham.MouseEnter += (s, e) => lblTrangThai.Text = "Quản lý sản phẩm, giá và tồn kho.";
            mnuKhachHang.MouseEnter += (s, e) => lblTrangThai.Text = "Quản lý khách hàng.";
            mnuNhanVien.MouseEnter += (s, e) => lblTrangThai.Text = "Quản lý nhân viên (chỉ dành cho Quản lý).";
            mnuHoaDon.MouseEnter += (s, e) => lblTrangThai.Text = "Lập và quản lý hoá đơn bán hàng.";

            mnuThongKeSanPham.MouseEnter += (s, e) => lblTrangThai.Text = "Thống kê sản phẩm tồn kho và doanh số.";
            mnuThongKeDoanhThu.MouseEnter += (s, e) => lblTrangThai.Text = "Báo cáo doanh thu theo thời gian.";

            mnuTroGiup.MouseEnter += (s, e) => lblTrangThai.Text = "Mở tài liệu hướng dẫn sử dụng.";
            
        }

        private void mnuLoaiSanPham_Click(object sender, EventArgs e)
        {
            if (loaiSanPham == null || loaiSanPham.IsDisposed)
            {
                loaiSanPham = new frmLoaiSanPham();
                loaiSanPham.MdiParent = this;
                loaiSanPham.Show();
            }
            else
                loaiSanPham.Activate();
        }

        private void mnuSanPham_Click(object sender, EventArgs e)
        {
            if (sanPham == null || sanPham.IsDisposed)
            {
                sanPham = new frmSanPham();
                sanPham.MdiParent = this;
                sanPham.Show();
            }
            else
                sanPham.Activate();
        }
        private void mnuHangSanXuat_Click(object sender, EventArgs e)
        {
            if (hangSanXuat == null || hangSanXuat.IsDisposed)
            {
                hangSanXuat = new frmHangSanXuat();
                hangSanXuat.MdiParent = this;
                hangSanXuat.Show();
            }
            else
                hangSanXuat.Activate();

        }

        private void mnuKhachHang_Click(object sender, EventArgs e)
        {
            if (khachHang == null || khachHang.IsDisposed)
            {
                khachHang = new frmKhachHang();
                khachHang.MdiParent = this;
                khachHang.Show();
            }
            else
                khachHang.Activate();
        }

        private void mnuNhanVien_Click(object sender, EventArgs e)
        {
            if (nhanVien == null || nhanVien.IsDisposed)
            {
                nhanVien = new frmNhanVien();
                nhanVien.MdiParent = this;
                nhanVien.Show();
            }
            else
                nhanVien.Activate();
        }

        private void mnuHoaDon_Click(object sender, EventArgs e)
        {
            if (hoaDon == null || hoaDon.IsDisposed)
            {
                hoaDon = new frmHoaDon();
                hoaDon.MdiParent = this;
                hoaDon.Show();
            }
            else
                hoaDon.Activate();
        }

        private void lblLienKet_Click(object sender, EventArgs e)
        {
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "explorer.exe";
            info.Arguments = "https://fit.agu.edu.vn";
            Process.Start(info);
        }
        private void DangNhap()
        {
        LamLai:
            if (dangNhap == null || dangNhap.IsDisposed)
            {
                dangNhap = new frmDangNhap();
            }
            if (dangNhap.ShowDialog() == DialogResult.OK)
            {
                string tenDangNhap = dangNhap.txtTenDangNhap.Text;
                string matKhau = dangNhap.txtMatKhau.Text;
                if (tenDangNhap.Trim() == "")
                {
                    MessageBox.Show("Tên đăng nhập không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dangNhap.txtTenDangNhap.Focus();
                    goto LamLai;
                }
                else if (matKhau.Trim() == "")
                {
                    MessageBox.Show("Mật khẩu không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dangNhap.txtTenDangNhap.Focus();
                    goto LamLai;
                }
                else
                {
                    var nhanVien = context.NhanVien.Where(r => r.TenDangNhap == tenDangNhap).SingleOrDefault();
                    if (nhanVien == null)
                    {
                        MessageBox.Show("Tên đăng nhập không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dangNhap.txtTenDangNhap.Focus();
                        goto LamLai;
                    }
                    else
                    {
                        if (BCrypt.Net.BCrypt.Verify(matKhau, nhanVien.MatKhau))
                        {
                            hoVaTenNhanVien = nhanVien.HoVaTen;
                            if (nhanVien.QuyenHan == true)
                            {
                                QuyenQuanLy();
                            }
                            else if (nhanVien.QuyenHan == false)
                            {
                                QuyenNhanVien();
                            }
                            else
                            {
                                ChuaDangNhap();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Mật khẩu không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dangNhap.txtTenDangNhap.Focus();
                            goto LamLai;
                        }
                    }
                }
            }
        }
        public void ChuaDangNhap()
        {
            // Sáng đăng nhập
            mnuDangNhap.Enabled = true;

            // Mở tất cả
            mnuDangXuat.Enabled = false;
            mnuDoiMatKhau.Enabled = false;

            mnuLoaiSanPham.Enabled = false;
            mnuHangSanXuat.Enabled = false;
            mnuSanPham.Enabled = false;
            mnuKhachHang.Enabled = false;
            mnuNhanVien.Enabled = false;
            mnuHoaDon.Enabled = false;

            mnuThongKeSanPham.Enabled = false;
            mnuThongKeDoanhThu.Enabled = false;

            // Hiển thị thông tin trên thanh trạng thái
            lblTrangThai.Text = "Chưa đăng nhập.";
        }
        public void QuyenQuanLy()
        {
            // Mở đăng nhập
            mnuDangNhap.Enabled = false;
            // Mở các chức năng quản lý không được phép
            // Sáng đăng xuất và các chức năng quản lý được phép
            mnuDangXuat.Enabled = true;
            mnuDoiMatKhau.Enabled = true;
            mnuLoaiSanPham.Enabled = true;
            mnuHangSanXuat.Enabled = true;
            mnuSanPham.Enabled = true;
            mnuKhachHang.Enabled = true;
            mnuNhanVien.Enabled = true;
            mnuHoaDon.Enabled = true;


            mnuThongKeSanPham.Enabled = true;
            mnuThongKeDoanhThu.Enabled = true;

            // Hiển thị thông tin trên thanh trạng thái
            lblTrangThai.Text = "Quản lý: " + hoVaTenNhanVien;
        }
        public void QuyenNhanVien()
        {
            // Mở đăng nhập
            mnuDangNhap.Enabled = false;
            // Mở các chức năng nhân viên không được phép
            mnuLoaiSanPham.Enabled = false;
            mnuHangSanXuat.Enabled = false;
            mnuSanPham.Enabled = false;
            mnuNhanVien.Enabled = false;
            // Sáng đăng xuất và các chức năng quản lý được phép
            mnuDangXuat.Enabled = true;
            mnuDoiMatKhau.Enabled = true;


            mnuKhachHang.Enabled = true;
            mnuHoaDon.Enabled = true;


            mnuThongKeSanPham.Enabled = true;
            mnuThongKeDoanhThu.Enabled = true;

            // Hiển thị thông tin trên thanh trạng thái
            lblTrangThai.Text = "Nhân viên: " + hoVaTenNhanVien;
        }

        private void mnuDangNhap_Click(object sender, EventArgs e)
        {
            DangNhap();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ChuaDangNhap();
            DangNhap();
            SetupToolTips();
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            foreach (Form child in MdiChildren)
            {
                child.Close();
            }
            ChuaDangNhap();
        }

        
    }
}
