using QuanLyBanHang.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLyBanHang.Forms
{
    public partial class frmHoaDon_ChiTiet : Form
    {
        QLBHDbContext context = new QLBHDbContext();
        int id;
        BindingList<DanhSachHoaDon_ChiTiet> hoaDonChiTiet = new BindingList<DanhSachHoaDon_ChiTiet>();
        public frmHoaDon_ChiTiet(int maHoaDon = 0)
        {
            InitializeComponent();
            id = maHoaDon;

        }
        private void SetupToolTips()
        {
            // Cấu hình ToolTip
            toolTip.IsBalloon = true;
            toolTip.ShowAlways = true;
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 400;
            toolTip.ReshowDelay = 200;

            // ── Thông tin hoá đơn ─────────────────────────────────────
            toolTip.SetToolTip(cboNhanVien,
                "Chọn nhân viên lập hoá đơn.\n" +
                "Mặc định là tài khoản đang đăng nhập.\n" +
                "⚠ Bắt buộc chọn.");

            toolTip.SetToolTip(cboKhachHang,
                "Chọn khách hàng mua hàng từ danh sách.\n" +
                "Để trống nếu là khách vãng lai.\n" +
                "⚠ Bắt buộc chọn.");

            toolTip.SetToolTip(txtGhiChuHoaDon,
                "Nhập ghi chú thêm cho hoá đơn.\n" +
                "Ví dụ: giao hàng tận nơi, thanh toán chuyển khoản...\n" +
                "(Không bắt buộc)");

            // ── Thông tin chi tiết sản phẩm ───────────────────────────
            toolTip.SetToolTip(cboSanPham,
                "Chọn sản phẩm cần thêm vào hoá đơn.\n" +
                "Đơn giá sẽ tự động điền sau khi chọn.\n" +
                "⚠ Bắt buộc chọn.");

            toolTip.SetToolTip(numDonGiaBan,
                "Đơn giá bán của sản phẩm (VNĐ).\n" +
                "Tự động lấy từ hệ thống, có thể điều chỉnh nếu cần.\n" +
                "⚠ Bắt buộc nhập.");

            toolTip.SetToolTip(numSoLuongBan,
                "Số lượng sản phẩm cần bán.\n" +
                "Không được vượt quá số lượng tồn kho hiện có.\n" +
                "⚠ Bắt buộc nhập. Tối thiểu: 1.");

            toolTip.SetToolTip(btnXacNhanBan,
                "Thêm sản phẩm đang chọn vào danh sách chi tiết hoá đơn.\n" +
                "Thành tiền = Đơn giá × Số lượng.");

            toolTip.SetToolTip(btnXoa,
                "Xóa dòng sản phẩm đang chọn khỏi chi tiết hoá đơn.\n" +
                "⚠ Thao tác không thể hoàn tác!");

            // ── DataGridView chi tiết ──────────────────────────────────
            toolTip.SetToolTip(dataGridView,
                "Danh sách sản phẩm trong hoá đơn.");

            // ── Nút dưới cùng ─────────────────────────────────────────
            toolTip.SetToolTip(btnLuuHoaDon,
                "Lưu hoá đơn vào cơ sở dữ liệu.\n" +
                "Tồn kho sản phẩm sẽ tự động giảm theo số lượng đã bán.\n" +
                "⚠ Hoá đơn phải có ít nhất một sản phẩm.");

            toolTip.SetToolTip(btnInHoaDon,
                "In hoá đơn ra máy in ngay sau khi lưu.");

            toolTip.SetToolTip(btnThoat,
                "Đóng cửa sổ hoá đơn chi tiết.\n" +
                "⚠ Nếu chưa lưu, dữ liệu sẽ bị mất!");
        }
        public void LayNhanVienVaoComboBox()
        {
            cboNhanVien.DataSource = context.NhanVien.ToList();
            cboNhanVien.ValueMember = "ID";
            cboNhanVien.DisplayMember = "HoVaTen";
        }
        public void LayKhachHangVaoComboBox()
        {
            cboKhachHang.DataSource = context.KhachHang.ToList();
            cboKhachHang.ValueMember = "ID";
            cboKhachHang.DisplayMember = "HoVaTen";
        }
        public void LaySanPhamVaoComboBox()
        {
            cboSanPham.DataSource = context.SanPham.ToList();
            cboSanPham.ValueMember = "ID";
            cboSanPham.DisplayMember = "TenSanPham";
        }
        public void BatTatChucNang()
        {
            if (id == 0 && dataGridView.Rows.Count == 0)
            {
                cboNhanVien.Text = "";
                cboKhachHang.Text = "";
                cboSanPham.Text = "";
                numDonGiaBan.Value = 0;
                numSoLuongBan.Value = 1;
            }
            btnLuuHoaDon.Enabled = dataGridView.Rows.Count > 0;
            btnXoa.Enabled = dataGridView.Rows.Count > 0;
        }

        private void frmHoaDon_ChiTiet_Load(object sender, EventArgs e)
        {
            SetupToolTips();
            LayNhanVienVaoComboBox();
            LayKhachHangVaoComboBox();
            LaySanPhamVaoComboBox();

            dataGridView.AutoGenerateColumns = false;
            if (id != 0) // Đã tồn tại chi tiết
            {
                var hoaDon = context.HoaDon.Where(r => r.ID == id).SingleOrDefault();
                cboNhanVien.SelectedValue = hoaDon.NhanVienID;
                cboKhachHang.SelectedValue = hoaDon.KhachHangID;
                txtGhiChuHoaDon.Text = hoaDon.GhiChuHoaDon;

                var ct = context.HoaDon_ChiTiet.Where(r => r.HoaDonID == id).Select(r => new DanhSachHoaDon_ChiTiet
                {
                    ID = r.ID,
                    HoaDonID = r.HoaDonID,
                    SanPhamID = r.SanPhamID,
                    TenSanPham = r.SanPham.TenSanPham,
                    SoLuongBan = r.SoLuongBan,
                    DonGiaBan = r.DonGiaBan,
                    ThanhTien = Convert.ToInt32(r.SoLuongBan * r.DonGiaBan)
                }).ToList();
                hoaDonChiTiet = new BindingList<DanhSachHoaDon_ChiTiet>(ct);
            }

            dataGridView.DataSource = hoaDonChiTiet;
            BatTatChucNang();
        }

        private void btnXacNhanBan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cboSanPham.Text))
                MessageBox.Show("Vui lòng chọn sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (numSoLuongBan.Value <= 0)
                MessageBox.Show("Số lượng bán phải lớn hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (numDonGiaBan.Value <= 0)
                MessageBox.Show("Đơn giá bán sản phẩm phải lớn hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                int maSanPham = Convert.ToInt32(cboSanPham.SelectedValue.ToString());
                var chiTiet = hoaDonChiTiet.FirstOrDefault(r => r.SanPhamID == maSanPham);
                if (chiTiet != null)
                {
                    chiTiet.SoLuongBan = Convert.ToInt32(numSoLuongBan.Value);
                    chiTiet.DonGiaBan = Convert.ToInt32(numDonGiaBan.Value);
                    chiTiet.ThanhTien = Convert.ToInt32(numDonGiaBan.Value * numSoLuongBan.Value);
                    dataGridView.Refresh();
                }
                else // Nếu chưa có sản phẩm thì thêm vào
                {
                    // Nếu chưa có sản phẩm nào
                    DanhSachHoaDon_ChiTiet ct = new DanhSachHoaDon_ChiTiet
                    {
                        ID = 0,
                        HoaDonID = id,
                        SanPhamID = maSanPham,
                        TenSanPham = cboSanPham.Text,
                        SoLuongBan = Convert.ToInt32(numSoLuongBan.Value),
                        DonGiaBan = Convert.ToInt32(numDonGiaBan.Value),
                        ThanhTien = Convert.ToInt32(numSoLuongBan.Value * numDonGiaBan.Value)

                    };
                    hoaDonChiTiet.Add(ct);

                }
                BatTatChucNang();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult trloi = MessageBox.Show("Xác nhận xoá chi tiết sản phẩm " + cboSanPham.Text + " của " + cboKhachHang.Text + "?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (trloi == DialogResult.Yes)
            {
                int maSanPham = Convert.ToInt32(dataGridView.CurrentRow.Cells["SanPhamID"].Value.ToString());
                var chiTiet = hoaDonChiTiet.FirstOrDefault(x => x.SanPhamID == maSanPham);
                if (chiTiet != null)
                {
                    hoaDonChiTiet.Remove(chiTiet);
                }
                BatTatChucNang();
            }

        }

        private void cboSanPham_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int maSanPham = Convert.ToInt32(cboSanPham.SelectedValue.ToString());
            var sanPham = context.SanPham.Find(maSanPham);
            if (sanPham != null)
            {
                numDonGiaBan.Value = sanPham.DonGia;
            }
        }

        private void btnLuuHoaDon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cboNhanVien.Text))
                MessageBox.Show("Vui lòng chọn nhân viên lập hoá đơn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (string.IsNullOrWhiteSpace(cboKhachHang.Text))
                MessageBox.Show("Vui lòng chọn khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {

                if (id != 0)// Đã tồn tại chi tiết thì chỉ cập nhật
                {
                    HoaDon hd = context.HoaDon.Find(id);
                    if (hd != null)
                    {
                        hd.NhanVienID = Convert.ToInt32(cboNhanVien.SelectedValue.ToString());
                        hd.KhachHangID = Convert.ToInt32(cboKhachHang.SelectedValue.ToString());
                        hd.GhiChuHoaDon = txtGhiChuHoaDon.Text;
                        context.HoaDon.Update(hd);
                        // Xoá chi tiết cũ
                        var old = context.HoaDon_ChiTiet.Where(r => r.HoaDonID == id).ToList();
                        context.HoaDon_ChiTiet.RemoveRange(old);

                        // Thêm lại chi tiết mới
                        foreach (var item in hoaDonChiTiet.ToList())
                        {
                            HoaDon_ChiTiet ct = new HoaDon_ChiTiet();
                            ct.HoaDonID = id;
                            ct.SanPhamID = item.SanPhamID;
                            ct.SoLuongBan = item.SoLuongBan;
                            ct.DonGiaBan = item.DonGiaBan;
                            context.HoaDon_ChiTiet.Add(ct);
                        }
                        context.SaveChanges();
                    }

                }
                else // Thêm mới
                {
                    HoaDon hd = new HoaDon();
                    hd.NhanVienID = Convert.ToInt32(cboNhanVien.SelectedValue.ToString());
                    hd.KhachHangID = Convert.ToInt32(cboKhachHang.SelectedValue.ToString());
                    hd.NgayLap = DateTime.Now;
                    hd.GhiChuHoaDon = txtGhiChuHoaDon.Text;
                    context.HoaDon.Add(hd);
                    context.SaveChanges();

                    foreach (var item in hoaDonChiTiet.ToList())
                    {
                        HoaDon_ChiTiet ct = new HoaDon_ChiTiet();
                        ct.HoaDonID = hd.ID;
                        ct.SanPhamID = item.SanPhamID;
                        ct.SoLuongBan = item.SoLuongBan;
                        ct.DonGiaBan = item.DonGiaBan;
                        context.HoaDon_ChiTiet.Add(ct);
                    }
                    context.SaveChanges();

                }
                MessageBox.Show("Đã lưu thành công!", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult trloi = MessageBox.Show("Xác nhận thoát khỏi Form Chi Tiết Hoá Đơn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (trloi == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void frmHoaDon_ChiTiet_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            string helpPath = Path.Combine(Application.StartupPath, "Help", "hoadon_chitiet.htm");

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = helpPath,
                UseShellExecute = true  // Mở bằng trình duyệt mặc định
            });

            hlpevent.Handled = true;
        }
    }

}
