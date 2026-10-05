using EF_Cau4.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_Cau4;

public partial class frmBacSi : Form
{
    private bool _isLoading = false;

    public frmBacSi()
    {
        InitializeComponent();
        SetupGrid();

        Load += (s, e) => LoadData();
        dgvBacSi.SelectionChanged += dgvBacSi_SelectionChanged;
        btnThem.Click += btnThem_Click;
        btnSua.Click += btnSua_Click;
        btnXoa.Click += btnXoa_Click;
        btnLamMoi.Click += btnLamMoi_Click;
    }

    // ================== CẤU HÌNH LƯỚI ==================
    private void SetupGrid()
    {
        dgvBacSi.ReadOnly = true;
        dgvBacSi.AllowUserToAddRows = false;
        dgvBacSi.AllowUserToDeleteRows = false;
        dgvBacSi.MultiSelect = false;
        dgvBacSi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvBacSi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        dgvBacSi.AutoGenerateColumns = false;
        dgvBacSi.Columns.Clear();
        AddCol("MaBs", "Mã BS");
        AddCol("HoTen", "Họ tên");
        AddCol("ChuyenKhoa", "Chuyên khoa");
        AddCol("Sdt", "Số điện thoại");
    }

    private void AddCol(string prop, string header)
    {
        dgvBacSi.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = prop,
            DataPropertyName = prop,
            HeaderText = header
        });
    }

    // ================== NẠP DỮ LIỆU ==================
    private void LoadData()
    {
        try
        {
            _isLoading = true;

            using var db = new AnKhangClinicContext();
            dgvBacSi.DataSource = db.Set<BacSi>()
                .AsNoTracking()
                .OrderBy(x => x.MaBs)
                .ToList();

            dgvBacSi.ClearSelection();
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
        txtMaBS.Clear();
        txtHoTen.Clear();
        txtChuyenKhoa.Clear();
        txtSDT.Clear();
    }

    // ================== CHỌN DÒNG -> ĐỔ LÊN CONTROL ==================
    private void dgvBacSi_SelectionChanged(object? sender, EventArgs e)
    {
        if (_isLoading) return;
        if (dgvBacSi.SelectedRows.Count == 0) return;
        if (dgvBacSi.SelectedRows[0].DataBoundItem is not BacSi bs) return;

        txtMaBS.Text = bs.MaBs.ToString();
        txtHoTen.Text = bs.HoTen;
        txtChuyenKhoa.Text = bs.ChuyenKhoa ?? "";
        txtSDT.Text = bs.Sdt ?? "";
    }

    // ================== VALIDATE ==================
    private bool Invalid(string msg, Control c)
    {
        MessageBox.Show(msg, "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        c.Focus();
        return false;
    }

    private bool ValidateInput()
    {
        if (txtHoTen.Text.Trim() == "")
            return Invalid("Họ tên bác sĩ không được để trống!", txtHoTen);
        if (txtHoTen.Text.Trim().Length > 100)
            return Invalid("Họ tên tối đa 100 ký tự!", txtHoTen);
        if (txtChuyenKhoa.Text.Trim().Length > 100)
            return Invalid("Chuyên khoa tối đa 100 ký tự!", txtChuyenKhoa);
        if (txtSDT.Text.Trim().Length > 15)
            return Invalid("Số điện thoại tối đa 15 ký tự!", txtSDT);
        return true;
    }

    private void FillEntity(BacSi bs)
    {
        bs.HoTen = txtHoTen.Text.Trim();
        bs.ChuyenKhoa = string.IsNullOrWhiteSpace(txtChuyenKhoa.Text) ? null : txtChuyenKhoa.Text.Trim();
        bs.Sdt = string.IsNullOrWhiteSpace(txtSDT.Text) ? null : txtSDT.Text.Trim();
    }

    // ================== THÊM ==================
    private async void btnThem_Click(object? sender, EventArgs e)
    {
        if (!ValidateInput()) return;
        try
        {
            using var db = new AnKhangClinicContext();
            var bs = new BacSi();
            FillEntity(bs);
            db.Add(bs);
            await db.SaveChangesAsync();

            MessageBox.Show("Thêm bác sĩ thành công!", "Thông báo",
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
        if (!int.TryParse(txtMaBS.Text, out int id))
        {
            MessageBox.Show("Vui lòng chọn một bác sĩ trong danh sách để sửa!", "Chưa chọn dòng",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        if (!ValidateInput()) return;

        try
        {
            using var db = new AnKhangClinicContext();
            var bs = await db.Set<BacSi>().FindAsync(id);
            if (bs == null)
            {
                MessageBox.Show("Bác sĩ này không còn tồn tại.", "Không tìm thấy",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadData();
                return;
            }

            FillEntity(bs);
            await db.SaveChangesAsync();

            MessageBox.Show("Cập nhật bác sĩ thành công!", "Thông báo",
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
        if (!int.TryParse(txtMaBS.Text, out int id))
        {
            MessageBox.Show("Vui lòng chọn một bác sĩ trong danh sách để xóa!", "Chưa chọn dòng",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var confirm = MessageBox.Show(
            $"Bạn có chắc muốn xóa bác sĩ \"{txtHoTen.Text}\"?",
            "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (confirm != DialogResult.Yes) return;

        try
        {
            using var db = new AnKhangClinicContext();
            var bs = await db.Set<BacSi>().FindAsync(id);
            if (bs == null)
            {
                MessageBox.Show("Bác sĩ này không còn tồn tại.", "Không tìm thấy",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadData();
                return;
            }

            db.Remove(bs);
            await db.SaveChangesAsync();

            MessageBox.Show("Xóa bác sĩ thành công!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadData();
        }
        catch (DbUpdateException)
        {
            MessageBox.Show(
                "Không thể xóa vì bác sĩ này đang có lịch khám!\n" +
                "Hãy xóa hoặc đổi bác sĩ của các lịch khám đó trước.",
                "Lỗi ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // ================== LÀM MỚI ==================
    private void btnLamMoi_Click(object? sender, EventArgs e)
    {
        LoadData();
        txtHoTen.Focus();
    }
}