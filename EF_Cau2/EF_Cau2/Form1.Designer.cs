#nullable enable
namespace EF_Cau2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer? components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblMaHV = new Label();
            txtMaHV = new TextBox();
            lblHoTen = new Label();
            txtHoTen = new TextBox();
            lblSDT = new Label();
            txtSDT = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            grpGioiTinh = new GroupBox();
            rdoNam = new RadioButton();
            rdoNu = new RadioButton();
            lblNgaySinh = new Label();
            dtpNgaySinh = new DateTimePicker();
            lblHang = new Label();
            cboHang = new ComboBox();
            chkTrangThai = new CheckBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            lblTimTen = new Label();
            txtTimTen = new TextBox();
            lblLocHang = new Label();
            cboLocHang = new ComboBox();
            dgvHoiVien = new DataGridView();
            grpGioiTinh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoiVien).BeginInit();
            SuspendLayout();
            // 
            // lblMaHV
            // 
            lblMaHV.AutoSize = true;
            lblMaHV.Location = new Point(20, 25);
            lblMaHV.Name = "lblMaHV";
            lblMaHV.TabIndex = 0;
            lblMaHV.Text = "Mã hội viên:";
            // 
            // txtMaHV
            // 
            txtMaHV.Location = new Point(130, 22);
            txtMaHV.Name = "txtMaHV";
            txtMaHV.ReadOnly = true;
            txtMaHV.Size = new Size(120, 23);
            txtMaHV.TabIndex = 1;
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(20, 65);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.TabIndex = 2;
            lblHoTen.Text = "Họ tên:";
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(130, 62);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(300, 23);
            txtHoTen.TabIndex = 3;
            // 
            // lblSDT
            // 
            lblSDT.AutoSize = true;
            lblSDT.Location = new Point(20, 105);
            lblSDT.Name = "lblSDT";
            lblSDT.TabIndex = 4;
            lblSDT.Text = "Số điện thoại:";
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(130, 102);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(300, 23);
            txtSDT.TabIndex = 5;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(20, 145);
            lblEmail.Name = "lblEmail";
            lblEmail.TabIndex = 6;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(130, 142);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(300, 23);
            txtEmail.TabIndex = 7;
            // 
            // grpGioiTinh
            // 
            grpGioiTinh.Controls.Add(rdoNam);
            grpGioiTinh.Controls.Add(rdoNu);
            grpGioiTinh.Location = new Point(480, 12);
            grpGioiTinh.Name = "grpGioiTinh";
            grpGioiTinh.Size = new Size(300, 50);
            grpGioiTinh.TabIndex = 8;
            grpGioiTinh.TabStop = false;
            grpGioiTinh.Text = "Giới tính";
            // 
            // rdoNam
            // 
            rdoNam.AutoSize = true;
            rdoNam.Checked = true;
            rdoNam.Location = new Point(20, 20);
            rdoNam.Name = "rdoNam";
            rdoNam.TabIndex = 0;
            rdoNam.TabStop = true;
            rdoNam.Text = "Nam";
            rdoNam.UseVisualStyleBackColor = true;
            // 
            // rdoNu
            // 
            rdoNu.AutoSize = true;
            rdoNu.Location = new Point(120, 20);
            rdoNu.Name = "rdoNu";
            rdoNu.TabIndex = 1;
            rdoNu.Text = "Nữ";
            rdoNu.UseVisualStyleBackColor = true;
            // 
            // lblNgaySinh
            // 
            lblNgaySinh.AutoSize = true;
            lblNgaySinh.Location = new Point(480, 85);
            lblNgaySinh.Name = "lblNgaySinh";
            lblNgaySinh.TabIndex = 9;
            lblNgaySinh.Text = "Ngày sinh:";
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.Format = DateTimePickerFormat.Short;
            dtpNgaySinh.Location = new Point(580, 81);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(200, 23);
            dtpNgaySinh.TabIndex = 10;
            // 
            // lblHang
            // 
            lblHang.AutoSize = true;
            lblHang.Location = new Point(480, 125);
            lblHang.Name = "lblHang";
            lblHang.TabIndex = 11;
            lblHang.Text = "Hạng thành viên:";
            // 
            // cboHang
            // 
            cboHang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboHang.Items.AddRange(new object[] { "Basic", "VIP", "Premium" });
            cboHang.Location = new Point(580, 121);
            cboHang.Name = "cboHang";
            cboHang.Size = new Size(200, 23);
            cboHang.TabIndex = 12;
            // 
            // chkTrangThai
            // 
            chkTrangThai.AutoSize = true;
            chkTrangThai.Location = new Point(580, 150);
            chkTrangThai.Name = "chkTrangThai";
            chkTrangThai.TabIndex = 13;
            chkTrangThai.Text = "Đang hoạt động";
            chkTrangThai.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(130, 190);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(100, 35);
            btnThem.TabIndex = 14;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(240, 190);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(100, 35);
            btnSua.TabIndex = 15;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(350, 190);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(100, 35);
            btnXoa.TabIndex = 16;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(460, 190);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(100, 35);
            btnLamMoi.TabIndex = 17;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // lblTimTen
            // 
            lblTimTen.AutoSize = true;
            lblTimTen.Location = new Point(20, 253);
            lblTimTen.Name = "lblTimTen";
            lblTimTen.TabIndex = 18;
            lblTimTen.Text = "Tìm họ tên:";
            // 
            // txtTimTen
            // 
            txtTimTen.Location = new Point(110, 250);
            txtTimTen.Name = "txtTimTen";
            txtTimTen.Size = new Size(220, 23);
            txtTimTen.TabIndex = 19;
            // 
            // lblLocHang
            // 
            lblLocHang.AutoSize = true;
            lblLocHang.Location = new Point(360, 253);
            lblLocHang.Name = "lblLocHang";
            lblLocHang.TabIndex = 20;
            lblLocHang.Text = "Lọc theo hạng:";
            // 
            // cboLocHang
            // 
            cboLocHang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocHang.Items.AddRange(new object[] { "Tất cả", "Basic", "VIP", "Premium" });
            cboLocHang.Location = new Point(460, 250);
            cboLocHang.Name = "cboLocHang";
            cboLocHang.Size = new Size(140, 23);
            cboLocHang.TabIndex = 21;
            // 
            // dgvHoiVien
            // 
            dgvHoiVien.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvHoiVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoiVien.Location = new Point(20, 290);
            dgvHoiVien.Name = "dgvHoiVien";
            dgvHoiVien.Size = new Size(860, 320);
            dgvHoiVien.TabIndex = 22;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 630);
            Controls.Add(dgvHoiVien);
            Controls.Add(cboLocHang);
            Controls.Add(lblLocHang);
            Controls.Add(txtTimTen);
            Controls.Add(lblTimTen);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(chkTrangThai);
            Controls.Add(cboHang);
            Controls.Add(lblHang);
            Controls.Add(dtpNgaySinh);
            Controls.Add(lblNgaySinh);
            Controls.Add(grpGioiTinh);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtSDT);
            Controls.Add(lblSDT);
            Controls.Add(txtHoTen);
            Controls.Add(lblHoTen);
            Controls.Add(txtMaHV);
            Controls.Add(lblMaHV);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý Hội viên - FitZone";
            grpGioiTinh.ResumeLayout(false);
            grpGioiTinh.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoiVien).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMaHV;
        private TextBox txtMaHV;
        private Label lblHoTen;
        private TextBox txtHoTen;
        private Label lblSDT;
        private TextBox txtSDT;
        private Label lblEmail;
        private TextBox txtEmail;
        private GroupBox grpGioiTinh;
        private RadioButton rdoNam;
        private RadioButton rdoNu;
        private Label lblNgaySinh;
        private DateTimePicker dtpNgaySinh;
        private Label lblHang;
        private ComboBox cboHang;
        private CheckBox chkTrangThai;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Label lblTimTen;
        private TextBox txtTimTen;
        private Label lblLocHang;
        private ComboBox cboLocHang;
        private DataGridView dgvHoiVien;
    }
}