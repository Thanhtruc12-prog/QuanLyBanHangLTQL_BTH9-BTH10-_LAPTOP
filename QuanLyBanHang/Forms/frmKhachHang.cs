using ClosedXML.Excel;
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
    public partial class frmKhachHang : Form
    {
        QLBHDbContext context = new QLBHDbContext();
        int id;
        bool xulyThem = false;
        public frmKhachHang()
        {
            InitializeComponent();
        }
        public void BatTatChucNang(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuyBo.Enabled = giaTri;
            txtDiaChi.Enabled = giaTri;
            txtHoVaTen.Enabled = giaTri;
            txtDienThoai.Enabled = giaTri;

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
            toolTip.SetToolTip(txtHoVaTen, "Nhập họ và tên đầy đủ của khách hàng.\n⚠ Bắt buộc nhập.");

           

            toolTip.SetToolTip(txtDienThoai, "Số điện thoại liên hệ của khách hàng.\n(Không bắt buộc)");

            

            toolTip.SetToolTip(txtDiaChi, "Địa chỉ nơi cư trú của khách hàng.\n(Không bắt buộc)");


            // ── Các nút chức năng ─────────────────────────────────────
            toolTip.SetToolTip(btnThem, "Xóa trắng các ô nhập liệu để thêm khách hàng mới.");

            toolTip.SetToolTip(btnLuu, "Lưu thông tin khách hàng vào cơ sở dữ liệu.");

            toolTip.SetToolTip(btnTimKiem, "Tìm kiếm khách hàng theo họ tên hoặc tên đăng nhập.");

            toolTip.SetToolTip(btnSua, "Kích hoạt chế độ chỉnh sửa thông tin khách hàng đang chọn.");

            toolTip.SetToolTip(btnHuyBo, "Hủy thao tác hiện tại, khôi phục dữ liệu cũ.");

            toolTip.SetToolTip(btnNhap, "Nhập danh sách khách hàng từ file Excel (.xlsx).");

            toolTip.SetToolTip(btnXoa, "Xóa khách hàng đang được chọn.\n⚠ Thao tác không thể hoàn tác!");

            toolTip.SetToolTip(btnThoat, "Đóng màn hình Khách hàng.");

            toolTip.SetToolTip(btnXuat, "Xuất danh sách khách hàng ra file Excel (.xlsx).");

            // ── DataGridView ──────────────────────────────────────────
            toolTip.SetToolTip(dataGridView, "Danh sách khách hàng — click vào dòng để chọn và xem chi tiết.");
        }
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            SetupToolTips();
            BatTatChucNang(false);

            List<KhachHang> kh = new List<KhachHang>();
            kh = context.KhachHang.ToList();

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = kh;

            txtHoVaTen.DataBindings.Clear();
            txtHoVaTen.DataBindings.Add(
                "Text",
                bindingSource,
                "HoVaTen",
                false,
                DataSourceUpdateMode.Never);

            txtDienThoai.DataBindings.Clear();
            txtDienThoai.DataBindings.Add(
                "Text",
                bindingSource,
                "DienThoai",
                false,
                DataSourceUpdateMode.Never);

            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add(
                "Text",
                bindingSource,
                "DiaChi",
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
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            xulyThem = true;
            BatTatChucNang(true);
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoVaTen.Text))
                MessageBox.Show("Vui lòng nhập họ và tên khách hàng?", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (xulyThem)
                {
                    KhachHang kh = new KhachHang();
                    kh.HoVaTen = txtHoVaTen.Text;
                    kh.DienThoai = txtDienThoai.Text;
                    kh.DiaChi = txtDiaChi.Text;
                    context.KhachHang.Add(kh);

                    context.SaveChanges();
                }
                else
                {
                    KhachHang kh = context.KhachHang.Find(id);
                    if (kh != null)
                    {
                        kh.HoVaTen = txtHoVaTen.Text;
                        kh.DienThoai = txtDienThoai.Text;
                        kh.DiaChi = txtDiaChi.Text;

                        context.KhachHang.Update(kh);

                        context.SaveChanges();
                    }
                }
                frmKhachHang_Load(sender, e);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult trloi = MessageBox.Show("Xác nhận xoá khách hàng " + txtHoVaTen.Text + "?", "Xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (trloi == DialogResult.Yes)
            {
                id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
                KhachHang kh = context.KhachHang.Find(id);
                if (kh != null)
                {
                    context.KhachHang.Remove(kh);
                }
                context.SaveChanges();

                frmKhachHang_Load(sender, e);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            frmKhachHang_Load(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult trloi = MessageBox.Show("Xác nhận thoát khỏi Form Khách Hàng", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                                KhachHang kh = new KhachHang();
                                kh.HoVaTen = r["HoVaTen"].ToString();
                                kh.DienThoai = r["DienThoai"].ToString();
                                kh.DiaChi = r["DiaChi"].ToString();

                                context.KhachHang.Add(kh);
                            }
                            context.SaveChanges();

                            MessageBox.Show("Đã nhập thành công " + table.Rows.Count + " dòng", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmKhachHang_Load(sender, e);
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

                    table.Columns.AddRange(new DataColumn[4]{
                        new DataColumn("ID", typeof(int)),
                        new DataColumn("HoVaTen", typeof(string)),
                        new DataColumn("DienThoai", typeof(string)),
                        new DataColumn("DiaChi", typeof(string))

                    });
                    var khachHang = context.KhachHang.ToList();
                    if (khachHang != null)
                    {
                        foreach (var p in khachHang)
                        {
                            table.Rows.Add(p.ID, p.HoVaTen, p.DienThoai, p.DiaChi);
                        }
                    }

                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var sheet = wb.Worksheets.Add(table, "KhachHang");
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

        private void frmKhachHang_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            string helpPath = Path.Combine(Application.StartupPath, "Help", "khachhang.htm");

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = helpPath,
                UseShellExecute = true  // Mở bằng trình duyệt mặc định
            });

            hlpevent.Handled = true;
        }
    }

}

