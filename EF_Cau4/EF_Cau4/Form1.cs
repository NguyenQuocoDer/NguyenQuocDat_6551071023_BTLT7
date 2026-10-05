using EF_Cau4.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_Cau4;

public partial class Form1 : Form
{
    private bool _isLoading = false;

    // true = đang áp dụng bộ lọc (khoảng ngày + bác sĩ); false = hiện toàn bộ
    private bool _filterActive = false;

    // Ngày khám ban đầu của dòng đang chọn (để biết người dùng có đổi ngày khi Sửa không)
    private DateTime? _selectedNgay = null;

    public Form1()
    {
        InitializeComponent();
        SetupGrid();

        cboTrangThai.SelectedIndex = 0;
        dtpTuNgay.Value = DateTime.Today.AddDays(-30);
        dtpDenNgay.Value = DateTime.Today.AddDays(30);

        // ===== Gắn sự kiện =====
        Load += Form1_Load;
        dgvLichKham.SelectionChanged += dgvLichKham_SelectionChanged;
        btnThem.Click += btnThem_Click;
        btnSua.Click += btnSua_Click;
        btnXoa.Click += btnXoa_Click;
        btnLamMoi.Click += btnLamMoi_Click;
        btnTimKiem.Click += btnTimKiem_Click;
        btnQuanLyBacSi.Click += btnQuanLyBacSi_Click;
    }

    // ================== CẤU HÌNH LƯỚI ==================
    private void SetupGrid()
    {
        dgvLichKham.ReadOnly = true;
        dgvLichKham.AllowUserToAddRows = false;
        dgvLichKham.AllowUserToDeleteRows = false;
        dgvLichKham.MultiSelect = false;
        dgvLichKham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvLichKham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        dgvLichKham.AutoGenerateColumns = false;
        dgvLichKham.Columns.Clear();
        AddCol("MaLich", "Mã lịch");
        AddCol("TenBenhNhan", "Tên bệnh nhân");
        AddCol("Sdt", "SĐT");
        AddCol("NgayKham", "Ngày khám", "dd/MM/yyyy");
        AddCol("GioKham", "Giờ khám");
        AddCol("TenBS", "Bác sĩ");
        AddCol("ChuyenKhoa", "Chuyên khoa");
        AddCol("TrangThai", "Trạng thái");
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
        dgvLichKham.Columns.Add(col);
    }

