#nullable enable
namespace EF_Cau4
{
    partial class frmBacSi
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
            txtMaBS = new TextBox();
            lblTen = new Label();
            txtHoTen = new TextBox();
            lblCK = new Label();
            txtChuyenKhoa = new TextBox();
            lblSdt = new Label();
            txtSDT = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            dgvBacSi = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvBacSi).BeginInit();
            SuspendLayout();
            // 
            // lblMa
            // 
            lblMa.AutoSize = true;
            lblMa.Location = new Point(20, 25);
            lblMa.Name = "lblMa";
            lblMa.TabIndex = 0;
            lblMa.Text = "Mã bác sĩ:";
            // 
            // txtMaBS
            // 
            txtMaBS.Location = new Point(130, 22);
            txtMaBS.Name = "txtMaBS";
            txtMaBS.ReadOnly = true;
            txtMaBS.Size = new Size(120, 23);
            txtMaBS.TabIndex = 1;
            // 
            // lblTen
            // 
            lblTen.AutoSize = true;
            lblTen.Location = new Point(20, 65);
            lblTen.Name = "lblTen";
            lblTen.TabIndex = 2;
            lblTen.Text = "Họ tên:";
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(130, 62);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(300, 23);
            txtHoTen.TabIndex = 3;
            // 
            // lblCK
            // 
            lblCK.AutoSize = true;
            lblCK.Location = new Point(20, 105);
            lblCK.Name = "lblCK";
            lblCK.TabIndex = 4;
            lblCK.Text = "Chuyên khoa:";
            // 
            // txtChuyenKhoa
            // 
            txtChuyenKhoa.Location = new Point(130, 102);
            txtChuyenKhoa.Name = "txtChuyenKhoa";
            txtChuyenKhoa.Size = new Size(300, 23);
            txtChuyenKhoa.TabIndex = 5;
            // 
            // lblSdt
            // 
            lblSdt.AutoSize = true;
            lblSdt.Location = new Point(20, 145);
            lblSdt.Name = "lblSdt";
            lblSdt.TabIndex = 6;
            lblSdt.Text = "Số điện thoại:";
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(130, 142);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(300, 23);
            txtSDT.TabIndex = 7;
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
            // dgvBacSi
            // 
            dgvBacSi.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvBacSi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBacSi.Location = new Point(20, 245);
            dgvBacSi.Name = "dgvBacSi";
            dgvBacSi.Size = new Size(710, 255);
            dgvBacSi.TabIndex = 12;
            // 
            // frmBacSi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(750, 520);
            Controls.Add(dgvBacSi);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(txtSDT);
            Controls.Add(lblSdt);
            Controls.Add(txtChuyenKhoa);
            Controls.Add(lblCK);
            Controls.Add(txtHoTen);
            Controls.Add(lblTen);
            Controls.Add(txtMaBS);
            Controls.Add(lblMa);
            Name = "frmBacSi";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Quản lý Bác sĩ";
            ((System.ComponentModel.ISupportInitialize)dgvBacSi).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMa;
        private TextBox txtMaBS;
        private Label lblTen;
        private TextBox txtHoTen;
        private Label lblCK;
        private TextBox txtChuyenKhoa;
        private Label lblSdt;
        private TextBox txtSDT;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private DataGridView dgvBacSi;
    }
}