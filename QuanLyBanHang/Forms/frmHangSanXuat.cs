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
    public partial class frmHangSanXuat : Form
    {
        QLBHDbContext context = new QLBHDbContext();
        bool xulyThem = false;
        int id;
        public frmHangSanXuat()
        {
            InitializeComponent();
        }
        public void BatTatChucNang(bool giatri)
        {
            btnLuu.Enabled = giatri;
            btnHuyBo.Enabled = giatri;
            txtTenHangSanXuat.Enabled = giatri;

            btnThem.Enabled = !giatri;
            btnSua.Enabled = !giatri;
            btnXoa.Enabled = !giatri;
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
            toolTip.SetToolTip(txtTenHangSanXuat, "Nhập tên hãng sản xuất.\n⚠ Bắt buộc nhập.");

 

            // ── Các nút chức năng ─────────────────────────────────────
            toolTip.SetToolTip(btnThem, "Xóa trắng các ô nhập liệu để thêm hãng sản xuất mới.");

            toolTip.SetToolTip(btnLuu, "Lưu thông tin hãng sản xuất vào cơ sở dữ liệu.");

   

            toolTip.SetToolTip(btnSua, "Kích hoạt chế độ chỉnh sửa thông tin hãng sản xuất đang chọn.");

            toolTip.SetToolTip(btnHuyBo, "Hủy thao tác hiện tại, khôi phục dữ liệu cũ.");

            toolTip.SetToolTip(btnNhap, "Nhập danh sách hãng sản xuất từ file Excel (.xlsx).");

            toolTip.SetToolTip(btnXoa, "Xóa hãng sản xuất đang được chọn.\n⚠ Thao tác không thể hoàn tác!");

            toolTip.SetToolTip(btnThoat, "Đóng màn hình Hãng sản xuất.");

            toolTip.SetToolTip(btnXuat, "Xuất danh sách hãng sản xuất ra file Excel (.xlsx).");

            // ── DataGridView ──────────────────────────────────────────
            toolTip.SetToolTip(dataGridView, "Danh sách hãng sản xuất — click vào dòng để chọn và xem chi tiết.");
        }

        private void frmHangSanXuat_Load(object sender, EventArgs e)
        {
            SetupToolTips();
            BatTatChucNang(false);

            List<HangSanXuat> hangsx = new List<HangSanXuat>();
            hangsx = context.HangSanXuat.ToList();

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = hangsx;

            txtTenHangSanXuat.DataBindings.Clear();
            txtTenHangSanXuat.DataBindings.Add(
                "Text",
                bindingSource,
                "TenHangSanXuat",
                false,
                DataSourceUpdateMode.Never
            );

            dataGridView.DataSource = hangsx;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xulyThem = true;
            BatTatChucNang(true);
            txtTenHangSanXuat.Clear();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            xulyThem = false;
            BatTatChucNang(true);
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenHangSanXuat.Text))
            {
                MessageBox.Show("Vui lòng nhập tên hãng sản xuất?", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (xulyThem)
                {
                    HangSanXuat hangsx = new HangSanXuat();
                    hangsx.TenHangSanXuat = txtTenHangSanXuat.Text;
                    context.HangSanXuat.Add(hangsx);

                    context.SaveChanges();
                }
                else
                {
                    HangSanXuat hangsx = context.HangSanXuat.Find(id);
                    if (hangsx != null)
                    {
                        hangsx.TenHangSanXuat = txtTenHangSanXuat.Text;
                        context.HangSanXuat.Update(hangsx);

                        context.SaveChanges();
                    }
                }
                frmHangSanXuat_Load(sender, e);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult trloi = MessageBox.Show("Xác nhận xoá hãng sản xuất", "Xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (trloi == DialogResult.Yes)
            {
                id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
                HangSanXuat hangsx = context.HangSanXuat.Find(id);
                if (hangsx != null)
                {
                    context.HangSanXuat.Remove(hangsx);
                }
                frmHangSanXuat_Load(sender, e);
            }

        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            frmHangSanXuat_Load(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult trloi = MessageBox.Show("Xác nhận thoát?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (trloi == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDiaLog = new OpenFileDialog();
            openFileDiaLog.Title = "Nhập dữ liệu từ tập tin Excel";
            openFileDiaLog.Filter = "Tập tin Excel|*.xls;*xlsx";
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
                                HangSanXuat hsx = new HangSanXuat();
                                hsx.TenHangSanXuat = r["TenHangSanXuat"].ToString();
                                context.HangSanXuat.Add(hsx);
                            }
                            context.SaveChanges();

                            MessageBox.Show("Đã nhập thành công " + table.Rows.Count + " dòng", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmHangSanXuat_Load(sender, e);
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

                    table.Columns.AddRange(new DataColumn[2]{
                        new DataColumn("ID", typeof(int)),
                        new DataColumn("TenHangSanXuat", typeof(string))
                    });
                    var hangSanXuat = context.HangSanXuat.ToList();
                    if (hangSanXuat != null)
                    {
                        foreach (var p in hangSanXuat)
                        {
                            table.Rows.Add(p.ID, p.TenHangSanXuat);
                        }
                    }

                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var sheet = wb.Worksheets.Add(table, "HangSanXuat");
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

        private void frmHangSanXuat_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            
            string helpPath = Path.Combine(Application.StartupPath, "Help", "hangsanxuat.htm");

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = helpPath,
                UseShellExecute = true  // Mở bằng trình duyệt mặc định
            });

            hlpevent.Handled = true;
        }
    
    }
}