    // ================== NẠP COMBOBOX BÁC SĨ ==================
    private void LoadBacSiCombos()
    {
        bool old = _isLoading;
        _isLoading = true;
        try
        {
            using var db = new AnKhangClinicContext();
            var bacSis = db.Set<BacSi>().AsNoTracking().OrderBy(x => x.HoTen).ToList();

            // Dạng hiển thị: "BS. Nguyễn Văn A - Nội tổng quát"
            string Hien(BacSi b) => "BS. " + b.HoTen
                + (string.IsNullOrWhiteSpace(b.ChuyenKhoa) ? "" : " - " + b.ChuyenKhoa);

            int? keepInput = cboBacSi.SelectedValue is int k ? k : null;
            int keepFilter = cboLocBacSi.SelectedValue is int f ? f : 0;

            // ComboBox nhập liệu (2 danh sách riêng biệt để 2 ComboBox không chạy theo nhau)
            cboBacSi.DisplayMember = "HienThi";
            cboBacSi.ValueMember = "MaBS";
            cboBacSi.DataSource = bacSis
                .Select(b => new BacSiItem { MaBS = b.MaBs, HienThi = Hien(b) })
                .ToList();
            cboBacSi.SelectedIndex = -1;                 // mặc định chưa chọn bác sĩ
            if (keepInput.HasValue) cboBacSi.SelectedValue = keepInput.Value;

            // ComboBox lọc (có thêm mục "Tất cả")
            var loc = new List<BacSiItem> { new BacSiItem { MaBS = 0, HienThi = "Tất cả" } };
            loc.AddRange(bacSis.Select(b => new BacSiItem { MaBS = b.MaBs, HienThi = Hien(b) }));
            cboLocBacSi.DisplayMember = "HienThi";
            cboLocBacSi.ValueMember = "MaBS";
            cboLocBacSi.DataSource = loc;
            cboLocBacSi.SelectedValue = keepFilter;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi khi tải danh sách bác sĩ: " + ex.Message, "Lỗi",
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
        LoadBacSiCombos();
        LoadData();
    }

    // ================== NẠP DỮ LIỆU: Include + Where ==================
    private void LoadData()
    {
        try
        {
            _isLoading = true;

            using var db = new AnKhangClinicContext();

            // Include = lấy kèm bảng BacSi trong cùng 1 câu truy vấn (JOIN)
            IQueryable<LichKham> query = db.Set<LichKham>()
                .AsNoTracking()
                .Include(x => x.MaBsNavigation);

            if (_filterActive)
            {
                DateOnly tu = DateOnly.FromDateTime(dtpTuNgay.Value);
                DateOnly den = DateOnly.FromDateTime(dtpDenNgay.Value);
                int maBs = cboLocBacSi.SelectedValue is int v ? v : 0;

                // Điều kiện so sánh ngày (>=, <=) kết hợp điều kiện bằng (==)
                query = query.Where(x => x.NgayKham >= tu && x.NgayKham <= den);
                if (maBs != 0)
                    query = query.Where(x => x.MaBs == maBs);
            }

            var data = query
                .OrderBy(x => x.NgayKham)
                .ThenBy(x => x.GioKham)
                .ToList();

            dgvLichKham.DataSource = data.Select(x => new LichRow
            {
                MaLich = x.MaLich,
                TenBenhNhan = x.TenBenhNhan,
                Sdt = x.Sdt ?? "",
                NgayKham = x.NgayKham.ToDateTime(TimeOnly.MinValue),
                GioRaw = x.GioKham,
                GioKham = x.GioKham.ToString("HH:mm"),
                MaBs = x.MaBs,
                TenBS = x.MaBsNavigation?.HoTen ?? "",
                ChuyenKhoa = x.MaBsNavigation?.ChuyenKhoa ?? "",
                TrangThai = x.TrangThai
            }).ToList();

            dgvLichKham.ClearSelection();
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
        txtMaLich.Clear();
        txtTenBenhNhan.Clear();
        txtSDT.Clear();
        dtpNgayKham.Value = DateTime.Today;
        dtpGioKham.Value = DateTime.Today.AddHours(8);
        cboBacSi.SelectedIndex = -1;
        cboTrangThai.SelectedIndex = 0;
        _selectedNgay = null;
    }

    // ================== CHỌN DÒNG -> ĐỔ LÊN CONTROL ==================
    private void dgvLichKham_SelectionChanged(object? sender, EventArgs e)
    {
        if (_isLoading) return;
        if (dgvLichKham.SelectedRows.Count == 0) return;
        if (dgvLichKham.SelectedRows[0].DataBoundItem is not LichRow r) return;

        txtMaLich.Text = r.MaLich.ToString();
        txtTenBenhNhan.Text = r.TenBenhNhan;
        txtSDT.Text = r.Sdt;
        dtpNgayKham.Value = r.NgayKham;
        dtpGioKham.Value = DateTime.Today.Add(r.GioRaw.ToTimeSpan());
        cboBacSi.SelectedValue = r.MaBs;
        cboTrangThai.SelectedIndex = cboTrangThai.FindStringExact(r.TrangThai);
        _selectedNgay = r.NgayKham;
    }

    // ================== VALIDATE (mỗi lỗi một thông báo riêng) ==================
    private bool Invalid(string msg, Control c)
    {
        MessageBox.Show(msg, "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        c.Focus();
        return false;
    }

    // checkPast = true: không cho chọn ngày trong quá khứ
    private bool ValidateInput(bool checkPast)
    {
        if (txtTenBenhNhan.Text.Trim() == "")
            return Invalid("Tên bệnh nhân không được để trống!", txtTenBenhNhan);
        if (txtTenBenhNhan.Text.Trim().Length > 100)
            return Invalid("Tên bệnh nhân tối đa 100 ký tự!", txtTenBenhNhan);
        if (txtSDT.Text.Trim().Length > 15)
            return Invalid("Số điện thoại tối đa 15 ký tự!", txtSDT);
        if (cboBacSi.SelectedValue == null)
            return Invalid("Vui lòng chọn bác sĩ!", cboBacSi);
        if (cboTrangThai.SelectedIndex < 0)
            return Invalid("Vui lòng chọn trạng thái!", cboTrangThai);
        if (checkPast && dtpNgayKham.Value.Date < DateTime.Today)
            return Invalid("Không thể đặt lịch khám vào ngày trong quá khứ!", dtpNgayKham);

        return true;
    }

    private void FillEntity(LichKham l)
    {
        l.TenBenhNhan = txtTenBenhNhan.Text.Trim();
        l.Sdt = string.IsNullOrWhiteSpace(txtSDT.Text) ? null : txtSDT.Text.Trim();
        l.NgayKham = DateOnly.FromDateTime(dtpNgayKham.Value);

        var g = dtpGioKham.Value;
        l.GioKham = new TimeOnly(g.Hour, g.Minute, g.Second);

        l.MaBs = (int)cboBacSi.SelectedValue!;
        l.TrangThai = cboTrangThai.Text;
    }

    // ================== THÊM ==================
    private async void btnThem_Click(object? sender, EventArgs e)
    {
        if (!ValidateInput(true)) return;

        try
        {
            using var db = new AnKhangClinicContext();
            var l = new LichKham();
            FillEntity(l);

            db.Add(l);
            await db.SaveChangesAsync();

            MessageBox.Show("Thêm lịch khám thành công!", "Thông báo",
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
        if (!int.TryParse(txtMaLich.Text, out int id))
        {
            MessageBox.Show("Vui lòng chọn một lịch khám trong danh sách để sửa!", "Chưa chọn dòng",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Chỉ kiểm tra "ngày quá khứ" khi người dùng ĐỔI ngày khám
        // (để vẫn sửa được trạng thái của lịch cũ, ví dụ chuyển sang "Đã khám")
        bool doiNgay = _selectedNgay == null || dtpNgayKham.Value.Date != _selectedNgay.Value.Date;
        if (!ValidateInput(doiNgay)) return;

        try
        {
            using var db = new AnKhangClinicContext();
            var l = await db.Set<LichKham>().FindAsync(id);
            if (l == null)
            {
                MessageBox.Show("Lịch khám này không còn tồn tại.", "Không tìm thấy",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadData();
                return;
            }

            FillEntity(l);
            await db.SaveChangesAsync();

            MessageBox.Show("Cập nhật lịch khám thành công!", "Thông báo",
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
        if (!int.TryParse(txtMaLich.Text, out int id))
        {
            MessageBox.Show("Vui lòng chọn một lịch khám trong danh sách để xóa!", "Chưa chọn dòng",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Bắt buộc hỏi xác nhận TRƯỚC khi gọi SaveChangesAsync
        var confirm = MessageBox.Show(
            $"Bạn có chắc muốn xóa lịch khám của bệnh nhân \"{txtTenBenhNhan.Text}\"?",
            "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (confirm != DialogResult.Yes) return;

        try
        {
            using var db = new AnKhangClinicContext();
            var l = await db.Set<LichKham>().FindAsync(id);
            if (l == null)
            {
                MessageBox.Show("Lịch khám này không còn tồn tại.", "Không tìm thấy",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadData();
                return;
            }

            db.Remove(l);
            await db.SaveChangesAsync();

            MessageBox.Show("Xóa lịch khám thành công!", "Thông báo",
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

    // ================== TÌM KIẾM (khoảng ngày + bác sĩ) ==================
    private void btnTimKiem_Click(object? sender, EventArgs e)
    {
        if (dtpTuNgay.Value.Date > dtpDenNgay.Value.Date)
        {
            MessageBox.Show("\"Từ ngày\" không được lớn hơn \"Đến ngày\"!", "Khoảng ngày không hợp lệ",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dtpTuNgay.Focus();
            return;
        }

        _filterActive = true;
        LoadData();

        if (dgvLichKham.Rows.Count == 0)
        {
            MessageBox.Show("Không tìm thấy lịch khám nào phù hợp.", "Kết quả tìm kiếm",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    // ================== LÀM MỚI (bỏ lọc, hiện toàn bộ) ==================
    private void btnLamMoi_Click(object? sender, EventArgs e)
    {
        _filterActive = false;
        dtpTuNgay.Value = DateTime.Today.AddDays(-30);
        dtpDenNgay.Value = DateTime.Today.AddDays(30);
        if (cboLocBacSi.Items.Count > 0) cboLocBacSi.SelectedIndex = 0;

        LoadData();
        txtTenBenhNhan.Focus();
    }

    // ================== MỞ FORM PHỤ ==================
    private void btnQuanLyBacSi_Click(object? sender, EventArgs e)
    {
        using var f = new frmBacSi();
        f.ShowDialog(this);

        // Quay lại: nạp lại ComboBox + lưới để thấy bác sĩ mới
        LoadBacSiCombos();
        LoadData();
    }
}

// ================== LỚP PHỤ (đặt cuối file Form1.cs) ==================

// 1 dòng hiển thị trên lưới Lịch khám (đã ghép sẵn thông tin Bác sĩ)
public class LichRow
{
    public int MaLich { get; set; }
    public string TenBenhNhan { get; set; } = "";
    public string Sdt { get; set; } = "";
    public DateTime NgayKham { get; set; }
    public TimeOnly GioRaw { get; set; }          // giờ gốc để đổ lại lên DateTimePicker
    public string GioKham { get; set; } = "";     // giờ dạng chữ "HH:mm" để hiện trên lưới
    public int MaBs { get; set; }
    public string TenBS { get; set; } = "";
    public string ChuyenKhoa { get; set; } = "";
    public string TrangThai { get; set; } = "";
}

// 1 mục của ComboBox bác sĩ: hiện "BS. Tên - Chuyên khoa"
public class BacSiItem
{
    public int MaBS { get; set; }
    public string HienThi { get; set; } = "";
}