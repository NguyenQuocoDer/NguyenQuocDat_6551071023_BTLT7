using EF_Cau2.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_Cau2;

public partial class Form1 : Form
{
    private bool _isLoading = false;

    public Form1()
    {
        InitializeComponent();

        SetupGrid();
        cboLocHang.SelectedIndex = 0;   // "Tất cả"

        // ===== Gắn sự kiện =====
        Load += Form1_Load;
        dgvHoiVien.SelectionChanged += dgvHoiVien_SelectionChanged;
        dgvHoiVien.CellFormatting += dgvHoiVien_CellFormatting;
        btnThem.Click += btnThem_Click;
        btnSua.Click += btnSua_Click;
        btnXoa.Click += btnXoa_Click;
        btnLamMoi.Click += btnLamMoi_Click;
        txtTimTen.TextChanged += (s, e) => LoadData();
        cboLocHang.SelectedIndexChanged += (s, e) => LoadData();
    }

    // ================== CẤU HÌNH LƯỚI ==================
    private void SetupGrid()
    {
        dgvHoiVien.ReadOnly = true;
        dgvHoiVien.AllowUserToAddRows = false;
        dgvHoiVien.AllowUserToDeleteRows = false;
        dgvHoiVien.MultiSelect = false;
        dgvHoiVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvHoiVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        dgvHoiVien.AutoGenerateColumns = false;
        dgvHoiVien.Columns.Clear();
        AddCol("MaHv", "Mã HV");
        AddCol("HoTen", "Họ tên");
        AddCol("GioiTinh", "Giới tính");
        AddCol("NgaySinh", "Ngày sinh", "dd/MM/yyyy");
        AddCol("Sdt", "SĐT");
        AddCol("Email", "Email");
        AddCol("HangThanhVien", "Hạng");
        AddCol("NgayDangKy", "Ngày đăng ký", "dd/MM/yyyy");
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
        dgvHoiVien.Columns.Add(col);
    }

