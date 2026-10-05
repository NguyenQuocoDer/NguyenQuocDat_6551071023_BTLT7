using EF_Cau1.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_Cau1;

public partial class Form1 : Form
{
    private bool _isLoading = false;

    public Form1()
    {
        InitializeComponent();

        // ===== Cấu hình DataGridView =====
        dgvTheLoai.ReadOnly = true;
        dgvTheLoai.AllowUserToAddRows = false;
        dgvTheLoai.AllowUserToDeleteRows = false;
        dgvTheLoai.MultiSelect = false;
        dgvTheLoai.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvTheLoai.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        // ===== Gắn sự kiện =====
        Load += Form1_Load;
        dgvTheLoai.SelectionChanged += dgvTheLoai_SelectionChanged;
        btnThem.Click += btnThem_Click;
        btnSua.Click += btnSua_Click;
        btnXoa.Click += btnXoa_Click;
        btnLamMoi.Click += btnLamMoi_Click;
        txtTimKiem.TextChanged += txtTimKiem_TextChanged;
    }

    // ================== LOAD FORM ==================
    private void Form1_Load(object? sender, EventArgs e)
    {
        LoadData();
    }

    // ================== NẠP DỮ LIỆU + TÌM KIẾM ==================
    private void LoadData()
    {
        try
        {
            _isLoading = true;

            string keyword = txtTimKiem.Text.Trim();

            using var db = new TriThucBooksContext();
            var query = db.Set<TheLoaiSach>().AsNoTracking();

            if (keyword != "")
            {
                query = query.Where(x => x.TenTheLoai.Contains(keyword));
            }

            dgvTheLoai.DataSource = query.OrderBy(x => x.MaTl).ToList();

            if (dgvTheLoai.Columns.Count > 0)
            {
                dgvTheLoai.Columns["MaTl"]!.HeaderText = "Mã TL";
                dgvTheLoai.Columns["TenTheLoai"]!.HeaderText = "Tên thể loại";
                dgvTheLoai.Columns["MoTa"]!.HeaderText = "Mô tả";
                dgvTheLoai.Columns["SoLuongSach"]!.HeaderText = "Số lượng sách";
                dgvTheLoai.Columns["NgayTao"]!.HeaderText = "Ngày tạo";
                dgvTheLoai.Columns["NgayTao"]!.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }

            dgvTheLoai.ClearSelection();
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
        txtMaTL.Clear();
        txtTenTheLoai.Clear();
        txtMoTa.Clear();
        lblNgayTao.Text = "—";
    }

    // ================== CHỌN DÒNG → ĐỔ LÊN CONTROL ==================
    private void dgvTheLoai_SelectionChanged(object? sender, EventArgs e)
    {
        if (_isLoading) return;
        if (dgvTheLoai.SelectedRows.Count == 0) return;

        if (dgvTheLoai.SelectedRows[0].DataBoundItem is not TheLoaiSach tl) return;

        txtMaTL.Text = tl.MaTl.ToString();
        txtTenTheLoai.Text = tl.TenTheLoai;
        txtMoTa.Text = tl.MoTa ?? "";
        lblNgayTao.Text = tl.NgayTao.ToString("dd/MM/yyyy HH:mm");
    }

    // ================== VALIDATE ==================
    // excludeId = null khi Thêm; = Mã đang sửa khi Cập nhật
    private async Task<bool> ValidateInputAsync(int? excludeId)
    {
        string ten = txtTenTheLoai.Text.Trim();

        if (ten == "")
        {
            MessageBox.Show("Tên thể loại không được để trống!", "Thiếu dữ liệu",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTenTheLoai.Focus();
            return false;
        }

        if (ten.Length > 100)
        {
            MessageBox.Show("Tên thể loại tối đa 100 ký tự!", "Dữ liệu không hợp lệ",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTenTheLoai.Focus();
            return false;
        }

        if (txtMoTa.Text.Trim().Length > 255)
        {
            MessageBox.Show("Mô tả tối đa 255 ký tự!", "Dữ liệu không hợp lệ",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtMoTa.Focus();
            return false;
        }

        using var db = new TriThucBooksContext();
        bool trung = await db.Set<TheLoaiSach>()
            .AnyAsync(x => x.TenTheLoai == ten && (excludeId == null || x.MaTl != excludeId));

        if (trung)
        {
            MessageBox.Show($"Thể loại \"{ten}\" đã tồn tại!", "Trùng tên",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTenTheLoai.Focus();
            return false;
        }

        return true;
    }

    // ================== THÊM ==================
    private async void btnThem_Click(object? sender, EventArgs e)
    {
        if (!await ValidateInputAsync(null)) return;

        try
        {
            using var db = new TriThucBooksContext();

            var tl = new TheLoaiSach
            {
                TenTheLoai = txtTenTheLoai.Text.Trim(),
                MoTa = string.IsNullOrWhiteSpace(txtMoTa.Text) ? null : txtMoTa.Text.Trim()
            };

            db.Add(tl);
            await db.SaveChangesAsync();

            MessageBox.Show("Thêm thể loại thành công!", "Thông báo",
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
        if (!int.TryParse(txtMaTL.Text, out int id))
        {
            MessageBox.Show("Vui lòng chọn một thể loại trong danh sách để sửa!", "Chưa chọn dòng",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!await ValidateInputAsync(id)) return;

        try
        {
            using var db = new TriThucBooksContext();

            var tl = await db.Set<TheLoaiSach>().FindAsync(id);
            if (tl == null)
            {
                MessageBox.Show("Thể loại này không còn tồn tại (có thể đã bị xóa).", "Không tìm thấy",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadData();
                return;
            }

            tl.TenTheLoai = txtTenTheLoai.Text.Trim();
            tl.MoTa = string.IsNullOrWhiteSpace(txtMoTa.Text) ? null : txtMoTa.Text.Trim();

            await db.SaveChangesAsync();

            MessageBox.Show("Cập nhật thể loại thành công!", "Thông báo",
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
        if (!int.TryParse(txtMaTL.Text, out int id))
        {
            MessageBox.Show("Vui lòng chọn một thể loại trong danh sách để xóa!", "Chưa chọn dòng",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var confirm = MessageBox.Show(
            $"Bạn có chắc muốn xóa thể loại \"{txtTenTheLoai.Text}\"?",
            "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (confirm != DialogResult.Yes) return;

        try
        {
            using var db = new TriThucBooksContext();

            var tl = await db.Set<TheLoaiSach>().FindAsync(id);
            if (tl == null)
            {
                MessageBox.Show("Thể loại này không còn tồn tại.", "Không tìm thấy",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadData();
                return;
            }

            db.Remove(tl);
            await db.SaveChangesAsync();

            MessageBox.Show("Xóa thể loại thành công!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadData();
        }
        catch (DbUpdateException)
        {
            MessageBox.Show(
                "Không thể xóa vì thể loại này đang được sách khác tham chiếu!\n" +
                "Hãy xóa hoặc chuyển các sách thuộc thể loại này trước.",
                "Lỗi ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        txtTimKiem.Clear();
        LoadData();
        txtTenTheLoai.Focus();
    }

    // ================== TÌM KIẾM ==================
    private void txtTimKiem_TextChanged(object? sender, EventArgs e)
    {
        LoadData();
    }
}