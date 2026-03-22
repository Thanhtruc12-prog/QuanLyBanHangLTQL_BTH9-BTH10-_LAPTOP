using ClosedXML.Excel;
using QuanLyBanHang.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace QuanLyBanHang.Forms
{
    public partial class frmNhanVien : Form
    {

        QLBHDbContext context = new QLBHDbContext();
        int id;
        bool xulyThem = false;
        
        public frmNhanVien()
        {
            InitializeComponent();
            
        }

       
        public void BatTatChucNang(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuyBo.Enabled = giaTri;
            txtHoVaTen.Enabled = giaTri;
            txtDienThoai.Enabled = giaTri;
            txtDiaChi.Enabled = giaTri;
            txtMatKhau.Enabled = giaTri;
            cboQuyenHan.Enabled = giaTri;

            btnThem.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnTimKiem.Enabled = !giaTri;
            btnNhap.Enabled = !giaTri;
            btnXuat.Enabled = !giaTri;
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
            toolTip.SetToolTip(txtHoVaTen,"Nhập họ và tên đầy đủ của nhân viên.\n⚠ Bắt buộc nhập.");

            toolTip.SetToolTip(txtTenDangNhap,
                "Tên tài khoản dùng để đăng nhập hệ thống.\n" +
                "Không dấu, không khoảng trắng, không được trùng.\n" +
                "⚠ Bắt buộc nhập.");

            toolTip.SetToolTip(txtDienThoai,"Số điện thoại liên hệ của nhân viên.\n(Không bắt buộc)");

            toolTip.SetToolTip(txtMatKhau,
                "Mật khẩu đăng nhập hệ thống.\n" +
                "Nên gồm chữ hoa, chữ thường, số và ký tự đặc biệt.\n" +
                "⚠ Bắt buộc nhập.");

            toolTip.SetToolTip(txtDiaChi,"Địa chỉ nơi cư trú của nhân viên.\n(Không bắt buộc)");

            toolTip.SetToolTip(cboQuyenHan,
                "Chọn cấp quyền truy cập của nhân viên trong hệ thống.\n" +
                "Admin: toàn quyền | Nhân viên: quyền hạn giới hạn.\n" +
                "⚠ Bắt buộc chọn.");

            // ── Các nút chức năng ─────────────────────────────────────
            toolTip.SetToolTip(btnThem, "Xóa trắng các ô nhập liệu để thêm nhân viên mới.");

            toolTip.SetToolTip(btnLuu,"Lưu thông tin nhân viên vào cơ sở dữ liệu.");

            toolTip.SetToolTip(btnTimKiem,"Tìm kiếm nhân viên theo họ tên hoặc tên đăng nhập.");

            toolTip.SetToolTip(btnSua, "Kích hoạt chế độ chỉnh sửa thông tin nhân viên đang chọn.");

            toolTip.SetToolTip(btnHuyBo, "Hủy thao tác hiện tại, khôi phục dữ liệu cũ.");

            toolTip.SetToolTip(btnNhap, "Nhập danh sách nhân viên từ file Excel (.xlsx).");

            toolTip.SetToolTip(btnXoa,"Xóa nhân viên đang được chọn.\n⚠ Thao tác không thể hoàn tác!");

            toolTip.SetToolTip(btnThoat, "Đóng màn hình Nhân viên.");

            toolTip.SetToolTip(btnXuat,"Xuất danh sách nhân viên ra file Excel (.xlsx).");

            // ── DataGridView ──────────────────────────────────────────
            toolTip.SetToolTip(dataGridView,"Danh sách nhân viên — click vào dòng để chọn và xem chi tiết.");
        }
      
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            SetupToolTips();
            BatTatChucNang(false);

            dataGridView.AutoGenerateColumns = false;

            List<NhanVien> nv = new List<NhanVien>();
            nv = context.NhanVien.ToList();

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = nv;

            txtHoVaTen.DataBindings.Clear();
            txtHoVaTen.DataBindings.Add(
                "Text",
                bindingSource,
                "HoVaTen",
                false,
                DataSourceUpdateMode.Never);


            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add(
                "Text",
                bindingSource,
                "DiaChi",
                false,
                DataSourceUpdateMode.Never);


            txtDienThoai.DataBindings.Clear();
            txtDienThoai.DataBindings.Add(
                "Text",
                bindingSource,
                "DienThoai",
                false,
                DataSourceUpdateMode.Never);

            txtTenDangNhap.DataBindings.Clear();
            txtTenDangNhap.DataBindings.Add(
                "Text",
                bindingSource,
                "TenDangNhap",
                false,
                DataSourceUpdateMode.Never);

            cboQuyenHan.DataBindings.Clear();
            cboQuyenHan.DataBindings.Add(
                "SelectedIndex",
                bindingSource,
                "QuyenHan",
                false,
                DataSourceUpdateMode.Never);

            dataGridView.DataSource = bindingSource;

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xulyThem = true;
            BatTatChucNang(true);
            txtHoVaTen.Clear();
            txtDienThoai.Clear();
            txtDiaChi.Clear();
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            cboQuyenHan.Text = "";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            xulyThem = false;
            BatTatChucNang(true);
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoVaTen.Text))
                MessageBox.Show("Vui lòng nhập họ và tên nhân viên?", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
                MessageBox.Show("Vui lòng nhập tên đăng nhập?", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (string.IsNullOrWhiteSpace(cboQuyenHan.Text))
                MessageBox.Show("Vui lòng chọn quyền hạn cho nhân viên?", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (xulyThem)
                {
                    if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
                        MessageBox.Show("Vui nhập mật khẩu?", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        NhanVien nv = new NhanVien();
                        nv.HoVaTen = txtHoVaTen.Text;
                        nv.DienThoai = txtDienThoai.Text;
                        nv.DiaChi = txtDiaChi.Text;
                        nv.TenDangNhap = txtTenDangNhap.Text;
                        nv.MatKhau = BCrypt.Net.BCrypt.HashPassword(txtMatKhau.Text);
                        nv.QuyenHan = cboQuyenHan.SelectedIndex == 0 ? true : false;
                        context.NhanVien.Add(nv);

                        context.SaveChanges();
                    }
                }
                else
                {
                    NhanVien nv = context.NhanVien.Find(id);
                    if (nv != null)
                    {
                        nv.HoVaTen = txtHoVaTen.Text;
                        nv.DienThoai = txtDienThoai.Text;
                        nv.DiaChi = txtDiaChi.Text;
                        nv.TenDangNhap = txtTenDangNhap.Text;
                        nv.QuyenHan = cboQuyenHan.SelectedIndex == 0 ? true : false;
                        context.NhanVien.Update(nv);

                        if (string.IsNullOrEmpty(txtMatKhau.Text))
                            context.Entry(nv).Property(x => x.MatKhau).IsModified = false; //Giữ nguyên mật khẩu cũ
                        else
                            nv.MatKhau = BCrypt.Net.BCrypt.HashPassword(txtMatKhau.Text);

                        context.SaveChanges();
                    }
                }
                frmNhanVien_Load(sender, e);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult trloi = MessageBox.Show("Xác nhận xoá nhân viên " + txtHoVaTen.Text + "?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (trloi == DialogResult.Yes)
            {
                id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
                NhanVien nv = context.NhanVien.Find(id);
                if (nv != null)
                {
                    context.NhanVien.Remove(nv);
                }
                context.SaveChanges();

                frmNhanVien_Load(sender, e);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            frmNhanVien_Load(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult trloi = MessageBox.Show("Xác nhận thoát khỏi Form Nhân Viên ", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (trloi == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDiaLog = new OpenFileDialog();
            openFileDiaLog.Title = "Nhập dữ liệu từ tập tin Excel";
            openFileDiaLog.Filter = "Tập tin Excel|*.xls;*.xlsx";
            openFileDiaLog.Multiselect = true;

            if (openFileDiaLog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable table = new DataTable();
                    using (XLWorkbook workbook = new XLWorkbook(openFileDiaLog.FileName))
                    {
                        IXLWorksheet worksheet = workbook.Worksheet(1);
                        bool firstRow = true;
                        string readRange = "1:1";
                        foreach (IXLRow row in worksheet.RowsUsed())
                        {
                            // Đọc dòng tiêu đề đầu tiên
                            if (firstRow)
                            {
                                readRange = string.Format("{0}:{1}", 1, row.LastCellUsed().Address.ColumnNumber);
                                foreach (IXLCell cell in row.Cells(readRange))
                                {
                                    table.Columns.Add(cell.Value.ToString());
                                }
                                firstRow = false;
                            }
                            else // Đọc các dòng nội dung (các dòng tiếp theo)
                            {
                                table.Rows.Add();
                                int cellIndex = 0;
                                foreach (IXLCell cell in row.Cells(readRange))
                                {
                                    table.Rows[table.Rows.Count - 1][cellIndex] = cell.Value.ToString();
                                    cellIndex++;
                                }
                            }
                        }
                        if (table.Rows.Count > 0)
                        {
                            foreach (DataRow r in table.Rows)
                            {
                                NhanVien nv = new NhanVien();
                                nv.HoVaTen = r["HoVaTen"].ToString();
                                nv.DienThoai = r["DienThoai"].ToString();
                                nv.DiaChi = r["DiaChi"].ToString();
                                nv.TenDangNhap = r["TenDangNhap"].ToString();
                                nv.MatKhau = r["MatKhau"].ToString();
                                nv.QuyenHan = Convert.ToBoolean(r["QuyenHan"]);

                                context.NhanVien.Add(nv);
                            }
                            context.SaveChanges();

                            MessageBox.Show("Đã nhập thành công " + table.Rows.Count + " dòng", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmNhanVien_Load(sender, e);
                        }
                        if (firstRow)
                        {
                            MessageBox.Show("Tập tin Excel rỗng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        }
                    }

                }
                catch (Exception ex)
                {
                    {
                        MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                }
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDiaLog = new SaveFileDialog();
            saveFileDiaLog.Title = "Xuất dữ liệu ra tập tin Excel";
            saveFileDiaLog.Filter = "Tập tin Excel|*.xlsx";

            if (saveFileDiaLog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable table = new DataTable();

                    table.Columns.AddRange(new DataColumn[7]{
                        new DataColumn("ID", typeof(int)),
                        new DataColumn("HoVaTen", typeof(string)),
                        new DataColumn("DienThoai", typeof(string)),
                        new DataColumn("DiaChi", typeof(string)),
                        new DataColumn("TenDangNhap", typeof(string)),
                        new DataColumn("MatKhau", typeof(string)),
                        new DataColumn("QuyenHan", typeof(string))


                    });
                    var nhanVien = context.NhanVien.ToList();
                    if (nhanVien != null)
                    {
                        foreach (var p in nhanVien)
                        {
                            table.Rows.Add(p.ID, p.HoVaTen, p.DienThoai, p.DiaChi, p.TenDangNhap, p.MatKhau, p.QuyenHan);
                        }
                    }

                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var sheet = wb.Worksheets.Add(table, "NhanVien");
                        sheet.Columns().AdjustToContents();
                        wb.SaveAs(saveFileDiaLog.FileName);

                        MessageBox.Show("Đã xuất dữ liệu ra tập tin Excel thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
                catch (Exception ex)
                {
                    {
                        MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void frmNhanVien_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            string helpPath = Path.Combine(Application.StartupPath, "Help", "nhanvien.htm");

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = helpPath,
                UseShellExecute = true  // Mở bằng trình duyệt mặc định
            });

            hlpevent.Handled = true;
        }



    }
}

