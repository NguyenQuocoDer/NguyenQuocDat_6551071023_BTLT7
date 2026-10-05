#nullable enable
namespace EF_Cau3
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
            lblMaPhong = new Label();
            txtMaPhong = new TextBox();
            lblSoPhong = new Label();
            txtSoPhong = new TextBox();
            lblTang = new Label();
            nudTang = new NumericUpDown();
            lblLoai = new Label();
            cboLoaiPhong = new ComboBox();
            btnQuanLyLoai = new Button();
            lblTinhTrang = new Label();
            cboTinhTrang = new ComboBox();
            picAnh = new PictureBox();
            btnChonAnh = new Button();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            lblLocTT = new Label();
            cboLocTinhTrang = new ComboBox();
            lblLocLoai = new Label();
            cboLocLoai = new ComboBox();
            dgvPhong = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)nudTang).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picAnh).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPhong).BeginInit();
            SuspendLayout();
            // 
            // lblMaPhong
            // 
            lblMaPhong.AutoSize = true;
            lblMaPhong.Location = new Point(20, 25);
            lblMaPhong.Name = "lblMaPhong";
            lblMaPhong.TabIndex = 0;
            lblMaPhong.Text = "Mã phòng:";
            // 
            // txtMaPhong
            // 
            txtMaPhong.Location = new Point(130, 22);
            txtMaPhong.Name = "txtMaPhong";
            txtMaPhong.ReadOnly = true;
            txtMaPhong.Size = new Size(120, 23);
            txtMaPhong.TabIndex = 1;
            // 
            // lblSoPhong
            // 
            lblSoPhong.AutoSize = true;
            lblSoPhong.Location = new Point(20, 65);
            lblSoPhong.Name = "lblSoPhong";
            lblSoPhong.TabIndex = 2;
            lblSoPhong.Text = "Số phòng:";
            // 
            // txtSoPhong
            // 
            txtSoPhong.Location = new Point(130, 62);
            txtSoPhong.Name = "txtSoPhong";
            txtSoPhong.Size = new Size(200, 23);
            txtSoPhong.TabIndex = 3;
            // 
            // lblTang
            // 
            lblTang.AutoSize = true;
            lblTang.Location = new Point(20, 105);
            lblTang.Name = "lblTang";
            lblTang.TabIndex = 4;
            lblTang.Text = "Tầng số:";
            // 
            // nudTang
            // 
            nudTang.Location = new Point(130, 102);
            nudTang.Maximum = 100;
            nudTang.Minimum = 1;
            nudTang.Name = "nudTang";
            nudTang.Size = new Size(100, 23);
            nudTang.TabIndex = 5;
            nudTang.Value = 1;
            // 
            // lblLoai
            // 
            lblLoai.AutoSize = true;
            lblLoai.Location = new Point(20, 145);
            lblLoai.Name = "lblLoai";
            lblLoai.TabIndex = 6;
            lblLoai.Text = "Loại phòng:";
            // 
            // cboLoaiPhong
            // 
            cboLoaiPhong.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiPhong.Location = new Point(130, 142);
            cboLoaiPhong.Name = "cboLoaiPhong";
            cboLoaiPhong.Size = new Size(200, 23);
            cboLoaiPhong.TabIndex = 7;
            // 
            // btnQuanLyLoai
            // 
            btnQuanLyLoai.Location = new Point(345, 139);
            btnQuanLyLoai.Name = "btnQuanLyLoai";
            btnQuanLyLoai.Size = new Size(150, 29);
            btnQuanLyLoai.TabIndex = 8;
            btnQuanLyLoai.Text = "Quản lý loại phòng";
            btnQuanLyLoai.UseVisualStyleBackColor = true;
            // 
            // lblTinhTrang
            // 
            lblTinhTrang.AutoSize = true;
            lblTinhTrang.Location = new Point(20, 185);
            lblTinhTrang.Name = "lblTinhTrang";
            lblTinhTrang.TabIndex = 9;
            lblTinhTrang.Text = "Tình trạng:";
            // 
            // cboTinhTrang
            // 
            cboTinhTrang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTinhTrang.Items.AddRange(new object[] { "Trống", "Đang ở", "Đang dọn" });
            cboTinhTrang.Location = new Point(130, 182);
            cboTinhTrang.Name = "cboTinhTrang";
            cboTinhTrang.Size = new Size(200, 23);
            cboTinhTrang.TabIndex = 10;
            // 
            // picAnh
            // 
            picAnh.BorderStyle = BorderStyle.FixedSingle;
            picAnh.Location = new Point(620, 20);
            picAnh.Name = "picAnh";
            picAnh.Size = new Size(240, 170);
            picAnh.SizeMode = PictureBoxSizeMode.Zoom;
            picAnh.TabIndex = 11;
            picAnh.TabStop = false;
            // 
            // btnChonAnh
            // 
            btnChonAnh.Location = new Point(620, 196);
            btnChonAnh.Name = "btnChonAnh";
            btnChonAnh.Size = new Size(240, 30);
            btnChonAnh.TabIndex = 12;
            btnChonAnh.Text = "Chọn ảnh...";
            btnChonAnh.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(130, 235);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(100, 35);
            btnThem.TabIndex = 13;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(240, 235);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(100, 35);
            btnSua.TabIndex = 14;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(350, 235);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(100, 35);
            btnXoa.TabIndex = 15;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(460, 235);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(100, 35);
            btnLamMoi.TabIndex = 16;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // lblLocTT
            // 
            lblLocTT.AutoSize = true;
            lblLocTT.Location = new Point(20, 293);
            lblLocTT.Name = "lblLocTT";
            lblLocTT.TabIndex = 17;
            lblLocTT.Text = "Lọc tình trạng:";
            // 
            // cboLocTinhTrang
            // 
            cboLocTinhTrang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocTinhTrang.Items.AddRange(new object[] { "Tất cả", "Trống", "Đang ở", "Đang dọn" });
            cboLocTinhTrang.Location = new Point(130, 290);
            cboLocTinhTrang.Name = "cboLocTinhTrang";
            cboLocTinhTrang.Size = new Size(130, 23);
            cboLocTinhTrang.TabIndex = 18;
            // 
            // lblLocLoai
            // 
            lblLocLoai.AutoSize = true;
            lblLocLoai.Location = new Point(290, 293);
            lblLocLoai.Name = "lblLocLoai";
            lblLocLoai.TabIndex = 19;
            lblLocLoai.Text = "Lọc loại phòng:";
            // 
            // cboLocLoai
            // 
            cboLocLoai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocLoai.Location = new Point(400, 290);
            cboLocLoai.Name = "cboLocLoai";
            cboLocLoai.Size = new Size(160, 23);
            cboLocLoai.TabIndex = 20;
            // 
            // dgvPhong
            // 
            dgvPhong.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPhong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPhong.Location = new Point(20, 330);
            dgvPhong.Name = "dgvPhong";
            dgvPhong.Size = new Size(840, 330);
            dgvPhong.TabIndex = 21;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(880, 680);
            Controls.Add(dgvPhong);
            Controls.Add(cboLocLoai);
            Controls.Add(lblLocLoai);
            Controls.Add(cboLocTinhTrang);
            Controls.Add(lblLocTT);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(btnChonAnh);
            Controls.Add(picAnh);
            Controls.Add(cboTinhTrang);
            Controls.Add(lblTinhTrang);
            Controls.Add(btnQuanLyLoai);
            Controls.Add(cboLoaiPhong);
            Controls.Add(lblLoai);
            Controls.Add(nudTang);
            Controls.Add(lblTang);
            Controls.Add(txtSoPhong);
            Controls.Add(lblSoPhong);
            Controls.Add(txtMaPhong);
            Controls.Add(lblMaPhong);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý Phòng - Sunrise Homestay";
            ((System.ComponentModel.ISupportInitialize)nudTang).EndInit();
            ((System.ComponentModel.ISupportInitialize)picAnh).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPhong).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMaPhong;
        private TextBox txtMaPhong;
        private Label lblSoPhong;
        private TextBox txtSoPhong;
        private Label lblTang;
        private NumericUpDown nudTang;
        private Label lblLoai;
        private ComboBox cboLoaiPhong;
        private Button btnQuanLyLoai;
        private Label lblTinhTrang;
        private ComboBox cboTinhTrang;
        private PictureBox picAnh;
        private Button btnChonAnh;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Label lblLocTT;
        private ComboBox cboLocTinhTrang;
        private Label lblLocLoai;
        private ComboBox cboLocLoai;
        private DataGridView dgvPhong;
    }
}