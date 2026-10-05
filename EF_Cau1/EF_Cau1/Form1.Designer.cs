namespace EF_Cau1
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
            lblMaCap = new Label();
            txtMaTL = new TextBox();
            lblNgayTaoCap = new Label();
            lblNgayTao = new Label();
            lblTenCap = new Label();
            txtTenTheLoai = new TextBox();
            lblMoTaCap = new Label();
            txtMoTa = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            lblTimCap = new Label();
            txtTimKiem = new TextBox();
            dgvTheLoai = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvTheLoai).BeginInit();
            SuspendLayout();
            // 
            // lblMaCap
            // 
            lblMaCap.AutoSize = true;
            lblMaCap.Location = new Point(20, 25);
            lblMaCap.Name = "lblMaCap";
            lblMaCap.TabIndex = 0;
            lblMaCap.Text = "Mã thể loại:";
            // 
            // txtMaTL
            // 
            txtMaTL.Location = new Point(130, 22);
            txtMaTL.Name = "txtMaTL";
            txtMaTL.ReadOnly = true;
            txtMaTL.Size = new Size(200, 23);
            txtMaTL.TabIndex = 1;
            // 
            // lblNgayTaoCap
            // 
            lblNgayTaoCap.AutoSize = true;
            lblNgayTaoCap.Location = new Point(400, 25);
            lblNgayTaoCap.Name = "lblNgayTaoCap";
            lblNgayTaoCap.TabIndex = 2;
            lblNgayTaoCap.Text = "Ngày tạo:";
            // 
            // lblNgayTao
            // 
            lblNgayTao.AutoSize = true;
            lblNgayTao.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNgayTao.Location = new Point(470, 25);
            lblNgayTao.Name = "lblNgayTao";
            lblNgayTao.TabIndex = 3;
            lblNgayTao.Text = "—";
            // 
            // lblTenCap
            // 
            lblTenCap.AutoSize = true;
            lblTenCap.Location = new Point(20, 65);
            lblTenCap.Name = "lblTenCap";
            lblTenCap.TabIndex = 4;
            lblTenCap.Text = "Tên thể loại:";
            // 
            // txtTenTheLoai
            // 
            txtTenTheLoai.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTenTheLoai.Location = new Point(130, 62);
            txtTenTheLoai.Name = "txtTenTheLoai";
            txtTenTheLoai.Size = new Size(650, 23);
            txtTenTheLoai.TabIndex = 5;
            // 
            // lblMoTaCap
            // 
            lblMoTaCap.AutoSize = true;
            lblMoTaCap.Location = new Point(20, 105);
            lblMoTaCap.Name = "lblMoTaCap";
            lblMoTaCap.TabIndex = 6;
            lblMoTaCap.Text = "Mô tả:";
            // 
            // txtMoTa
            // 
            txtMoTa.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMoTa.Location = new Point(130, 102);
            txtMoTa.Multiline = true;
            txtMoTa.Name = "txtMoTa";
            txtMoTa.ScrollBars = ScrollBars.Vertical;
            txtMoTa.Size = new Size(650, 70);
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
            // lblTimCap
            // 
            lblTimCap.AutoSize = true;
            lblTimCap.Location = new Point(20, 253);
            lblTimCap.Name = "lblTimCap";
            lblTimCap.TabIndex = 12;
            lblTimCap.Text = "Tìm theo tên:";
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(130, 250);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(300, 23);
            txtTimKiem.TabIndex = 13;
            // 
            // dgvTheLoai
            // 
            dgvTheLoai.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTheLoai.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTheLoai.Location = new Point(20, 290);
            dgvTheLoai.Name = "dgvTheLoai";
            dgvTheLoai.Size = new Size(760, 270);
            dgvTheLoai.TabIndex = 14;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 580);
            Controls.Add(dgvTheLoai);
            Controls.Add(txtTimKiem);
            Controls.Add(lblTimCap);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(txtMoTa);
            Controls.Add(lblMoTaCap);
            Controls.Add(txtTenTheLoai);
            Controls.Add(lblTenCap);
            Controls.Add(lblNgayTao);
            Controls.Add(lblNgayTaoCap);
            Controls.Add(txtMaTL);
            Controls.Add(lblMaCap);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý Thể loại Sách - Tri Thức Books";
            ((System.ComponentModel.ISupportInitialize)dgvTheLoai).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMaCap;
        private TextBox txtMaTL;
        private Label lblNgayTaoCap;
        private Label lblNgayTao;
        private Label lblTenCap;
        private TextBox txtTenTheLoai;
        private Label lblMoTaCap;
        private TextBox txtMoTa;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Label lblTimCap;
        private TextBox txtTimKiem;
        private DataGridView dgvTheLoai;
    }
}