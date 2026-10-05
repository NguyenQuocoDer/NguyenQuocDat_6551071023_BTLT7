#nullable enable
namespace EF_Cau4
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
            lblMaLich = new Label();
            txtMaLich = new TextBox();
            lblTenBN = new Label();
            txtTenBenhNhan = new TextBox();
            lblSDT = new Label();
            txtSDT = new TextBox();
            lblNgayKham = new Label();
            dtpNgayKham = new DateTimePicker();
            lblGioKham = new Label();
            dtpGioKham = new DateTimePicker();
            lblBacSi = new Label();
            cboBacSi = new ComboBox();
            btnQuanLyBacSi = new Button();
            lblTrangThai = new Label();
            cboTrangThai = new ComboBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            lblTu = new Label();
            dtpTuNgay = new DateTimePicker();
            lblDen = new Label();
            dtpDenNgay = new DateTimePicker();
            lblLocBS = new Label();
            cboLocBacSi = new ComboBox();
            btnTimKiem = new Button();
            dgvLichKham = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvLichKham).BeginInit();
            SuspendLayout();
            // 
            // lblMaLich
            // 
            lblMaLich.AutoSize = true;
            lblMaLich.Location = new Point(20, 25);
            lblMaLich.Name = "lblMaLich";
            lblMaLich.TabIndex = 0;
            lblMaLich.Text = "Mã lịch:";
            // 
            // txtMaLich
            // 
            txtMaLich.Location = new Point(130, 22);
            txtMaLich.Name = "txtMaLich";
            txtMaLich.ReadOnly = true;
            txtMaLich.Size = new Size(120, 23);
            txtMaLich.TabIndex = 1;
            // 
            // lblTenBN
            // 
            lblTenBN.AutoSize = true;
            lblTenBN.Location = new Point(20, 65);
            lblTenBN.Name = "lblTenBN";
            lblTenBN.TabIndex = 2;
            lblTenBN.Text = "Tên bệnh nhân:";
            // 
            // txtTenBenhNhan
            // 
            txtTenBenhNhan.Location = new Point(130, 62);
            txtTenBenhNhan.Name = "txtTenBenhNhan";
            txtTenBenhNhan.Size = new Size(280, 23);
            txtTenBenhNhan.TabIndex = 3;
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
            txtSDT.Size = new Size(280, 23);
            txtSDT.TabIndex = 5;
            // 
            // lblNgayKham
            // 
            lblNgayKham.AutoSize = true;
            lblNgayKham.Location = new Point(20, 145);
            lblNgayKham.Name = "lblNgayKham";
            lblNgayKham.TabIndex = 6;
            lblNgayKham.Text = "Ngày khám:";
            // 
            // dtpNgayKham
            // 
            dtpNgayKham.Format = DateTimePickerFormat.Short;
            dtpNgayKham.Location = new Point(130, 142);
            dtpNgayKham.Name = "dtpNgayKham";
            dtpNgayKham.Size = new Size(160, 23);
            dtpNgayKham.TabIndex = 7;
            // 
            // lblGioKham
            // 
            lblGioKham.AutoSize = true;
            lblGioKham.Location = new Point(20, 185);
            lblGioKham.Name = "lblGioKham";
            lblGioKham.TabIndex = 8;
            lblGioKham.Text = "Giờ khám:";
            // 
            // dtpGioKham
            // 
            dtpGioKham.Format = DateTimePickerFormat.Time;
            dtpGioKham.Location = new Point(130, 182);
            dtpGioKham.Name = "dtpGioKham";
            dtpGioKham.ShowUpDown = true;
            dtpGioKham.Size = new Size(160, 23);
            dtpGioKham.TabIndex = 9;
            // 
            // lblBacSi
            // 
            lblBacSi.AutoSize = true;
            lblBacSi.Location = new Point(450, 25);
            lblBacSi.Name = "lblBacSi";
            lblBacSi.TabIndex = 10;
            lblBacSi.Text = "Bác sĩ:";
            // 
            // cboBacSi
            // 
            cboBacSi.DropDownStyle = ComboBoxStyle.DropDownList;
            cboBacSi.Location = new Point(540, 22);
            cboBacSi.Name = "cboBacSi";
            cboBacSi.Size = new Size(340, 23);
            cboBacSi.TabIndex = 11;
            // 
            // btnQuanLyBacSi
            // 
            btnQuanLyBacSi.Location = new Point(540, 58);
            btnQuanLyBacSi.Name = "btnQuanLyBacSi";
            btnQuanLyBacSi.Size = new Size(160, 29);
            btnQuanLyBacSi.TabIndex = 12;
            btnQuanLyBacSi.Text = "Quản lý bác sĩ";
            btnQuanLyBacSi.UseVisualStyleBackColor = true;
            // 
            // lblTrangThai
            // 
            lblTrangThai.AutoSize = true;
            lblTrangThai.Location = new Point(450, 105);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.TabIndex = 13;
            lblTrangThai.Text = "Trạng thái:";
            // 
            // cboTrangThai
            // 
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.Items.AddRange(new object[] { "Chờ khám", "Đã khám", "Đã hủy" });
            cboTrangThai.Location = new Point(540, 102);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(200, 23);
            cboTrangThai.TabIndex = 14;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(130, 235);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(100, 35);
            btnThem.TabIndex = 15;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(240, 235);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(100, 35);
            btnSua.TabIndex = 16;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(350, 235);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(100, 35);
            btnXoa.TabIndex = 17;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(460, 235);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(100, 35);
            btnLamMoi.TabIndex = 18;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // lblTu
            // 
            lblTu.AutoSize = true;
            lblTu.Location = new Point(20, 299);
            lblTu.Name = "lblTu";
            lblTu.TabIndex = 19;
            lblTu.Text = "Từ ngày:";
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.Format = DateTimePickerFormat.Short;
            dtpTuNgay.Location = new Point(85, 295);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(110, 23);
            dtpTuNgay.TabIndex = 20;
            // 
            // lblDen
            // 
            lblDen.AutoSize = true;
            lblDen.Location = new Point(215, 299);
            lblDen.Name = "lblDen";
            lblDen.TabIndex = 21;
            lblDen.Text = "Đến ngày:";
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.Format = DateTimePickerFormat.Short;
            dtpDenNgay.Location = new Point(285, 295);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(110, 23);
            dtpDenNgay.TabIndex = 22;
            // 
            // lblLocBS
            // 
            lblLocBS.AutoSize = true;
            lblLocBS.Location = new Point(415, 299);
            lblLocBS.Name = "lblLocBS";
            lblLocBS.TabIndex = 23;
            lblLocBS.Text = "Bác sĩ:";
            // 
            // cboLocBacSi
            // 
            cboLocBacSi.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocBacSi.Location = new Point(465, 295);
            cboLocBacSi.Name = "cboLocBacSi";
            cboLocBacSi.Size = new Size(280, 23);
            cboLocBacSi.TabIndex = 24;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(760, 291);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(120, 30);
            btnTimKiem.TabIndex = 25;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // dgvLichKham
            // 
            dgvLichKham.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvLichKham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLichKham.Location = new Point(20, 335);
            dgvLichKham.Name = "dgvLichKham";
            dgvLichKham.Size = new Size(860, 325);
            dgvLichKham.TabIndex = 26;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 680);
            Controls.Add(dgvLichKham);
            Controls.Add(btnTimKiem);
            Controls.Add(cboLocBacSi);
            Controls.Add(lblLocBS);
            Controls.Add(dtpDenNgay);
            Controls.Add(lblDen);
            Controls.Add(dtpTuNgay);
            Controls.Add(lblTu);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(cboTrangThai);
            Controls.Add(lblTrangThai);
            Controls.Add(btnQuanLyBacSi);
            Controls.Add(cboBacSi);
            Controls.Add(lblBacSi);
            Controls.Add(dtpGioKham);
            Controls.Add(lblGioKham);
            Controls.Add(dtpNgayKham);
            Controls.Add(lblNgayKham);
            Controls.Add(txtSDT);
            Controls.Add(lblSDT);
            Controls.Add(txtTenBenhNhan);
            Controls.Add(lblTenBN);
            Controls.Add(txtMaLich);
            Controls.Add(lblMaLich);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý Lịch khám - An Khang Clinic";
            ((System.ComponentModel.ISupportInitialize)dgvLichKham).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMaLich;
        private TextBox txtMaLich;
        private Label lblTenBN;
        private TextBox txtTenBenhNhan;
        private Label lblSDT;
        private TextBox txtSDT;
        private Label lblNgayKham;
        private DateTimePicker dtpNgayKham;
        private Label lblGioKham;
        private DateTimePicker dtpGioKham;
        private Label lblBacSi;
        private ComboBox cboBacSi;
        private Button btnQuanLyBacSi;
        private Label lblTrangThai;
        private ComboBox cboTrangThai;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Label lblTu;
        private DateTimePicker dtpTuNgay;
        private Label lblDen;
        private DateTimePicker dtpDenNgay;
        private Label lblLocBS;
        private ComboBox cboLocBacSi;
        private Button btnTimKiem;
        private DataGridView dgvLichKham;
    }
}