#nullable enable
namespace EF_Cau3
{
    partial class frmLoaiPhong
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
            lblMa = new Label();
            txtMaLoai = new TextBox();
            lblTen = new Label();
            txtTenLoai = new TextBox();
            lblGia = new Label();
            nudGia = new NumericUpDown();
            lblMoTa = new Label();
            txtMoTa = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            dgvLoaiPhong = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)nudGia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvLoaiPhong).BeginInit();
            SuspendLayout();
            // 
            // lblMa
            // 
            lblMa.AutoSize = true;
            lblMa.Location = new Point(20, 25);
            lblMa.Name = "lblMa";
            lblMa.TabIndex = 0;
            lblMa.Text = "Mã loại:";
            // 
            // txtMaLoai
            // 
            txtMaLoai.Location = new Point(130, 22);
            txtMaLoai.Name = "txtMaLoai";
            txtMaLoai.ReadOnly = true;
            txtMaLoai.Size = new Size(120, 23);
            txtMaLoai.TabIndex = 1;
            // 
            // lblTen
            // 
            lblTen.AutoSize = true;
            lblTen.Location = new Point(20, 65);
            lblTen.Name = "lblTen";
            lblTen.TabIndex = 2;
            lblTen.Text = "Tên loại phòng:";
            // 
            // txtTenLoai
            // 
            txtTenLoai.Location = new Point(130, 62);
            txtTenLoai.Name = "txtTenLoai";
            txtTenLoai.Size = new Size(300, 23);
            txtTenLoai.TabIndex = 3;
            // 
            // lblGia
            // 
            lblGia.AutoSize = true;
            lblGia.Location = new Point(20, 105);
            lblGia.Name = "lblGia";
            lblGia.TabIndex = 4;
            lblGia.Text = "Giá mỗi đêm:";
            // 
            // nudGia
            // 
            nudGia.Increment = 10000;
            nudGia.Location = new Point(130, 102);
            nudGia.Maximum = 1000000000;
            nudGia.Name = "nudGia";
            nudGia.Size = new Size(200, 23);
            nudGia.TabIndex = 5;
            nudGia.ThousandsSeparator = true;
            // 
            // lblMoTa
            // 
            lblMoTa.AutoSize = true;
            lblMoTa.Location = new Point(20, 145);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.TabIndex = 6;
            lblMoTa.Text = "Mô tả:";
            // 
            // txtMoTa
            // 
            txtMoTa.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMoTa.Location = new Point(130, 142);
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Size = new Size(600, 23);
            txtMoTa.TabIndex = 7;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(130, 190);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(100, 35);
            btnThem.TabIndex = 8;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(240, 190);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(100, 35);
            btnSua.TabIndex = 9;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(350, 190);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(100, 35);
            btnXoa.TabIndex = 10;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(460, 190);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(100, 35);
            btnLamMoi.TabIndex = 11;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // dgvLoaiPhong
            // 
            dgvLoaiPhong.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvLoaiPhong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLoaiPhong.Location = new Point(20, 245);
            dgvLoaiPhong.Name = "dgvLoaiPhong";
            dgvLoaiPhong.Size = new Size(710, 255);
            dgvLoaiPhong.TabIndex = 12;
            // 
            // frmLoaiPhong
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(750, 520);
            Controls.Add(dgvLoaiPhong);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(txtMoTa);
            Controls.Add(lblMoTa);
            Controls.Add(nudGia);
            Controls.Add(lblGia);
            Controls.Add(txtTenLoai);
            Controls.Add(lblTen);
            Controls.Add(txtMaLoai);
            Controls.Add(lblMa);
            Name = "frmLoaiPhong";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Quản lý Loại phòng";
            ((System.ComponentModel.ISupportInitialize)nudGia).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvLoaiPhong).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMa;
        private TextBox txtMaLoai;
        private Label lblTen;
        private TextBox txtTenLoai;
        private Label lblGia;
        private NumericUpDown nudGia;
        private Label lblMoTa;
        private TextBox txtMoTa;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private DataGridView dgvLoaiPhong;
    }
}