    // bool -> chữ cho dễ đọc trên lưới
    private void dgvHoiVien_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.Value == null || e.ColumnIndex < 0) return;
        string col = dgvHoiVien.Columns[e.ColumnIndex].Name;

        if (col == "GioiTinh" && e.Value is bool g)
        {
            e.Value = g ? "Nam" : "Nữ";
            e.FormattingApplied = true;
        }
        else if (col == "TrangThai" && e.Value is bool t)
        {
            e.Value = t ? "Đang hoạt động" : "Tạm ngưng";
            e.FormattingApplied = true;
        }
    }

    // ================== HÀM HỖ TRỢ NGÀY (chạy được cả DateOnly lẫn DateTime) ==================
    private static T DateTo<T>(DateTime d, T mau)
    {
        object r = (typeof(T) == typeof(DateOnly) || typeof(T) == typeof(DateOnly?))
            ? DateOnly.FromDateTime(d)
            : d;
        return (T)r;
    }

    private static DateTime ToDateTime(object? v) => v switch
    {
        DateOnly d => d.ToDateTime(TimeOnly.MinValue),
        DateTime dt => dt,
        _ => DateTime.Today.AddYears(-20)
    };

    // ================== LOAD FORM ==================
    private void Form1_Load(object? sender, EventArgs e)
    {
        LoadData();
    }

    // ================== NẠP DỮ LIỆU + TÌM KIẾM 2 ĐIỀU KIỆN ==================
    private void LoadData()
    {
        try
        {
            _isLoading = true;

            string ten = txtTimTen.Text.Trim();
            string hang = cboLocHang.SelectedIndex <= 0 ? "" : cboLocHang.Text;

            using var db = new FitZoneContext();

            var ds = db.Set<HoiVien>()
                .AsNoTracking()
                .Where(x => (ten == "" || x.HoTen.Contains(ten))
                         && (hang == "" || x.HangThanhVien == hang))
                .OrderBy(x => x.MaHv)
                .ToList();

            dgvHoiVien.DataSource = ds;
            dgvHoiVien.ClearSelection();
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
        txtMaHV.Clear();
        txtHoTen.Clear();
        txtSDT.Clear();
        txtEmail.Clear();
        rdoNam.Checked = true;
        dtpNgaySinh.Value = DateTime.Today.AddYears(-20);
        cboHang.SelectedIndex = 0;
        chkTrangThai.Checked = true;
    }

    // ================== CHỌN DÒNG -> ĐỔ LÊN CONTROL ==================
    private void dgvHoiVien_SelectionChanged(object? sender, EventArgs e)
    {
        if (_isLoading) return;
        if (dgvHoiVien.SelectedRows.Count == 0) return;
        if (dgvHoiVien.SelectedRows[0].DataBoundItem is not HoiVien hv) return;

        txtMaHV.Text = hv.MaHv.ToString();
        txtHoTen.Text = hv.HoTen;
        txtSDT.Text = hv.Sdt ?? "";
        txtEmail.Text = hv.Email ?? "";

        // RadioButton
        bool laNam = hv.GioiTinh == true;
        rdoNam.Checked = laNam;
        rdoNu.Checked = !laNam;

        // DateTimePicker
        dtpNgaySinh.Value = ToDateTime(hv.NgaySinh);

        // ComboBox
        cboHang.SelectedIndex = cboHang.FindStringExact(hv.HangThanhVien ?? "");

        // CheckBox
        chkTrangThai.Checked = hv.TrangThai == true;
    }

    // ================== VALIDATE (mỗi lỗi một thông báo riêng) ==================
    private bool Invalid(string msg, Control c)
    {
        MessageBox.Show(msg, "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        c.Focus();
        return false;
    }

    private bool ValidateInput()
    {
        // Họ tên
        if (txtHoTen.Text.Trim() == "")
            return Invalid("Họ tên không được để trống!", txtHoTen);

        // SĐT
        string sdt = txtSDT.Text.Trim();
        if (sdt == "")
            return Invalid("Số điện thoại không được để trống!", txtSDT);
        if (!sdt.All(c => c >= '0' && c <= '9'))
            return Invalid("Số điện thoại chỉ được chứa chữ số (0-9)!", txtSDT);
        if (sdt.Length < 9 || sdt.Length > 11)
            return Invalid("Số điện thoại phải từ 9 đến 11 chữ số!", txtSDT);

        // Email
        string email = txtEmail.Text.Trim();
        if (email == "")
            return Invalid("Email không được để trống!", txtEmail);
        if (!email.Contains('@'))
            return Invalid("Email phải chứa ký tự '@'!", txtEmail);

        // Hạng
        if (cboHang.SelectedIndex < 0)
            return Invalid("Vui lòng chọn hạng thành viên!", cboHang);

        // Tuổi >= 15
        DateTime today = DateTime.Today;
        DateTime birth = dtpNgaySinh.Value.Date;
        int tuoi = today.Year - birth.Year;
        if (birth > today.AddYears(-tuoi)) tuoi--;
        if (tuoi < 15)
            return Invalid($"Hội viên phải từ 15 tuổi trở lên (hiện tại: {tuoi} tuổi)!", dtpNgaySinh);

        return true;
    }

    // Đổ dữ liệu từ control vào đối tượng (dùng chung cho Thêm và Sửa)
    private void FillEntity(HoiVien hv)
    {
        hv.HoTen = txtHoTen.Text.Trim();
        hv.GioiTinh = rdoNam.Checked;
        hv.NgaySinh = DateTo(dtpNgaySinh.Value.Date, hv.NgaySinh);
        hv.Sdt = txtSDT.Text.Trim();
        hv.Email = txtEmail.Text.Trim();
        hv.HangThanhVien = cboHang.Text;
        hv.TrangThai = chkTrangThai.Checked;
    }

    // ================== THÊM ==================
    private async void btnThem_Click(object? sender, EventArgs e)
    {
        if (!ValidateInput()) return;

        try
        {
            using var db = new FitZoneContext();

            var hv = new HoiVien();
            FillEntity(hv);

            db.Add(hv);
            await db.SaveChangesAsync();

            MessageBox.Show("Thêm hội viên thành công!", "Thông báo",
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
            MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // ================== SỬA ==================
    private async void btnSua_Click(object? sender, EventArgs e)
    {
        if (!int.TryParse(txtMaHV.Text, out int id))
        {
            MessageBox.Show("Vui lòng chọn một hội viên trong danh sách để sửa!", "Chưa chọn dòng",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!ValidateInput()) return;

        try
        {
            using var db = new FitZoneContext();

            var hv = await db.Set<HoiVien>().FindAsync(id);
            if (hv == null)
            {
                MessageBox.Show("Hội viên này không còn tồn tại (có thể đã bị xóa).", "Không tìm thấy",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadData();
                return;
            }

            FillEntity(hv);
            await db.SaveChangesAsync();

            MessageBox.Show("Cập nhật hội viên thành công!", "Thông báo",
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
            MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // ================== XÓA ==================
    private async void btnXoa_Click(object? sender, EventArgs e)
    {
        if (!int.TryParse(txtMaHV.Text, out int id))
        {
            MessageBox.Show("Vui lòng chọn một hội viên trong danh sách để xóa!", "Chưa chọn dòng",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var confirm = MessageBox.Show(
            $"Bạn có chắc muốn xóa hội viên \"{txtHoTen.Text}\"?",
            "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (confirm != DialogResult.Yes) return;

        try
        {
            using var db = new FitZoneContext();

            var hv = await db.Set<HoiVien>().FindAsync(id);
            if (hv == null)
            {
                MessageBox.Show("Hội viên này không còn tồn tại.", "Không tìm thấy",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadData();
                return;
            }

            db.Remove(hv);
            await db.SaveChangesAsync();

            MessageBox.Show("Xóa hội viên thành công!", "Thông báo",
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
            MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // ================== LÀM MỚI ==================
    private void btnLamMoi_Click(object? sender, EventArgs e)
    {
        txtTimTen.Clear();
        cboLocHang.SelectedIndex = 0;
        LoadData();
        txtHoTen.Focus();
    }
}