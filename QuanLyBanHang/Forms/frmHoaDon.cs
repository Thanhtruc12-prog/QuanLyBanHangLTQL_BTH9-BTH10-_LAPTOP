using ClosedXML.Excel;
using QuanLyBanHang.Data;
using QuanLyBanHang.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLyBanHang.Forms
{
    public partial class frmHoaDon : Form
    {
        QLBHDbContext context = new QLBHDbContext();
        int id;
        public frmHoaDon()
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

            // ── Các nút chức năng ─────────────────────────────────────
            toolTip.SetToolTip(btnLapHoaDon,
                "Mở cửa sổ lập hoá đơn bán hàng mới.\n" +
                "Chọn khách hàng, sản phẩm và số lượng cần mua.");

            toolTip.SetToolTip(btnInHoaDon,
                "In hoá đơn đang được chọn ra máy in.\n" +
                "⚠ Vui lòng chọn một hoá đơn trong danh sách trước.");

            toolTip.SetToolTip(btnSua,
                "Mở hoá đơn đang chọn để chỉnh sửa thông tin.\n" +
                "⚠ Vui lòng chọn một hoá đơn trong danh sách trước.");

            toolTip.SetToolTip(btnXoa,
                "Xóa hoá đơn đang được chọn khỏi hệ thống.\n" +
                "⚠ Thao tác không thể hoàn tác!");

            toolTip.SetToolTip(btnThoat,
                "Đóng màn hình Hoá đơn.\n" +
                "Phím tắt: Alt+F4");

            toolTip.SetToolTip(btnTimKiem,
                "Tìm kiếm hoá đơn theo nhân viên, khách hàng hoặc ngày lập.");

            toolTip.SetToolTip(btnNhap,
                "Nhập danh sách hoá đơn từ file Excel (.xlsx).");

            toolTip.SetToolTip(btnXuat,
                "Xuất danh sách hoá đơn ra file Excel (.xlsx).");

            // ── DataGridView ──────────────────────────────────────────
            toolTip.SetToolTip(dataGridView,
                "Danh sách hoá đơn — click vào dòng để chọn.\n" +
                "Cột 'Chi tiết': xem danh sách sản phẩm trong hoá đơn.\n" +
                "Sau khi chọn có thể: In, Sửa hoặc Xoá.");
        }


        private void frmHoaDon_Load(object sender, EventArgs e)
        {

            SetupToolTips();
            dataGridView.AutoGenerateColumns = false;
            List<DanhSachHoaDon> hd = new List<DanhSachHoaDon>();
            hd = context.HoaDon.Select(r => new DanhSachHoaDon
            {
                ID = r.ID,
                NhanVienID = r.NhanVienID,
                HoVaTenNhanVien = r.NhanVien.HoVaTen,
                KhachHangID = r.KhachHangID,
                HoVaTenKhachHang = r.KhachHang.HoVaTen,
                NgayLap = r.NgayLap,
                GhiChuHoaDon = r.GhiChuHoaDon,
                TongTienHoaDon = r.HoaDon_ChiTiet.Sum(r => r.SoLuongBan * r.DonGiaBan),
                XemChiTiet = "Xem chi tiết",
            }).ToList();

            dataGridView.DataSource = hd;
        }

        private void btnLapHoaDon_Click(object sender, EventArgs e)
        {
            using (frmHoaDon_ChiTiet chiTiet = new frmHoaDon_ChiTiet())
            {
                chiTiet.ShowDialog();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
            using (frmHoaDon_ChiTiet chiTiet = new frmHoaDon_ChiTiet(id))
            {
                chiTiet.ShowDialog();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult trloi = MessageBox.Show("Xác nhận xoá hoá đơn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (trloi == DialogResult.Yes)
            {
                id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
                HoaDon hd = context.HoaDon.Find(id);
                if (hd != null)
                {
                    context.HoaDon.Remove(hd);
                }
                context.SaveChanges();
                frmHoaDon_Load(sender, e);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult trloi = MessageBox.Show("Xác nhận thoát khỏi Form Hoá Đơn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

            if (openFileDiaLog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (XLWorkbook workbook = new XLWorkbook(openFileDiaLog.FileName))
                    {
                        // ========================
                        // ĐỌC SHEET HoaDon
                        // ========================
                        IXLWorksheet sheetHoaDon = workbook.Worksheet("HoaDon");

                        bool firstRow = true;
                        DataTable tableHoaDon = new DataTable();
                        string readRange = "1:1";

                        foreach (IXLRow row in sheetHoaDon.RowsUsed())
                        {
                            if (firstRow)
                            {
                                readRange = string.Format("{0}:{1}", 1, row.LastCellUsed().Address.ColumnNumber);

                                foreach (IXLCell cell in row.Cells(readRange))
                                {
                                    tableHoaDon.Columns.Add(cell.Value.ToString());
                                }
                                firstRow = false;
                            }
                            else
                            {
                                tableHoaDon.Rows.Add();
                                int cellIndex = 0;

                                foreach (IXLCell cell in row.Cells(readRange))
                                {
                                    tableHoaDon.Rows[tableHoaDon.Rows.Count - 1][cellIndex] = cell.Value.ToString();
                                    cellIndex++;
                                }
                            }
                        }

                        foreach (DataRow r in tableHoaDon.Rows)
                        {
                            HoaDon hd = new HoaDon();
                            hd.ID = Convert.ToInt32(r["ID"]);
                            hd.NhanVienID = Convert.ToInt32(r["NhanVienID"]);
                            hd.KhachHangID = Convert.ToInt32(r["KhachHangID"]);
                            hd.NgayLap = DateTime.Parse(r["NgayLap"].ToString());
                            hd.GhiChuHoaDon = r["GhiChuHoaDon"].ToString();

                            context.HoaDon.Add(hd);
                        }

                        context.SaveChanges();

                        // ========================
                        // ĐỌC SHEET HoaDon_ChiTiet
                        // ========================
                        IXLWorksheet sheetChiTiet = workbook.Worksheet("HoaDon_ChiTiet");

                        bool firstRow2 = true;
                        DataTable tableChiTiet = new DataTable();
                        string readRange2 = "1:1";

                        foreach (IXLRow row in sheetChiTiet.RowsUsed())
                        {
                            if (firstRow2)
                            {
                                readRange2 = string.Format("{0}:{1}", 1, row.LastCellUsed().Address.ColumnNumber);

                                foreach (IXLCell cell in row.Cells(readRange2))
                                {
                                    tableChiTiet.Columns.Add(cell.Value.ToString());
                                }
                                firstRow2 = false;
                            }
                            else
                            {
                                tableChiTiet.Rows.Add();
                                int cellIndex = 0;

                                foreach (IXLCell cell in row.Cells(readRange2))
                                {
                                    tableChiTiet.Rows[tableChiTiet.Rows.Count - 1][cellIndex] = cell.Value.ToString();
                                    cellIndex++;
                                }
                            }
                        }

                        foreach (DataRow r in tableChiTiet.Rows)
                        {
                            HoaDon_ChiTiet ct = new HoaDon_ChiTiet();

                            ct.ID = Convert.ToInt32(r["ID"]);
                            ct.HoaDonID = Convert.ToInt32(r["HoaDonID"]);
                            ct.SanPhamID = Convert.ToInt32(r["SanPhamID"]);
                            ct.SoLuongBan = Convert.ToInt32(r["SoLuongBan"]);
                            ct.DonGiaBan = Convert.ToInt32(r["DonGiaBan"]);

                            context.HoaDon_ChiTiet.Add(ct);
                        }

                        context.SaveChanges();

                        MessageBox.Show("Nhập dữ liệu thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        frmHoaDon_Load(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void btnXuat_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Xuất dữ liệu ra Excel";
            saveFileDialog.Filter = "Excel|*.xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // ===== Sheet HoaDon =====
                    DataTable hoaDonTable = new DataTable();
                    hoaDonTable.Columns.Add("ID", typeof(int));
                    hoaDonTable.Columns.Add("NhanVienID", typeof(int));
                    //hoaDonTable.Columns.Add("NhanVien", typeof(string));

                    hoaDonTable.Columns.Add("KhachHangID", typeof(int));
                    //hoaDonTable.Columns.Add("KhachHang", typeof(string));

                    hoaDonTable.Columns.Add("NgayLap", typeof(DateTime));
                    hoaDonTable.Columns.Add("GhiChuHoaDon", typeof(string));

                    var hoaDon = context.HoaDon.ToList();
                    foreach (var hd in hoaDon)
                    {
                        hoaDonTable.Rows.Add(
                            hd.ID,
                            hd.NhanVienID,
                            //hd.NhanVien.HoVaTen,

                            hd.KhachHangID,
                            //hd.KhachHang.HoVaTen,

                            hd.NgayLap,
                            hd.GhiChuHoaDon
                        );
                    }

                    // ===== Sheet HoaDon_ChiTiet =====
                    DataTable chiTietTable = new DataTable();
                    chiTietTable.Columns.Add("ID", typeof(int));
                    chiTietTable.Columns.Add("HoaDonID", typeof(int));
                    chiTietTable.Columns.Add("SanPhamID", typeof(int));
                    chiTietTable.Columns.Add("SoLuongBan", typeof(int));
                    chiTietTable.Columns.Add("DonGiaBan", typeof(decimal));

                    var chiTiet = context.HoaDon_ChiTiet.ToList();
                    foreach (var ct in chiTiet)
                    {
                        chiTietTable.Rows.Add(
                            ct.ID,
                            ct.HoaDonID,
                            ct.SanPhamID,
                            ct.SoLuongBan,
                            ct.DonGiaBan
                        );
                    }

                    // ===== Tạo file Excel =====
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        wb.Worksheets.Add(hoaDonTable, "HoaDon");
                        wb.Worksheets.Add(chiTietTable, "HoaDon_ChiTiet");

                        wb.SaveAs(saveFileDialog.FileName);
                    }

                    MessageBox.Show("Xuất Excel thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
            using (frmInHoaDon inHoaDon = new frmInHoaDon(id))
            {
                inHoaDon.ShowDialog();
            }
        }

        private void frmHoaDon_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            string helpPath = Path.Combine(Application.StartupPath, "Help", "hoadon.htm");

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = helpPath,
                UseShellExecute = true  // Mở bằng trình duyệt mặc định
            });

            hlpevent.Handled = true;
        }
    }
}
