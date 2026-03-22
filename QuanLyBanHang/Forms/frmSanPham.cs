using ClosedXML.Excel;
using QuanLyBanHang.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyBanHang.Forms
{
    public partial class frmSanPham : Form
    {
        QLBHDbContext context = new QLBHDbContext(); // Khởi tạo biến ngữ cảnh CSDL
        bool xuLyThem = false; // Kiểm tra có nhấn vào nút Thêm hay không?
        int id;
        string imagesFolder = Path.Combine(Application.StartupPath, "Images");
        public frmSanPham()
        {
            InitializeComponent();
        }
        private void BatTatChucNang(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuyBo.Enabled = giaTri;
            cboHangSanXuat.Enabled = giaTri;
            cboLoaiSanPham.Enabled = giaTri;
            txtTenSanPham.Enabled = giaTri;
            numSoLuong.Enabled = giaTri;
            numDonGia.Enabled = giaTri;
            txtMoTa.Enabled = giaTri;
            picHinhAnh.Enabled = giaTri;
            btnThem.Enabled = !giaTri;
            btnDoiAnh.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
            btnTimKiem.Enabled = !giaTri;
            btnNhap.Enabled = !giaTri;
            btnXuat.Enabled = !giaTri;
        }

        private void SetupToolTips()
        {
            // Cấu hình ToolTip
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 400;
            toolTip.ReshowDelay = 200;
            toolTip.ShowAlways = true;
            toolTip.IsBalloon = false;

            // ── Ô nhập liệu ──────────────────────────────────────────
            toolTip.SetToolTip(cboLoaiSanPham,
                "Chọn phân loại (danh mục) của sản phẩm.\n" +
                "Ví dụ: Laptop, Điện thoại, Máy tính bảng...\n" +
                "⚠ Bắt buộc chọn.");

            toolTip.SetToolTip(cboHangSanXuat,
                "Chọn hãng sản xuất của sản phẩm.\n" +
                "Ví dụ: Apple, Samsung, Asus...\n" +
                "⚠ Bắt buộc chọn.");

            toolTip.SetToolTip(txtTenSanPham,
                "Nhập tên đầy đủ của sản phẩm.\n" +
                "Ví dụ: iPhone 15 Pro Max 256GB...\n" +
                "⚠ Bắt buộc nhập.");

            toolTip.SetToolTip(txtMoTa,
                "Nhập mô tả chi tiết về sản phẩm.\n" +
                "Thông số kỹ thuật, tính năng nổi bật...\n" +
                "(Không bắt buộc)");

            toolTip.SetToolTip(numSoLuong,
                "Nhập số lượng sản phẩm tồn kho.\n" +
                "Giá trị tối thiểu: 0.\n" +
                "⚠ Bắt buộc nhập.");

            toolTip.SetToolTip(numDonGia,
                "Nhập đơn giá bán của sản phẩm (VNĐ).\n" +
                "Giá trị tối thiểu: 0.\n" +
                "⚠ Bắt buộc nhập.");

            toolTip.SetToolTip(picHinhAnh,
                "Hình ảnh minh họa của sản phẩm.\n" +
                "Nhấn 'Đổi ảnh...' để chọn ảnh từ máy tính.\n" +
                "(Không bắt buộc)");

            // ── Nút ảnh ──────────────────────────────────────────────
            toolTip.SetToolTip(btnDoiAnh,
                "Chọn hình ảnh sản phẩm từ máy tính.\n" +
                "Định dạng hỗ trợ: JPG, PNG, BMP.");

            toolTip.SetToolTip(btnXoayAnh,
                "Xoay hình ảnh sản phẩm 90° theo chiều kim đồng hồ.");

            // ── Các nút chức năng ─────────────────────────────────────
            toolTip.SetToolTip(btnThem,
                "Xóa trắng các ô nhập liệu để thêm sản phẩm mới.");

            toolTip.SetToolTip(btnSua,
                "Kích hoạt chế độ chỉnh sửa thông tin sản phẩm đang chọn.");

            toolTip.SetToolTip(btnXoa,
                "Xóa sản phẩm đang được chọn.\n" +
                "⚠ Thao tác không thể hoàn tác!\n");

            toolTip.SetToolTip(btnLuu,
                "Lưu thông tin sản phẩm vào cơ sở dữ liệu.");

            toolTip.SetToolTip(btnHuyBo,
                "Hủy thao tác hiện tại, khôi phục dữ liệu cũ.\n" +
                "Phím tắt: Esc");

            toolTip.SetToolTip(btnThoat,
                "Đóng màn hình Sản phẩm.\n" +
                "Phím tắt: Alt+F4");

            toolTip.SetToolTip(btnTimKiem,
                "Tìm kiếm sản phẩm theo tên, phân loại hoặc hãng sản xuất.");

            toolTip.SetToolTip(btnNhap,
                "Nhập danh sách sản phẩm từ file Excel (.xlsx).\n" +
                "Cần có các cột: Phân loại, Hãng sản xuất, Tên sản phẩm,\n" +
                "Mô tả, Số lượng, Đơn giá.");

            toolTip.SetToolTip(btnXuat,
                "Xuất danh sách sản phẩm ra file Excel (.xlsx).");

            // ── DataGridView ──────────────────────────────────────────
            toolTip.SetToolTip(dataGridView,
                "Danh sách sản phẩm — click vào dòng để chọn và xem chi tiết.\n" +
                "Sau khi chọn có thể thực hiện: Sửa hoặc Xoá.");
        }
        public void LayLoaiSanPhamVaoComboBox()
        {
            cboLoaiSanPham.DataSource = context.LoaiSanPham.ToList();
            cboLoaiSanPham.ValueMember = "ID";
            cboLoaiSanPham.DisplayMember = "TenLoai";
        }
        public void LayHangSanXuatVaoComboBox()
        {
            cboHangSanXuat.DataSource = context.HangSanXuat.ToList();
            cboHangSanXuat.ValueMember = "ID";
            cboHangSanXuat.DisplayMember = "TenHangSanXuat";
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            SetupToolTips();

            BatTatChucNang(false);
            LayLoaiSanPhamVaoComboBox();
            LayHangSanXuatVaoComboBox();
            dataGridView.AutoGenerateColumns = false;
            List<DanhSachSanPham> sp = new List<DanhSachSanPham>();
            sp = context.SanPham.Select(r => new DanhSachSanPham
            {
                ID = r.ID,
                LoaiSanPhamID = r.LoaiSanPhamID,
                TenLoai = r.LoaiSanPham.TenLoai,
                HangSanXuatID = r.HangSanXuatID,
                TenHangSanXuat = r.HangSanXuat.TenHangSanXuat,
                TenSanPham = r.TenSanPham,
                SoLuong = r.SoLuong,
                DonGia = r.DonGia,
                HinhAnh = r.HinhAnh
            }).ToList();
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = sp;
            cboLoaiSanPham.DataBindings.Clear();
            cboLoaiSanPham.DataBindings.Add("SelectedValue", bindingSource, "LoaiSanPhamID", false, DataSourceUpdateMode.Never);

            cboHangSanXuat.DataBindings.Clear();
            cboHangSanXuat.DataBindings.Add("SelectedValue", bindingSource, "HangSanXuatID", false, DataSourceUpdateMode.Never);

            txtTenSanPham.DataBindings.Clear();
            txtTenSanPham.DataBindings.Add("Text", bindingSource, "TenSanPham", false, DataSourceUpdateMode.Never);

            txtMoTa.DataBindings.Clear();
            txtMoTa.DataBindings.Add("Text", bindingSource, "MoTa", false, DataSourceUpdateMode.Never);

            numSoLuong.DataBindings.Clear();
            numSoLuong.DataBindings.Add("Value", bindingSource, "SoLuong", false, DataSourceUpdateMode.Never);

            numDonGia.Maximum = 1000000000;
            numDonGia.DataBindings.Clear();
            numDonGia.DataBindings.Add("Value", bindingSource, "DonGia", false, DataSourceUpdateMode.Never);

            picHinhAnh.DataBindings.Clear();
            Binding hinhAnh = new Binding("ImageLocation", bindingSource, "HinhAnh");
            hinhAnh.Format += (s, e) =>
            {
                if (e.Value != null)
                {
                    string fullPath = Path.Combine(imagesFolder, e.Value.ToString());
                    e.Value = File.Exists(fullPath) ? fullPath : Path.Combine(imagesFolder, "default.png");
                }
                else
                {
                    e.Value = Path.Combine(imagesFolder, "default.png");
                    // or: e.Value = null; // to clear the image
                }
            };
            picHinhAnh.DataBindings.Add(hinhAnh);
            dataGridView.DataSource = bindingSource;

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            BatTatChucNang(true);
            cboLoaiSanPham.Text = "";
            cboHangSanXuat.Text = "";
            txtTenSanPham.Clear();
            txtMoTa.Clear();
            numSoLuong.Value = 0;
            numDonGia.Value = 0;
            if (picHinhAnh.Image != null)
            {
                picHinhAnh.Image.Dispose();
                picHinhAnh.Image = null;
            }
            selectedImagePath = null;
        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (dataGridView.Columns[e.ColumnIndex].Name == "HinhAnh")
            //{
            //    Image image = Image.FromFile(Path.Combine(imagesFolder, e.Value.ToString()));
            //    image = new Bitmap(image, 24, 24);
            //    e.Value = image;
            //}

            if (dataGridView.Columns[e.ColumnIndex].Name == "HinhAnh" && e.Value != null)
            {
                string fileName = e.Value.ToString();
                string fullPath = Path.Combine(imagesFolder, fileName);

                // Kiểm tra file có tồn tại không
                if (File.Exists(fullPath))
                {
                    try
                    {
                        Image image = Image.FromFile(fullPath);
                        image = new Bitmap(image, 24, 24); // Resize về 24x24
                        e.Value = image;
                    }
                    catch (Exception ex)
                    {
                        // Nếu có lỗi khi đọc file, để trống hoặc dùng ảnh mặc định
                        e.Value = null;
                    }
                }
                else
                {
                    // File không tồn tại - để trống
                    e.Value = null;
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cboLoaiSanPham.Text))
                MessageBox.Show("Vui lòng chọn loại sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (string.IsNullOrWhiteSpace(cboHangSanXuat.Text))
                MessageBox.Show("Vui lòng chọn hãng sản xuất.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (string.IsNullOrWhiteSpace(txtTenSanPham.Text))
                MessageBox.Show("Vui lòng nhập tên sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (numSoLuong.Value <= 0)
                MessageBox.Show("Số lượng phải lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (numDonGia.Value <= 0)
                MessageBox.Show("Đơn giá sản phẩm phải lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (xuLyThem)
                {
                    SanPham sp = new SanPham();
                    sp.LoaiSanPhamID = Convert.ToInt32(cboLoaiSanPham.SelectedValue);
                    sp.HangSanXuatID = Convert.ToInt32(cboHangSanXuat.SelectedValue);
                    sp.TenSanPham = txtTenSanPham.Text.Trim();
                    sp.DonGia = Convert.ToInt32(numDonGia.Value);
                    sp.SoLuong = Convert.ToInt32(numSoLuong.Value);
                    sp.MoTa = txtMoTa.Text.Trim();
                    sp.HinhAnh = SaveImageToFolder();
                    context.SanPham.Add(sp);


                    context.SaveChanges();
                }
                else
                {
                    SanPham sp = context.SanPham.Find(id);
                    if (sp != null)
                    {
                        sp.LoaiSanPhamID = Convert.ToInt32(cboLoaiSanPham.SelectedValue);
                        sp.HangSanXuatID = Convert.ToInt32(cboHangSanXuat.SelectedValue);
                        sp.TenSanPham = txtTenSanPham.Text.Trim();
                        sp.DonGia = Convert.ToInt32(numDonGia.Value);
                        sp.SoLuong = Convert.ToInt32(numSoLuong.Value);
                        sp.MoTa = txtMoTa.Text.Trim();
                        string newImage = SaveImageToFolder();
                        if (!string.IsNullOrEmpty(newImage))
                        {
                            // Xóa ảnh cũ nếu có
                            if (!string.IsNullOrEmpty(sp.HinhAnh) && sp.HinhAnh != "default.png")
                            {
                                string oldImagePath = Path.Combine(imagesFolder, sp.HinhAnh);
                                if (File.Exists(oldImagePath))
                                {
                                    try
                                    {
                                        File.Delete(oldImagePath);
                                    }
                                    catch { }
                                }
                            }
                            sp.HinhAnh = newImage;
                        }
                        context.SanPham.Update(sp);
                        context.SaveChanges();
                    }
                }
                frmSanPham_Load(sender, e);
            }
        }
        // Biến toàn cục
        private string selectedImagePath = null;

        // Sự kiện khi click vào PictureBox để chọn hình
        private void picHinhAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                ofd.Title = "Chọn hình ảnh sản phẩm";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = ofd.FileName;
                    picHinhAnh.Image = Image.FromFile(selectedImagePath);
                    picHinhAnh.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }

        // Hàm lưu hình vào thư mục Images và trả về tên file
        private string SaveImageToFolder()
        {
            // Nếu không chọn hình, trả về null
            if (string.IsNullOrEmpty(selectedImagePath))
                return null;

            try
            {
                string imagesFolder = Path.Combine(Application.StartupPath, "Images");

                // Tạo thư mục Images nếu chưa có
                if (!Directory.Exists(imagesFolder))
                    Directory.CreateDirectory(imagesFolder);

                // Tạo tên file mới (tránh trùng tên)
                string extension = Path.GetExtension(selectedImagePath);
                string productName = txtTenSanPham.Text.Trim()
                    .Replace(" ", "-")
                    .ToLower();
                string fileName = $"{productName}-{DateTime.Now:yyyyMMddHHmmss}{extension}";

                string destinationPath = Path.Combine(imagesFolder, fileName);

                // Copy file vào thư mục Images
                File.Copy(selectedImagePath, destinationPath, true);

                return fileName;  // Chỉ lưu tên file vào database
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu hình ảnh: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void btnDoiAnh_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần đổi ảnh.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int idSanPham = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value);
            SanPham sp = context.SanPham.Find(idSanPham);
            if (sp == null)
            {
                MessageBox.Show("Không tìm thấy sản phẩm", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                openFileDialog.Title = "Chọn ảnh mới cho sản phẩm";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string oldImageName = sp.HinhAnh;

                        string newImagePath = openFileDialog.FileName;
                        string extension = Path.GetExtension(newImagePath);
                        string productName = sp.TenSanPham.Trim().Replace(" ", "-").ToLower();
                        string newFileName = $"{productName}-{extension}";

                        string destinationPath = Path.Combine(imagesFolder, newFileName);

                        File.Copy(newImagePath, destinationPath, true);

                        sp.HinhAnh = newFileName;
                        context.SaveChanges();
                        if (!string.IsNullOrEmpty(oldImageName) && oldImageName != "default.jpg")
                        {
                            string oldImagePath = Path.Combine(imagesFolder, oldImageName);
                            if (File.Exists(oldImagePath))
                            {
                                try
                                {
                                    File.Delete(oldImagePath);
                                }
                                catch { }
                            }
                        }
                        MessageBox.Show("Đổi ảnh thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Reload lại form để hiển thị ảnh mới
                        frmSanPham_Load(sender, e);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi đổi ảnh: {ex.Message}", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            xuLyThem = false;
            BatTatChucNang(true);
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());

        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            frmSanPham_Load(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult trloi = MessageBox.Show("Xác nhận thoát khỏi Form Sản Phẩm?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (trloi == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnXoayAnh_Click(object sender, EventArgs e)
        {
            if (picHinhAnh.Image == null)
            {
                MessageBox.Show("Chưa có ảnh để xoay?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            picHinhAnh.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            picHinhAnh.Refresh();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận xóa sản phẩm " + txtTenSanPham.Text + "?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
                SanPham sp = context.SanPham.Find(id);
                if (sp != null)
                {
                    context.SanPham.Remove(sp);
                }
                context.SaveChanges();
                frmSanPham_Load(sender, e);
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
                                var sp = new SanPham();
                                sp.TenSanPham = r["TenHangSanXuat"].ToString();
                                sp.LoaiSanPhamID = Convert.ToInt32(r["LoaiSanPhamID"]);
                                sp.HangSanXuatID = Convert.ToInt32(r["HangSanXuatID"]);
                                sp.TenSanPham = r["TenSanPham"].ToString();
                                sp.DonGia = Convert.ToInt32(r["DonGia"]);
                                sp.SoLuong = Convert.ToInt32(r["SoLuong"]);
                                sp.HinhAnh = r["HinhAnh"].ToString();
                                sp.MoTa = r["MoTa"].ToString();


                                context.SanPham.Add(sp);
                            }
                            context.SaveChanges();

                            MessageBox.Show("Đã nhập thành công " + table.Rows.Count + " dòng", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmSanPham_Load(sender, e);
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

                    table.Columns.AddRange(new DataColumn[8]{
                        new DataColumn("ID", typeof(int)),
                        new DataColumn("LoaiSanPhamID", typeof(int)),
                        new DataColumn("HangSanXuatID", typeof(int)),
                        new DataColumn("TenSanPham", typeof(string)),
                        new DataColumn("DonGia", typeof(int)),
                        new DataColumn("SoLuong", typeof(int)),
                        new DataColumn("HinhAnh", typeof(string)),
                        new DataColumn("MoTa", typeof(string)),


                    });
                    var sanPham = context.SanPham.ToList();
                    if (sanPham != null)
                    {
                        foreach (var p in sanPham)
                        {
                            table.Rows.Add(p.ID, p.LoaiSanPhamID, p.HangSanXuatID, p.TenSanPham, p.DonGia, p.SoLuong, p.HinhAnh, p.MoTa);
                        }
                    }

                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var sheet = wb.Worksheets.Add(table, "SanPham");
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

     
        private void frmSanPham_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            string helpPath = Path.Combine(Application.StartupPath, "Help", "sanpham.htm");

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = helpPath,
                UseShellExecute = true  // Mở bằng trình duyệt mặc định
            });

            hlpevent.Handled = true;
        }
    }
}
