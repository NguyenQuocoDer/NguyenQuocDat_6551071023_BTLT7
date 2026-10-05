using EF_Cau3.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_Cau3;

public partial class Form1 : Form
{
    private bool _isLoading = false;

    // Tên file ảnh hiện tại (CHỈ TÊN, không full path) - đây là thứ lưu vào cột HinhAnh
    private string? _currentFileName = null;

    // Thư mục Images nằm cạnh file .exe của ứng dụng
    private readonly string _imagesDir = Path.Combine(Application.StartupPath, "Images");

    public Form1()
    {
        InitializeComponent();
        Directory.CreateDirectory(_imagesDir);
        SetupGrid();

        cboTinhTrang.SelectedIndex = 0;
        cboLocTinhTrang.SelectedIndex = 0;

        // ===== Gắn sự kiện =====
        Load += Form1_Load;
        dgvPhong.SelectionChanged += dgvPhong_SelectionChanged;
        btnThem.Click += btnThem_Click;
        btnSua.Click += btnSua_Click;
        btnXoa.Click += btnXoa_Click;
        btnLamMoi.Click += btnLamMoi_Click;
        btnChonAnh.Click += btnChonAnh_Click;
        btnQuanLyLoai.Click += btnQuanLyLoai_Click;
        cboLocTinhTrang.SelectedIndexChanged += FilterChanged;
        cboLocLoai.SelectedIndexChanged += FilterChanged;
    }

    // ================== CẤU HÌNH LƯỚI ==================
    private void SetupGrid()
    {
        dgvPhong.ReadOnly = true;
        dgvPhong.AllowUserToAddRows = false;
        dgvPhong.AllowUserToDeleteRows = false;
        dgvPhong.AllowUserToResizeRows = false;
        dgvPhong.MultiSelect = false;
        dgvPhong.RowHeadersVisible = false;
        dgvPhong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvPhong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvPhong.RowTemplate.Height = 60;

        dgvPhong.AutoGenerateColumns = false;
        dgvPhong.Columns.Clear();

        // Cột ảnh
        var imgCol = new DataGridViewImageColumn
        {
            Name = "HinhAnh",
            DataPropertyName = "HinhAnh",
            HeaderText = "Ảnh",
            ImageLayout = DataGridViewImageCellLayout.Zoom,
            AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
            Width = 90
        };
        imgCol.DefaultCellStyle.NullValue = null;   // không có ảnh thì để trống, không hiện dấu X đỏ
        dgvPhong.Columns.Add(imgCol);

        AddCol("MaPhong", "Mã phòng");
        AddCol("SoPhong", "Số phòng");
        AddCol("TangSo", "Tầng");
        AddCol("TenLoai", "Loại phòng");
        AddCol("GiaMoiDem", "Giá mỗi đêm", "N0");
        AddCol("TinhTrang", "Tình trạng");
    }

    private void AddCol(string prop, string header, string? format = null)
    {
        var col = new DataGridViewTextBoxColumn
        {
            Name = prop,
            DataPropertyName = prop,
            HeaderText = header
        };
        if (format != null) col.DefaultCellStyle.Format = format;
        dgvPhong.Columns.Add(col);
    }

    // ================== HÀM XỬ LÝ ẢNH ==================
    // maxW/maxH = 0 -> lấy ảnh gốc; > 0 -> thu nhỏ (thumbnail) giữ đúng tỉ lệ
    // Đọc qua FileStream rồi copy ra Bitmap để KHÔNG khóa file ảnh
    private Image? LoadImage(string? fileName, int maxW, int maxH)
    {
        if (string.IsNullOrWhiteSpace(fileName)) return null;

        string path = Path.Combine(_imagesDir, fileName);
        if (!File.Exists(path)) return null;

        try
        {
            using var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            using var original = Image.FromStream(fs);

            if (maxW <= 0 || maxH <= 0) return new Bitmap(original);

            double ratio = Math.Min((double)maxW / original.Width, (double)maxH / original.Height);
            if (ratio > 1) ratio = 1;
            int w = Math.Max(1, (int)(original.Width * ratio));
            int h = Math.Max(1, (int)(original.Height * ratio));
            return new Bitmap(original, w, h);
        }
        catch
        {
            return null;
        }
    }

