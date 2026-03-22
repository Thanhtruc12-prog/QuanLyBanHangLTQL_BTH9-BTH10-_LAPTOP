using ClosedXML.Excel;
using QuanLyBanHang.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyBanHang.Forms
{
    public partial class frmLoaiSanPham : Form
    {
        QLBHDbContext context = new QLBHDbContext(); // Khởi tạo biến ngữ cảnh CSDL
        bool xuLyThem = false; // Kiểm tra có nhấn vào nút Thêm hay không?
        int id;// Lấy mã loại sản phẩm (dùng cho Sửa và Xóa)

        public frmLoaiSanPham()
        {
            InitializeComponent();
        }
        private void BatTatChucNang(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuyBo.Enabled = giaTri;
            txtTenLoai.Enabled = giaTri;
            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
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
            toolTip.SetToolTip(txtTenLoai, "Nhập tên loại sản phẩm.\n⚠ Bắt buộc nhập.");



            // ── Các nút chức năng ─────────────────────────────────────
            toolTip.SetToolTip(btnThem, "Xóa trắng các ô nhập liệu để thêm loại sản phẩm mới.");

            toolTip.SetToolTip(btnLuu, "Lưu thông tin loại sản phẩm vào cơ sở dữ liệu.");



            toolTip.SetToolTip(btnSua, "Kích hoạt chế độ chỉnh sửa thông tin loại sản phẩm đang chọn.");

            toolTip.SetToolTip(btnHuyBo, "Hủy thao tác hiện tại, khôi phục dữ liệu cũ.");

            toolTip.SetToolTip(btnNhap, "Nhập danh sách loại sản phẩm từ file Excel (.xlsx).");

            toolTip.SetToolTip(btnXoa, "Xóa loại sản phẩm đang được chọn.\n⚠ Thao tác không thể hoàn tác!");

            toolTip.SetToolTip(btnThoat, "Đóng màn hình Loại sản phẩm.");

            toolTip.SetToolTip(btnXuat, "Xuất danh sách loại sản phẩm ra file Excel (.xlsx).");

            // ── DataGridView ──────────────────────────────────────────
            toolTip.SetToolTip(dataGridView, "Danh sách loại sản phẩm — click vào dòng để chọn và xem chi tiết.");
        }

        private void frmLoaiSanPham_Load(object sender, EventArgs e)
        {
            SetupToolTips();
            BatTatChucNang(false);

            List<LoaiSanPham> lsp = new List<LoaiSanPham>();
            lsp = context.LoaiSanPham.ToList();

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = lsp;

            txtTenLoai.DataBindings.Clear();
            txtTenLoai.DataBindings.Add(
                "Text",
                bindingSource,
                "TenLoai",
                false,
                DataSourceUpdateMode.Never

             );

            dataGridView.DataSource = bindingSource;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            BatTatChucNang(true);
            txtTenLoai.Clear();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            xuLyThem = false;
            BatTatChucNang(true);
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult trloi = MessageBox.Show("Xác nhận xoá loại sản phẩm?", "Xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (trloi == DialogResult.Yes)
            {
                id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
                LoaiSanPham lsp = context.LoaiSanPham.Find(id);
                if (lsp != null)
                {
                    context.LoaiSanPham.Remove(lsp);
                }
                context.SaveChanges();
                frmLoaiSanPham_Load(sender, e);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenLoai.Text))
            {
                MessageBox.Show("Vui lòng nhập tên loại sản phẩm?", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (xuLyThem)
                {
                    LoaiSanPham lsp = new LoaiSanPham();
                    lsp.TenLoai = txtTenLoai.Text;
                    context.LoaiSanPham.Add(lsp);

                    context.SaveChanges();
                }
                else
                {
                    LoaiSanPham lsp = context.LoaiSanPham.Find(id);
                    if (lsp != null)
                    {
                        lsp.TenLoai = txtTenLoai.Text;
                        context.LoaiSanPham.Update(lsp);

                        context.SaveChanges();
                    }
                }
                frmLoaiSanPham_Load(sender, e);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            frmLoaiSanPham_Load(sender, e);
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
                                LoaiSanPham lsp = new LoaiSanPham();
                                lsp.TenLoai = r["TenLoai"].ToString();
                                context.LoaiSanPham.Add(lsp);
                            }
                            context.SaveChanges();

                            MessageBox.Show("Đã nhập thành công " + table.Rows.Count + " dòng", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmLoaiSanPham_Load(sender, e);
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
                        new DataColumn("TenLoai", typeof(string))
                    });
                    var loaiSanPham = context.LoaiSanPham.ToList();
                    if (loaiSanPham != null)
                    {
                        foreach (var p in loaiSanPham)
                        {
                            table.Rows.Add(p.ID, p.TenLoai);
                        }
                    }

                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var sheet = wb.Worksheets.Add(table, "LoaiSanPham");
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

        
        private void frmLoaiSanPham_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            string helpPath = Path.Combine(Application.StartupPath, "Help", "loaisanpham.htm");

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = helpPath,
                UseShellExecute = true  // Mở bằng trình duyệt mặc định
            });

            hlpevent.Handled = true;
        }
    }
}