    private void SetPicture(Image? img)
    {
        var old = picAnh.Image;
        picAnh.Image = img;
        old?.Dispose();
    }

    // ================== NẠP COMBOBOX LOẠI PHÒNG ==================
    private void LoadLoaiPhongCombos()
    {
        bool old = _isLoading;
        _isLoading = true;
        try
        {
            using var db = new SunriseHomestayContext();
            var ds = db.Set<LoaiPhong>().AsNoTracking().OrderBy(x => x.TenLoai).ToList();

            int? keepInput = cboLoaiPhong.SelectedValue is int k ? k : null;
            int keepFilter = cboLocLoai.SelectedValue is int f ? f : 0;

            // ComboBox nhập liệu
            cboLoaiPhong.DisplayMember = "TenLoai";
            cboLoaiPhong.ValueMember = "MaLoai";
            cboLoaiPhong.DataSource = ds;

            // ComboBox lọc (có thêm mục "Tất cả")
            var loc = new List<LoaiItem> { new LoaiItem { MaLoai = 0, TenLoai = "Tất cả" } };
            loc.AddRange(ds.Select(x => new LoaiItem { MaLoai = x.MaLoai, TenLoai = x.TenLoai }));
            cboLocLoai.DisplayMember = "TenLoai";
            cboLocLoai.ValueMember = "MaLoai";
            cboLocLoai.DataSource = loc;

            if (keepInput.HasValue) cboLoaiPhong.SelectedValue = keepInput.Value;
            cboLocLoai.SelectedValue = keepFilter;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi khi tải loại phòng: " + ex.Message, "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            _isLoading = old;
        }
    }

    // ================== LOAD FORM ==================
    private void Form1_Load(object? sender, EventArgs e)
    {
        LoadLoaiPhongCombos();
        LoadData();
    }

    private void FilterChanged(object? sender, EventArgs e)
    {
        if (_isLoading) return;
        LoadData();
    }

    // ================== NẠP DỮ LIỆU + TÌM KIẾM (Include + Where) ==================
    private void LoadData()
    {
        try
        {
            _isLoading = true;

            int maLoaiLoc = cboLocLoai.SelectedValue is int v ? v : 0;
            string tinhTrang = cboLocTinhTrang.SelectedIndex <= 0 ? "" : cboLocTinhTrang.Text;

            using var db = new SunriseHomestayContext();

            var data = db.Set<Phong>()
                .AsNoTracking()
                .Include(x => x.MaLoaiNavigation)                       // Eager Loading: lấy kèm loại phòng
                .Where(x => (tinhTrang == "" || x.TinhTrang == tinhTrang)
                         && (maLoaiLoc == 0 || x.MaLoai == maLoaiLoc))
                .OrderBy(x => x.MaPhong)
                .ToList();

            var rows = data.Select(x => new PhongRow
            {
                MaPhong = x.MaPhong,
                SoPhong = x.SoPhong,
                TangSo = x.TangSo,
                MaLoai = x.MaLoai,
                TenLoai = x.MaLoaiNavigation?.TenLoai ?? "",
                GiaMoiDem = x.MaLoaiNavigation?.GiaMoiDem ?? 0,
                TinhTrang = x.TinhTrang,
                TenHinh = x.HinhAnh,
                HinhAnh = LoadImage(x.HinhAnh, 80, 54)      // ảnh thumbnail cho cột ảnh
            }).ToList();

            dgvPhong.DataSource = rows;
            dgvPhong.ClearSelection();
            ClearInputs();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            _isLoading = false;
        }
    }

    private void ClearInputs()
    {
        txtMaPhong.Clear();
        txtSoPhong.Clear();
        nudTang.Value = 1;
        cboLoaiPhong.SelectedIndex = cboLoaiPhong.Items.Count > 0 ? 0 : -1;
        cboTinhTrang.SelectedIndex = 0;
        _currentFileName = null;
        SetPicture(null);
    }

    // ================== CHỌN DÒNG -> ĐỔ LÊN CONTROL + ẢNH ==================
    private void dgvPhong_SelectionChanged(object? sender, EventArgs e)
    {
        if (_isLoading) return;
        if (dgvPhong.SelectedRows.Count == 0) return;
        if (dgvPhong.SelectedRows[0].DataBoundItem is not PhongRow r) return;

        txtMaPhong.Text = r.MaPhong.ToString();
        txtSoPhong.Text = r.SoPhong;
        nudTang.Value = Math.Clamp(r.TangSo, (int)nudTang.Minimum, (int)nudTang.Maximum);
        cboLoaiPhong.SelectedValue = r.MaLoai;
        cboTinhTrang.SelectedIndex = cboTinhTrang.FindStringExact(r.TinhTrang);

        _currentFileName = r.TenHinh;
        SetPicture(LoadImage(r.TenHinh, 0, 0));             // ảnh gốc lên PictureBox
    }

    // ================== CHỌN ẢNH (copy vào Images, chỉ lưu tên file) ==================
    private void btnChonAnh_Click(object? sender, EventArgs e)
    {
        using var ofd = new OpenFileDialog
        {
            Title = "Chọn ảnh phòng",
            Filter = "Ảnh (*.jpg;*.jpeg;*.png;*.bmp;*.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
        };
        if (ofd.ShowDialog() != DialogResult.OK) return;

        try
        {
            // Tên file mới = thời gian + đuôi gốc -> không bao giờ trùng tên
            string newName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Path.GetExtension(ofd.FileName);
            File.Copy(ofd.FileName, Path.Combine(_imagesDir, newName), true);

            _currentFileName = newName;                     // chỉ giữ TÊN FILE
            SetPicture(LoadImage(newName, 0, 0));
        }
        catch (Exception ex)
        {
            MessageBox.Show("Không thể chọn ảnh: " + ex.Message, "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // ================== MỞ FORM PHỤ ==================
    private void btnQuanLyLoai_Click(object? sender, EventArgs e)
    {
        using var f = new frmLoaiPhong();
        f.ShowDialog(this);

        // Quay lại: nạp lại ComboBox + lưới để thấy loại phòng mới
        LoadLoaiPhongCombos();
        LoadData();
    }

    // ================== VALIDATE ==================
    private bool Invalid(string msg, Control c)
    {
        MessageBox.Show(msg, "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        c.Focus();
        return false;
    }

    private async Task<bool> ValidateAsync(int? excludeId)
    {
        string so = txtSoPhong.Text.Trim();

        if (so == "")
            return Invalid("Số phòng không được để trống!", txtSoPhong);
        if (so.Length > 10)
            return Invalid("Số phòng tối đa 10 ký tự!", txtSoPhong);
        if (cboLoaiPhong.SelectedValue == null)
            return Invalid("Vui lòng chọn loại phòng (hoặc bấm \"Quản lý loại phòng\" để thêm)!", cboLoaiPhong);
        if (cboTinhTrang.SelectedIndex < 0)
            return Invalid("Vui lòng chọn tình trạng phòng!", cboTinhTrang);

        using var db = new SunriseHomestayContext();
        bool trung = await db.Set<Phong>()
            .AnyAsync(x => x.SoPhong == so && (excludeId == null || x.MaPhong != excludeId));
        if (trung)
            return Invalid($"Số phòng \"{so}\" đã tồn tại!", txtSoPhong);

        return true;
    }

    private void FillEntity(Phong p)
    {
        p.SoPhong = txtSoPhong.Text.Trim();
        p.TangSo = (int)nudTang.Value;
        p.MaLoai = (int)cboLoaiPhong.SelectedValue!;
        p.TinhTrang = cboTinhTrang.Text;
        p.HinhAnh = _currentFileName;                       // chỉ tên file
    }

    // ================== THÊM ==================
    private async void btnThem_Click(object? sender, EventArgs e)
    {
        if (!await ValidateAsync(null)) return;

        try
        {
            using var db = new SunriseHomestayContext();
            var p = new Phong();
            FillEntity(p);

            db.Add(p);
            await db.SaveChangesAsync();

            MessageBox.Show("Thêm phòng thành công!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadData();
        }
        catch (DbUpdateException ex)
        {
            MessageBox.Show("Không thể thêm: " + (ex.InnerException?.Message ?? ex.Message),
                "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // ================== SỬA ==================
    private async void btnSua_Click(object? sender, EventArgs e)
    {
        if (!int.TryParse(txtMaPhong.Text, out int id))
        {
            MessageBox.Show("Vui lòng chọn một phòng trong danh sách để sửa!", "Chưa chọn dòng",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        if (!await ValidateAsync(id)) return;

        try
        {
            using var db = new SunriseHomestayContext();
            var p = await db.Set<Phong>().FindAsync(id);
            if (p == null)
            {
                MessageBox.Show("Phòng này không còn tồn tại.", "Không tìm thấy",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadData();
                return;
            }

            FillEntity(p);
            await db.SaveChangesAsync();

            MessageBox.Show("Cập nhật phòng thành công!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadData();
        }
        catch (DbUpdateException ex)
        {
            MessageBox.Show("Không thể cập nhật: " + (ex.InnerException?.Message ?? ex.Message),
                "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // ================== XÓA ==================
    private async void btnXoa_Click(object? sender, EventArgs e)
    {
        if (!int.TryParse(txtMaPhong.Text, out int id))
        {
            MessageBox.Show("Vui lòng chọn một phòng trong danh sách để xóa!", "Chưa chọn dòng",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var confirm = MessageBox.Show(
            $"Bạn có chắc muốn xóa phòng \"{txtSoPhong.Text}\"?",
            "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (confirm != DialogResult.Yes) return;

        try
        {
            using var db = new SunriseHomestayContext();
            var p = await db.Set<Phong>().FindAsync(id);
            if (p == null)
            {
                MessageBox.Show("Phòng này không còn tồn tại.", "Không tìm thấy",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadData();
                return;
            }

            db.Remove(p);
            await db.SaveChangesAsync();

            MessageBox.Show("Xóa phòng thành công!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadData();
        }
        catch (DbUpdateException ex)
        {
            MessageBox.Show("Không thể xóa: " + (ex.InnerException?.Message ?? ex.Message),
                "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // ================== LÀM MỚI ==================
    private void btnLamMoi_Click(object? sender, EventArgs e)
    {
        _isLoading = true;                  // tránh load nhiều lần khi đổi 2 ComboBox lọc
        cboLocTinhTrang.SelectedIndex = 0;
        cboLocLoai.SelectedIndex = 0;
        _isLoading = false;

        LoadData();
        txtSoPhong.Focus();
    }
}

// ================== LỚP PHỤ (đặt cuối file Form1.cs) ==================

// 1 dòng hiển thị trên lưới Phòng
public class PhongRow
{
    public int MaPhong { get; set; }
    public string SoPhong { get; set; } = "";
    public int TangSo { get; set; }
    public int MaLoai { get; set; }
    public string TenLoai { get; set; } = "";
    public decimal GiaMoiDem { get; set; }
    public string TinhTrang { get; set; } = "";
    public string? TenHinh { get; set; }        // tên file ảnh trong DB
    public Image? HinhAnh { get; set; }         // ảnh thumbnail để vẽ lên lưới
}

// 1 mục của ComboBox lọc loại phòng (có mục "Tất cả" với MaLoai = 0)
public class LoaiItem
{
    public int MaLoai { get; set; }
    public string TenLoai { get; set; } = "";
}